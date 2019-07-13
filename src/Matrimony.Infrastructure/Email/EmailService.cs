using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using Matrimony.Core.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfig _emailConfig;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailConfig> emailConfigOptions, ILogger<EmailService> logger)
        {
            _emailConfig = emailConfigOptions.Value;
            _logger = logger;
        }

        public async Task SendEmailAsync(string emailTo, string emailSubject, string emailBody)
        {
            // forward email code goes here
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_emailConfig.NoReplyAddress));
                message.To.Add(new MailboxAddress(emailTo));
                message.Subject = emailSubject;

                message.Body = new TextPart("plain")
                {
                    Text = emailBody
                };

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Connect(_emailConfig.ServerName, _emailConfig.ServerPort, true);
                    smtpClient.Authenticate(new NetworkCredential(_emailConfig.UserName, _emailConfig.UserPassword));
                    smtpClient.Send(message);
                    smtpClient.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
