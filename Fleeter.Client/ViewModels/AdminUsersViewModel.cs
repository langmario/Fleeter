using Fleeter.Client.Framework;
using Fleeter.Client.UserServiceProxy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Client.ViewModels
{
    public class AdminUsersViewModel : ViewModelBase
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>
        {
            new User
            {
                Id = 1,
                Firstname = "Mario",
                Lastname = "Lang",
                Username = "langmario",
                IsAdmin = true
            }
        };

        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set => Set(ref _selectedUser, value);
        }
    }
}
