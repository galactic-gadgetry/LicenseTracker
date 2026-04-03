using LicenseTracker.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Utilities
{
    internal static class StoreFactory
    {

        public static NavigationStore GetNewNaivgationStore()
        {
            return new NavigationStore(); 
        }
    }
}
