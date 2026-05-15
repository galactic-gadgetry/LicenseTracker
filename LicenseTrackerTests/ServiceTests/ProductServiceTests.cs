using LicenseTracker.Models;
using LicenseTracker.Models.DTOs;
using LicenseTracker.Services;
using System.Diagnostics;


namespace LicenseTrackerTests;

[TestClass]
public class ProductServiceTests
{
    // Constants
    private const string id1 = "ABCDE";
    private const string id2 = "FGHIJ";



    [TestMethod]
    [TestCategory("CreateNewProduct")]
    public void CreateNewProduct_NullDto_ThrowsArgumentNullException()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => ProductService.CreateNewProduct(null!));
    }


    [TestMethod]
    [TestCategory("IsProductDtoUniqueInCollection")]
    public void IsProductDtoUniqueInCollection_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        ProductDTO product = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => ProductService.IsProductDtoUniqueInCollection(null!, product));
    }

    [TestMethod]
    [TestCategory("IsProductDtoUniqueInCollection")]
    public void IsProductDtoUniqueInCollection_NullDto_ThrowsArgumentNullException()
    {
        // Arrange
        List<Product> products = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => ProductService.IsProductDtoUniqueInCollection(products, null!));
    }

    [TestMethod]
    [TestCategory("IsProductDtoUniqueInCollection")]
    public void IsProductDtoUniqueInCollection_UniqueDto_ReturnsTrue()
    {
        // Arrange
        Product product = new() { Name = id1 };
        ProductDTO dto = new() { Name = id2 };
        List<Product> products = new();
        products.Add(product);

        // Act
        (bool result, string? detail) = ProductService.IsProductDtoUniqueInCollection(products, dto);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("IsProductDtoUniqueInCollection")]
    public void IsProductDtoUniqueInCollection_UniqueDto_ReturnsNull()
    {
        // Arrange
        Product product = new() { Name = id1 };
        ProductDTO dto = new() { Name = id2 };
        List<Product> products = new();
        products.Add(product);

        // Act
        (bool result, string? detail) = ProductService.IsProductDtoUniqueInCollection(products, dto);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("IsProductDtoUniqueInCollection")]
    public void IsProductDtoUniqueInCollection_NonUniqueDto_ReturnsFalse()
    {
        // Arrange
        Product product = new() { Name = id1 };
        ProductDTO dto = new() { Name = id1 };
        List<Product> products = new();
        products.Add(product);

        // Act
        (bool result, string? detail) = ProductService.IsProductDtoUniqueInCollection(products, dto);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("IsProductDtoUniqueInCollection")]
    public void IsProductDtoUniqueInCollection_NonUniqueDto_ReturnsNameString()
    {
        // Arrange
        Product product = new() { Name = id1 };
        ProductDTO dto = new() { Name = id1 };
        List<Product> products = new();
        products.Add(product);

        // Act
        (bool result, string? detail) = ProductService.IsProductDtoUniqueInCollection(products, dto);

        // Assert
        Assert.AreEqual("Name", detail);
    }


    [TestMethod]
    [TestCategory("IsProductUniqueInCollection")]
    public void IsProductUniqueInCollection_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        Product product = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => ProductService.IsProductUniqueInCollection(null!, product));
    }

    [TestMethod]
    [TestCategory("IsProductUniqueInCollection")]
    public void IsProductUniqueInCollection_NullProduct_ThrowsArgumentNullException()
    {
        // Arrange
        List<Product> products = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => ProductService.IsProductUniqueInCollection(products, null!));
    }

    [TestMethod]
    [TestCategory("IsProductUniqueInCollection")]
    public void IsProductUniqueInCollection_UniqueProduct_ReturnsTrue()
    {
        // Arrange
        Product product1 = new() { Name = id1 };
        Product product2 = new() { Name = id2 };
        List<Product> products = new();
        products.Add(product1);

        // Act
        (bool result, string? detail) = ProductService.IsProductUniqueInCollection(products, product2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("IsProductUniqueInCollection")]
    public void IsProductUniqueInCollection_UniqueProduct_ReturnsNull()
    {
        // Arrange
        Product product1 = new() { Name = id1 };
        Product product2 = new() { Name = id2 };
        List<Product> products = new();
        products.Add(product1);

        // Act
        (bool result, string? detail) = ProductService.IsProductUniqueInCollection(products, product2);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("IsProductUniqueInCollection")]
    public void IsProductUniqueInCollection_NonUniqueProduct_ReturnsFalse()
    {
        // Arrange
        Product product1 = new() { Name = id1 };
        Product product2 = new() { Name = id1 };
        List<Product> products = new();
        products.Add(product1);

        // Act
        (bool result, string? detail) = ProductService.IsProductUniqueInCollection(products, product2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("IsProductUniqueInCollection")]
    public void IsProductUniqueInCollection_NonUniqueProduct_ReturnsNameString()
    {
        // Arrange
        Product product1 = new() { Name = id1 };
        Product product2 = new() { Name = id1 };
        List<Product> products = new();
        products.Add(product1);

        // Act
        (bool result, string? detail) = ProductService.IsProductUniqueInCollection(products, product2);

        // Assert
        Assert.AreEqual("Name", detail);
    }


    [TestMethod]
    [TestCategory("IsProductUniqueInSession")]
    public void IsProductUniqueInSession_NullSession_ThrowsArgumentNullException()
    {
        // Arrange
        Product product = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => ProductService.IsProductUniqueInCollection(null!, product));
    }

    [TestMethod]
    [TestCategory("IsProductUniqueInSession")]
    public void IsProductUniqueInSession_NullProduct_ThrowsArgumentNullException()
    {
        // Arrange
        Session session = new();

        // Assert
        Assert.Throws<ArgumentNullException>(() => ProductService.IsProductUniqueInSession(session, null!));
    }

    [TestMethod]
    [TestCategory("IsProductUniqueInSession")]
    public void IsProductUniqueInSession_UniqueProduct_ReturnsTrue()
    {
        // Arrange
        Product product1 = new() { Name = id1 };
        Product product2 = new() { Name = id2 };
        Session session = new();
        session.Products.Add(product1);

        // Act
        (bool result, string? detail) = ProductService.IsProductUniqueInSession(session, product2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [TestCategory("IsProductUniqueInSession")]
    public void IsProductUniqueInSession_UniqueProduct_ReturnsNull()
    {
        // Arrange
        Product product1 = new() { Name = id1 };
        Product product2 = new() { Name = id2 };
        Session session = new();
        session.Products.Add(product1);

        // Act
        (bool result, string? detail) = ProductService.IsProductUniqueInSession(session, product2);

        // Assert
        Assert.IsNull(detail);
    }

    [TestMethod]
    [TestCategory("IsProductUniqueInSession")]
    public void IsProductUniqueInSession_NonUniqueProduct_ReturnsFalse()
    {
        // Arrange
        Product product1 = new() { Name = id1 };
        Product product2 = new() { Name = id1 };
        Session session = new();
        session.Products.Add(product1);

        // Act
        (bool result, string? detail) = ProductService.IsProductUniqueInSession(session, product2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [TestCategory("IsProductUniqueInSession")]
    public void IsProductUniqueInSession_NonUniqueProduct_ReturnsNameString()
    {
        // Arrange
        Product product1 = new() { Name = id1 };
        Product product2 = new() { Name = id1 };
        Session session = new();
        session.Products.Add(product1);

        // Act
        (bool result, string? detail) = ProductService.IsProductUniqueInSession(session, product2);

        // Assert
        Assert.AreEqual("Name", detail);
    }
}
