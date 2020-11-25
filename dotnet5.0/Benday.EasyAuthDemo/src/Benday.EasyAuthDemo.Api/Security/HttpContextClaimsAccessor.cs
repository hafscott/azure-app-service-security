using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Benday.EasyAuthDemo.Api.Security
{
    public class HttpContextClaimsAccessor : IClaimsAccessor
    {
        private IHttpContextAccessor _Accessor;
        
        public HttpContextClaimsAccessor(IHttpContextAccessor accessor)
        {
            _Accessor = accessor;
        }
        
        private HttpContext _Context;
        private HttpContext Context
        {
            get
            {
                if (_Context == null)
                {
                    if (_Accessor != null)
                    {
                        _Context = _Accessor.HttpContext;
                    }
                }
                
                return _Context;
            }
        }
        
        private IEnumerable<Claim> _Claims;
        public IEnumerable<Claim> Claims
        {
            get
            {
                if (_Claims == null)
                {
                    if (Context == null || Context.User == null || Context.User.Claims == null)
                    {
                        _Claims = new List<Claim>();
                    }
                    else
                    {
                        _Claims = Context.User.Claims.ToList();
                    }
                }
                
                return _Claims;
            }
        }
    }
}

