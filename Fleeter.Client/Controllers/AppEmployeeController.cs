using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Fleeter.Client.Controllers
{
    public class AppEmployeeController : IController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IBusinessUnitService _businessUnitsService;

        public AppEmployeeController(IEmployeeService employeeService, IBusinessUnitService businessUnitsService)
        {
            _employeeService = employeeService;
            _businessUnitsService = businessUnitsService;
        }

        private AppEmployeesViewModel _vm;

        public ViewModelBase Initialize()
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
                            LoadEmployees();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Fehler beim Speichern", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            });

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
                        LoadEmployees();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fehler beim Löschen", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            _vm.New = new RelayCommand(o =>
            {
                _vm.SelectedEmployee = new Employee();
            });

            _vm.Cancel = new RelayCommand(o =>
            {
                _vm.SelectedEmployee = null;
            });

            LoadEmployees();
            LoadBusinessUnits();

            return _vm;
        }


        private async void LoadEmployees()
        {
            var employees = await _employeeService.GetAll();
            _vm.Employees = new ObservableCollection<Employee>(employees);
        }

        private async void LoadBusinessUnits()
        {
            var businessUnits = await _businessUnitsService.GetAll();
            _vm.BusinessUnits = businessUnits;
        }
    }
}
