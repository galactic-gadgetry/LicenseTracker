using LicenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Models.DTOs
{
    public class LicenseDTO
    {

        public User Administrator { get; set; }


        public DateTime ExpirationDate { get; set; }


        public DateTime IssueDate { get; set; }


        public string NumberOrID { get; set; }


        public Product Product { get; set; }


        public DateTime PurchaseDate { get; set; }


        public LicenseItem.LicenseStatus Status { get; set; }


        public User User { get; set; }


        public Vendor Vendor { get; set; }
    }
}
