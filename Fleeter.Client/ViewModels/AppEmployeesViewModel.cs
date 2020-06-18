using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Fleeter.Client.ViewModels
{
    public class AppEmployeesViewModel : ViewModelBase
    {
        private ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set => Set(ref _employees, value);
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                Set(ref _selectedEmployee, value);
                RaisePropertyChanged(nameof(EmployeeNumber));
                RaisePropertyChanged(nameof(Salutation));
                RaisePropertyChanged(nameof(Title));
                RaisePropertyChanged(nameof(Firstname));
                RaisePropertyChanged(nameof(Lastname));
                RaisePropertyChanged(nameof(BusinessUnit));
            }
        }

        private IEnumerable<BusinessUnit> _businessUnits;
        public IEnumerable<BusinessUnit> BusinessUnits
        {
            get => _businessUnits;
            set => Set(ref _businessUnits, value);
        }


        public int? EmployeeNumber
        {
            get => _selectedEmployee?.EmployeeNumber ?? null;
            set
            {
                if (_selectedEmployee != null && value != null)
                    _selectedEmployee.EmployeeNumber = (int)value;
                RaisePropertyChanged();
            }
        }

        public string Salutation
        {
            get => _selectedEmployee?.Salutation;
            set
            {
                if (_selectedEmployee != null)
                    _selectedEmployee.Salutation = value;
                RaisePropertyChanged();
            }
        }

        public string Title
        {
            get => _selectedEmployee?.Title;
            set
            {
                if (_selectedEmployee != null)
                    _selectedEmployee.Title = value;
                RaisePropertyChanged();
            }
        }

        public string Firstname
        {
            get => _selectedEmployee?.Firstname;
            set
            {
                if (_selectedEmployee != null)
                    _selectedEmployee.Firstname = value;
                RaisePropertyChanged();
            }
        }

        public string Lastname
        {
            get => _selectedEmployee?.Lastname;
            set
            {
                if (_selectedEmployee != null)
                    _selectedEmployee.Lastname = value;
                RaisePropertyChanged();
            }
        }

        public BusinessUnit BusinessUnit
        {
            get => _selectedEmployee?.BusinessUnit;
            set
            {
                if (_selectedEmployee != null)
                    _selectedEmployee.BusinessUnit = value;
                RaisePropertyChanged();
            }
        }


        public ICommand CreateOrUpdate { get; set; }
        public ICommand Delete { get; set; }
        public ICommand New { get; set; }
        public ICommand Cancel { get; set; }
    }
}
