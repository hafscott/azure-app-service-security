using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.Api.Security
{
    public class UserInformation : IUserInformation, IUsernameProvider
    {
        private readonly IClaimsAccessor _Accessor;
        
        public UserInformation(IClaimsAccessor accessor)
        {
            if (accessor == null)
            {
                throw new ArgumentNullException(nameof(accessor), "Argument cannot be null.");
            }
            
            _Accessor = accessor;
        }
        
        private List<Claim> _Claims;
        public List<Claim> Claims
        {
            get
            {
                if (_Claims == null)
                {
                    _Claims = _Accessor.Claims.ToList();
                }
                
                return _Claims;
            }
        }
        
        public bool IsLoggedIn
        {
            get
            {
                return Claims.ContainsClaim(SecurityConstants.Claim_X_MsClientPrincipalIdp);
            }
        }
        
        public string FirstName
        {
            get
            {
                return Claims.GetClaimValue(ClaimTypes.GivenName).SafeToString();
            }
        }
        
        public string LastName
        {
            get
            {
                return Claims.GetClaimValue(ClaimTypes.Surname).SafeToString();
            }
        }
        
        public string EmailAddress
        {
            get
            {
                return Claims.GetClaimValue(ClaimTypes.Email).SafeToString();
            }
        }
        
        public bool IsAdministrator
        {
            get
            {
                return Claims.ContainsRoleClaim(SecurityConstants.RoleName_Admin);
            }
        }
        
        public int UserId
        {
            get
            {
                var temp = Claims.GetClaimValue(ApiConstants.ClaimName_UserId);
                
                if (String.IsNullOrEmpty(temp) == true)
                {
                    return -1;
                }
                else
                {
                    int returnValue = -1;
                    
                    if (Int32.TryParse(temp, out returnValue) == false)
                    {
                        return -1;
                    }
                    else
                    {
                        return returnValue;
                    }
                }
            }
        }
        
        public string Username
        {
            get
            {
                var returnValue = Claims.GetClaimValue(SecurityConstants.Claim_X_MsClientPrincipalName);
                
                if (String.IsNullOrWhiteSpace(returnValue) == false)
                {
                    return returnValue;
                }
                else
                {
                    return Claims.GetClaimValue(ClaimTypes.Email).SafeToString("(unknown username)");
                }
            }
        }
        
        public string Source
        {
            get
            {
                var returnValue = Claims.GetClaimValue(SecurityConstants.Claim_X_MsClientPrincipalIdp);
                
                if (String.IsNullOrWhiteSpace(returnValue) == false)
                {
                    return returnValue;
                }
                else
                {
                    return Claims.GetClaimValue(ClaimTypes.Email).SafeToString("(unknown source)");
                }
            }
        }
    }
}
