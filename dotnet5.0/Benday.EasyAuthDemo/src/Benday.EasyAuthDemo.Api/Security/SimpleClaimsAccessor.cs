using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Benday.EasyAuthDemo.Api.Security
{
    public class SimpleClaimsAccessor : IClaimsAccessor
    {
        public SimpleClaimsAccessor(IEnumerable<Claim> claims)
        {
            Claims = claims;
        }
        
        public IEnumerable<Claim> Claims { get; private set; }
    }
}

