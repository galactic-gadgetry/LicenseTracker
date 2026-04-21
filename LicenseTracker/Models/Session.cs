using LicenseTracker.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace LicenseTracker.Models
{
    class Session : INotifyPropertyChanged
    {

        // Backing Fields
        private bool hasUnsavedChanges = false;



        public bool HasUnsavedChanges
        {
            get => hasUnsavedChanges;
            set
            {
                hasUnsavedChanges = value;
                OnPropertyChanged(nameof(HasUnsavedChanges));
            }
        }


        public Guid Id { get; init; }


        public ObservableCollection<LicenseItem> Licenses { get; set; } = new();



        public event PropertyChangedEventHandler? PropertyChanged;


        public string SaveFilePath { get; set; }



        public Session()
        {
            Id = Guid.NewGuid();
            SaveFilePath = Path.Combine(
                FileService.SaveFileDirectory,
                Id.ToString() + ".json");
        }



        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
