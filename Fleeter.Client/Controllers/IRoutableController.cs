using Fleeter.Client.Framework;
using System.Threading.Tasks;

namespace Fleeter.Client.Controllers
{
    public interface IRoutableController
    {
        Task<ViewModelBase> Initialize();
    }
}
