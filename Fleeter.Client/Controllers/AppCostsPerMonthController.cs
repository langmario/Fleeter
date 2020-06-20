using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.ViewModels;
using System;
using System.Collections.Generic;
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

            var costs = await GetCosts();
            _vm.Costs = costs;

            return _vm;
        }

        private async Task<Dictionary<DateTime, MonthCostDetails>> GetCosts()
        {
            try
            {
                var costs = await _calcService.GetCostsPerMonth();
                return costs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Abrufen" + Environment.NewLine + ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return new Dictionary<DateTime, MonthCostDetails>();
            }
        }
    }
}
