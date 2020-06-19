using Fleeter.Client.FleeterServiceProxy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public class CalculationService : ICalculationService
    {
        public Task<Dictionary<DateTime, MonthCostDetails>> GetCostsPerMonth()
        {
            var fleeter = new FleeterServiceClient();
            fleeter.Open();
            return fleeter.GetCostsPerMonthAsync();
        }

        public Task<Dictionary<DateTime, Dictionary<BusinessUnit, MonthCostDetails>>> GetCostsPerMonthPerBusinessUnit()
        {
            var fleeter = new FleeterServiceClient();
            fleeter.Open();
            return fleeter.GetCostsPerMonthPerBusinessUnitAsync();
        }
    }
}
