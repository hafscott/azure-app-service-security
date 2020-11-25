using Benday.EasyAuthDemo.Api.DomainModels;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.Api.ServiceLayers
{
    public interface IEmailService
    {
        Task SendEmail(string recipientEmail, string recipientName, string subject);
    }
}
