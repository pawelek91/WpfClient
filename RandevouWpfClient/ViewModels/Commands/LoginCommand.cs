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
            
            try
            {
                ResultHandler.ProgressAction(() =>
                {
                    var loginResult = QueryProvider.Login(VM.Username, VM.Password);
                    var userId = QueryProvider.GetIdentity(loginResult);
                    QueryProvider.SetUserData(loginResult, userId);
                    VM.LoginSuccessfull();

                }, "Logowanie");
                
            }

            catch(Exception ex)
            {
                ResultHandler.Exception(ex, "Nie udało się zalogować");
            }
        }
    }

    
}
