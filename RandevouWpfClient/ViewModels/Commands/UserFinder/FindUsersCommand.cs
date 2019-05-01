using RandevouWpfClient.Api;
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
        private readonly ApiQueryProvider _queryProvider;

        public FindUsersCommand(UserSearchViewModel vm)
        {
            _vm = vm;
            _queryProvider = ApiQueryProvider.GetInstance();
        }
 
        public override void Execute(object parameter)
        {
            var dto = _vm.Finder;
            _vm.FoundUsers.Clear();
            var usersIds = _queryProvider.FindUsers(dto);
            _queryProvider.GetManyUsers(usersIds.ToArray()).ToList().ForEach(x => _vm.FoundUsers.Add(x));           
        }
    }
}
