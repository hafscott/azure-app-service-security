using System.Collections.Generic;

namespace Benday.EasyAuthDemo.WebUi.Models
{
    public partial class SecurityLoginModel
    {
        public SecurityLoginModel()
        {
            LoginTypes = new List<SecurityLoginOption>();
        }
        
        public List<SecurityLoginOption> LoginTypes { get; set; }
    }
}
