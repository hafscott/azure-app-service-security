using System.Linq;
using Benday.EasyAuthDemo.Api.DomainModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.Api.ServiceLayers
{
    public class EmailService : IEmailService
    {
        private EmailConfigurationOptions _Options;
        private IConfigurationItemService _ConfigItemService;
        private ILogger<EmailService> _Logger;
        private IUserService _UserService;
        
        public EmailService(
            ILogger<EmailService> logger,
            IConfigurationItemService configItemService,
            IOptionsMonitor<EmailConfigurationOptions> options,
            IUserService userService)
        {
            _Options = options.CurrentValue;
            
            if (_Options.SendGridApiKey == null)
            {
                throw new ArgumentNullException(nameof(_Options.SendGridApiKey), "Argument cannot be null.");
            }
            
            _ConfigItemService = configItemService;
            _Logger = logger;
            _UserService = userService;
        }
        
        public async Task SendEmail(
            string recipientEmail, string recipientName, string subject)
        {
            if (recipientEmail == null)
            {
                throw new ArgumentNullException(nameof(recipientEmail), "Argument cannot be null.");
            }
            
            if (recipientName == null)
            {
                throw new ArgumentNullException(nameof(recipientName), "Argument cannot be null.");
            }
            
            var msg = new SendGridMessage();
            
            msg.SetFrom(new EmailAddress(_Options.FromEmail, _Options.FromName));
            
            var recipients = new List<EmailAddress>
            {
                new EmailAddress(recipientEmail, recipientName)
            };
            
            msg.AddTos(recipients);
            
            msg.SetSubject(subject);
            
            msg.AddContent(MimeType.Text, "Hello World plain text!");
            msg.AddContent(MimeType.Html, "<p>Hello World!</p>");
            
            await SendEmail(msg, $"Subject '{subject}' to '{recipientName}' '{recipientEmail}'");
        }
        
        private async Task SendEmail(
            string emailType,
            string recipientEmail, string recipientName,
            string subject, string bodyPlainText, string bodyHtml)
        {
            if (recipientEmail == null)
            {
                throw new ArgumentNullException(nameof(recipientEmail), "Argument cannot be null.");
            }
            
            if (recipientName == null)
            {
                throw new ArgumentNullException(nameof(recipientName), "Argument cannot be null.");
            }
            
            var msg = new SendGridMessage();
            
            msg.SetFrom(new EmailAddress(_Options.FromEmail, _Options.FromName));
            
            var recipients = new List<EmailAddress>
            {
                new EmailAddress(recipientEmail, recipientName)
            };
            
            msg.AddTos(recipients);
            
            msg.SetSubject(subject);
            
            msg.AddContent(MimeType.Text, bodyPlainText);
            msg.AddContent(MimeType.Html, bodyHtml);
            
            await SendEmail(msg, $"{emailType}: Subject '{subject}' to '{recipientName}' '{recipientEmail}'");
        }
        
        private ConfigurationItem GetConfigByKey(
            IList<ConfigurationItem> configs,
            string category, string key)
        {
            var match = (from temp in configs
            where temp.ConfigurationKey == key
            select temp).FirstOrDefault();
            
            if (match == null)
            {
                throw new InvalidOperationException($"Could not locate config item {category}.{key}.");
            }
            
            return match;
        }
        
        private async Task SendEmail(SendGridMessage msg, string msgDescriptionForLogging)
        {
            try
            {
                var apiKey = _Options.SendGridApiKey;
                
                var client = new SendGridClient(apiKey);
                
                _Logger.LogInformation($"Sending: {msgDescriptionForLogging}");
                
                var response = await client.SendEmailAsync(msg);
                
                var statusCode = "(null response)";
                
                if (response != null)
                {
                    statusCode = response.StatusCode.ToString();
                }
                
                _Logger.LogInformation($"Sent: {msgDescriptionForLogging}, Status code: {statusCode}");
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "Problem sending email.");
                throw;
            }
        }
    }
}
