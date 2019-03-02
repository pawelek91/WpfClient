using RandevouApiCommunication.Users;
using RandevouWpfClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandevouWpfClient.ViewModels.Commands.UserFriends
{
    public class ShowUserFriendCommand : ICommand
    {
        private UserFriendsViewModel _vm;
        public ShowUserFriendCommand(UserFriendsViewModel vm)
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
            if(_vm.FriendsChoosenUser==null)
            {
                ResultHandler.Message("Not any user has been selected");
                return;
            }
        }
    }
}
