using RandevouWpfClient.ViewModels;
using RandevouWpfClient.ViewModels.Commands;
using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginData LoginData { get; set; }
        public LoginView(LoginData loginData)
        {
            InitializeComponent();
            
            LoginData = loginData;
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            LoginData.Username = loginNameTxtBox.Text;
            LoginData.Password = loginPasswordTxtBox.Password;
            this.DialogResult = true;
            this.Close();
        }
    }

    public class LoginData
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
