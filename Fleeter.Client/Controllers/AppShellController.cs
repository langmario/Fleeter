using Fleeter.Client.Controllers;
using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;

namespace Fleeter.Client.Controller
{
    public class AppShellController
    {
        private readonly AppShellViewModel _appVM = new AppShellViewModel();
        private readonly IAuthenticationService _authService;
        private readonly Dictionary<string, IRoutableController> _controllers = new Dictionary<string, IRoutableController>();


        public AppShellController(IAuthenticationService authService,
                                  HomeController homeController,
                                  AdminUsersController adminUsersController,
                                  AppBusinessUnitController businessUnitController,
                                  AppCostsPerMonthController costsPerMonthController,
                                  AppEmployeeController employeeController,
                                  AppVehicleController vehicleController)
        {
            _authService = authService;

            _controllers.Add("home", homeController);
            _controllers.Add("costsPerMonth", costsPerMonthController);
            _controllers.Add("businessUnits", businessUnitController);
            _controllers.Add("vehicles", vehicleController);
            _controllers.Add("employees", employeeController);
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
