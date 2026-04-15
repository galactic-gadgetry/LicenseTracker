using LicenseTracker.Services;
using LicenseTracker.Stores;
using LicenseTracker.Utilities;
using LicenseTracker.ViewModels;
using LicenseTracker.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace LicenseTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly NavigationStore _navigationStore;


        private readonly SessionStore _sessionStore;



        public App()
        {
            _navigationStore = StoreFactory.GetNewNaivgationStore();
            _sessionStore = StoreFactory.GetNewSessionStore();
        }



        protected override void OnStartup(StartupEventArgs e)
        {
            INavigate layoutNavService =
                ServiceFactory.CreateNavigationService(
                    "layout", _navigationStore, _sessionStore);
            INavigate dashboardNavService =
                ServiceFactory.CreateNavigationService(
                    "dashboard", _navigationStore, _sessionStore);
            layoutNavService.Navigate();
            dashboardNavService.Navigate();

            MainViewModel mainViewModel = new(_navigationStore);
            MainWindow = new MainView()
            {
                DataContext = mainViewModel,
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
