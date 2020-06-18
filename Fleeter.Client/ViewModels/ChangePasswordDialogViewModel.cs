using Fleeter.Client.Framework;
using System.Windows.Input;

namespace Fleeter.Client.ViewModels
{
    public class ChangePasswordDialogViewModel : ViewModelBase
    {
        private string _oldPassword;
        public string OldPassword
        {
            get => _oldPassword;
            set => Set(ref _oldPassword, value);
        }

        private string _newPassword;
        public string NewPassword
        {
            get => _newPassword;
            set => Set(ref _newPassword, value);
        }

        private string _newPasswordRepeat;
        public string NewPasswordRepeat
        {
            get => _newPasswordRepeat;
            set => Set(ref _newPasswordRepeat, value);
        }

        public ICommand Change { get; set; }
        public ICommand Cancel { get; set; }
    }
}
