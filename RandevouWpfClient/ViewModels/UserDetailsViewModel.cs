using RandevouApiCommunication.Users;
using RandevouWpfClient.Models;
using RandevouWpfClient.Models.Common;
using RandevouWpfClient.ViewModels.Commands.Messages;
using RandevouWpfClient.ViewModels.Commands.UserFriends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RandevouWpfClient.ViewModels
{
    public class UserDetailsViewModel : PrimaryViewModel
    {
        public GotoConversationCommand GoToConversationCommand { get; set; }
        public SendFriendshipInvitationCommand SendFriendshipInvitationCommand { get; set; }
        private UserDetailsDto userDetails;
        public UserDetailsDto UserDetails
        {
            get => userDetails;
            set { userDetails = value;OnChanged(nameof(UserDetails)); }
        }

        private UsersDto user;
        public UsersDto User
        {
            get => user;
            set { user = value; OnChanged(nameof(User)); GetUserDetails(); }
        }

        private BitmapImage avatar;

        public BitmapImage Avatar
        {
            get => avatar;
            set
            {
                avatar = value;
                OnChanged(nameof(avatar));
            }
        }

        public UserDetailsViewModel()
        {
            SendFriendshipInvitationCommand = new SendFriendshipInvitationCommand();
            GoToConversationCommand = new GotoConversationCommand();
        }

        private void GetUserDetails()
        {
            if (User == null)
                return;

            UserDetails = queryProvider.GetUserDetails(User.Id.Value);

            if(UserDetails.AvatarImage != null && UserDetails.AvatarImage.Length > 0 && !string.IsNullOrWhiteSpace(UserDetails.AvatarContentType))
            {
                Avatar = FileHandler.GetImageFromBytes(UserDetails.AvatarImage);
            }
        }


    }
}
