using LicenseTracker.Commands;
using LicenseTracker.Models;
using LicenseTracker.Services;
using LicenseTracker.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace LicenseTracker.ViewModels
{
    internal class DashboardViewModel : ViewModelBase
    {

        private readonly SessionStore _sessionStore;


        // Backing Fields
        private bool isProductSelected = false;
        private LicenseItem? selectedLicenseItem = null;



        public bool IsProductSelected
        {
            get => isProductSelected;
            set
            {
                isProductSelected = value;
                OnPropertyChanged(nameof(IsProductSelected));
            }
        }


        public List<LicenseItem> Licenses { get; set; } = new()
        {
            new LicenseItem { ExpirationDate = DateTime.Now.AddYears(1), IssueDate = DateTime.Now, LicenseId = "1234567890", Product = "Mathematica", Status = LicenseStatus.Active, User = "User Name 1" , PurchaseDate = DateTime.Now, Vendor = "Mathematica" },
            new LicenseItem { ExpirationDate = DateTime.Now.AddYears(2), IssueDate = DateTime.Now, LicenseId = "0987654321", Product = "MATLAB", Status = LicenseStatus.Archived, User = "User Name 2" , PurchaseDate = DateTime.Now, Vendor = "MathWorks" },
        };


        public LicenseItem? SelectedLicenseItem
        {
            get => selectedLicenseItem;
            set
            {
                selectedLicenseItem = value;
                OnSelectedLicenseItemChanged();
                OnPropertyChanged(nameof(SelectedLicenseItem));
            }
        }



        public ICommand FilterUpdateButtonClickedCommand { get; }


        public ICommand NewLicenseButtonClickedCommand { get; }


        public ICommand SaveButtonClickedCommand { get; }



        public DashboardViewModel(SessionStore sessionStore)
        {
            _sessionStore = sessionStore;

            FilterUpdateButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnFilterUpdateButtonClicked));
            NewLicenseButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnNewLicenseButtonClicked));
            SaveButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnSaveButtonClicked));
        }



        private void OnFilterUpdateButtonClicked(object? obj)
        {
            throw new NotImplementedException();
        }


        private void OnNewLicenseButtonClicked(object? obj)
        {
            throw new NotImplementedException();
        }


        private void OnSaveButtonClicked(object? obj)
        {
            FileService.SaveSession(_sessionStore.CurrentSession);
        }


        private void OnSelectedLicenseItemChanged()
        {
            IsProductSelected = SelectedLicenseItem != null;
        }
    }
}
