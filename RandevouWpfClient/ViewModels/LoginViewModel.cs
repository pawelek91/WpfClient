using RandevouWpfClient.Models;
using RandevouWpfClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandevouWpfClient.ViewModels
{
    public class LoginViewModel : PrimaryViewModel
    {
        private readonly LoginView _view;
        public string UserLogin { get; set; }
        public string UserPassowrd { get; set; }
        public string ApiKey { get; set; }

        public void LoginUser()
        {
            if(string.IsNullOrWhiteSpace(UserLogin) || string.IsNullOrWhiteSpace(UserPassowrd))
            {
                ResultHandler.Exception(new ArgumentException("Brak loginu i/lub hasła"));
            }

            //api -> login...
            ApiKey = UserLogin + UserPassowrd;
            ResultHandler.Message("Zalogowano pomyślnie");
            _view.Close();
        }

        public LoginViewModel(LoginView view)
        {
            _view = view;
        }

    }
}
