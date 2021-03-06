﻿using Fleeter.Client.FleeterServiceProxy;
using Fleeter.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Client.ViewModels
{
    public class AppCostsPerBusinessUnitViewModel : ViewModelBase
    {
        private IEnumerable<BusinessUnitCostDetails> _costs;
        public IEnumerable<BusinessUnitCostDetails> Costs
        {
            get => _costs;
            set => Set(ref _costs, value);
        }

    }
}
