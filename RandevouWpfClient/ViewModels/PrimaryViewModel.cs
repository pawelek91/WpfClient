using RandevouWpfClient.Api;
using RandevouWpfClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevouWpfClient.ViewModels
{
    public class PrimaryViewModel: INotifyPropertyChanged
    {
        protected readonly ApiQueryProvider queryProvider;
        public PrimaryViewModel()
        {
            queryProvider = new ApiQueryProvider();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnChanged(string propertyName)
        {
            if(PropertyChanged!=null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
