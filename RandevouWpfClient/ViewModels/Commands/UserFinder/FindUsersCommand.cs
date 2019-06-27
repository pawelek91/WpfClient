using RandevouWpfClient.Api;
using RandevouWpfClient.Models.Common;
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
            var dto = _vm.Finder;
            _vm.FoundUsers.Clear();
            var usersIds = QueryProvider.FindUsers(dto);
            var usersDtos = QueryProvider.GetManyUsers(usersIds.ToArray()).ToList();

            var avatars = QueryProvider.GetUsersAvatars(usersIds);

            foreach(var userDto in usersDtos)
            {

                var vm = new UsersSearchResultViewModel()
                {
                    DisplayName = userDto.DisplayName,
                    Age = DateTime.Today.Year - userDto.BirthDate.Value.Year,
                };

                var avatarInfo = avatars.FirstOrDefault(x => x.UserId == userDto.Id);
                if(avatarInfo != null && !string.IsNullOrWhiteSpace(avatarInfo.AvatarContentType) && avatarInfo.AvatarContentBytes.Length > 0)
                {
                    vm.Avatar = FileHandler.GetImageFromBytes(avatarInfo.AvatarContentBytes);
                }

                if (userDto.Gender.HasValue)
                {
                    vm.Gender = userDto.Gender == 'F' ? "Kobieta" : "Mężczyzna"; 
                }

                _vm.FoundUsers.Add(vm);
            }
        }
    }
}
