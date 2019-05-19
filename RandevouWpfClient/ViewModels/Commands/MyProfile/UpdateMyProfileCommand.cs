using RandevouWpfClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels.Commands.MyProfile
{
    public class UpdateMyProfileCommand : BasicCommand
    {
        MyProfileViewModel _vm;
        public UpdateMyProfileCommand(MyProfileViewModel vm)
        {
            _vm = vm;
        }
        public override void Execute(object parameter)
        {
            ResultHandler.ProgressAction(() =>
            {
                QueryProvider.UpdateMyProfileUserBasic(_vm.MyProfileBasic);
                QueryProvider.UpdateMyProfileUser(_vm.MyProfile);
            }, "Aktualizowanie profilu");
        }
    }
}
