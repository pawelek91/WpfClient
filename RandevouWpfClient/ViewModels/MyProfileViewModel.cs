using RandevouApiCommunication.Users;
using RandevouApiCommunication.Users.DictionaryValues;
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
        public DictionaryItemDto[] EyesColorsDictionary { get; set; }
        public DictionaryItemDto[] HairColorsDictionary { get; set; }

        private DictionaryItemDto myProfileHairColor;

        public DictionaryItemDto MyProfileHairColor
        {
            get { return myProfileHairColor; }
            set
            {
                myProfileHairColor = value;
                MyProfile.HairColor = value.Id;
            }
        }

        private DictionaryItemDto myProfileEyesColor;

        public DictionaryItemDto MyProfileEyesColor
        {
            get { return myProfileEyesColor; }
            set
            {
                myProfileEyesColor = value;
                MyProfile.EyesColor = value.Id;
            }
        }


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

            EyesColorsDictionary = queryProvider.GetAllEyesColors();
            HairColorsDictionary = queryProvider.GetAllHairColors();

            AssignyProfileEyesColor(MyProfileEyesColor);
            AssignMyProfileHairColor(MyProfileHairColor);
        }

        private void AssignMyProfileHairColor(DictionaryItemDto myProfileHairColor)
        {
            if(MyProfile.HairColor.HasValue)
                MyProfileHairColor = HairColorsDictionary.Single(x => x.Id == MyProfile.HairColor);
        }

        private void AssignyProfileEyesColor(DictionaryItemDto myProfileEyesColor)
        {
            if(MyProfile.EyesColor.HasValue)
                MyProfileEyesColor = EyesColorsDictionary.Single(x => x.Id == MyProfile.EyesColor);
        }
    }
}
