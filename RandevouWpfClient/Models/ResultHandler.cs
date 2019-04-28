using RandevouWpfClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RandevouWpfClient.Models
{
    public static class ResultHandler
    {
        public static void Exception(Exception ex, string message ="")
        {
            string content = string.Empty;
            if(message != null)
            {
                content = message + Environment.NewLine;
            }
            content += ex.Message;
            MessageBox.Show(content);
        }

        public static void Message(String message)
        {
            MessageBox.Show(message);
        }

        public static void ProgressAction(Action act, string progressText)
        {
            var window = new OperationProgressWindow(act, progressText);
            window.Show();
        }
        public static void CloseWindowOfWhichThereIsOnlyOne<T>()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            foreach (Window w in Application.Current.Windows)
            {
                if (w.GetType().Assembly == currentAssembly && w is T)
                {
                    w.Close();
                    break;
                }
            }
        }

        public static void KillProgressBarWindow()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            foreach (Window w in Application.Current.Windows)
            {
                if (w.GetType().Assembly == currentAssembly && w is OperationProgressWindow)
                {
                    w.Close();
                    break;
                }
            }
        }

        public static void ShowMainWindowDispatcher()
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                var window = new MainWindow();
                CloseWindowOfWhichThereIsOnlyOne<Views.StartWindow>();
                KillProgressBarWindow();
                window.ShowDialog();
            });
        }
    }
}
