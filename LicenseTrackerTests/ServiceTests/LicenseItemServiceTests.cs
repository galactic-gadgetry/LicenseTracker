using LicenseTracker.Models;
using LicenseTracker.Models.DTOs;
using LicenseTracker.Services;
using System.Collections.ObjectModel;

namespace LicenseTrackerTests;

[TestClass]
public class LicenseItemServiceTests
{
    [TestMethod]
    [TestCategory("CreateNewLicenseItem")]
    public void CreateNewLicenseItem_Null_ThrowsArgumentNullException()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => LicenseItemService.CreateNewLicenseItem(null!));
    }


    [TestMethod]
    [TestCategory("IsLicenseItemDtoUniqueInCollection")]
    public void IsLicenseItemDtoUniqueInCollection_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        LicenseItemDTO dto = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => LicenseItemService.IsLicenseItemDtoUniqueInCollection(null!, dto));
    }

    [TestMethod]
    [TestCategory("IsLicenseItemDtoUniqueInCollection")]
    public void IsLicenseItemDtoUniqueInCollection_NullDto_ThrowsArgumentNullException()
    {
        // Arrange
        List<LicenseItem> licenses = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        LicenseItemService.IsLicenseItemDtoUniqueInCollection(
            licenses, null!));
    }


    [TestMethod]
    [TestCategory("IsLicenseItemUniqueInCollection")]
    public void IsLicenseItemUniqueInCollection_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        LicenseItem license = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        LicenseItemService.IsLicenseItemUniqueInCollection(null!, license));
    }

    [TestMethod]
    [TestCategory("IsLicenseItemUniqueInCollection")]
    public void IsLicenseItemUniqueInCollection_NullLicenseItem_ThrowsArgumentNullException()
    {
        // Arrange
        List<LicenseItem> licenses = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => LicenseItemService.IsLicenseItemUniqueInCollection(licenses, null!));
    }


    [TestMethod]
    [TestCategory("IsLicenseItemUniqueInSession")]
    public void IsLicenseItemUniqueInSession_NullSession_ThrowsArgumentNullException()
    {
        // Arrange
        LicenseItem license = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => LicenseItemService.IsLicenseItemUniqueInSession(null!, license));
    }

    [TestMethod]
    [TestCategory("IsLicenseItemUniqueInSession")]
    public void IsLicenseItemUniqueInSession_NullLicenseItem_ThrowsArgumentNullException()
    {
        // Arrange
        Session session = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => LicenseItemService.IsLicenseItemUniqueInSession(session, null!));
    }
}
