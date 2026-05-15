using LicenseTracker.Stores;
using LicenseTracker.Utilities;


namespace LicenseTrackerTests;

[TestClass]
public class StoreFactoryTests
{
    [TestMethod]
    [TestCategory("GetNewNavigationStore")]
    public void GetNewNavigationStore_Success_ReturnsNavigationStore()
    {
        // Arrange
        NavigationStore store;

        // Act
        store = StoreFactory.GetNewNaivgationStore();

        // Assert
        Assert.IsInstanceOfType<NavigationStore>(store);
    }



    [TestMethod]
    [TestCategory("GetNewSessionStore")]
    public void GetNewSessionStore_Success_ReturnsSessionStore()
    {
        // Arrange
        SessionStore store;

        // Act
        store = StoreFactory.GetNewSessionStore();

        // Assert
        Assert.IsInstanceOfType<SessionStore>(store);
    }
}
