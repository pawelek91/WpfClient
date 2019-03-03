﻿using RandevouWpfClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandevouWpfClient.ViewModels.Commands.UserFinder
{
    public class ShowSelectedUserCommand : ICommand
    {
        private readonly UserSearchViewModel _vm;
        public ShowSelectedUserCommand(UserSearchViewModel vm)
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
            if (_vm.SelectedUser == null)
                return;
            var udViewModel = new UserDetailsViewModel() { User = _vm.SelectedUser };

            var window = new UserDetailsView(udViewModel);
            window.Show();
        }
    }
}
