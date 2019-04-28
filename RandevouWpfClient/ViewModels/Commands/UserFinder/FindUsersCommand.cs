using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandevouWpfClient.ViewModels.Commands.UserFinder
{
    public class FindUsersCommand : BasicCommand
    {
        private readonly UserSearchViewModel _vm;


        public FindUsersCommand(UserSearchViewModel vm)
        {
            _vm = vm;
        }
 
        public override void Execute(object parameter)
        {
            FindUsers();
        }

        private void FindUsers()
        {
            //api => find users...
            var rand = new Random().Next(0, 4);

        }
    }
}
