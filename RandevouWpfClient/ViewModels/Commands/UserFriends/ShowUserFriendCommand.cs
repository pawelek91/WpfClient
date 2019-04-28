using RandevouApiCommunication.Users;
using RandevouWpfClient.Models;
using RandevouWpfClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandevouWpfClient.ViewModels.Commands.UserFriends
{
    public class ShowUserFriendCommand : BasicCommand
    {
        private readonly UserFriendsViewModel _vm;
        private readonly UserDetailsViewModel _userVm;
        public ShowUserFriendCommand(UserFriendsViewModel vm)
        {
            _vm = vm;
            _userVm = new UserDetailsViewModel();
        }

        public override void Execute(object parameter)
        {
            if(_vm.FriendsChoosenUser==null)
            {
                ResultHandler.Message("Not any user has been selected");
                return;
            }

            _userVm.User = _vm.FriendsChoosenUser;
            var window = new UserDetailsView(_userVm);
            window.Show();
        }
    }
}
