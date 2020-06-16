using Fleeter.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Client.Controllers
{
    public interface IController
    {
        ViewModelBase Initialize();
    }
}
