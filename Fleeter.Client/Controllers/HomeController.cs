using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.ViewModels;
using System.Windows;

namespace Fleeter.Client.Controllers
{
    public class HomeController : IRoutableController
    {
        private readonly ChangePasswordDialogController _changePasswordDialogController;
        private HomeViewModel _vm;

        public HomeController(ChangePasswordDialogController changePasswordDialogController)
        {
            _changePasswordDialogController = changePasswordDialogController;
        }

        public ViewModelBase Initialize()
        {
            _vm = new HomeViewModel();
            _vm.ChangePassword = new RelayCommand(o => _changePasswordDialogController.ShowPasswordChangeDialog());

            return _vm;
        }
    }
}
