using Fleeter.Client.UserServiceProxy;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public event EventHandler LogoutRequested;

        private User _user;

        public bool IsAdmin
        {
            get => _user != null && _user.IsAdmin;
        }

        public async Task<LoginResult> LoginAsync(string username, string password)
        {
            var users = new UserServiceClient();
            users.Open();
            var response = await users.LoginAsync(username, password);
            _user = response.User;
            return response;
        }

        public void Logout()
        {
            _user = null;
            LogoutRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
