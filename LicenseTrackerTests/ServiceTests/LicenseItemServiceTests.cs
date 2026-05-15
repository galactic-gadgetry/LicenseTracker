using LicenseTracker.Models;
using LicenseTracker.Models.DTOs;
using LicenseTracker.Services;
using System.Collections.ObjectModel;

namespace LicenseTrackerTests;

[TestClass]
public class LicenseItemServiceTests
{
    // Constants
    private const string id1 = "ABCDE";
    private const string id2 = "FGHIJ";


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
    [TestCategory("IsLicenseItemDtoUniqueInCollection")]
    public void IsLicenseItemDtoUniqueInCollection_UniqueDto_ReturnTrue()
    {
        // Arrange
        LicenseItem license = new() { LicenseId = id1 };
        LicenseItemDTO dto = new() { LicenseId = id2 };
        List<LicenseItem> collection = new();
        collection.Add(license);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemDtoUniqueInCollection(collection, dto);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("IsLicenseItemDtoUniqueInCollection")]
    public void IsLicenseItemDtoUniqueInCollection_UniqueDto_ReturnNull()
    {
        // Arrange
        LicenseItem license = new() { LicenseId = id1 };
        LicenseItemDTO dto = new() { LicenseId = id2 };
        List<LicenseItem> collection = new();
        collection.Add(license);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemDtoUniqueInCollection(collection, dto);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("IsLicenseItemDtoUniqueInCollection")]
    public void IsLicenseItemDtoUniqueInCollection_NonUniqueDto_ReturnFalse()
    {
        // Arrange
        LicenseItem license = new() { LicenseId = id1 };
        LicenseItemDTO dto = new() { LicenseId = id1 };
        List<LicenseItem> collection = new();
        collection.Add(license);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemDtoUniqueInCollection(collection, dto);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("IsLicenseItemDtoUniqueInCollection")]
    public void IsLicenseItemDtoUniqueInCollection_NonUniqueDto_ReturnIDString()
    {
        // Arrange
        LicenseItem license = new() { LicenseId = id1 };
        LicenseItemDTO dto = new() { LicenseId = id1 };
        List<LicenseItem> collection = new();
        collection.Add(license);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemDtoUniqueInCollection(collection, dto);

        // Assert
        Assert.AreEqual("ID", detail);
    }


    [TestMethod]
    [TestCategory("IsLicenseItemDtoUniqueInSession")]
    public void IsLicenseItemDtoUniqueInSession_NullSession_ThrowsArgumentNullException()
    {
        // Arrange
        LicenseItemDTO dto = new();
        
        // Assert
        Assert.Throws<ArgumentNullException>(() => LicenseItemService.IsLicenseItemDtoUniqueInSession(null!, dto));
    }

    [TestMethod]
    [TestCategory("IsLicenseItemDtoUniqueInSession")]
    public void IsLicenseItemDtoUniqueInSession_NullDto_ThrowsArgumentNullException()
    {
        // Arrange
        Session session = SessionService.GetNewSession();

        // Assert
        Assert.Throws<ArgumentNullException>(() => LicenseItemService.IsLicenseItemDtoUniqueInSession(session, null!));
    }

    [TestMethod]
    [TestCategory("IsLicenseItemDtoUniqueInSession")]
    public void IsLicenseItemDtoUniqueInSession_UniqueDto_ReturnsTrue()
    {
        // Arrange
        LicenseItem license = new() { LicenseId = id1 };
        LicenseItemDTO dto = new() { LicenseId = id2 };
        Session session = SessionService.GetNewSession();
        session.Licenses.Add(license);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemDtoUniqueInSession(session, dto);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("IsLicenseItemDtoUniqueInSession")]
    public void IsLicenseItemDtoUniqueInSession_UniqueDto_ReturnsNull()
    {
        // Arrange
        LicenseItem license = new() { LicenseId = id1 };
        LicenseItemDTO dto = new() { LicenseId = id2 };
        Session session = SessionService.GetNewSession();
        session.Licenses.Add(license);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemDtoUniqueInSession(session, dto);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("IsLicenseItemDtoUniqueInSession")]
    public void IsLicenseItemDtoUniqueInSession_NonUniqueDto_ReturnsFalse()
    {
        // Arrange
        LicenseItem license = new() { LicenseId = id1 };
        LicenseItemDTO dto = new() { LicenseId = id1 };
        Session session = SessionService.GetNewSession();
        session.Licenses.Add(license);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemDtoUniqueInSession(session, dto);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("IsLicenseItemDtoUniqueInSession")]
    public void IsLicenseItemDtoUniqueInSession_NonUniqueDto_ReturnsIDString()
    {
        // Arrange
        LicenseItem license = new() { LicenseId = id1 };
        LicenseItemDTO dto = new() { LicenseId = id1 };
        Session session = SessionService.GetNewSession();
        session.Licenses.Add(license);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemDtoUniqueInSession(session, dto);

        // Assert
        Assert.AreEqual("ID", detail);
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
    [TestCategory("IsLicenseItemUniqueInCollection")]
    public void IsLicenseItemUniqueInCollection_UniqueLicenseItem_ReturnsTrue()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id2 };
        List<LicenseItem> collection = new();
        collection.Add(license1);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemUniqueInCollection(collection, license2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("IsLicenseItemUniqueInCollection")]
    public void IsLicenseItemUniqueInCollection_UniqueLicenseItem_ReturnsNull()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id2 };
        List<LicenseItem> collection = new();
        collection.Add(license1);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemUniqueInCollection(collection, license2);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("IsLicenseItemUniqueInCollection")]
    public void IsLicenseItemUniqueInCollection_NonUniqueLicenseItem_ReturnsFalse()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id1 };
        List<LicenseItem> collection = new();
        collection.Add(license1);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemUniqueInCollection(collection, license2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("IsLicenseItemUniqueInCollection")]
    public void IsLicenseItemUniqueInCollection_NonUniqueLicenseItem_ReturnsIDString()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id1 };
        List<LicenseItem> collection = new();
        collection.Add(license1);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemUniqueInCollection(collection, license2);

        // Assert
        Assert.AreEqual("ID", detail);
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

    [TestMethod]
    [TestCategory("IsLicenseItemUniqueInSession")]
    public void IsLicenseItemUniqueInSession_UniqueLicenseItem_ReturnsTrue()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id2 };
        Session session = SessionService.GetNewSession();
        session.Licenses.Add(license1);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemUniqueInSession(session, license2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("IsLicenseItemUniqueInSession")]
    public void IsLicenseItemUniqueInSession_UniqueLicenseItem_ReturnsNull()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id2 };
        Session session = SessionService.GetNewSession();
        session.Licenses.Add(license1);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemUniqueInSession(session, license2);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("IsLicenseItemUniqueInSession")]
    public void IsLicenseItemUniqueInSession_NonUniqueLicenseItem_ReturnsFalse()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id1 };
        Session session = SessionService.GetNewSession();
        session.Licenses.Add(license1);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemUniqueInSession(session, license2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("IsLicenseItemUniqueInSession")]
    public void IsLicenseItemUniqueInSession_NonUniqueLicenseItem_ReturnsIDString()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id1 };
        Session session = SessionService.GetNewSession();
        session.Licenses.Add(license1);

        // Act
        (bool result, string? detail) = LicenseItemService.IsLicenseItemUniqueInSession(session, license2);

        // Assert
        Assert.AreEqual("ID", detail);
    }
}
