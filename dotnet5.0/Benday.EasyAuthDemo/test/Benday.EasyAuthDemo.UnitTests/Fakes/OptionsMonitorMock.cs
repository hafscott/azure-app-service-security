using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace Benday.EasyAuthDemo.UnitTests.Fakes
{
    public class OptionsMonitorMock<T> : IOptionsMonitor<T>
    {
        
        public T CurrentValue { get; set; }
        
        public T Get(string name)
        {
            throw new NotImplementedException();
        }
        
        public IDisposable OnChange(Action<T, string> listener)
        {
            throw new NotImplementedException();
        }
    }
}
