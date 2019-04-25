using RandevouWpfClient.Api;
using RandevouWpfClient.Models.Api;
using RandevouWpfClient.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels
{
    public class MainViewModel : PrimaryViewModel
    {
        private Auth auth;
        public Auth Auth
        {
            get => auth;
            set
            {
                auth = value;
                OnChanged(nameof(Auth));
                OnChanged(nameof(ZalogowanoField));
      
            }
        }

        public string ZalogowanoField
            => UserLogged ? "Zalogowano: "+Auth.User
            : "Nie zalogowano";


    
        

        public bool UserLogged
            => !String.IsNullOrWhiteSpace(Auth?.Key);
        
        public LoginCommand LoginCommand { get; set; }
        public MainViewModel()
        {
            //LoginCommand = new LoginCommand(this);
        }

        public void Login()
        {
            
        }
    }
}
