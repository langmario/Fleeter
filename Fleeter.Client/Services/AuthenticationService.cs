using Fleeter.Client.Controller;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<LoginResult> LoginAsync(string username, string password)
        {
            return new LoginResult
            {
                Message = null,
                Success = true,
                Token = "abcdefg"
            };
        }
    }
}
