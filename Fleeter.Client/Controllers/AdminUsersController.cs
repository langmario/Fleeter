using Fleeter.Client.Framework;
using Fleeter.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Client.Controllers
{
    public class AdminUsersController : IController
    {
        private AdminUsersViewModel _vm;

        public AdminUsersController()
        {
            _vm = new AdminUsersViewModel();
        }

        public ViewModelBase Initialize() => _vm;
    }
}
