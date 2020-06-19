using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.ViewModels;
using Fleeter.Client.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Fleeter.Client.Controllers
{
    public class AddEmployeeRelationController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IVehicleService _vehicleService;
        private AddEmployeeRelationDialog _window;
        private AddEmployeeRelationViewModel _vm;

        public AddEmployeeRelationController(IEmployeeService employeeService, IVehicleService vehicleService)
        {
            _employeeService = employeeService;
            _vehicleService = vehicleService;
        }

        public async Task<bool> ShowAddRelationDialog(Vehicle v)
        {
            _vm = new AddEmployeeRelationViewModel();

            _vm.Add = new RelayCommand(async o =>
            {
                try
                {
                    var result = await _vehicleService.AddRelation(v, new VehicleToEmployeeRelation
                    {
                        Employee = _vm.SelectedEmployee,
                        StartDate = _vm.From,
                        EndDate = _vm.To ?? null
                    });

                    if (result.Status == Status.Created)
                    {
                        _window.DialogResult = true;
                        _window.Close();
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "Fehler beim Erstellen", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fehler beim Erstellen", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }, o => _vm.SelectedEmployee != null);

            _vm.Cancel = new RelayCommand(o =>
            {
                _window.Close();
            });

            _window = new AddEmployeeRelationDialog
            {
                DataContext = _vm
            };

            var employees = await GetMissingEmployeesForVehicle(v);
            _vm.Employees = new ObservableCollection<Employee>(employees);

            return _window.ShowDialog() ?? false;
        }

        private async Task<List<Employee>> GetMissingEmployeesForVehicle(Vehicle v)
        {
            var bookedEmployees = v.EmployeeRelations.Select(r => r.Employee);
            var employees = await _employeeService.GetAll();
            employees.RemoveAll(e => bookedEmployees.Any(be => be.Id == e.Id));
            return employees;
        }
    }
}
