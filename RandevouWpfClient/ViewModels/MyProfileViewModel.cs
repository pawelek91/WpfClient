﻿using RandevouApiCommunication.Users;
using RandevouApiCommunication.Users.DictionaryValues;
using RandevouWpfClient.Models;
using RandevouWpfClient.Models.Common;
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

        public SetAvatarCommand SetAvatarCommand { get; set; }


        private BitmapImage avatar;
        public BitmapImage Avatar
        {
            get => avatar;
            set
            {
                avatar = value;
                OnChanged(nameof(Avatar));
            }
        }

        private void GetAvatar(bool RefreshUserDetails = false)
        {
            if (RefreshUserDetails)
                UpdateMyProfileDetails();

            if (MyProfile.AvatarImage != null && MyProfile.AvatarImage.Length > 0 && !string.IsNullOrWhiteSpace(MyProfile.AvatarContentType))
            {
                Avatar = FileHandler.GetImageFromBytes(MyProfile.AvatarImage);
            }
        }

        public void GetAvatar(Byte[] content)
        {
            if (content != null & content.Length > 0)
            {
                try
                {
                    Avatar = FileHandler.GetImageFromBytes(content);
                }
                catch
                {
                    GetAvatar(RefreshUserDetails:true);
                }
                
            }
        }

        public MyProfileViewModel()
        {
            MyProfileBasic = queryProvider.GetMyProfileUser();
            UpdateMyProfileDetails();

            UpdateProfileCommand = new UpdateMyProfileCommand(this);
            MyProfileAddInterestCommand = new MyProfileAddInterestCommand(this);
            MyProfileRemoveInterestCommand = new MyProfileRemoveInterestCommand(this);
            SetAvatarCommand = new SetAvatarCommand(this);

            MyProfileInteresets = new ObservableCollection<DictionaryItemDto>();

            EyesColorsDictionary = queryProvider.GetAllEyesColors();
            HairColorsDictionary = queryProvider.GetAllHairColors();
            InterestDictionary = queryProvider.GetAllInterests();

            AssignyProfileEyesColor();
            AssignMyProfileHairColor();
            AssignMyProfileInteresets();
            GetAvatar();
        }

        private void UpdateMyProfileDetails()
        {
            MyProfile = queryProvider.GetMyProfileUserDetails();
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
