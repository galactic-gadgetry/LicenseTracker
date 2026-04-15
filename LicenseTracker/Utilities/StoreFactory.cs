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


        public static SessionStore GetNewSessionStore()
        {
            return new SessionStore();
        }
    }
}
