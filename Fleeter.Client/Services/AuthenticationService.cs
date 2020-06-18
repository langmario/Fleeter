using Fleeter.Client.UserServiceProxy;
using System;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public event EventHandler LogoutRequested;

        private User _user;

        private readonly UserServiceClient _client;

        public bool IsAdmin => _user != null && _user.IsAdmin;

        public async Task<LoginResult> LoginAsync(string username, string password)
        {
            return await OpenAndExecute(async users =>
            {
                var result = await users.LoginAsync(username, password);
                _user = result.User;
                return result;
            });
        }


        public void Logout()
        {
            _user = null;
            LogoutRequested?.Invoke(this, EventArgs.Empty);
        }


        public async Task<BaseResult> ChangePassword(string oldPassword, string newPassword)
        {
            return await OpenAndExecute(users => users.ChangePasswordAsync(_user, oldPassword, newPassword));
        }


        private async Task<T> OpenAndExecute<T>(Func<UserServiceClient, Task<T>> func)
        {
            var client = new UserServiceClient();

            var wasOpened = await Task.Run(() =>
            {
                try
                {
                    client.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
            if (!wasOpened)
            {
                throw new TimeoutException("Konnte keine Verbindung zum Server aufbauen");
            }
            return await func.Invoke(client);
        }
    }
}
