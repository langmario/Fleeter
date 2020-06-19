using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Fleeter.Client.Controllers
{
    public class AppCostsPerMonthController : IRoutableController
    {
        private readonly ICalculationService _calcService;
        private AppCostsPerMonthViewModel _vm;

        public AppCostsPerMonthController(ICalculationService calcService)
        {
            _calcService = calcService;
        }

        public async Task<ViewModelBase> Initialize()
        {
            _vm = new AppCostsPerMonthViewModel();

            SetCosts();

            return _vm;
        }

        private async void SetCosts()
        {
            try
            {
                var costs = await _calcService.GetCostsPerMonth();
                _vm.Costs = costs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Abrufen" + Environment.NewLine + ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
