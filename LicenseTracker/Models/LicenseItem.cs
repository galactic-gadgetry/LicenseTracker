using LicenseTracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LicenseTracker.Models
{
    public class LicenseItem: INotifyPropertyChanged
    {

        public enum LicenseStatus
        {
            Active,
            Archived,
            Expired,
            Inactive,
        }



        // Backing Fields
        private User administrator = UserService.GetDefaultUser();
        private string licenseId = string.Empty;
        private DateTime? expirationDate;
        private DateTime? issueDate;
        private Product product = ProductService.GetDefaultProduct();
        private DateTime? purchaseDate;
        private LicenseStatus status = LicenseStatus.Active;
        private User user = UserService.GetDefaultUser();
        private Vendor vendor = VendorService.GetDefaultVendor();



        public User Administrator
        {
            get => administrator;
            set
            {
                administrator = value;
                OnPropertyChanged(nameof(Administrator));
            }
        }


        public DateTime? ExpirationDate
        {
            get => expirationDate;
            set
            {
                expirationDate = value;
                OnPropertyChanged(nameof(ExpirationDate));
            }
        }


        public DateTime? IssueDate
        {
            get => issueDate;
            set
            {
                issueDate = value;
                OnPropertyChanged(nameof(IssueDate));
            }
        }


        public string LicenseId
        {
            get => licenseId;
            set
            {
                licenseId = value;
                OnPropertyChanged(nameof(LicenseId));
            }
        }


        public Product Product
        {
            get => product;
            set
            {
                product = value;
                OnPropertyChanged(nameof(Product));
            }
        }


        public DateTime? PurchaseDate
        {
            get => purchaseDate;
            set
            {
                purchaseDate = value;
                OnPropertyChanged(nameof(PurchaseDate));
            }
        }


        public LicenseStatus Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }


        public User User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }


        public Vendor Vendor
        {
            get => vendor;
            set
            {
                vendor = value;
                OnPropertyChanged(nameof(Vendor));
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;



        public (bool, string?) ContainsDetailConflict(LicenseItem license)
        {
            if (LicenseId.ToLower() == license.LicenseId.ToLower())
            {
                return (true, "ID");
            }
            else
            {
                return (false, null);
            }
        }


        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
