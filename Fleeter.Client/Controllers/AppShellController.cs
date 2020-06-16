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

        private readonly Dictionary<string, ViewModelBase> _viewModels = new Dictionary<string, ViewModelBase>();
        private readonly Dictionary<string, IController> _controllers = new Dictionary<string, IController>();

        public AppShellController(IAuthenticationService authService)
        {
            _authService = authService;
            RegisterViewModels();

            _controllers.Add("home", new HomeController());
        }

        public void Initialize(RootShellViewModel rootVM)
        {
            _appVM.Logout = new RelayCommand(o => _authService.Logout());
            _appVM.ChangeView = new RelayCommand(ChangeLayoutExecute);
            _appVM.IsAdmin = _authService.IsAdmin;
            rootVM.ActiveViewModel = _appVM;
            _appVM.ActiveViewModel = _viewModels["home"];
        }

        private void RegisterViewModels()
        {
            _viewModels.Add("home", new HomeViewModel());
            _viewModels.Add("costsPerMonth", new AppCostsPerMonthViewModel());
            _viewModels.Add("costsPerUnit", new AppCostsPerUnitViewModel());
            _viewModels.Add("vehicles", new AppVehiclesViewModel());
            _viewModels.Add("employees", new AppEmployeesViewModel());
            _viewModels.Add("businessUnits", new AppBusinessUnitsViewModel());
            _viewModels.Add("admin/users", new AdminUsersViewModel());
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
