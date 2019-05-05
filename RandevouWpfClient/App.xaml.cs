using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace RandevouWpfClient
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<CancellationToken> TaskToDisposeTokens;

        public App()
        {
            TaskToDisposeTokens = new List<CancellationToken>();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            foreach(var token in TaskToDisposeTokens)
            {
                token.ThrowIfCancellationRequested();
            }
        }
    }
}
