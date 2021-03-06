﻿using Fleeter.Client.FleeterServiceProxy;
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
        private Dictionary<DateTime, MonthCostDetails> _costs;
        public Dictionary<DateTime, MonthCostDetails> Costs
        {
            get => _costs;
            set => Set(ref _costs, value);
        }
    }
}
