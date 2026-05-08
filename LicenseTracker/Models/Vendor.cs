using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Models
{
    public class Vendor
    {

        public const string DefaultName = "None";



        public string Name { get; set; }



        public (bool, string?) ContainsDetailConflict(Vendor vendor)
        {
            if (Name.ToLower() == vendor.Name.ToLower())
            {
                return (true, "Name");
            }
            else
            {
                return (false, null);
            }
        }
    }
}
