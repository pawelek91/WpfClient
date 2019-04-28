using RandevouWpfClient.Api;
using RandevouWpfClient.Models;
using RandevouWpfClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandevouWpfClient.ViewModels.Commands
{
    public class LoginCommand : BasicCommand
    {

        public StartViewModel VM { get; set; }

        public LoginCommand(StartViewModel vm)
        {
            VM = vm;
        }


        public override bool CanExecute(object parameter)
        => !String.IsNullOrWhiteSpace(VM.Username) && !String.IsNullOrWhiteSpace(VM.Password);



        public override void Execute(object parameter)
        {
            var aqp = new ApiQueryProvider();
            try
            { 
                var loginResult = aqp.Login(VM.Username, VM.Password);
                var userId = aqp.GetIdentity(loginResult);
                aqp.SetUserData(loginResult, userId);
                VM.LoginSuccessfull();
            }

            catch(Exception ex)
            {
                ResultHandler.Exception(ex, "Nie udało się zalogować");
            }
        }
    }

    
}
