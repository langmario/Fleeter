using Fleeter.Client.Framework;
using Fleeter.Client.ViewModels;

namespace Fleeter.Client.Controllers
{
    public class AppCostsPerMonthController : IRoutableController
    {
        private AppCostsPerMonthViewModel _vm;

        public AppCostsPerMonthController()
        {

        }

        public ViewModelBase Initialize()
        {
            _vm = new AppCostsPerMonthViewModel();
            return _vm;
        }
    }
}
