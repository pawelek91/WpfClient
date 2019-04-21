using RandevouApiCommunication.Users;
using RandevouWpfClient.Api;
using RandevouWpfClient.Models;
using RandevouWpfClient.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels
{
    public class RegisterViewModel : PrimaryViewModel
    {
        public CreateUserCommand CreateUserCMD { get; set; }
        public RegisterViewModel()
        {
            CreateUserCMD = new CreateUserCommand(this);
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnChanged(nameof(Name));
            }
        }

        private string displayName;
        public string DisplayName
        {
            get => !string.IsNullOrWhiteSpace(displayName) ? displayName : Name;
            set
            {
                displayName = value;
                OnChanged(nameof(DisplayName));
            }
        }


        private string choosenGender;
        public string ChoosenGender
        {
            get => choosenGender;
            set
            {
                choosenGender = value;
                if (value.Equals("Kobieta", StringComparison.CurrentCultureIgnoreCase))
                    Gender = 'F';
                else
                    Gender = 'M';
                OnChanged(ChoosenGender);
            }
        }

        public IEnumerable<string> Genders
        {
            get { return new string[] { "Mężczyzna", "Kobieta" }; }
        }
        public char Gender { get; private set; }


        private DateTime birthdate;

        public DateTime BirthDate
        {
            get => birthdate;
            set
            {
                birthdate = value;
                OnChanged(nameof(BirthDate));
            }
        }

        public string Password { get; set; }

        public void CreateUser(UserComplexDto dto)
        {
            try
            {
                queryProvider.CreateUser(dto);
            }
            catch(Exception ex)
            {
                ResultHandler.Exception(ex);
            }
        }
    }


}
