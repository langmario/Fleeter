using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Fleeter.Client.ViewModels
{
    public class AppBusinessUnitsViewModel : ViewModelBase
    {
        private ObservableCollection<BusinessUnit> _businessUnits = new ObservableCollection<BusinessUnit>();
        public ObservableCollection<BusinessUnit> BusinessUnits
        {
            get => _businessUnits;
            set => Set(ref _businessUnits, value);
        }

        private BusinessUnit _selectedBusinessUnit;
        public BusinessUnit SelectedBusinessUnit
        {
            get => _selectedBusinessUnit;
            set
            {
                Set(ref _selectedBusinessUnit, value);
                RaisePropertyChanged(nameof(Name));
                RaisePropertyChanged(nameof(Description));
            }
        }


        public string Name
        {
            get => SelectedBusinessUnit?.Name;
            set
            {
                if (SelectedBusinessUnit != null)
                    SelectedBusinessUnit.Name = value;
                RaisePropertyChanged();
            }
        }

        public string Description
        {
            get => SelectedBusinessUnit?.Description;
            set
            {
                if (SelectedBusinessUnit != null)
                    SelectedBusinessUnit.Description = value;
                RaisePropertyChanged();
            }
        }


        public ICommand CreateOrUpdate { get; set; }
        public ICommand Delete { get; set; }
        public ICommand New { get; set; }
        public ICommand Cancel { get; set; }
    }
}
