using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Fleeter.Client.Controllers
{
    public class AppEmployeeController : IRoutableController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IBusinessUnitService _businessUnitsService;

        public AppEmployeeController(IEmployeeService employeeService, IBusinessUnitService businessUnitsService)
        {
            _employeeService = employeeService;
            _businessUnitsService = businessUnitsService;
        }

        private AppEmployeesViewModel _vm;

        public async Task<ViewModelBase> Initialize()
        {
            _vm = new AppEmployeesViewModel();

            _vm.CreateOrUpdate = new RelayCommand(async o =>
            {
                if (_vm.EmployeeNumber < 0)
                {
                    MessageBox.Show("Die Personalnummer darf nicht negativ sein");
                }
                else
                {
                    try
                    {
                        var result = await _employeeService.CreateOrUpdate(_vm.SelectedEmployee);
                        if (!(result.Status == Status.Created || result.Status == Status.Updated))
                        {
                            MessageBox.Show(result.Message, "Fehler beim Speichern", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            _vm.SelectedEmployee = null;
                            _vm.Employees = await GetEmployees();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Fehler beim Speichern", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }, o => _vm.Firstname != null && _vm.Lastname != null && _vm.EmployeeNumber >= 0 && _vm.BusinessUnit != null);

            _vm.Delete = new RelayCommand(async o =>
            {
                try
                {
                    var result = await _employeeService.Delete(_vm.SelectedEmployee);
                    if (result.Status != Status.Deleted)
                    {
                        MessageBox.Show(result.Message, "Fehler beim Löschen", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        _vm.SelectedEmployee = null;
                        _vm.Employees = await GetEmployees();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fehler beim Löschen", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }, o => _vm.SelectedEmployee?.Id != 0);

            _vm.New = new RelayCommand(o =>
            {
                _vm.SelectedEmployee = new Employee();
            });

            _vm.Cancel = new RelayCommand(o =>
            {
                _vm.SelectedEmployee = null;
            });

            _vm.Employees = await GetEmployees();
            _vm.BusinessUnits = await GetBusinessUnits();

            return _vm;
        }


        private async Task<ObservableCollection<Employee>> GetEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAll();
                return new ObservableCollection<Employee>(employees);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Abrufen der Mitarbeiter" + Environment.NewLine + ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ObservableCollection<Employee>();
            }
        }

        private async Task<ObservableCollection<BusinessUnit>> GetBusinessUnits()
        {
            try
            {
                var businessUnits = await _businessUnitsService.GetAll();
                return new ObservableCollection<BusinessUnit>(businessUnits);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Abrufen der Geschäftsbereiche" + Environment.NewLine + ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ObservableCollection<BusinessUnit>();
            }
        }
    }
}
