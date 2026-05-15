using LicenseTracker.Services;
using LicenseTracker.Stores;
using LicenseTracker.Utilities;
using LicenseTracker.ViewModels;
using System.Windows.Navigation;

namespace LicenseTrackerTests;

[TestClass]
public class ServiceFactoryTests
{
    [TestMethod]
    [TestCategory("CreateNavigationService")]
    public void CreateNavigationService_DashboardType_ReturnsDashboardViewModelTypeLayoutNavigationService()
    {
        // Arrange
        string type = "dashboard";
        NavigationStore navigationStore = new();
        SessionStore sessionStore = new();
        INavigate layoutNavigationService;

        // Act
        layoutNavigationService = ServiceFactory.CreateNavigationService(type, navigationStore, sessionStore);

        // Assert
        Assert.IsInstanceOfType<LayoutNavigationService<DashboardViewModel>>(layoutNavigationService);
    }

    [TestMethod]
    [TestCategory("CreateNavigationService")]
    public void CreateNavigationService_LayoutType_ReturnsLayoutViewModelTypeNavigationService()
    {
        // Arrange
        string type = "layout";
        NavigationStore navigationStore = new();
        SessionStore sessionStore = new();
        INavigate navigationService;

        // Act
        navigationService = ServiceFactory.CreateNavigationService(type, navigationStore, sessionStore);

        // Assert
        Assert.IsInstanceOfType<NavigationService<LayoutViewModel>>(navigationService);
    }

    [TestMethod]
    [TestCategory("CreateNavigationService")]
    public void CreateNavigationService_CapitalizedDashboardType_ReturnsDashboardViewModelTypeLayoutNavigationService()
    {
        // Arrange
        string type = "DASHBOARD";
        NavigationStore navigationStore = new();
        SessionStore sessionStore = new();
        INavigate layoutNavigationService;

        // Act
        layoutNavigationService = ServiceFactory.CreateNavigationService(type, navigationStore, sessionStore);

        // Assert
        Assert.IsInstanceOfType<LayoutNavigationService<DashboardViewModel>>(layoutNavigationService);
    }

    [TestMethod]
    [TestCategory("CreateNavigationService")]
    public void CreateNavigationService_EmptyStringType_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        string type = string.Empty;
        NavigationStore navigationStore = new();
        SessionStore sessionStore = new();

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => ServiceFactory.CreateNavigationService(type, navigationStore, sessionStore));
    }

    [TestMethod]
    [TestCategory("CreateNavigationService")]
    public void CreateNavigationService_InvalidType_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        string type = "InvalidType";
        NavigationStore navigationStore = new();
        SessionStore sessionStore = new();

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => ServiceFactory.CreateNavigationService(type, navigationStore, sessionStore));
    }
}
