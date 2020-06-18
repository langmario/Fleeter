using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
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
            set
            {
                Set(ref _selectedVehicle, value);
                RaisePropertyChanged(nameof(LicensePlate));
                RaisePropertyChanged(nameof(Brand));
                RaisePropertyChanged(nameof(Model));
                RaisePropertyChanged(nameof(Insurance));
                RaisePropertyChanged(nameof(LeasingFrom));
                RaisePropertyChanged(nameof(LeasingTo));
                RaisePropertyChanged(nameof(LeasingRate));
                RaisePropertyChanged(nameof(EmployeeRelations));
            }
        }

        public string LicensePlate
        {
            get => SelectedVehicle?.LicensePlate;
            set
            {
                if (_selectedVehicle != null)
                {
                    _selectedVehicle.LicensePlate = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Brand
        {
            get => _selectedVehicle?.Brand;
            set
            {
                if (_selectedVehicle != null)
                {
                    _selectedVehicle.Brand = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Model
        {
            get => _selectedVehicle?.Model;
            set
            {
                if (_selectedVehicle != null)
                {
                    _selectedVehicle.Model = value;
                    RaisePropertyChanged();
                }
            }
        }

        public decimal? Insurance
        {
            get => _selectedVehicle?.Insurance;
            set
            {
                if (_selectedVehicle != null && value != null)
                {
                    _selectedVehicle.Insurance = (decimal)value;
                    RaisePropertyChanged();
                }
            }
        }

        public DateTime? LeasingFrom
        {
            get => SelectedVehicle?.LeasingFrom;
            set
            {
                if (SelectedVehicle != null && value != null)
                {
                    SelectedVehicle.LeasingFrom = (DateTime)value;
                    RaisePropertyChanged();
                }
            }
        }

        public DateTime? LeasingTo
        {
            get => SelectedVehicle?.LeasingTo;
            set
            {
                if (SelectedVehicle != null && value != null)
                {
                    SelectedVehicle.LeasingTo = (DateTime)value;
                    RaisePropertyChanged();
                }
            }
        }

        public decimal? LeasingRate
        {
            get => SelectedVehicle?.LeasingRate;
            set
            {
                if (SelectedVehicle != null && value != null)
                {
                    SelectedVehicle.LeasingRate= (decimal)value;
                    RaisePropertyChanged();
                }
            }
        }

        public List<VehicleToEmployeeRelation> EmployeeRelations
        {
            get => SelectedVehicle?.EmployeeRelations;
        }


        private VehicleToEmployeeRelation _selectedEmployeeRelation;
        public VehicleToEmployeeRelation SelectedEmployeeRelation
        {
            get => _selectedEmployeeRelation;
            set => Set(ref _selectedEmployeeRelation, value);
        }



        public ICommand CreateOrUpdate { get; set; }
        public ICommand Delete { get; set; }
        public ICommand New { get; set; }
        public ICommand Cancel { get; set; }

        public ICommand NewRelation { get; set; }
        public ICommand DeleteRelation { get; set; }
    }
}
