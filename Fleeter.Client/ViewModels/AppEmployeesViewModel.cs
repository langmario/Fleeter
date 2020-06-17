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
            get => SelectedEmployee?.EmployeeNumber ?? null;
            set
            {
                if (SelectedEmployee != null && value != null)
                    SelectedEmployee.EmployeeNumber = (int)value;
                RaisePropertyChanged();
            }
        }

        public string Salutation
        {
            get => SelectedEmployee?.Salutation;
            set
            {
                if (SelectedEmployee != null)
                    SelectedEmployee.Salutation = value;
                RaisePropertyChanged();
            }
        }

        public string Title
        {
            get => SelectedEmployee?.Title;
            set
            {
                if (SelectedEmployee != null)
                    SelectedEmployee.Title = value;
                RaisePropertyChanged();
            }
        }

        public string Firstname
        {
            get => SelectedEmployee?.Firstname;
            set
            {
                if (SelectedEmployee != null)
                    SelectedEmployee.Firstname = value;
                RaisePropertyChanged();
            }
        }

        public string Lastname
        {
            get => SelectedEmployee?.Lastname;
            set
            {
                if (SelectedEmployee != null)
                    SelectedEmployee.Lastname = value;
                RaisePropertyChanged();
            }
        }

        public BusinessUnit BusinessUnit
        {
            get => SelectedEmployee?.BusinessUnit;
            set
            {
                if (SelectedEmployee != null)
                    SelectedEmployee.BusinessUnit = value;
                RaisePropertyChanged();
            }
        }


        public ICommand CreateOrUpdate { get; set; }
        public ICommand Delete { get; set; }
        public ICommand New { get; set; }
    }
}
