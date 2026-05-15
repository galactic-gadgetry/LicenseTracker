using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LicenseTracker.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        public event EventHandler<string>? InfoUpdated;

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnInfoUpdated(string info)
        {
            InfoUpdated?.Invoke(this, info);
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
