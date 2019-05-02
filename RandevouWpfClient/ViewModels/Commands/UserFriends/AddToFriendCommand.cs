using RandevouWpfClient.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandevouWpfClient.ViewModels.Commands.UserFriends
{
    public class AddToFriendCommand : BasicCommand
    {
        private readonly ApiQueryProvider aqp;
        private readonly UserFriendsViewModel _vm;
        
        public AddToFriendCommand(UserFriendsViewModel vm)
        {
            _vm = vm;
            aqp = ApiQueryProvider.GetInstance();
        }

        public override void Execute(object parameter)
        {
            if (_vm.InvitationChoosenUser != null)
            {
                aqp.AcceptFriendshipInvitation(_vm.InvitationChoosenUser.Id.Value);
                _vm.Friends.Add(_vm.InvitationChoosenUser);
                _vm.Invitations.Remove(_vm.InvitationChoosenUser);
            }
        }
    }
}
