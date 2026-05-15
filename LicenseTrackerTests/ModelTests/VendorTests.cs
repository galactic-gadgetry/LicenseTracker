using LicenseTracker.Models;

namespace LicenseTrackerTests;

[TestClass]
public class VendorTests
{
    // Constants
    private const string name1 = "ABCDEFG";
    private const string name1Lower = "abcdefg";
    private const string name2 = "HIJKLMN";
    private const string name2Lower = "hijklmn";



    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithUniqueName_ReturnsFalse()
    {
        // Arrange
        Vendor vendor1 = new() { Name = name1 };
        Vendor vendor2 = new() { Name = name2 };

        // Act
        (bool result, string? detail) = vendor1.ContainsDetailConflict(vendor2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithUniqueName_ReturnsNull()
    {
        // Arrange
        Vendor vendor1 = new() { Name = name1 };
        Vendor vendor2 = new() { Name = name2 };

        // Act
        (bool result, string? detail) = vendor1.ContainsDetailConflict(vendor2);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueName_ReturnsTrue()
    {
        // Arrange
        Vendor vendor1 = new() { Name = name1 };
        Vendor vendor2 = new() { Name = name1 };

        // Act
        (bool result, string? detail) = vendor1.ContainsDetailConflict(vendor2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueName_ReturnsNameMessage()
    {
        // Arrange
        Vendor vendor1 = new() { Name = name1 };
        Vendor vendor2 = new() { Name = name1 };

        // Act
        (bool result, string? detail) = vendor1.ContainsDetailConflict(vendor2);

        // Assert
        Assert.AreEqual("Name", detail);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueCapitalizationName_ReturnsTrue()
    {
        // Arrange
        Vendor vendor1 = new() { Name = name1 };
        Vendor vendor2 = new() { Name = name1Lower };

        // Act
        (bool result, string? detail) = vendor1.ContainsDetailConflict(vendor2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueCapitalizationName_ReturnsNameMessage()
    {
        // Arrange
        Vendor vendor1 = new() { Name = name1 };
        Vendor vendor2 = new() { Name = name1Lower };

        // Act
        (bool result, string? detail) = vendor1.ContainsDetailConflict(vendor2);

        // Assert
        Assert.AreEqual("Name", detail);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithEmptyStringName_ReturnsTrue()
    {
        // Arrange
        Vendor vendor1 = new() { Name = string.Empty };
        Vendor vendor2 = new() { Name = string.Empty };

        // Act
        (bool result, string? detail) = vendor1.ContainsDetailConflict(vendor2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithEmptyStringName_ReturnsNameMessage()
    {
        // Arrange
        Vendor vendor1 = new() { Name = string.Empty };
        Vendor vendor2 = new() { Name = string.Empty };

        // Act
        (bool result, string? detail) = vendor1.ContainsDetailConflict(vendor2);

        // Assert
        Assert.AreEqual("Name", detail);
    }
}
