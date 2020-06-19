using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Fleeter.Client.Controllers
{
    public class AppVehicleController : IRoutableController
    {
        private readonly IVehicleService _vehicleService;
        private readonly AddEmployeeRelationController _addEmployeeRelationController;
        private AppVehiclesViewModel _vm;

        public AppVehicleController(IVehicleService vehicleService, AddEmployeeRelationController addEmployeeRelationController)
        {
            _vehicleService = vehicleService;
            _addEmployeeRelationController = addEmployeeRelationController;
        }

        public ViewModelBase Initialize()
        {
            _vm = new AppVehiclesViewModel();

            _vm.CreateOrUpdate = new RelayCommand(async o =>
            {
                if (!IsValid(_vm.SelectedVehicle, out var errors))
                {
                    MessageBox.Show(string.Join(Environment.NewLine, errors), "Fehler beim Speichern", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    try
                    {
                        var result = await _vehicleService.CreateOrUpdate(_vm.SelectedVehicle);
                        if (!(result.Status == Status.Created || result.Status == Status.Updated))
                        {
                            MessageBox.Show(result.Message, "Fehler beim Speichern", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            _vm.SelectedVehicle = null;
                            LoadVehicles();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Fehler beim Speichern", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }, o => _vm.LicensePlate != null && _vm.Insurance != null && _vm.Brand != null && _vm.Model != null && _vm.LeasingFrom != null && _vm.LeasingTo != null);

            _vm.Delete = new RelayCommand(async o =>
            {
                try
                {
                    var result = await _vehicleService.Delete(_vm.SelectedVehicle);
                    if (result.Status != Status.Deleted)
                    {
                        MessageBox.Show(result.Message, "Fehler beim Löschen", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        LoadVehicles();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fehler beim Löschen", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }, o => _vm.SelectedVehicle?.Id != 0);

            _vm.New = new RelayCommand(o =>
            {
                _vm.SelectedVehicle = new Vehicle()
                {
                    LeasingFrom = DateTime.Today,
                    LeasingTo = DateTime.Today.AddYears(4)
                };
            });

            _vm.Cancel = new RelayCommand(o =>
            {
                _vm.SelectedVehicle = null;
            });

            _vm.NewRelation = new RelayCommand(async o =>
            {
                var shouldReload = await _addEmployeeRelationController.ShowAddRelationDialog(_vm.SelectedVehicle);
                if (shouldReload)
                {
                    LoadVehicles();
                }
            }, o => _vm.SelectedVehicle != null);

            _vm.DeleteRelation = new RelayCommand(async o =>
            {
                try
                {
                    var result = await _vehicleService.DeleteRelation(_vm.SelectedVehicle, _vm.SelectedEmployeeRelation);
                    if (result.Status != Status.Deleted)
                    {
                        MessageBox.Show(result.Message, "Fehler beim Löschen", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        LoadVehicles();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fehler beim Löschen", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }, o => _vm.SelectedEmployeeRelation != null);

            LoadVehicles();

            return _vm;
        }


        private bool IsValid(Vehicle v, out List<string> errors)
        {
            errors = new List<string>();

            var licenseRegex = new Regex("^[a-zA-Z]{1,3}-[a-zA-Z]{1,2}-[0-9]{1,4}$");
            if (v?.LicensePlate == null || !licenseRegex.Match(v.LicensePlate).Success)
            {
                errors.Add("Kein Valides Nummernschild (z.B. XXX-XX-0000)");
            }

            if (v?.Insurance < 0)
            {
                errors.Add("Der Versicherungsbetrag darf nicht negativ sein");
            }

            if (string.IsNullOrEmpty(v?.Model))
            {
                errors.Add("Kein Modell angegeben");
            }

            if (string.IsNullOrEmpty(v?.Brand))
            {
                errors.Add("Keine Marke angegeben");
            }

            if (v?.Insurance == null)
            {
                errors.Add("Versicherungsbeitrag darf nicht leer sein");
            }

            return errors.Count == 0;
        }


        private async void LoadVehicles()
        {
            try
            {
                var vehicles = await _vehicleService.GetAll();
                _vm.Vehicles = new ObservableCollection<Vehicle>(vehicles);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler beim Laden der Fahrzeuge");
            }
        }
    }
}
