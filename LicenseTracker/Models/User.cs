using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Models
{
    public class User
    {

        public string Name { get; set; } = String.Empty;



        public (bool, string?) ContainsDetailConflict(User user)
        {
            if (Name.ToLower() == user.Name.ToLower())
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
