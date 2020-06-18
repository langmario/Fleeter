using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using Fleeter.Client.ViewModels;

namespace Fleeter.Client.Controllers
{
    public class AppVehicleController : IController
    {
        private AppVehiclesViewModel _vm;

        public ViewModelBase Initialize()
        {
            _vm = new AppVehiclesViewModel();



            _vm.New = new RelayCommand(o =>
            {
                _vm.SelectedVehicle = new Vehicle();
            });

            _vm.Cancel = new RelayCommand(o =>
            {
                _vm.SelectedVehicle = null;
            });

            return _vm;
        }
    }
}
