﻿using RandevouWpfClient.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandevouWpfClient.ViewModels.Commands.UserFriends
{
    public class RemoveInvitationCommand : BasicCommand
    {
        private readonly UserFriendsViewModel _vm;
        public RemoveInvitationCommand(UserFriendsViewModel vm)
        {
            _vm = vm;
        }



        public override void Execute(object parameter)
        {
            if (_vm.InvitationChoosenUser != null)
            {
                QueryProvider.RejectFriendshipInvitation(_vm.InvitationChoosenUser.Id.Value);
                _vm.Invitations.Remove(_vm.InvitationChoosenUser);
            }
                
        }
    }
}
