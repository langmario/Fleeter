using Fleeter.Client.UserServiceProxy;
using System;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public interface IAuthenticationService
    {
        bool IsAdmin { get; }

        event EventHandler LogoutRequested;

        Task<LoginResult> LoginAsync(string username, string password);

        void Logout();

        Task<BaseResult> ChangePassword(string oldPassword, string newPassword);
    }
}