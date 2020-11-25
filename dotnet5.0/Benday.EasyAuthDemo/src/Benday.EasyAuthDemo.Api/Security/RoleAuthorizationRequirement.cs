using Microsoft.AspNetCore.Authorization;
using System;

namespace Benday.EasyAuthDemo.Api.Security
{
    public class RoleAuthorizationRequirement : IAuthorizationRequirement
    {
        public RoleAuthorizationRequirement(string roleName)
        {
            if (roleName == null)
            {
                throw new ArgumentNullException(nameof(roleName), "Argument cannot be null.");
            }
            
            RoleName = roleName;
        }
        public string RoleName { get; set; }
    }
}
