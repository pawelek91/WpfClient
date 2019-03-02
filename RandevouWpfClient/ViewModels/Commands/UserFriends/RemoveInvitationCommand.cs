using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandevouWpfClient.ViewModels.Commands.UserFriends
{
    public class RemoveInvitationCommand : ICommand
    {
        private readonly UserFriendsViewModel _vm;
        public RemoveInvitationCommand(UserFriendsViewModel vm)
        {
            _vm = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_vm.InvitationChoosenUser != null)
                _vm.Invitations.Remove(_vm.InvitationChoosenUser);
        }
    }
}
