using Fleeter.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fleeter.Client.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand ChangePassword { get; set; }
    }
}
