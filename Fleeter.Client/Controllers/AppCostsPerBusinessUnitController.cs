using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Fleeter.Client.Controllers
{
    public class AppCostsPerBusinessUnitController : IRoutableController
    {
        private readonly ICalculationService _calcService;
        private AppCostsPerBusinessUnitViewModel _vm;

        public AppCostsPerBusinessUnitController(ICalculationService calcService)
        {
            _calcService = calcService;
        }

        public async Task<ViewModelBase> Initialize()
        {
            _vm = new AppCostsPerBusinessUnitViewModel();

            var costs = await GetCosts();
            _vm.Costs = costs;

            return _vm;
        }

        private async Task<IEnumerable<BusinessUnitCostDetails>> GetCosts()
        {
            try
            {
                var costs = await _calcService.GetCostsPerMonthPerBusinessUnit();
                return costs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Abrufen" + Environment.NewLine + ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return Enumerable.Empty<BusinessUnitCostDetails>();
            }
        }
    }
}
