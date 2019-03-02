using RandevouApiCommunication.Users;
using RandevouWpfClient.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RandevouWpfClient.Views
{
    /// <summary>
    /// Interaction logic for UserDetailsView.xaml
    /// </summary>
    public partial class UserDetailsView : Window, INotifyPropertyChanged
    {

        
        private UsersDto user;

        public event PropertyChangedEventHandler PropertyChanged;

        public UsersDto User
        {
            get { return user; }
            set
            {
                user = value;
                if(PropertyChanged!=null)
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(User)));
            }
        }

        public UserDetailsView(UsersDto dto)
        {
            
            InitializeComponent();
            User = dto;
        }
    }
}
