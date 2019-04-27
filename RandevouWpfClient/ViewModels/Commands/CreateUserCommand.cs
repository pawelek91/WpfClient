using RandevouApiCommunication.Users;
using RandevouWpfClient.Models;
using RandevouWpfClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels.Commands
{
    public class CreateUserCommand : BasicCommand
    {
        public RegisterViewModel RegisterVm { get; set; }
        public CreateUserCommand(RegisterViewModel vm)
        {
            RegisterVm = vm;
        }

        public override bool CanExecute(object parameter)
            => DataFilled;

        public override void Execute(object parameter)
        {
            if (!DataFilled)
                return;
           
            var dto = new UserComplexDto
            {
                UserDto = new UsersDto
                {
                    BirthDate = RegisterVm.BirthDate,
                    Name = RegisterVm.Name,
                    Gender = RegisterVm.Gender,
                    DisplayName = RegisterVm.DisplayName,
                },
                Password = RegisterVm.Password,
            };

            ResultHandler.ProgressAction(() =>
            {
                RegisterVm.CreateUser(dto);

            }, "Tworzenie konta");
            if (parameter is RegisterView view)
                view.Close();
        }

        private bool DataFilled
            => !(string.IsNullOrWhiteSpace(RegisterVm.Name)
                || string.IsNullOrWhiteSpace(RegisterVm.DisplayName)
                || string.IsNullOrWhiteSpace(RegisterVm.Password)
                || RegisterVm.BirthDate == default(DateTime)
                || RegisterVm.Gender == default(char));
        
    }
}
