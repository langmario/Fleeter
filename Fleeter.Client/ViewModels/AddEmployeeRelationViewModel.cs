using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Fleeter.Client.ViewModels
{
    public class AddEmployeeRelationViewModel : ViewModelBase
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
            set => Set(ref _selectedEmployee, value);
        }


        private DateTime _from = DateTime.Today;
        public DateTime From
        {
            get => _from;
            set => Set(ref _from, value);
        }


        private DateTime? _to = null;
        public DateTime? To
        {
            get => _to;
            set => Set(ref _to, value);
        }


        public ICommand Add { get; set; }
        public ICommand Cancel { get; set; }
    }
}
