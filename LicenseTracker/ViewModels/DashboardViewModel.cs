using LicenseTracker.Commands;
using LicenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LicenseTracker.ViewModels
{
    internal class DashboardViewModel : ViewModelBase
    {


        public List<LicenseItem> Licenses { get; set; } = new()
        {
            new LicenseItem { ExpirationDate = DateTime.Now.AddYears(1), IssueDate = DateTime.Now, LicenseId = "1234567890", Product = "Mathematica", Status = LicenseStatus.Active, User = "User Name 1" },
            new LicenseItem { ExpirationDate = DateTime.Now.AddYears(2), IssueDate = DateTime.Now, LicenseId = "0987654321", Product = "MATLAB", Status = LicenseStatus.Archived, User = "User Name 2" }
        };



        public ICommand NewLicenseButtonClickedCommand { get; }



        public DashboardViewModel()
        {
            NewLicenseButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnNewLicenseButtonClicked));
        }



        private void OnNewLicenseButtonClicked(object? obj)
        {
            throw new NotImplementedException();
        }
    }
}
