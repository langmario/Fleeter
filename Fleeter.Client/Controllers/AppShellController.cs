using Fleeter.Client.Controllers;
using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.ViewModels;
using System.Collections.Generic;
using System.Windows;

namespace Fleeter.Client.Controller
{
    public class AppShellController
    {
        private readonly AppShellViewModel _appVM = new AppShellViewModel();
        private readonly IAuthenticationService _authService;
        private readonly Dictionary<string, IController> _controllers = new Dictionary<string, IController>();


        public AppShellController(IAuthenticationService authService,
                                  HomeController homeController,
                                  AdminUsersController adminUsersController,
                                  AppBusinessUnitController businessUnitController)
        {
            _authService = authService;

            _controllers.Add("home", homeController);
            _controllers.Add("businessUnits", businessUnitController);
            _controllers.Add("admin/users", adminUsersController);
        }

        public void Initialize(RootShellViewModel rootVM)
        {
            _appVM.Logout = new RelayCommand(o => _authService.Logout());
            _appVM.ChangeView = new RelayCommand(ChangeLayoutExecute);
            _appVM.IsAdmin = _authService.IsAdmin;
            rootVM.ActiveViewModel = _appVM;
            _appVM.ActiveViewModel = _controllers["home"].Initialize();
        }


        private void ChangeLayoutExecute(object param)
        {
            if (param is string route && _controllers.TryGetValue(route, out var controller))
            {
                _appVM.ActiveViewModel = controller.Initialize();
            }
            else
            {
                MessageBox.Show($"Unknown View: {param}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
