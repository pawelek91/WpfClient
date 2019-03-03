using RandevouApiCommunication.Users;
using RandevouApiCommunication.UsersFinder;
using RandevouWpfClient.ViewModels.Commands.UserFinder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels
{
    public class UserSearchViewModel : PrimaryViewModel
    {
        public FindUsersCommand FindUsersCommand { get; set; }
        public ShowSelectedUserCommand ShowSelectedCommand { get; set; }

        private UsersFinderDto finder;
        public UsersFinderDto Finder { get => finder; set { finder = value; OnChanged(nameof(Finder)); } }

        private UsersDto selectedUser;
        public UsersDto SelectedUser { get => selectedUser; set { selectedUser = value; OnChanged(nameof(SelectedUser)); } }

        public ObservableCollection<UsersDto> FoundUsers { get; set; }
        public UserSearchViewModel()
        {
            FindUsersCommand = new FindUsersCommand(this);
            ShowSelectedCommand = new ShowSelectedUserCommand(this);
            FoundUsers = new ObservableCollection<UsersDto>();
        }
    }
}
