using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Client.ViewModels
{
    public class AppCostsPerMonthViewModel : ViewModelBase
    {
        private Dictionary<DateTime, MonthCostDetails> _costsPerMonth;
        public Dictionary<DateTime, MonthCostDetails> CostsPerMonth
        {
            get => _costsPerMonth;
            set => Set(ref _costsPerMonth, value);
        }
    }
}
