using Fleeter.Client.Framework;
using System.Windows.Input;

namespace Fleeter.Client.ViewModels
{
    public class AppShellViewModel : ViewModelBase
    {
        private ViewModelBase _activeViewModel;
        public ViewModelBase ActiveViewModel
        {
            get => _activeViewModel;
            set => Set(ref _activeViewModel, value);
        }

        public bool IsAdmin { get; set; }

        public ICommand Logout { get; set; }
        public ICommand ChangeView { get; set; }
    }
}
