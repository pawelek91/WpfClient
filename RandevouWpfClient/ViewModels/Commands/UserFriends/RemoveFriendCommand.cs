using RandevouWpfClient.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandevouWpfClient.ViewModels.Commands.UserFriends
{
    public class RemoveFriendCommand : BasicCommand
    {
        private readonly UserFriendsViewModel _vm;
        private readonly ApiQueryProvider aqp;
        public RemoveFriendCommand(UserFriendsViewModel vm)
        {
            _vm = vm;
        }

        public override void Execute(object parameter)
        {
            if(_vm.FriendsChoosenUser != null)
            {
                _vm.Friends.Remove(_vm.FriendsChoosenUser);
            }
           
        }
    }
}
