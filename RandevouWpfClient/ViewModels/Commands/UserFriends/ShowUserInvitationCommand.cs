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
    public class ShowUserInvitationCommand : ICommand
    {
        private readonly UserFriendsViewModel _vm;
        public ShowUserInvitationCommand(UserFriendsViewModel vm)
        {
            _vm = vm;
            
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
            
        }

        public void Execute(object parameter)
        {
            if (_vm.InvitationChoosenUser == null)
            {
                ResultHandler.Message("Not any user has been selected");
                return;
            }

            
            var view = new UserDetailsView(_vm.InvitationChoosenUser);
            view.Show();
        }
    }
}
