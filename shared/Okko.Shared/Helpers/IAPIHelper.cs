using System.Net.Http;
using System.Threading.Tasks;
using Okko.Shared.Models;

namespace Okko.Shared.Helpers
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
        void LogOffUser();
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}