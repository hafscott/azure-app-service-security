using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.Api.ServiceLayers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.UnitTests.Fakes.ServiceLayers
{
    public class FakeEmailService : IEmailService
    {
        public Task SendEmail(string recipientEmail, string recipientName, string subject)
        {
            return Task.CompletedTask;
        }
    }
}
