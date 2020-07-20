using System.Threading.Tasks;

namespace okko.uzapi.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message);
    }
}
