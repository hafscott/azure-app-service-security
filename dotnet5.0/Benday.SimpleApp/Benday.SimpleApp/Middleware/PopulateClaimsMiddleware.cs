using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Benday.SimpleApp.Middleware
{
    public class PopulateClaimsMiddleware : IMiddleware
    {
        public PopulateClaimsMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            List<Claim> claims = new List<Claim>();

            PopulateClaims(context, claims);

            await next(context);
        }

        private void PopulateClaims(HttpContext context, List<Claim> claims)
        {
            AddClaimsFromHeader(context, claims);

            var identity = new ClaimsIdentity(claims, "EasyAuth");

            context.User = new ClaimsPrincipal(identity);
        }

        private static void AddClaim(List<Claim> claims, string claimTypeName, string value)
        {
            claims.Add(new Claim(claimTypeName, value));
        }

        private void AddClaimsFromHeader(HttpContext context, List<Claim> claims)
        {
            var identityProviderHeader =
            GetHeaderValue(context, SecurityConstants.Claim_X_MsClientPrincipalIdp);

            if (identityProviderHeader != null)
            {
                var identityHeader =
                    GetHeaderValue(context, SecurityConstants.Claim_X_MsClientPrincipalId);

                var nameHeader =
                    GetHeaderValue(context, SecurityConstants.Claim_X_MsClientPrincipalName);

                claims.Add(new Claim(SecurityConstants.Claim_X_MsClientPrincipalIdp, identityProviderHeader));

                claims.Add(new Claim(SecurityConstants.Claim_X_MsClientPrincipalId, identityHeader));

                claims.Add(new Claim(SecurityConstants.Claim_X_MsClientPrincipalName, nameHeader));

                claims.Add(new Claim(ClaimTypes.Name, nameHeader));
            }
        }

        private string GetHeaderValue(HttpContext context, string headerName)
        {
            var match = (
                from temp in context.Request.Headers 
                where temp.Key == headerName 
                select temp.Value).FirstOrDefault();

            return match;
        }
    }
}
