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
            GetDataAndRefreshUI();
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
            await Task.Run(() =>
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
        }

        protected DateTime LastSyncrhonization;

        protected virtual TimeSpan RefreshTime => new TimeSpan(0, 0, 3);

        protected virtual void GetDataAndRefreshUI() { }

    }
}
