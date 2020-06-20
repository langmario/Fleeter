using Fleeter.Client.FleeterServiceProxy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public interface ICalculationService
    {
        Task<Dictionary<DateTime, MonthCostDetails>> GetCostsPerMonth();
        Task<List<BusinessUnitCostDetails>> GetCostsPerMonthPerBusinessUnit();
    }
}