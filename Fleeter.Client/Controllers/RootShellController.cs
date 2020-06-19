using Fleeter.Client.Controllers;
using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.UserServiceProxy;
using Fleeter.Client.ViewModels;
using Fleeter.Client.Views;
using System;

namespace Fleeter.Client.Controller
{
    public class RootShellController
    {
        private readonly RootShell window = new RootShell();
        private readonly RootShellViewModel rootVM = new RootShellViewModel();
        private readonly LoginViewModel loginVM = new LoginViewModel();
        private readonly IAuthenticationService _authService;
        private readonly ShellController _appController;


        public RootShellController(IAuthenticationService authService, ShellController appController)
        {
            _authService = authService;
            _appController = appController;
            _authService.LogoutRequested += (o, e) => rootVM.ActiveViewModel = loginVM;
        }

        public void Initialize()
        {
            ShowLogin();
            window.Show();
        }

        private void ShowLogin()
        {
            loginVM.Login = new RelayCommand(LoginExecute, o => !string.IsNullOrEmpty(loginVM.Username) && !string.IsNullOrEmpty(loginVM.Password) && !loginVM.IsLoading);
            loginVM.Username = "admin";

            rootVM.ActiveViewModel = loginVM;

            window.DataContext = rootVM;
        }

        private async void LoginExecute(object o)
        {
            loginVM.ErrorMessage = null;
            loginVM.IsLoading = true;
            try
            {
                LoginResult result = await _authService.LoginAsync(loginVM.Username, loginVM.Password);
                loginVM.Password = string.Empty;
                if (result.Success)
                {
                    rootVM.ActiveViewModel = await _appController.Initialize();
                }
                else
                {
                    loginVM.ErrorMessage = result.Message;
                }
            }
            catch (Exception ex)
            {
                loginVM.ErrorMessage = ex.Message;
            }
            finally
            {
                loginVM.IsLoading = false;
            }
        }
    }
}
