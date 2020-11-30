using Benday.EasyAuthDemo.Api.DataAccess;
using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.Api.ServiceLayers;
using Benday.JsonUtilities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.Api.Security
{
    public class PopulateClaimsMiddleware : IMiddleware
    {
        private ISecurityConfiguration _Configuration;
        private IUserService _UserService;

        public PopulateClaimsMiddleware(ISecurityConfiguration configuration,
            IUserService userService)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration), $"{nameof(configuration)} is null.");
            }

            _Configuration = configuration;
            _UserService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            List<Claim> claims = new List<Claim>();

            if (_Configuration.DevelopmentMode == true)
            {
                ProcessDevelopmentModeClaims(context, claims);
            }
            else
            {
                ProcessNonDevelopmentModeClaims(context, claims);
            }

            await next(context);
        }

        private void ProcessNonDevelopmentModeClaims(
            HttpContext context, List<Claim> claims)
        {
            AddClaimsFromHeader(context, claims);
            AddClaimsFromAuthMeService(context, claims);
            AddClaimsFromDatabaseAndCreateUserIfNotPresent(context, claims);

            var identity = new ClaimsIdentity(claims, "EasyAuth");

            context.User = new System.Security.Claims.ClaimsPrincipal(identity);
        }

        private void ProcessDevelopmentModeClaims(
            HttpContext context, List<Claim> claims)
        {
            if (context.User != null &&
            context.User.Identity != null &&
            context.User.Identity.IsAuthenticated == true)
            {
                // copy the existing claims
                claims.AddRange(context.User.Claims);

                var info = new UserInformation(
                new SimpleClaimsAccessor(claims));

                var username = info.Username;

                username = username.Replace(".com", String.Empty)
                .Replace(".org", String.Empty);

                var tokens = username.Split("@");

                AddClaim(claims, ClaimTypes.GivenName, tokens.FirstOrDefault());
                AddClaim(claims, ClaimTypes.Surname, tokens.LastOrDefault());
                AddClaim(claims, ClaimTypes.Email, info.Username);
                AddClaim(claims, ClaimTypes.Name, info.Username);
                //AddClaim(claims,
                //    SecurityConstants.Claim_X_MsClientPrincipalName,
                //    info.EmailAddress);

                AddClaimsFromDatabaseAndCreateUserIfNotPresent(info, claims);

                var identity = new ClaimsIdentity(claims, "DevelopmentMode");

                context.User = new System.Security.Claims.ClaimsPrincipal(identity);
            }
        }

        private void AddClaimsFromDatabaseAndCreateUserIfNotPresent(
            UserInformation info, List<Claim> claims)
        {
            AddClaimsFromDatabaseAndCreateUserIfNotPresent(
            claims,
            info.Username);
        }

        private void AddClaimsFromAuthMeService(
            HttpContext context, List<Claim> claims)
        {
            if (context.Request.Cookies.ContainsKey(SecurityConstants.Cookie_AppServiceAuthSession) == true)
            {
                var authMeJson = GetAuthMeInfo(context.Request);

                var jsonArray = JArray.Parse(authMeJson);

                var editor = new JsonEditor(jsonArray[0].ToString(), true);

                AddClaimIfExists(claims, editor, ClaimTypes.GivenName);
                AddClaimIfExists(claims, editor, ClaimTypes.Surname);
                if (AddClaimIfExists(claims, editor, ClaimTypes.Email) == false)
                {
                    var temp = editor.GetValue("user_id");

                    if (temp.IsNullOrWhitespace() == false)
                    {
                        claims.Add(new Claim(ClaimTypes.Email, temp));
                    }
                }
            }
        }

        private bool AddClaimIfExists(List<Claim> claims, JsonEditor editor, string claimTypeName)
        {
            var temp = GetClaimValue(editor, claimTypeName);

            if (temp.IsNullOrWhitespace() == false)
            {
                AddClaim(claims, claimTypeName, temp);

                return true;
            }
            else
            {
                return false;
            }
        }

        private static void AddClaim(List<Claim> claims, string claimTypeName, string value)
        {
            claims.Add(new Claim(claimTypeName, value));
        }

        private string GetClaimValue(JsonEditor editor, string claimName)
        {
            var args = new SiblingValueArguments();

            args.SiblingSearchKey = "typ";
            args.SiblingSearchValue = claimName;

            args.DesiredNodeKey = "val";
            args.PathArguments = new[] { "user_claims" };

            var temp = editor.GetSiblingValue(args);

            return temp;
        }

        private string GetAuthMeInfo(HttpRequest request)
        {
            var client = new AzureEasyAuthClient(request);

            if (client.IsReadyForAuthenticatedCall == false)
            {
                return null;
            }
            else
            {
                var resultAsString = client.GetUserInformationJson();

                return resultAsString;
            }
        }


        private void AddClaimsFromDatabaseAndCreateUserIfNotPresent(
            HttpContext context, List<Claim> claims)
        {
            var identityProviderHeader =
            GetHeaderValue(context, SecurityConstants.Claim_X_MsClientPrincipalIdp);

            var username =
            GetHeaderValue(
            context,
            SecurityConstants.Claim_X_MsClientPrincipalName);

            if (identityProviderHeader != null &&
            username != null)
            {
                AddClaimsFromDatabaseAndCreateUserIfNotPresent(claims, username);
            }
        }

        private void AddClaimsFromDatabaseAndCreateUserIfNotPresent(List<Claim> claims, string username)
        {
            var user = _UserService.GetByUsername(username);

            if (user == null)
            {
                user = CreateNewUser(claims);
            }

            if (user == null || user.Claims == null)
            {
                throw new InvalidOperationException("User or user claims collection was null.");
            }

            var values = user.Claims.ToList();

            foreach (var item in values)
            {
                if (item.ClaimName == "role")
                {
                    AddClaim(claims,
                    ClaimTypes.Role, item.ClaimValue);
                }
                else
                {
                    AddClaim(claims,
                    item.ClaimName, item.ClaimValue);
                }
            }
        }

        private User CreateNewUser(List<Claim> claims)
        {
            var info = new UserInformation(new SimpleClaimsAccessor(claims));

            var user = new User();

            user.EmailAddress = info.EmailAddress;
            user.FirstName = info.FirstName;
            user.Username = info.Username;
            user.LastName = info.LastName;
            user.PhoneNumber = String.Empty;
            user.Status = ApiConstants.StatusActive;
            user.Source = info.Source;

            _UserService.Save(user);

            return user;
        }

        private void AddClaimsFromHeader(HttpContext context, List<Claim> claims)
        {
            var identityProviderHeader =
            GetHeaderValue(context, SecurityConstants.Claim_X_MsClientPrincipalIdp);

            if (identityProviderHeader != null)
            {
                var identityHeader =
                GetHeaderValue(
                context,
                SecurityConstants.Claim_X_MsClientPrincipalId);

                var nameHeader =
                GetHeaderValue(
                context,
                SecurityConstants.Claim_X_MsClientPrincipalName);

                claims.Add(new Claim(
                SecurityConstants.Claim_X_MsClientPrincipalIdp,
                identityProviderHeader));

                claims.Add(new Claim(
                SecurityConstants.Claim_X_MsClientPrincipalId,
                identityHeader));

                claims.Add(new Claim(
                SecurityConstants.Claim_X_MsClientPrincipalName,
                nameHeader));

                claims.Add(new Claim(ClaimTypes.Name, nameHeader));
            }
        }

        private string GetHeaderValue(HttpContext context, string headerName)
        {
            var match = (from temp in context.Request.Headers
                         where temp.Key == headerName
                         select temp.Value).FirstOrDefault();

            return match;
        }
    }
}
