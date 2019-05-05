using RandevouApiCommunication.Users;
using RandevouWpfClient.ViewModels.Commands.UserFriends;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RandevouWpfClient.ViewModels
{
    public class UserFriendsViewModel : PrimaryViewModel
    {
        public ShowUserInvitationCommand ShowUserInvitationCommand { get; set; }
        public ShowUserFriendCommand ShowUserFriendCommand { get; set; }
        public RemoveFriendCommand RemoveFriendCommand { get; set; }
        public AddToFriendCommand AddToFriendCommand { get; set; }
        public RemoveInvitationCommand RemoveInvitationCommand { get; set; }

        public ObservableCollection<UsersDto> Friends { get; set; }
        public ObservableCollection<UsersDto> Invitations { get; set; }

        private UsersDto invitationChoosenUser;
        public UsersDto InvitationChoosenUser
        {
            get { return invitationChoosenUser; }
            set { invitationChoosenUser = value;OnChanged(nameof(InvitationChoosenUser)); }
        }

        private UsersDto friendsChoosenUser;
        public UsersDto FriendsChoosenUser
        {
            get { return friendsChoosenUser; }
            set { friendsChoosenUser = value; OnChanged(nameof(FriendsChoosenUser)); }
        }



        public UserFriendsViewModel() :base()
        {
            ShowUserInvitationCommand = new ShowUserInvitationCommand(this);
            ShowUserFriendCommand = new ShowUserFriendCommand(this);
            RemoveFriendCommand = new RemoveFriendCommand(this);
            AddToFriendCommand = new AddToFriendCommand(this);
            RemoveInvitationCommand = new RemoveInvitationCommand(this);

            Friends = new ObservableCollection<UsersDto>();
            Invitations = new ObservableCollection<UsersDto>();
        }

        private void GetFriends()
        {
            Friends.Clear();
            var friends = queryProvider.GetFriends();

            foreach (var f in friends)
                Friends.Add(f);
        }

        private void GetInvitations()
        {
            Invitations.Clear();

            foreach (var f in queryProvider.GetInvitatios())
                Invitations.Add(f);
        }

        protected override void GetDataAndRefreshUI()
        {
            GetFriends();
            GetInvitations();
        }
    }
}
