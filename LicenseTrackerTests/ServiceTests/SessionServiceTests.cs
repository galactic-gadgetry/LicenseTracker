using LicenseTracker.Models;
using LicenseTracker.Models.DTOs;
using LicenseTracker.Services;
using LicenseTracker.Stores;
using Microsoft.Extensions.DependencyModel;
using System.Collections.ObjectModel;
using System.ComponentModel.Design.Serialization;


namespace LicenseTrackerTests;

[TestClass]
public class SessionServiceTests
{
    // Constants
    private const string id1 = "ABCDE";
    private const string id2 = "FGHIJ";



    [TestMethod]
    [TestCategory("AddLicenseToSession")]
    public void AddLicenseItemToSession_NullSession_ThrowsArgumentNullException()
    {
        // Arrange
        LicenseItem license = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.AddLicenseItemToSession(null!, license));
    }

    [TestMethod]
    [TestCategory("AddLicenseToSession")]
    public void AddLicenseItemToSession_NullLicenseItem_ThrowsArgumentNullException()
    {
        // Arrange
        Session session = SessionService.GetNewSession();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.AddLicenseItemToSession(session, null!));
    }

    [TestMethod]
    [TestCategory("AddLicenseToSession")]
    public void AddLicenseItemToSession_ValidLicenseItem_AddsLicenseItemToSessionLicenses()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        LicenseItem license = new() { LicenseId = id1 };

        // Act
        (bool result, string? detail) = SessionService.AddLicenseItemToSession(session, license);

        // Assert
        Assert.Contains(license, session.Licenses);
    }

    [TestMethod]
    [TestCategory("AddLicenseToSession")]
    public void AddLicenseItemToSession_ValidLicenseItem_ReturnsTrue()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        LicenseItem license = new() { LicenseId = id1 };

        // Act
        (bool result, string? detail) = SessionService.AddLicenseItemToSession(session, license);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("AddLicenseToSession")]
    public void AddLicenseItemToSession_ValidLicenseItem_ReturnsNull()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        LicenseItem license = new() { LicenseId = id1 };

        // Act
        (bool result, string? detail) = SessionService.AddLicenseItemToSession(session, license);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("AddLicenseToSession")]
    public void AddLicenseItemToSession_InvalidLicenseItem_DoesNotAddLicenseItemToSessionLicenses()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id1 };
        Session session = SessionService.GetNewSession();
        session.Licenses.Add(license1);

        // Act
        (bool result, string? detail) = SessionService.AddLicenseItemToSession(session, license2);

        // Assert
        Assert.DoesNotContain(license2, session.Licenses);
    }

    [TestMethod]
    [TestCategory("AddLicenseToSession")]
    public void AddLicenseItemToSession_InvalidLicenseItem_ReturnsFalse()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id1 };
        Session session = SessionService.GetNewSession();
        session.Licenses.Add(license1);

        // Act
        (bool result, string? detail) = SessionService.AddLicenseItemToSession(session, license2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("AddLicenseToSession")]
    public void AddLicenseItemToSession_InvalidLicenseItem_ReturnsIDString()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id1 };
        Session session = SessionService.GetNewSession();
        session.Licenses.Add(license1);

        // Act
        (bool result, string? detail) = SessionService.AddLicenseItemToSession(session, license2);

        // Assert
        Assert.AreEqual("ID", detail);
    }


    [TestMethod]
    [TestCategory("AddProductToSession")]
    public void AddProductToSession_NullSession_ThrowsArgumentNullException()
    {
        // Arrange
        Product product = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.AddProductToSession(null!, product));
    }

    [TestMethod]
    [TestCategory("AddProductToSession")]
    public void AddProductToSession_NullProduct_ThrowsArgumentNullException()
    {
        // Arrange
        Session session = SessionService.GetNewSession();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.AddProductToSession(session, null!));
    }

    [TestMethod]
    [TestCategory("AddProductToSession")]
    public void AddProductToSession_ValidProduct_AddsProductToSessionProducts()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        Product product = new() { Name = id1 };

        // Act
        (bool result, string? detail) = SessionService.AddProductToSession(session, product);

        // Assert
        Assert.Contains(product, session.Products);
    }

    [TestMethod]
    [TestCategory("AddProductToSession")]
    public void AddProductToSession_ValidProduct_ReturnsTrue()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        Product product = new() { Name = id1 };

        // Act
        (bool result, string? detail) = SessionService.AddProductToSession(session, product);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("AddProductToSession")]
    public void AddProductToSession_ValidProduct_ReturnsNull()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        Product product = new() { Name = id1 };

        // Act
        (bool result, string? detail) = SessionService.AddProductToSession(session, product);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("AddProductToSession")]
    public void AddProductToSession_InvalidProduct_DoesNotAddProductToSessionProducts()
    {
        // Arrange
        Product product1 = new() { Name = id1 };
        Product product2 = new() { Name = id1 };
        Session session = SessionService.GetNewSession();
        session.Products.Add(product1);

        // Act
        (bool result, string? detail) = SessionService.AddProductToSession(session, product2);

        // Assert
        Assert.DoesNotContain(product2, session.Products);
    }

    [TestMethod]
    [TestCategory("AddProductToSession")]
    public void AddProductToSession_InvalidProduct_ReturnsFalse()
    {
        // Arrange
        Product product1 = new() { Name = id1 };
        Product product2 = new() { Name = id1 };
        Session session = SessionService.GetNewSession();
        session.Products.Add(product1);

        // Act
        (bool result, string? detail) = SessionService.AddProductToSession(session, product2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("AddProductToSession")]
    public void AddProductToSession_InvalidProduct_ReturnsNameString()
    {
        // Arrange
        Product product1 = new() { Name = id1 };
        Product product2 = new() { Name = id1 };
        Session session = SessionService.GetNewSession();
        session.Products.Add(product1);

        // Act
        (bool result, string? detail) = SessionService.AddProductToSession(session, product2);

        // Assert
        Assert.AreEqual("Name", detail);
    }


    [TestMethod]
    [TestCategory("AddUserToSession")]
    public void AddUserToSession_NullSession_ThrowsArgumentNullException()
    {
        // Arrange
        User user = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.AddUserToSession(null!, user));
    }

    [TestMethod]
    [TestCategory("AddUserToSession")]
    public void AddUserToSession_NullUser_ThrowsArgumentNullException()
    {
        // Arrange
        Session session = SessionService.GetNewSession();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.AddUserToSession(session, null!));
    }

    [TestMethod]
    [TestCategory("AddUserToSession")]
    public void AddUserToSession_ValidUser_AddsUserToSessionUsers()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        User user = new() { Name = id1 };

        // Act
        (bool result, string? detail) = SessionService.AddUserToSession(session, user);

        // Assert
        Assert.Contains(user, session.Users);
    }

    [TestMethod]
    [TestCategory("AddUserToSession")]
    public void AddUserToSession_ValidUser_ReturnsTrue()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        User user = new() { Name = id1 };

        // Act
        (bool result, string? detail) = SessionService.AddUserToSession(session, user);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("AddUserToSession")]
    public void AddUserToSession_ValidUser_ReturnsNull()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        User user = new() { Name = id1 };

        // Act
        (bool result, string? detail) = SessionService.AddUserToSession(session, user);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("AddUserToSession")]
    public void AddUserToSession_InvalidUser_DoesNotAddUserToSessionUsers()
    {
        // Arrange
        User user1 = new() { Name = id1 };
        User user2 = new() { Name = id1 };
        Session session = SessionService.GetNewSession();
        session.Users.Add(user1);

        // Act
        (bool result, string? detail) = SessionService.AddUserToSession(session, user2);

        // Assert
        Assert.DoesNotContain(user2, session.Users);
    }

    [TestMethod]
    [TestCategory("AddUserToSession")]
    public void AddUserToSession_InvalidUser_ReturnsFalse()
    {
        // Arrange
        User user1 = new() { Name = id1 };
        User user2 = new() { Name = id1 };
        Session session = SessionService.GetNewSession();
        session.Users.Add(user1);

        // Act
        (bool result, string? detail) = SessionService.AddUserToSession(session, user2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("AddUserToSession")]
    public void AddUserToSession_InvalidUser_ReturnsNameString()
    {
        // Arrange
        User user1 = new() { Name = id1 };
        User user2 = new() { Name = id1 };
        Session session = SessionService.GetNewSession();
        session.Users.Add(user1);

        // Act
        (bool result, string? detail) = SessionService.AddUserToSession(session, user2);

        // Assert
        Assert.AreEqual("Name", detail);
    }


    [TestMethod]
    [TestCategory("AddVendorToSession")]
    public void AddVendorToSession_NullSession_ThrowsArgumentNullException()
    {
        // Arrange
        Vendor vendor = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.AddVendorToSession(null!, vendor));
    }

    [TestMethod]
    [TestCategory("AddVendorToSession")]
    public void AddVendorToSession_NullVendor_ThrowsArgumentNullException()
    {
        // Arrange
        Session session = SessionService.GetNewSession();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.AddVendorToSession(session, null!));
    }

    [TestMethod]
    [TestCategory("AddVendorToSession")]
    public void AddVendorToSession_ValidVendor_AddsVendorToSessionVendors()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        Vendor vendor = new() { Name = "id1" };

        // Act
        (bool result, string? detail) = SessionService.AddVendorToSession(session, vendor);

        // Assert
        Assert.Contains(vendor, session.Vendors);
    }

    [TestMethod]
    [TestCategory("AddVendorToSession")]
    public void AddVendorToSession_ValidVendor_ReturnsTrue()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        Vendor vendor = new() { Name = "id1" };

        // Act
        (bool result, string? detail) = SessionService.AddVendorToSession(session, vendor);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("AddVendorToSession")]
    public void AddVendorToSession_ValidVendor_ReturnsNull()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        Vendor vendor = new() { Name = "id1" };

        // Act
        (bool result, string? detail) = SessionService.AddVendorToSession(session, vendor);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("AddVendorToSession")]
    public void AddVendorToSession_InvalidVendor_DoesNotAddVendorToSessionVendors()
    {
        // Arrange
        Vendor vendor1 = new() { Name = id1 };
        Vendor vendor2 = new() { Name = id1 };
        Session session = SessionService.GetNewSession();
        session.Vendors.Add(vendor1);

        // Act
        (bool result, string? detail) = SessionService.AddVendorToSession(session, vendor2);

        // Assert
        Assert.DoesNotContain(vendor2, session.Vendors);
    }

    [TestMethod]
    [TestCategory("AddVendorToSession")]
    public void AddVendorToSession_InvalidVendor_ReturnsFalse()
    {
        // Arrange
        Vendor vendor1 = new() { Name = id1 };
        Vendor vendor2 = new() { Name = id1 };
        Session session = SessionService.GetNewSession();
        session.Vendors.Add(vendor1);

        // Act
        (bool result, string? detail) = SessionService.AddVendorToSession(session, vendor2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("AddVendorToSession")]
    public void AddVendorToSession_InvalidVendor_ReturnsNameString()
    {
        // Arrange
        Vendor vendor1 = new() { Name = id1 };
        Vendor vendor2 = new() { Name = id1 };
        Session session = SessionService.GetNewSession();
        session.Vendors.Add(vendor1);

        // Act
        (bool result, string? detail) = SessionService.AddVendorToSession(session, vendor2);

        // Assert
        Assert.AreEqual("Name", detail);
    }


    [TestMethod]
    [TestCategory("CloseCurrentSession")]
    public void CloseCurrentSession_NullSessionStore_ThrowsArgumentNullException()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.CloseCurrentSession(null!));
    }


    [TestMethod]
    [TestCategory("CreateNewLicenseItemInCurrentSession")]
    public void CreateNewLicenseItemInCurrentSession_NullSessionStore_ThrowsArgumentNullException()
    {
        // Arrange
        LicenseItemDTO dto = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.CreateNewLicenseItemInCurrentSession(null!, dto));
    }

    [TestMethod]
    [TestCategory("CreateNewLicenseItemInCurrentSession")]
    public void CreateNewLicenseItemInCurrentSession_NullLicenseItemDto_ThrowsArgumentNullException()
    {
        // Arrange
        SessionStore sessionStore = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.CreateNewLicenseItemInCurrentSession(sessionStore, null!));
    }


    [TestMethod]
    [TestCategory("CreateNewProductInCurrentSession")]
    public void CreateNewProductInCurrentSession_NullSessionStore_ThrowsArgumentNullException()
    {
        // Arrange
        ProductDTO dto = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.CreateNewProductInCurrentSession(null!, dto));
    }

    [TestMethod]
    [TestCategory("CreateNewProductInCurrentSession")]
    public void CreateNewProductInCurrentSession_NullProductDto_ThrowsArgumentNullException()
    {
        // Arrange
        SessionStore sessionStore = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.CreateNewProductInCurrentSession(sessionStore, null!));
    }


    [TestMethod]
    [TestCategory("CreateNewUserInCurrentSession")]
    public void CreateNewUserInCurrentSession_NullSessionStore_ThrowsArgumentNullException()
    {
        // Arrange
        UserDTO dto = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.CreateNewUserInCurrentSession(null!, dto));
    }

    [TestMethod]
    [TestCategory("CreateNewUserInCurrentSession")]
    public void CreateNewUserInCurrentSession_NullUserDto_ThrowsArgumentNullException()
    {
        // Arrange
        SessionStore sessionStore = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.CreateNewUserInCurrentSession(sessionStore, null!));
    }


    [TestMethod]
    [TestCategory("CreateNewVendorInCurrentSession")]
    public void CreateNewVendorInCurrentSession_NullSessionStore_ThrowsArgumentNullException()
    {
        // Arrange
        VendorDTO dto = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.CreateNewVendorInCurrentSession(null!, dto));
    }

    [TestMethod]
    [TestCategory("CreateNewVendorInCurrentSession")]
    public void CreateNewVendorInCurrentSession_NullVendorDto_ThrowsArgumentNullException()
    {
        // Arrange
        SessionStore sessionStore = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.CreateNewVendorInCurrentSession(sessionStore, null!));
    }


    [TestMethod]
    [TestCategory("EditLicenseItemDetailsInCurrentSession")]
    public void EditLicenseItemDetailsInCurrentSession_NullSessionStore_ThrowsArgumentNullException()
    {
        // Arrange
        LicenseItem license = new();
        LicenseItemDTO dto = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.EditLicenseItemDetailsInCurrentSession(null!, license, dto));
    }

    [TestMethod]
    [TestCategory("EditLicenseItemDetailsInCurrentSession")]
    public void EditLicenseItemDetailsInCurrentSession_NullLicenseItem_ThrowsArgumentNullException()
    {
        // Arrange
        SessionStore sessionStore = new();
        LicenseItemDTO dto = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.EditLicenseItemDetailsInCurrentSession(sessionStore, null!, dto));
    }

    [TestMethod]
    [TestCategory("EditLicenseItemDetailsInCurrentSession")]
    public void EditLicenseItemDetailsInCurrentSession_NullLicenseItemDto_ThrowsArgumentNullException()
    {
        // Arrange
        SessionStore sessionStore = new();
        LicenseItem license = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.EditLicenseItemDetailsInCurrentSession(sessionStore, license, null!));
    }

    [TestMethod]
    [TestCategory("EditLicenseItemDetailsInCurrentSession")]
    public void EditLicenseItemDetailsInCurrentSession_ValidLicenseItemDto_UpdatesLicenseItemDetails()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        LicenseItem license = new() { LicenseId = id1, Status = LicenseItem.LicenseStatus.Inactive };
        session.Licenses.Add(license);
        SessionStore sessionStore = new();
        sessionStore.CurrentSession = session;
        LicenseItemDTO dto = new() { LicenseId = id2, Status = LicenseItem.LicenseStatus.Archived };

        // Act
        (bool result, string? detail) = SessionService.EditLicenseItemDetailsInCurrentSession(sessionStore, license, dto);

        // Assert
        Assert.AreEqual(dto.Status, license.Status);
    }

    [TestMethod]
    [TestCategory("EditLicenseItemDetailsInCurrentSession")]
    public void EditLicenseItemDetailsInCurrentSession_ValidLicenseItemDto_ReturnsTrue()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        LicenseItem license = new() { LicenseId = id1 };
        session.Licenses.Add(license);
        SessionStore sessionStore = new();
        sessionStore.CurrentSession = session;
        LicenseItemDTO dto = new() { LicenseId = id2 };

        // Act
        (bool result, string? detail) = SessionService.EditLicenseItemDetailsInCurrentSession(sessionStore, license, dto);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("EditLicenseItemDetailsInCurrentSession")]
    public void EditLicenseItemDetailsInCurrentSession_ValidLicenseItemDto_ReturnsNull()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        LicenseItem license = new() { LicenseId = id1 };
        session.Licenses.Add(license);
        SessionStore sessionStore = new();
        sessionStore.CurrentSession = session;
        LicenseItemDTO dto = new() { LicenseId = id2 };

        // Act
        (bool result, string? detail) = SessionService.EditLicenseItemDetailsInCurrentSession(sessionStore, license, dto);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("EditLicenseItemDetailsInCurrentSession")]
    public void EditLicenseItemDetailsInCurrentSession_InvalidLicenseItemDto_DoesNotUpdateLicenseItemDetails()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        LicenseItem license1 = new() { LicenseId = id1};
        LicenseItem license2 = new() { LicenseId = id2 };
        session.Licenses.Add(license1);
        session.Licenses.Add(license2);
        SessionStore sessionStore = new();
        sessionStore.CurrentSession = session;
        LicenseItemDTO dto = new() { LicenseId = id2 };

        // Act
        (bool result, string? detail) = SessionService.EditLicenseItemDetailsInCurrentSession(sessionStore, license1, dto);

        // Assert
        Assert.AreNotEqual(dto.LicenseId, license1.LicenseId);
    }

    [TestMethod]
    [TestCategory("EditLicenseItemDetailsInCurrentSession")]
    public void EditLicenseItemDetailsInCurrentSession_InvalidLicenseItemDto_ReturnsFalse()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id2 };
        session.Licenses.Add(license1);
        session.Licenses.Add(license2);
        SessionStore sessionStore = new();
        sessionStore.CurrentSession = session;
        LicenseItemDTO dto = new() { LicenseId = id2 };

        // Act
        (bool result, string? detail) = SessionService.EditLicenseItemDetailsInCurrentSession(sessionStore, license1, dto);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("EditLicenseItemDetailsInCurrentSession")]
    public void EditLicenseItemDetailsInCurrentSession_InvalidLicenseItemDto_ReturnsIDString()
    {
        // Arrange
        Session session = SessionService.GetNewSession();
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id2 };
        session.Licenses.Add(license1);
        session.Licenses.Add(license2);
        SessionStore sessionStore = new();
        sessionStore.CurrentSession = session;
        LicenseItemDTO dto = new() { LicenseId = id2 };

        // Act
        (bool result, string? detail) = SessionService.EditLicenseItemDetailsInCurrentSession(sessionStore, license1, dto);

        // Assert
        Assert.AreEqual("ID", detail);
    }


    [TestMethod]
    [TestCategory("InitializeSessionCollections")]
    public void InitializeSessionCollections_NullSession_ThrowsArgumentNullException()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.InitializeSessionCollections(null!));
    }

    [TestMethod]
    [TestCategory("InitializeSessionCollections")]
    public void InitializeSessionCollections_SessionProductsDoesNotHaveDefaultProduct_AddsDefaultProductToSessionProducts()
    {
        // Arrange
        Session session = SessionService.GetNewSession();

        // Act
        SessionService.InitializeSessionCollections(session);

        // Assert
        Assert.HasCount(1, session.Products);
        Assert.AreEqual(Product.DefaultName, session.Products[0].Name);
    }

    [TestMethod]
    [TestCategory("InitializeSessionCollections")]
    public void InitializeSessionCollections_SessionProductsHasDefaultProduct_DoesNotAddDefaultProductToSessionProducts()
    {
        // Arrange
        Product product = ProductService.GetDefaultProduct();
        Session session = new();
        session.Products.Add(product);

        // Act
        SessionService.InitializeSessionCollections(session);

        // Assert
        Assert.HasCount(1, session.Products);
    }

    [TestMethod]
    [TestCategory("InitializeSessionCollections")]
    public void InitializeSessionCollections_SessionUsersDoesNotHaveDefaultUser_AddsDefaultUserToSessionUsers()
    {
        // Arrange
        Session session = SessionService.GetNewSession();

        // Act
        SessionService.InitializeSessionCollections(session);

        // Assert
        Assert.HasCount(1, session.Users);
        Assert.AreEqual(User.DefaultName, session.Users[0].Name);
    }

    [TestMethod]
    [TestCategory("InitializeSessionCollections")]
    public void InitializeSessionCollections_SessionUsersHasDefaultUser_DoesNotAddDefaultUserToSessionUsers()
    {
        // Arrange
        User user = UserService.GetDefaultUser();
        Session session = new();
        session.Users.Add(user);

        // Act
        SessionService.InitializeSessionCollections(session);

        // Assert
        Assert.HasCount(1, session.Users);
    }

    [TestMethod]
    [TestCategory("InitializeSessionCollections")]
    public void InitializeSessionCollections_SessionVendorsDoesNotHaveDefaultVendors_AddsDefaultVendorToSessionVendors()
    {
        // Arrange
        Session session = SessionService.GetNewSession();

        // Act
        SessionService.InitializeSessionCollections(session);

        // Assert
        Assert.HasCount(1, session.Vendors);
        Assert.AreEqual(Vendor.DefaultName, session.Vendors[0].Name);
    }

    [TestMethod]
    [TestCategory("InitializeSessionCollections")]
    public void InitializeSessionCollections_SessionVendorsHasDefaultVendors_DoesNotAddDefaultVendorToSessionVendors()
    {
        // Arrange
        Vendor vendor = VendorService.GetDefaultVendor();
        Session session = new();
        session.Vendors.Add(vendor);

        // Act
        SessionService.InitializeSessionCollections(session);

        // Assert
        Assert.HasCount(1, session.Vendors);
    }


    [TestMethod]
    [TestCategory("RemoveLicenseFromCurrentSession")]
    public void RemoveLicenseItemFromCurrentSession_NullSessionStore_ThrowsArgumentNullException()
    {
        // Arrange
        LicenseItem license = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.RemoveLicenseItemFromCurrentSession(null!, license));
    }

    [TestMethod]
    [TestCategory("RemoveLicenseFromCurrentSession")]
    public void RemoveLicenseItemFromCurrentSession_NullLicenseItem_ThrowsArgumentNullException()
    {
        // Arrange
        SessionStore sessionStore = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.RemoveLicenseItemFromCurrentSession(sessionStore, null!));
    }


    [TestMethod]
    [TestCategory("RemoveLicenseitemFromSession")]
    public void RemoveLicenseItemFromSession_NullSession_ThrowsArgumentNullException()
    {
        // Arrange
        LicenseItem license = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.RemoveLicenseItemFromSession(null!, license));
    }

    [TestMethod]
    [TestCategory("RemoveLicenseitemFromSession")]
    public void RemoveLicenseItemFromSession_NullLicenseItem_ThrowsArgumentNullException()
    {
        // Arrange
        Session session = SessionService.GetNewSession();

        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.RemoveLicenseItemFromSession(session, null!));
    }

    [TestMethod]
    [TestCategory("RemoveLicenseitemFromSession")]
    public void RemoveLicenseItemFromSession_Success_RemovesLicenseItemFromSessionLicenses()
    {
        // Arrange
        LicenseItem license = new();
        Session session = SessionService.GetNewSession();
        session.Licenses.Add(license);

        // Act
        SessionService.RemoveLicenseItemFromSession(session, license);

        // Assert
        Assert.HasCount(0, session.Licenses);
    }

    [TestMethod]
    [TestCategory("RemoveLicenseitemFromSession")]
    public void RemoveLicenseItemFromSession_Failure_ThrowsInvalidOperationsException()
    {
        // Arrange
        LicenseItem license = new();
        Session session = SessionService.GetNewSession();

        // Act
        Assert.Throws<InvalidOperationException>(() => SessionService.RemoveLicenseItemFromSession(session, license));
    }


    [TestMethod]
    [TestCategory("SaveCurrentSession")]
    public void SaveCurrentSession_NullSessionStore_ThrowsArgumentNullException()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.SaveCurrentSession(null!));
    }


    [TestMethod]
    [TestCategory("SaveCurrentSession")]
    public void SaveCurrentSession_Success_ReturnsTrue()
    {
        throw new NotImplementedException();
    }

    [TestMethod]
    [TestCategory("SaveCurrentSession")]
    public void SaveCurrentSession_Success_ReturnsNull()
    {
        throw new NotImplementedException();
    }

    [TestMethod]
    [TestCategory("SaveCurrentSession")]
    public void SaveCurrentSession_Failure_ReturnsFalse()
    {
        throw new NotImplementedException();
    }

    [TestMethod]
    [TestCategory("SaveCurrentSession")]
    public void SaveCurrentSession_Failure_ReturnsDetailString()
    {
        throw new NotImplementedException();
    }


    [TestMethod]
    [TestCategory("SortLicensesCollection")]
    public void SortLicensesCollection_NullSession_ThrowsArgumentNullException()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.SortLicensesCollection(null!));
    }

    [TestMethod]
    [TestCategory("SortLicensesCollection")]
    public void SortLicensesCollection_Success_SortsLicensesByAscendingLicenseItemLicenseId()
    {
        // Arrange
        LicenseItem license1 = new() { LicenseId = id1 };
        LicenseItem license2 = new() { LicenseId = id2 };
        Session session = SessionService.GetNewSession();
        session.Licenses.Add(license2);
        session.Licenses.Add(license1);

        // Act
        SessionService.SortLicensesCollection(session);

        // Assert
        Assert.AreEqual(license1, session.Licenses[0]);
        Assert.AreEqual(license2, session.Licenses[1]);
    }


    [TestMethod]
    [TestCategory("SortProductsCollection")]
    public void SortProductsCollection_NullSession_ThrowsArgumentNullException()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.SortProductsCollection(null!));
    }

    [TestMethod]
    [TestCategory("SortProductsCollection")]
    public void SortProductsCollection_Success_SortsProductsCollectionByAscendingName()
    {
        // Arrange
        Product product1 = new() { Name = id1 };
        Product product2 = new() { Name = id2 };
        Product defaultProduct = ProductService.GetDefaultProduct();
        Session session = SessionService.GetNewSession();
        session.Products.Add(product2);
        session.Products.Add(product1);
        session.Products.Add(defaultProduct);

        // Act
        SessionService.SortProductsCollection(session);

        // Assert
        Assert.AreEqual(product1, session.Products[1]);
        Assert.AreEqual(product2, session.Products[2]);
    }

    [TestMethod]
    [TestCategory("SortProductsCollection")]
    public void SortProductsCollection_Success_SetsDefaultProductAsFirstElementInProductsCollection()
    {
        // Arrange
        Product product1 = new() { Name = id1 };
        Product product2 = new() { Name = id2 };
        Product defaultProduct = ProductService.GetDefaultProduct();
        Session session = SessionService.GetNewSession();
        session.Products.Add(product2);
        session.Products.Add(product1);

        // Act
        SessionService.SortProductsCollection(session);

        // Assert
        Assert.AreEqual(defaultProduct.Name, session.Products[0].Name);
    }

    [TestMethod]
    [TestCategory("SortProductsCollection")]
    public void SortProductsCollection_DefaultProductDoesNotExistInProductsCollection_ThrowsKeyNotFoundException()
    {
        // Arrange
        Product product1 = new() { Name = id1 };
        Product product2 = new() { Name = id2 };
        Session session = new();
        session.Products.Add(product2);
        session.Products.Add(product1);

        // Assert
        Assert.Throws<KeyNotFoundException>(() => SessionService.SortProductsCollection(session));
    }


    [TestMethod]
    [TestCategory("SortUsersCollection")]
    public void SortUsersCollection_NullSession_ThrowsArgumentNullException()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => SessionService.SortUsersCollection(null!));
    }

    [TestMethod]
    [TestCategory("SortUsersCollection")]
    public void SortUsersCollection_Success_SortsUsersCollectionByAscendingName()
    {
        // Arrange
        User user1 = new() { Name = id1 };
        User user2 = new() { Name = id2 };
        User defaultUser = UserService.GetDefaultUser();
        Session session = SessionService.GetNewSession();
        session.Users.Add(user2);
        session.Users.Add(user1);
        session.Users.Add(defaultUser);

        // Act
        SessionService.SortUsersCollection(session);

        // Assert
        Assert.AreEqual(user1, session.Users[1]);
        Assert.AreEqual(user2, session.Users[2]);
    }

    [TestMethod]
    [TestCategory("SortUsersCollection")]
    public void SortUsersCollection_Success_SetsDefaultUserAsFirstElementInUsersCollection()
    {
        // Arrange
        User user1 = new() { Name = id1 };
        User user2 = new() { Name = id2 };
        User defaultUser = UserService.GetDefaultUser();
        Session session = new();
        session.Users.Add(user2);
        session.Users.Add(user1);
        session.Users.Add(defaultUser);

        // Act
        SessionService.SortUsersCollection(session);

        // Assert
        Assert.AreEqual(defaultUser.Name, session.Users[0].Name);
    }

    [TestMethod]
    [TestCategory("SortUsersCollection")]
    public void SortUsersCollection_DefaultUserDoesNotExistInUsersCollection_ThrowsKeyNotFoundException()
    {
        // Arrange
        User user1 = new() { Name = id1 };
        User user2 = new() { Name = id2 };
        Session session = new();
        session.Users.Add(user2);
        session.Users.Add(user1);

        // Assert
        Assert.Throws<KeyNotFoundException>(() => SessionService.SortUsersCollection(session));
    }


    [TestMethod]
    [TestCategory("SortVendorsCollection")]
    public void SortVendorsCollection_NullSession_ThrowsArgumentNullException()
    {
        // Asssert
        Assert.Throws<ArgumentNullException>(() => SessionService.SortVendorsCollection(null!));
    }

    [TestMethod]
    [TestCategory("SortVendorsCollection")]
    public void SortVendorsCollection_Success_SortsVendorsCollectionByAscendingName()
    {
        // Arrange
        Vendor vendor1 = new() { Name = id1 };
        Vendor vendor2 = new() { Name = id2 };
        Vendor defaultVendor = VendorService.GetDefaultVendor();
        Session session = SessionService.GetNewSession();
        session.Vendors.Add(vendor2);
        session.Vendors.Add(vendor1);
        session.Vendors.Add(defaultVendor);

        // Act
        SessionService.SortVendorsCollection(session);

        // Assert
        Assert.AreEqual(vendor1, session.Vendors[1]);
        Assert.AreEqual(vendor2, session.Vendors[2]);
    }

    [TestMethod]
    [TestCategory("SortVendorsCollection")]
    public void SortVendorsCollection_Success_SetsDefaultVendorAsFirstElementInVendorsCollection()
    {
        // Arrange
        Vendor vendor1 = new() { Name = id1 };
        Vendor vendor2 = new() { Name = id2 };
        Vendor defaultVendor = VendorService.GetDefaultVendor();
        Session session = new();
        session.Vendors.Add(vendor2);
        session.Vendors.Add(vendor1);
        session.Vendors.Add(defaultVendor);

        // Act
        SessionService.SortVendorsCollection(session);

        // Assert
        Assert.AreEqual(defaultVendor.Name, session.Vendors[0].Name);
    }

    [TestMethod]
    [TestCategory("SortVendorsCollection")]
    public void SortVendorsCollection_DefaultVendorDoesNotExistInVendorsCollection_ThrowsKeyNotFoundException()
    {
        // Arrange
        Vendor vendor1 = new() { Name = id1 };
        Vendor vendor2 = new() { Name = id2 };
        Session session = new();
        session.Vendors.Add(vendor2);
        session.Vendors.Add(vendor1);

        // Assert
        Assert.Throws<KeyNotFoundException>(() => SessionService.SortVendorsCollection(session));
    }
}
