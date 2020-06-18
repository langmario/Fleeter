using Fleeter.Client.Framework;
using Fleeter.Client.UserServiceProxy;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Fleeter.Client.ViewModels
{
    public class AdminUsersViewModel : ViewModelBase
    {
        private ObservableCollection<User> _users = new ObservableCollection<User>();
        public ObservableCollection<User> Users { get => _users; set => Set(ref _users, value); }

        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                Set(ref _selectedUser, value);
                RaisePropertyChanged(nameof(Firstname));
                RaisePropertyChanged(nameof(Lastname));
                RaisePropertyChanged(nameof(Username));
                RaisePropertyChanged(nameof(IsAdmin));
            }
        }


        public ICommand CreateOrUpdate { get; set; }
        public ICommand Delete { get; set; }
        public ICommand New { get; set; }
        public ICommand Cancel { get; set; }


        public string Firstname
        {
            get => SelectedUser?.Firstname;
            set
            {
                if (SelectedUser != null)
                {
                    SelectedUser.Firstname = value;
                }

                RaisePropertyChanged();
            }
        }

        public string Lastname
        {
            get => SelectedUser?.Lastname;
            set
            {
                if (SelectedUser != null)
                {
                    SelectedUser.Lastname = value;
                }

                RaisePropertyChanged();
            }
        }

        public string Username
        {
            get => SelectedUser?.Username;
            set
            {
                if (SelectedUser != null)
                {
                    SelectedUser.Username = value;
                }

                RaisePropertyChanged();
            }
        }

        public bool IsAdmin
        {
            get => SelectedUser?.IsAdmin ?? false;
            set
            {
                if (SelectedUser != null)
                {
                    SelectedUser.IsAdmin = value;
                }

                RaisePropertyChanged();
            }
        }
    }
}
