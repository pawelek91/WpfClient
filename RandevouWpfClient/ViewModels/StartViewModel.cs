using RandevouWpfClient.Models;
using RandevouWpfClient.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels
{
    public class StartViewModel : PrimaryViewModel
    {
        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnChanged(nameof(Username),true);
            }
        }

        private string password;

        public string Password
        {
            get =>password; 
            set
            {
                password = value;
                OnChanged(nameof(Password), true);
            }
        }

        public LoginCommand LoginCMD { get; set; }

        public StartViewModel()
        {
            LoginCMD = new LoginCommand(this);
        }
        internal void LoginSuccessfull()
        {
            var window = new MainWindow();
            window.Show();
            ResultHandler.CloseWindowOfWhichThereIsOnlyOne<Views.StartWindow>();
        }
    }
}
