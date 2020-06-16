using Fleeter.Client.Framework;
using Fleeter.Client.ViewModels;
using System.Windows;

namespace Fleeter.Client.Controllers
{
    public class HomeController : IController
    {
        private readonly HomeViewModel _vm = new HomeViewModel();

        public HomeController()
        {
            _vm.ChangePassword = new RelayCommand(o => MessageBox.Show("Password Reset"));
        }

        public ViewModelBase Initialize() => _vm;
    }
}
