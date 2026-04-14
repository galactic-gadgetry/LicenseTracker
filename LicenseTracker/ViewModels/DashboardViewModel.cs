using LicenseTracker.Commands;
using LicenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace LicenseTracker.ViewModels
{
    internal class DashboardViewModel : ViewModelBase
    {

        // Backing Fields
        private LicenseItem? selectedLicenseItem = null;



        public List<LicenseItem> Licenses { get; set; } = new()
        {
            new LicenseItem { ExpirationDate = DateTime.Now.AddYears(1), IssueDate = DateTime.Now, LicenseId = "1234567890", Product = "Mathematica", Status = LicenseStatus.Active, User = "User Name 1" },
            new LicenseItem { ExpirationDate = DateTime.Now.AddYears(2), IssueDate = DateTime.Now, LicenseId = "0987654321", Product = "MATLAB", Status = LicenseStatus.Archived, User = "User Name 2" }
        };


        public LicenseItem SelectedLicenseItem
        {
            get => selectedLicenseItem;
            set
            {
                selectedLicenseItem = value;
                OnSelectedLicenseItemChanged();
            }
        }



        public ICommand FilterUpdateButtonClickedCommand { get; }


        public ICommand NewLicenseButtonClickedCommand { get; }



        public DashboardViewModel()
        {
            FilterUpdateButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnFilterUpdateButtonClicked));
            NewLicenseButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnNewLicenseButtonClicked));
        }



        private void OnFilterUpdateButtonClicked(object? obj)
        {
            throw new NotImplementedException();
        }


        private void OnNewLicenseButtonClicked(object? obj)
        {
            throw new NotImplementedException();
        }


        private void OnSelectedLicenseItemChanged()
        {
            throw new NotImplementedException();
        }
    }
}
