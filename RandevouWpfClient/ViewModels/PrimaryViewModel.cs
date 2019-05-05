using RandevouWpfClient.Api;
using RandevouWpfClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RandevouWpfClient.ViewModels
{
    public abstract class PrimaryViewModel: INotifyPropertyChanged
    {
        
        protected readonly ApiQueryProvider queryProvider;
        public PrimaryViewModel()
        {
            queryProvider = ApiQueryProvider.GetInstance();
            RunSynchronizeTask();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnChanged(string propertyName, bool withCommands = true)
        {
            if(PropertyChanged!=null)
            { 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                if(withCommands)
                    CommandManager.InvalidateRequerySuggested();
            }
        }

        protected virtual async void RunSynchronizeTask()
        {
            var cancelationToken = new CancellationToken();
            App.TaskToDisposeTokens.Add(cancelationToken);
            await Task.Run(() =>
            {
                try { 
                while (true)
                {
                    Thread.Sleep(RefreshTime);
                    if (DateTime.Now.TimeOfDay - LastSyncrhonization.TimeOfDay > RefreshTime)
                    {
                        Application.Current.Dispatcher.Invoke(delegate
                        {
                            GetDataAndRefreshUI();
                        });
                        LastSyncrhonization = DateTime.Now;
                    }
                }
                }
                catch(OperationCanceledException) { }
            }, cancelationToken);

        }

        private Task Sync()
        {
            var task = new Task(() =>
            {
                while (true)
                {
                    Thread.Sleep(RefreshTime);
                    if (DateTime.Now.TimeOfDay - LastSyncrhonization.TimeOfDay > RefreshTime)
                    {
                        Application.Current.Dispatcher.Invoke(delegate
                        {
                            GetDataAndRefreshUI();
                        });
                        LastSyncrhonization = DateTime.Now;
                    }
                }
            });
            return task;
        }

        protected DateTime LastSyncrhonization;

        protected virtual TimeSpan RefreshTime => new TimeSpan(0, 0, 30);

        protected virtual void GetDataAndRefreshUI() { }

    }
}
