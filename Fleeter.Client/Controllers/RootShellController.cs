using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.ViewModels;
using Fleeter.Client.Views;
using System;
using System.Windows;

namespace Fleeter.Client.Controller
{
    public class RootShellController
    {
        private readonly RootShell window = new RootShell();
        private readonly RootShellViewModel rootVM = new RootShellViewModel();
        private readonly LoginViewModel loginVM = new LoginViewModel();
        private readonly AppShellViewModel appVM = new AppShellViewModel();

        private readonly IAuthenticationService _authService;


        public RootShellController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public void Initialize()
        {
            ShowLogin();
            window.Show();
        }

        private void ShowLogin()
        {
            loginVM.Login = new RelayCommand(LoginExecute, o => !string.IsNullOrEmpty(loginVM.Username) && !string.IsNullOrEmpty(loginVM.Password));
            loginVM.Username = "admin";

            rootVM.ActiveViewModel = loginVM;

            window.DataContext = rootVM;
        }

        private async void LoginExecute(object o)
        {
            loginVM.IsLoading = true;
            try
            {
                LoginResult result = await _authService.LoginAsync(loginVM.Username, loginVM.Password);
                if (result.Success)
                {
                    rootVM.ActiveViewModel = appVM;
                } else
                {
                    loginVM.Password = string.Empty;
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
