using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Fleeter.Client.Controllers
{
    public class AppBusinessUnitController : IRoutableController
    {
        private readonly IBusinessUnitService _businessUnits;
        private AppBusinessUnitsViewModel _vm;

        public AppBusinessUnitController(IBusinessUnitService businessUnits)
        {
            _businessUnits = businessUnits;
        }

        public async Task<ViewModelBase> Initialize()
        {
            _vm = new AppBusinessUnitsViewModel();

            _vm.CreateOrUpdate = new RelayCommand(async o =>
            {
                try
                {
                    var result = await _businessUnits.CreateOrUpdate(_vm.SelectedBusinessUnit);
                    if (!(result.Status == Status.Created || result.Status == Status.Updated))
                    {
                        MessageBox.Show(result.Message, "Fehler beim Speichern", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        _vm.SelectedBusinessUnit = null;
                        _vm.BusinessUnits = await GetBusinessUnit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fehler beim Speichern", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }, o => _vm.Name != null);

            _vm.Delete = new RelayCommand(async o =>
            {
                try
                {
                    var result = await _businessUnits.Delete(_vm.SelectedBusinessUnit);
                    if (result.Status != Status.Deleted)
                    {
                        MessageBox.Show(result.Message, "Fehler beim Löschen", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        _vm.SelectedBusinessUnit = null;
                        _vm.BusinessUnits = await GetBusinessUnit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fehler beim Löschen", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }, o => _vm.SelectedBusinessUnit?.Id != 0);

            _vm.New = new RelayCommand(o =>
            {
                _vm.SelectedBusinessUnit = new BusinessUnit();
            });

            _vm.Cancel = new RelayCommand(o =>
            {
                _vm.SelectedBusinessUnit = null;
            });

            _vm.BusinessUnits = await GetBusinessUnit();

            return _vm;
        }


        private async Task<ObservableCollection<BusinessUnit>> GetBusinessUnit()
        {
            try
            {
                var businessUnits = await _businessUnits.GetAll();
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
