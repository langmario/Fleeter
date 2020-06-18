using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.ViewModels;
using System;
using System.Collections.ObjectModel;
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

        public ViewModelBase Initialize()
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
                        LoadBusinessUnits();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fehler beim Speichern", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

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
                        LoadBusinessUnits();
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

            LoadBusinessUnits();

            return _vm;
        }

        private async void LoadBusinessUnits()
        {
            var businessUnits = await _businessUnits.GetAll();
            _vm.BusinessUnits = new ObservableCollection<BusinessUnit>(businessUnits);
        }
    }
}
