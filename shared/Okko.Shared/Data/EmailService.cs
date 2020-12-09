using Microsoft.Extensions.Options;
using Okko.Shared.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Okko.Shared.Data
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<EmailOptions> options;

        public EmailService(IOptions<EmailOptions> options)
        {
            this.options = options;
        }
        public async Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message)
        {
            var mailMessage = new MailMessage(fromAddress, toAddress, subject, message);
            using (var client = new SmtpClient(options.Value.Host, options.Value.Port)
            {
                Credentials = new NetworkCredential(options.Value.Username, options.Value.Password)
            })
            {
                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
