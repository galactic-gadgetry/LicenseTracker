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



        public User? Administrator { get; set; }


        public DateTime? ExpirationDate { get; set; }


        public DateTime? IssueDate { get; set; }


        public string LicenseId { get; set; } = string.Empty;


        public Product? Product { get; set; }


        public DateTime? PurchaseDate { get; set; }


        public LicenseStatus Status { get; set; }


        public User? User { get; set; }


        public Vendor? Vendor { get; set; }



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
    }
}
