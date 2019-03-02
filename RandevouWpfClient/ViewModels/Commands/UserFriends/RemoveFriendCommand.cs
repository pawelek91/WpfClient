using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandevouWpfClient.ViewModels.Commands.UserFriends
{
    public class RemoveFriendCommand : ICommand
    {
        private readonly UserFriendsViewModel _vm;
        public RemoveFriendCommand(UserFriendsViewModel vm)
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
            if(_vm.FriendsChoosenUser != null)
            _vm.Friends.Remove(_vm.FriendsChoosenUser);
        }
    }
}
