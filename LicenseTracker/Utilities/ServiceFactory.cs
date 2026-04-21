using LicenseTracker.Services;
using LicenseTracker.Stores;
using LicenseTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Utilities
{
    internal static class ServiceFactory
    {

        public static INavigate CreateNavigationService(string type,
            NavigationStore navigationStore, SessionStore sessionStore)
        {
            switch (type.ToLower())
            {
                case "dashboard":
                    return new LayoutNavigationService<DashboardViewModel>(
                        navigationStore,
                        () => new DashboardViewModel(sessionStore));
                case "layout":
                    return new NavigationService<LayoutViewModel>(
                        navigationStore,
                        () => new LayoutViewModel(navigationStore));
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }
    }
}
