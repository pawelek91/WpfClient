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
    public class ShowUserInvitationCommand : BasicCommand
    {
        private readonly UserFriendsViewModel _vm;
        private readonly UserDetailsViewModel _userVm;
        public ShowUserInvitationCommand(UserFriendsViewModel vm)
        {
            _vm = vm;
            _userVm = new UserDetailsViewModel();
        }

        public override void Execute(object parameter)
        {
            if (_vm.InvitationChoosenUser == null)
            {
                ResultHandler.Message("Not any user has been selected");
                return;
            }

            _userVm.User = _vm.InvitationChoosenUser;
            var view = new UserDetailsView(_userVm);
            view.Show();
        }
    }
}
