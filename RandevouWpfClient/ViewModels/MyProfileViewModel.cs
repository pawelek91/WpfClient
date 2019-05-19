using RandevouApiCommunication.Users;
using RandevouWpfClient.ViewModels.Commands.MyProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels
{
    public class MyProfileViewModel : PrimaryViewModel
    {
        private UserDetailsDto myProfile;
        public UpdateMyProfileCommand UpdateProfileCommand { get; set; }

        private UsersDto myProfileBasic;
        public UsersDto MyProfileBasic
        {
            get => myProfileBasic;
            set { myProfileBasic = value;OnChanged(nameof(MyProfileBasic)); }
        }
        public UserDetailsDto MyProfile
        {
            get => myProfile;
            set { myProfile = value;OnChanged(nameof(MyProfile)); }
        }
        public MyProfileViewModel()
        {
            MyProfileBasic = queryProvider.GetMyProfileUser();
            MyProfile = queryProvider.GetMyProfileUserDetails();

            UpdateProfileCommand = new UpdateMyProfileCommand(this);
        }
    }
}
