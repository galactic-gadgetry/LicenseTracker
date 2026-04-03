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


        protected override void OnStartup(StartupEventArgs e)
        {
            MainViewModel mainViewModel = new();
            MainWindow = new MainView()
            {
                DataContext = mainViewModel,
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
