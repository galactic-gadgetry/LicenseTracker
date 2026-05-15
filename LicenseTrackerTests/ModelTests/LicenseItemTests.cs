using LicenseTracker.Models;

namespace LicenseTrackerTests;

[TestClass]
public class LicenseItemTests
{
    // Constants
    private const string id1 = "ABCDEFG";
    private const string id1Lower = "abcdefg";
    private const string id2 = "HIJKLMN";
    private const string id2Lower = "hijklmn";



    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithUniqueLicenseId_ReturnsFalse()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id2 };

        // Act
        (bool result, string? detail) = license1.ContainsDetailConflict(license2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithUniqueLicenseId_ReturnsNull()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id2 };

        // Act
        (bool result, string? detail) = license1.ContainsDetailConflict(license2);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueLicenseId_ReturnsTrue()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id1 };

        // Act
        (bool result, string? detail) = license1.ContainsDetailConflict(license2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueLicenseId_ReturnsIDMessage()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id1 };

        // Act
        (bool result, string? detail) = license1.ContainsDetailConflict(license2);

        // Assert
        Assert.AreEqual("ID", detail);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueCapitalizationLicenseId_ReturnsTrue()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id1Lower };

        // Act
        (bool result, string? detail) = license1.ContainsDetailConflict(license2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueCapitalizationLicenseId_ReturnsIDMessage()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id1Lower };

        // Act
        (bool result, string? detail) = license1.ContainsDetailConflict(license2);

        // Assert
        Assert.AreEqual("ID", detail);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithEmptyStringLicenseId_ReturnsTrue()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = string.Empty };
        LicenseItem license2 = new() { LicenseId = string.Empty };

        // Act
        (bool result, string? detail) = license1.ContainsDetailConflict(license2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithEmptyStringLicenseId_ReturnsIDMessage()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = string.Empty };
        LicenseItem license2 = new() { LicenseId = string.Empty };

        // Act
        (bool result, string? detail) = license1.ContainsDetailConflict(license2);

        // Assert
        Assert.AreEqual("ID", detail);
    }
}
