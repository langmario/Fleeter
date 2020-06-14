using System.Threading.Tasks;
using Fleeter.Client.Controller;
using Fleeter.Client.Services;

namespace Fleeter.Client.Services
{
    public interface IAuthenticationService
    {
        Task<LoginResult> LoginAsync(string username, string password);
    }
}