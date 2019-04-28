using RandevouWpfClient.Models;
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
    /// Interaction logic for OperationProgressWindow.xaml
    /// </summary>
    public partial class OperationProgressWindow : Window
    {
        private Action _action;
        public OperationProgressWindow(Action action, string Text = "")
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            InitializeComponent();

            if (!string.IsNullOrEmpty(Text))
                progressLabel.Content = Text;

            _action = action;
        }

        
        private void ShowProgressBar()
        {
            progressBar.IsIndeterminate = true;
            var worker = new BackgroundWorker();
            worker.DoWork += (s, e) =>
            {
                try
                { 
                    _action();
                }
                catch (Exception ex)
                {
                    ResultHandler.Exception(ex);
                    CloseWindow();
                }
            };
            worker.RunWorkerCompleted += (s, e) =>
            {
                CloseWindow();
            };

            worker.RunWorkerAsync();
        }

        private void CloseWindow()
        {
            this.Dispatcher.Invoke(() => this.Close());
        }

        bool _shown;

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            if (_shown)
                return;

            _shown = true;

            ShowProgressBar();
        }
    }
}
