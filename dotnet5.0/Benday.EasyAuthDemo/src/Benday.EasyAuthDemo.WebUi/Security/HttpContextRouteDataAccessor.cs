using Benday.EasyAuthDemo.Api.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.WebUi.Security
{
    public class HttpContextRouteDataAccessor : IRouteDataAccessor
    {
        private IHttpContextAccessor _Accessor;
        
        public HttpContextRouteDataAccessor(IHttpContextAccessor accessor)
        {
            _Accessor = accessor;
        }
        
        public string GetId()
        {
            var values = _Accessor.HttpContext.Request.RouteValues!;
            
            if (values == null)
            {
                return null;
            }
            else if (values.ContainsKey("id") == true)
            {
                return GetValue(values, "id");
            }
            else if (values.ContainsKey("courseId") == true)
            {
                return GetValue(values, "courseId");
            }
            else
            {
                return null;
            }
        }
        
        private string GetValue(RouteValueDictionary values, string key)
        {
            var val = values[key].ToString();
            
            if (String.IsNullOrEmpty(val) == true)
            {
                return null;
            }
            else
            {
                return val;
            }
        }
    }
}
