using LicenseTracker.Models;
using LicenseTracker.Models.DTOs;
using LicenseTracker.Services;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;


namespace LicenseTrackerTests;

[TestClass]
public class VendorServiceTests
{
    // Constants
    private const string id1 = "ABCDE";
    private const string id2 = "FGHIJ";


    [TestMethod]
    [TestCategory("CreateNewVendor")]
    public void CreateNewVendor_NullDto_ThrowsArgumentNullException()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => VendorService.CreateNewVendor(null!));
    }


    [TestMethod]
    [TestCategory("IsVendorDtoValid")]
    public void IsVendorDtoValid_NullDto_ThrowsArgumentNullException()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => VendorService.IsVendorDtoValid(null!));
    }

    [TestMethod]
    [TestCategory("IsVendorDtoValid")]
    public void IsVendorDtoValid_ValidNameProperty_ReturnsTrue()
    {
        // Arrange
        VendorDTO dto = new() { Name = "Valid" };

        // Act
        (bool result, string? detail) = VendorService.IsVendorDtoValid(dto);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("IsVendorDtoValid")]
    public void IsVendorDtoValid_ValidNameProperty_ReturnsNull()
    {
        // Arrange
        VendorDTO dto = new() { Name = "Valid" };

        // Act
        (bool result, string? detail) = VendorService.IsVendorDtoValid(dto);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("IsVendorDtoValid")]
    public void IsVendorDtoValid_EmptyStringNameProperty_ReturnsFalse()
    {
        // Arrange
        VendorDTO dto = new() { Name = string.Empty };

        // Act
        (bool result, string? detail) = VendorService.IsVendorDtoValid(dto);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("IsVendorDtoValid")]
    public void IsVendorDtoValid_EmptyStringNameProperty_ReturnsEmptyStringNamePropertyDetail()
    {
        // Arrange
        VendorDTO dto = new() { Name = string.Empty };

        // Act
        (bool result, string? detail) = VendorService.IsVendorDtoValid(dto);

        // Assert
        Assert.AreEqual(VendorService.InvalidNamePropertyEmptyStringMessage, detail);
    }


    [TestMethod]
    [TestCategory("IsVendorUniqueInCollection")]
    public void IsVendorUniqueInCollection_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        Vendor vendor = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => VendorService.IsVendorUniqueInCollection(null!, vendor));
    }

    [TestMethod]
    [TestCategory("IsVendorUniqueInCollection")]
    public void IsVendorUniqueInCollection_NullVendor_ThrowsArgumentNullException()
    {
        // Arrange
        List<Vendor> vendors = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => VendorService.IsVendorUniqueInCollection(vendors, null!));
    }

    [TestMethod]
    [TestCategory("IsVendorUniqueInCollection")]
    public void IsVendorUniqueInCollection_UniqueVendor_ReturnsTrue()
    {
        // Arrange
        Vendor vendor1 = new() { Name = id1 };
        Vendor vendor2 = new() { Name = id2 };
        List<Vendor> vendors = new();
        vendors.Add(vendor1);

        // Act
        (bool result, string? detail) = VendorService.IsVendorUniqueInCollection(vendors, vendor2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("IsVendorUniqueInCollection")]
    public void IsVendorUniqueInCollection_UniqueVendor_ReturnsNull()
    {
        // Arrange
        Vendor vendor1 = new() { Name = id1 };
        Vendor vendor2 = new() { Name = id2 };
        List<Vendor> vendors = new();
        vendors.Add(vendor1);

        // Act
        (bool result, string? detail) = VendorService.IsVendorUniqueInCollection(vendors, vendor2);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("IsVendorUniqueInCollection")]
    public void IsVendorUniqueInCollection_NonUniqueVendor_ReturnsFalse()
    {
        // Arrange
        Vendor vendor1 = new() { Name = id1 };
        Vendor vendor2 = new() { Name = id1 };
        List<Vendor> vendors = new();
        vendors.Add(vendor1);

        // Act
        (bool result, string? detail) = VendorService.IsVendorUniqueInCollection(vendors, vendor2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("IsVendorUniqueInCollection")]
    public void IsVendorUniqueInCollection_NonUniqueVendor_ReturnsNameString()
    {
        // Arrange
        Vendor vendor1 = new() { Name = id1 };
        Vendor vendor2 = new() { Name = id1 };
        List<Vendor> vendors = new();
        vendors.Add(vendor1);

        // Act
        (bool result, string? detail) = VendorService.IsVendorUniqueInCollection(vendors, vendor2);

        // Assert
        Assert.AreEqual("Name", detail);
    }


    [TestMethod]
    [TestCategory("IsVendorUniqueInSession")]
    public void IsVendorUniqueInSession_NullSession_ThrowsArgumentNullException()
    {
        // Arrange
        Vendor vendor = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => VendorService.IsVendorUniqueInSession(null!, vendor));
    }

    [TestMethod]
    [TestCategory("IsVendorUniqueInSession")]
    public void IsVendorUniqueInSession_NullVendor_ThrowsArgumentNullException()
    {
        // Arrange
        Session session = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => VendorService.IsVendorUniqueInSession(session, null!));
    }

    [TestMethod]
    [TestCategory("IsVendorUniqueInSession")]
    public void IsVendorUniqueInSession_UniqueVendor_ReturnsTrue()
    {
        // Arrange
        Vendor vendor1 = new() { Name = id1 };
        Vendor vendor2 = new() { Name = id2 };
        Session session = new();
        session.Vendors.Add(vendor1);

        // Act
        (bool result, string? detail) = VendorService.IsVendorUniqueInSession(session, vendor2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("IsVendorUniqueInSession")]
    public void IsVendorUniqueInSession_UniqueVendor_ReturnsNull()
    {
        // Arrange
        Vendor vendor1 = new() { Name = id1 };
        Vendor vendor2 = new() { Name = id2 };
        Session session = new();
        session.Vendors.Add(vendor1);

        // Act
        (bool result, string? detail) = VendorService.IsVendorUniqueInSession(session, vendor2);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("IsVendorUniqueInSession")]
    public void IsVendorUniqueInSession_NonUniqueVendor_ReturnsFalse()
    {
        // Arrange
        Vendor vendor1 = new() { Name = id1 };
        Vendor vendor2 = new() { Name = id1 };
        Session session = new();
        session.Vendors.Add(vendor1);

        // Act
        (bool result, string? detail) = VendorService.IsVendorUniqueInSession(session, vendor2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("IsVendorUniqueInSession")]
    public void IsVendorUniqueInSession_NonUniqueVendor_ReturnsNameString()
    {
        // Arrange
        Vendor vendor1 = new() { Name = id1 };
        Vendor vendor2 = new() { Name = id1 };
        Session session = new();
        session.Vendors.Add(vendor1);

        // Act
        (bool result, string? detail) = VendorService.IsVendorUniqueInSession(session, vendor2);

        // Assert
        Assert.AreEqual("Name", detail);
    }
}
