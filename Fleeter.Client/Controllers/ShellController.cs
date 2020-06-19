using Fleeter.Client.Controllers;
using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Media;
using System.Threading.Tasks;
using System.Windows;

namespace Fleeter.Client.Controller
{
    public class ShellController : IRoutableController
    {
        private readonly IAuthenticationService _authService;
        private readonly Dictionary<string, IRoutableController> _controllers = new Dictionary<string, IRoutableController>();
        private AppShellViewModel _appVM;


        public ShellController(IAuthenticationService authService,
                               HomeController homeController,
                               AdminUsersController adminUsersController,
                               AppBusinessUnitController businessUnitController,
                               AppCostsPerMonthController costsPerMonthController,
                               AppCostsPerBusinessUnitController costsPerUnitController,
                               AppEmployeeController employeeController,
                               AppVehicleController vehicleController)
        {
            _authService = authService;

            _controllers.Add("home", homeController);
            _controllers.Add("costsPerMonth", costsPerMonthController);
            _controllers.Add("costsPerUnit", costsPerUnitController);
            _controllers.Add("businessUnits", businessUnitController);
            _controllers.Add("vehicles", vehicleController);
            _controllers.Add("employees", employeeController);
            _controllers.Add("admin/users", adminUsersController);
        }

        public async Task<ViewModelBase> Initialize()
        {
            _appVM = new AppShellViewModel();
            _appVM.Logout = new RelayCommand(o => _authService.Logout());
            _appVM.ChangeView = new RelayCommand(ChangeLayoutExecute);
            _appVM.IsAdmin = _authService.IsAdmin;
            _appVM.ActiveViewModel = await _controllers["home"].Initialize();
            return _appVM;
        }


        private async void ChangeLayoutExecute(object param)
        {
            if (param is string route && _controllers.TryGetValue(route, out var controller))
            {
                _appVM.ActiveViewModel = await controller.Initialize();
            }
            else
            {
                MessageBox.Show($"Unknown View: {param}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
