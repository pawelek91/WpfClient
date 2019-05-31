using RandevouApiCommunication.Users.DictionaryValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels.Commands.MyProfile
{
    public abstract class MyProfileInteresCommand : BasicCommand
    {
        protected MyProfileViewModel _vm;
        public MyProfileInteresCommand(MyProfileViewModel vm)
        {
            _vm = vm;
        }

        protected void RefreshUserInterests()
        {
            _vm.MyProfile.Interests = _vm.MyProfileInteresets.Select(x => x.Id.Value).ToArray();
        }
    }
    public class MyProfileAddInterestCommand : MyProfileInteresCommand
    {
        public MyProfileAddInterestCommand(MyProfileViewModel vm) : base(vm) { }
   
        public override void Execute(object parameter)
        {
            if (_vm.DictionaryInterestSelectedItem == null)
                return;

            if(_vm.MyProfileInteresets.Any(x=> x.Id == _vm.DictionaryInterestSelectedItem.Id))
                return;

            _vm.MyProfileInteresets.Add(_vm.DictionaryInterestSelectedItem);
            RefreshUserInterests();
        }
    }

    public class MyProfileRemoveInterestCommand : MyProfileInteresCommand
    {
        public MyProfileRemoveInterestCommand(MyProfileViewModel vm) : base(vm) { }
        
        public override void Execute(object parameter)
        {
            if (_vm.MyInterestSelectedItem == null)
                return;

            _vm.MyProfileInteresets.Remove(_vm.MyInterestSelectedItem);
            RefreshUserInterests();
        }
    }
}
