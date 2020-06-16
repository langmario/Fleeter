using Fleeter.Client.Framework;
using Fleeter.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Client.Controllers
{
    public class AppCostsPerMonthController : IController
    {
        private readonly AppCostsPerMonthViewModel _vm;

        public AppCostsPerMonthController()
        {
            _vm = new AppCostsPerMonthViewModel();
        }

        public ViewModelBase Initialize() => _vm;
    }
}
