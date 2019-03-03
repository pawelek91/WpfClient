using RandevouApiCommunication.Users;
using RandevouWpfClient.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RandevouWpfClient
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowFriends_Click(object sender, RoutedEventArgs e)
        {
            var v = new UserFriendsView();
            v.Show();
        }

        private void FindUsersBTN_Click(object sender, RoutedEventArgs e)
        {
            var v = new UserSearchView();
            v.Show();
        }
    }
}
