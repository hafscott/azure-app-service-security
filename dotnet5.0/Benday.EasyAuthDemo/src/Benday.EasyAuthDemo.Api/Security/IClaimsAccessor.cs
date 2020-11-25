using System.Collections.Generic;
using System.Security.Claims;

namespace Benday.EasyAuthDemo.Api.Security
{
    public interface IClaimsAccessor
    {
        IEnumerable<Claim> Claims { get; }
    }
}
