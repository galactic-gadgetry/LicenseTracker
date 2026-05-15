using LicenseTracker.Models;
using LicenseTracker.Services;


namespace LicenseTrackerTests;

[TestClass]
public class UserServiceTests
{
    // Constants
    private const string id1 = "ABCDE";
    private const string id2 = "FGHIJ";


    [TestMethod]
    [TestCategory("CreateNewUser")]
    public void CreateNewUser_NullDto_ThrowsArgumentNullException()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => UserService.CreateNewUser(null!));
    }


    [TestMethod]
    [TestCategory("IsUserUniqueInCollection")]
    public void IsUserUniqueInCollection_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        User user = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => UserService.IsUserUniqueInCollection(null!, user));
    }

    [TestMethod]
    [TestCategory("IsUserUniqueInCollection")]
    public void IsUserUniqueInCollection_NullUser_ThrowsArgumentNullException()
    {
        // Arrange
        List<User> users = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => UserService.IsUserUniqueInCollection(users, null!));
    }

    [TestMethod]
    [TestCategory("IsUserUniqueInCollection")]
    public void IsUserUniqueInCollection_UniqueUser_ReturnsTrue()
    {
        // Arrange
        User user1 = new() { Name = id1 };
        User user2 = new() { Name = id2 };
        List<User> users = new();
        users.Add(user1);

        // Act
        (bool result, string? detail) = UserService.IsUserUniqueInCollection(users, user2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("IsUserUniqueInCollection")]
    public void IsUserUniqueInCollection_UniqueUser_ReturnsNull()
    {
        // Arrange
        User user1 = new() { Name = id1 };
        User user2 = new() { Name = id2 };
        List<User> users = new();
        users.Add(user1);

        // Act
        (bool result, string? detail) = UserService.IsUserUniqueInCollection(users, user2);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("IsUserUniqueInCollection")]
    public void IsUserUniqueInCollection_NonUniqueUser_ReturnsFalse()
    {
        // Arrange
        User user1 = new() { Name = id1 };
        User user2 = new() { Name = id1 };
        List<User> users = new();
        users.Add(user1);

        // Act
        (bool result, string? detail) = UserService.IsUserUniqueInCollection(users, user2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("IsUserUniqueInCollection")]
    public void IsUserUniqueInCollection_NonUniqueUser_ReturnsNameString()
    {
        // Arrange
        User user1 = new() { Name = id1 };
        User user2 = new() { Name = id1 };
        List<User> users = new();
        users.Add(user1);

        // Act
        (bool result, string? detail) = UserService.IsUserUniqueInCollection(users, user2);

        // Assert
        Assert.AreEqual("Name", detail);
    }


    [TestMethod]
    [TestCategory("IsUserUniqueInSession")]
    public void IsUserUniqueInSession_NullSession_ThrowsArgumentNullException()
    {
        // Arrange
        User user = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => UserService.IsUserUniqueInSession(null!, user));
    }

    [TestMethod]
    [TestCategory("IsUserUniqueInSession")]
    public void IsUserUniqueInSession_NullUser_ThrowsArgumentNullException()
    {
        // Arrange
        Session session = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => UserService.IsUserUniqueInSession(session, null!));
    }

    [TestMethod]
    [TestCategory("IsUserUniqueInSession")]
    public void IsUserUniqueInSession_UniqueUser_ReturnsTrue()
    {
        // Arrange
        User user1 = new() { Name = id1 };
        User user2 = new() { Name = id2 };
        Session session = new();
        session.Users.Add(user1);

        // Act
        (bool result, string? detail) = UserService.IsUserUniqueInSession(session, user2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("IsUserUniqueInSession")]
    public void IsUserUniqueInSession_UniqueUser_ReturnsNull()
    {
        // Arrange
        User user1 = new() { Name = id1 };
        User user2 = new() { Name = id2 };
        Session session = new();
        session.Users.Add(user1);

        // Act
        (bool result, string? detail) = UserService.IsUserUniqueInSession(session, user2);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("IsUserUniqueInSession")]
    public void IsUserUniqueInSession_NonUniqueUser_ReturnsFalse()
    {
        // Arrange
        User user1 = new() { Name = id1 };
        User user2 = new() { Name = id1 };
        Session session = new();
        session.Users.Add(user1);

        // Act
        (bool result, string? detail) = UserService.IsUserUniqueInSession(session, user2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("IsUserUniqueInSession")]
    public void IsUserUniqueInSession_NonUniqueUser_ReturnsNameString()
    {
        // Arrange
        User user1 = new() { Name = id1 };
        User user2 = new() { Name = id1 };
        Session session = new();
        session.Users.Add(user1);

        // Act
        (bool result, string? detail) = UserService.IsUserUniqueInSession(session, user2);

        // Assert
        Assert.AreEqual("Name", detail);
    }
}
