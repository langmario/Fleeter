using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Fleeter.Client.ViewModels
{
    public class AppVehiclesViewModel : ViewModelBase
    {
        private ObservableCollection<Vehicle> _vehicles = new ObservableCollection<Vehicle>();
        public ObservableCollection<Vehicle> Vehicles
        {
            get => _vehicles;
            set => Set(ref _vehicles, value);
        }

        private Vehicle _selectedVehicle;
        public Vehicle SelectedVehicle
        {
            get => _selectedVehicle;
            set => Set(ref _selectedVehicle, value);
        }


        public ICommand CreateOrUpdate { get; set; }
        public ICommand Delete { get; set; }
        public ICommand New { get; set; }
        public ICommand Cancel { get; set; }
    }
}
