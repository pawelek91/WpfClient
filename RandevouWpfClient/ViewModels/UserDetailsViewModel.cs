using RandevouApiCommunication.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RandevouWpfClient.ViewModels
{
    public class UserDetailsViewModel : PrimaryViewModel
    {
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

        public UserDetailsViewModel()
        {
        }

        private void GetUserDetails()
        {
            if (User == null)
                return;

        }


    }
}
