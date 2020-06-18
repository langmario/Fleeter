using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.UserServiceProxy;
using Fleeter.Client.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace Fleeter.Client.Controllers
{
    public class AdminUsersController : IController
    {
        private AdminUsersViewModel _vm;
        private readonly IUsersService _userService;

        public AdminUsersController(IUsersService userService)
        {
            _userService = userService;
        }


        public ViewModelBase Initialize()
        {
            _vm = new AdminUsersViewModel();


            _vm.CreateOrUpdate = new RelayCommand(async o =>
            {
                var result = await _userService.CreateOrUpdate(_vm.SelectedUser);
                if (!(result.Status == Status.Created || result.Status == Status.Updated))
                {
                    MessageBox.Show(result.Message, "Fehler beim Erstellen", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    _vm.SelectedUser = null;
                    LoadUsers();
                }
            }, o => !string.IsNullOrEmpty(_vm.SelectedUser?.Lastname) && !string.IsNullOrEmpty(_vm.SelectedUser?.Username));


            _vm.Delete = new RelayCommand(async o =>
            {
                var result = await _userService.Delete(_vm.SelectedUser);
                if (result.Status != Status.Deleted)
                {
                    MessageBox.Show(result.Message, "Fehler beim Löschen", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                LoadUsers();
            }, o => _vm.SelectedUser != null && _vm.SelectedUser.Id > 0);


            _vm.New = new RelayCommand(o =>
            {
                _vm.SelectedUser = new User();
            });

            _vm.Cancel = new RelayCommand(o =>
            {
                _vm.SelectedUser = null;
            });


            LoadUsers();
            return _vm;
        }


        private async void LoadUsers()
        {
            var users = await _userService.GetAll();
            _vm.Users = new ObservableCollection<User>(users);
        }
    }
}
