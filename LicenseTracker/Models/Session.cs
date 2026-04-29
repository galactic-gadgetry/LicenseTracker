using LicenseTracker.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace LicenseTracker.Models
{
    public class Session : INotifyPropertyChanged
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


        public ObservableCollection<Product> Products { get; set; } = new()
        {
            new Product() { Name = "None" },
        };


        public ObservableCollection<User> Users { get; set; } = new()
        {
            new User() { Name = "Unassigned" },
        };


        public ObservableCollection<Vendor> Vendors { get; set; } = new()
        {
            new Vendor() { Name = "Unassigned" },
        };



        public event PropertyChangedEventHandler? PropertyChanged;


        public string SaveFilePath { get; set; }



        public Session()
        {
            Id = Guid.NewGuid();
            SaveFilePath = Path.Combine(
                FileService.SaveFileDirectory,
                Id.ToString() + ".json");

            Licenses.CollectionChanged += OnLicensesChanged;
            Products.CollectionChanged += OnProductsChanged;
            Users.CollectionChanged += OnUsersChanged;
            Vendors.CollectionChanged += OnVendorsChanged;
        }

        

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }


        private void OnLicensesChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            HasUnsavedChanges = true;
        }


        private void OnUsersChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            HasUnsavedChanges = true;
        }


        private void OnProductsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            HasUnsavedChanges = true;
        }


        private void OnVendorsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            HasUnsavedChanges = true;
        }        
    }
}
