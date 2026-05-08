using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Models
{
    public class Product
    {

        public const string DefaultName = "None";



        public string Name { get; set; } = string.Empty;



        public (bool, string?) ContainsDetailConflict(Product product)
        {
            if (Name.ToLower() == product.Name.ToLower())
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
