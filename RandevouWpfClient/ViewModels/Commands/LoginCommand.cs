using RandevouWpfClient.Api;
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
        public MainViewModel MainVM{get;set;}

        public LoginCommand(MainViewModel vm)
        {
            MainVM = vm;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            var loginData = new LoginData();
            var window = new LoginView(loginData);
            var result = window.ShowDialog();
            var aqp = new ApiQueryProvider();
            var loginResult = aqp.Login(loginData.Username, loginData.Password);
            var userId = aqp.GetIdentity(loginResult);


            aqp.SetUserData(loginResult, userId);

            MainVM.Auth = new Models.Api.Auth
            {
                Key = loginResult,
                User = loginData.Username
            };           
        }
    }

    
}
