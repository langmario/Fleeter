using Fleeter.Client.Framework;
using Fleeter.Client.UserServiceProxy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fleeter.Client.ViewModels
{
    public class AdminUsersViewModel : ViewModelBase
    {
        private ObservableCollection<User> _users = new ObservableCollection<User>();
        public ObservableCollection<User> Users { get => _users; set => Set(ref _users, value); }

        private User _selectedUser = null;
        public User SelectedUser {
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


        public string Firstname
        {
            get => _selectedUser?.Firstname;
            set
            {
                _selectedUser.Firstname = value;
                RaisePropertyChanged();
            }
        }

        public string Lastname
        {
            get => _selectedUser?.Lastname;
            set
            {
                _selectedUser.Lastname = value;
                RaisePropertyChanged();
            }
        }

        public string Username
        {
            get => _selectedUser?.Username;
            set
            {
                _selectedUser.Username = value;
                RaisePropertyChanged();
            }
        }

        public bool IsAdmin
        {
            get => _selectedUser?.IsAdmin ?? false;
            set
            {
                _selectedUser.IsAdmin = value;
                RaisePropertyChanged();
            }
        }
    }
}
