using LicenseTracker.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Models.DTOs
{
    public class LicenseItemDTO
    {

        public User Administrator { get; set; } = UserService.GetDefaultUser();


        public DateTime? ExpirationDate { get; set; }


        public DateTime? IssueDate { get; set; }


        public string LicenseId { get; set; } = string.Empty;


        public Product Product { get; set; } = ProductService.GetDefaultProduct();


        public DateTime? PurchaseDate { get; set; }


        public LicenseItem.LicenseStatus Status { get; set; }


        public User User { get; set; } = UserService.GetDefaultUser();


        public Vendor Vendor { get; set; } = VendorService.GetDefaultVendor();
    }
}
