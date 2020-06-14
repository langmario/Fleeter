using Fleeter.Client.Framework;

namespace Fleeter.Client.ViewModels
{
    public class RootShellViewModel : ViewModelBase
    {
        private ViewModelBase _activeViewModel;
        public ViewModelBase ActiveViewModel
        {
            get => _activeViewModel;
            set => Set(ref _activeViewModel, value);
        }
    }
}
