using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LicenseTracker.ViewModels
{
    internal class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
