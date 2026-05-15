using LicenseTracker.Models;

namespace LicenseTrackerTests;

[TestClass]
public class ProductTests
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
        Product product1 = new() { Name = name1 };
        Product product2 = new() { Name = name2 };

        // Act
        (bool result, string? detail) = product1.ContainsDetailConflict(product2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithUniqueName_ReturnsNull()
    {
        // Arrange
        Product product1 = new() { Name = name1 };
        Product product2 = new() { Name = name2 };

        // Act
        (bool result, string? detail) = product1.ContainsDetailConflict(product2);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueName_ReturnsTrue()
    {
        // Arrange
        Product product1 = new() { Name = name1 };
        Product product2 = new() { Name = name1 };

        // Act
        (bool result, string? detail) = product1.ContainsDetailConflict(product2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueName_ReturnsNameMessage()
    {
        // Arrange
        Product product1 = new() { Name = name1 };
        Product product2 = new() { Name = name1 };

        // Act
        (bool result, string? detail) = product1.ContainsDetailConflict(product2);

        // Assert
        Assert.AreEqual("Name", detail);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueCapitalizationName_ReturnsTrue()
    {
        // Arrange
        Product product1 = new() { Name = name1 };
        Product product2 = new() { Name = name1Lower };

        // Act
        (bool result, string? detail) = product1.ContainsDetailConflict(product2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueCapitalizationName_ReturnsNameMessage()
    {
        // Arrange
        Product product1 = new() { Name = name1 };
        Product product2 = new() { Name = name1Lower };

        // Act
        (bool result, string? detail) = product1.ContainsDetailConflict(product2);

        // Assert
        Assert.AreEqual("Name", detail);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithEmptyStringName_ReturnsTrue()
    {
        // Arrange
        Product product1 = new() { Name = string.Empty };
        Product product2 = new() { Name = string.Empty };

        // Act
        (bool result, string? detail) = product1.ContainsDetailConflict(product2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithEmptyStringName_ReturnsNameMessage()
    {
        // Arrange
        Product product1 = new() { Name = string.Empty };
        Product product2 = new() { Name = string.Empty };

        // Act
        (bool result, string? detail) = product1.ContainsDetailConflict(product2);

        // Assert
        Assert.AreEqual("Name", detail);
    }
}
