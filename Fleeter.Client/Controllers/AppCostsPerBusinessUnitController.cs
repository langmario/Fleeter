using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            return _vm;
        }
    }
}
