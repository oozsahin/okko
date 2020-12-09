using System.Threading.Tasks;

namespace Okko.Shared.Data
{
    public interface IEmailService
    {
        Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message);
    }
}
