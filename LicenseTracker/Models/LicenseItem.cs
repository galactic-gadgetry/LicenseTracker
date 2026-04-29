using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Models
{
    public class LicenseItem
    {

        public enum LicenseStatus
        {
            Active,
            Archived,
            Expired,
            Inactive,
        }



        public DateTime ExpirationDate { get; set; }


        public DateTime IssueDate { get; set; }


        public string LicenseId { get; set; }


        public string Product { get; set; }


        public DateTime PurchaseDate { get; set; }


        public LicenseStatus Status { get; set; }


        public string User { get; set; }


        public string Vendor { get; set; }
    }
}
