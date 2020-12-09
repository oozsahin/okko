using System.Threading.Tasks;

namespace okko.uzapi.Contracts
{
    public interface IEmailService
    {
        Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message);
    }
}
