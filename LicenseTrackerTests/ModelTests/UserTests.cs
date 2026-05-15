using LicenseTracker.Models;

namespace LicenseTrackerTests;

[TestClass]
public class UserTests
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
        User user1 = new() { Name = name1 };
        User user2 = new() { Name = name2 };

        // Act
        (bool result, string? detail) = user1.ContainsDetailConflict(user2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithUniqueName_ReturnsNull()
    {
        // Arrange
        User user1 = new() { Name = name1 };
        User user2 = new() { Name = name2 };

        // Act
        (bool result, string? detail) = user1.ContainsDetailConflict(user2);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueName_ReturnsTrue()
    {
        // Arrange
        User user1 = new() { Name = name1 };
        User user2 = new() { Name = name1 };

        // Act
        (bool result, string? detail) = user1.ContainsDetailConflict(user2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueName_ReturnsNameMessage()
    {
        // Arrange
        User user1 = new() { Name = name1 };
        User user2 = new() { Name = name1 };

        // Act
        (bool result, string? detail) = user1.ContainsDetailConflict(user2);

        // Assert
        Assert.AreEqual("Name", detail);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueCapitalizationName_ReturnsTrue()
    {
        // Arrange
        User user1 = new() { Name = name1 };
        User user2 = new() { Name = name1Lower };

        // Act
        (bool result, string? detail) = user1.ContainsDetailConflict(user2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithNonUniqueCapitalizationName_ReturnsNameMessage()
    {
        // Arrange
        User user1 = new() { Name = name1 };
        User user2 = new() { Name = name1Lower };

        // Act
        (bool result, string? detail) = user1.ContainsDetailConflict(user2);

        // Assert
        Assert.AreEqual("Name", detail);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithEmptyStringName_ReturnsTrue()
    {
        // Arrange
        User user1 = new() { Name = string.Empty };
        User user2 = new() { Name = string.Empty };

        // Act
        (bool result, string? detail) = user1.ContainsDetailConflict(user2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("ContainsDetailConflict")]
    public void ContainsDetailConflict_WithEmptyStringName_ReturnsNameMessage()
    {
        // Arrange
        User user1 = new() { Name = string.Empty };
        User user2 = new() { Name = string.Empty };

        // Act
        (bool result, string? detail) = user1.ContainsDetailConflict(user2);

        // Assert
        Assert.AreEqual("Name", detail);
    }
}
