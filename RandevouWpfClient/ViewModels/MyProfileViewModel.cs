using RandevouApiCommunication.Users;
using RandevouApiCommunication.Users.DictionaryValues;
using RandevouWpfClient.Models;
using RandevouWpfClient.ViewModels.Commands.MyProfile;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RandevouWpfClient.ViewModels
{
    public class MyProfileViewModel : PrimaryViewModel
    {
        private UsersDto myProfileBasic;
        public UsersDto MyProfileBasic
        {
            get => myProfileBasic;
            set { myProfileBasic = value; OnChanged(nameof(MyProfileBasic)); }
        }

        private UserDetailsDto myProfile;
        public UserDetailsDto MyProfile
        {
            get => myProfile;
            set { myProfile = value; OnChanged(nameof(MyProfile)); }
        }

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


        public DictionaryItemDto[] InterestDictionary { get; set; }
        public ObservableCollection<DictionaryItemDto> MyProfileInteresets { get; set; }

        private DictionaryItemDto myInterestSelectedItem;

        public DictionaryItemDto MyInterestSelectedItem
        {
            get { return myInterestSelectedItem; }
            set { myInterestSelectedItem = value; }
        }

        private DictionaryItemDto interestDictionarySelectedItem;

        public DictionaryItemDto DictionaryInterestSelectedItem
        {
            get { return interestDictionarySelectedItem; }
            set { interestDictionarySelectedItem = value; }
        }


        public UpdateMyProfileCommand UpdateProfileCommand { get; set; }
        public MyProfileAddInterestCommand MyProfileAddInterestCommand { get; set; }
        public MyProfileRemoveInterestCommand MyProfileRemoveInterestCommand { get; set; }


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

        private void GetAvatar()
        {

            if (MyProfile.AvatarImage != null && MyProfile.AvatarImage.Length > 0 && !string.IsNullOrWhiteSpace(MyProfile.AvatarContentType))
            {
                Avatar = ResultHandler.GetImageFromBytes(MyProfile.AvatarImage);
            }
        }

        public MyProfileViewModel()
        {
            MyProfileBasic = queryProvider.GetMyProfileUser();
            MyProfile = queryProvider.GetMyProfileUserDetails();

            UpdateProfileCommand = new UpdateMyProfileCommand(this);
            MyProfileAddInterestCommand = new MyProfileAddInterestCommand(this);
            MyProfileRemoveInterestCommand = new MyProfileRemoveInterestCommand(this);

            MyProfileInteresets = new ObservableCollection<DictionaryItemDto>();

            EyesColorsDictionary = queryProvider.GetAllEyesColors();
            HairColorsDictionary = queryProvider.GetAllHairColors();
            InterestDictionary = queryProvider.GetAllInterests();

            AssignyProfileEyesColor();
            AssignMyProfileHairColor();
            AssignMyProfileInteresets();

            GetAvatar();
        }

        private void AssignMyProfileHairColor()
        {
            if(MyProfile.HairColor.HasValue)
                MyProfileHairColor = HairColorsDictionary.Single(x => x.Id == MyProfile.HairColor);
        }

        private void AssignyProfileEyesColor()
        {
            if(MyProfile.EyesColor.HasValue)
                MyProfileEyesColor = EyesColorsDictionary.Single(x => x.Id == MyProfile.EyesColor);
        }

        private void AssignMyProfileInteresets()
        {
            if(MyProfile.Interests != null && MyProfile.Interests.Any())
            {
                var userInterests = InterestDictionary.Where(x => MyProfile.Interests.Contains(x.Id.Value));
                foreach(var interest in userInterests)
                {
                    MyProfileInteresets.Add(interest);
                }
            }
        }
    }
}
