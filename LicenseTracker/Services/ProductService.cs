using LicenseTracker.Models;
using LicenseTracker.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Services
{
    public static class ProductService
    {
        
        public static Product CreateNewProduct(ProductDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            Product product = new()
            {
                Name = dto.Name,
            };

            return product;
        }


        public static Product GetDefaultProduct()
        {
            Product product = new()
            {
                Name = Product.DefaultName,
            };

            return product;
        }

        /// <summary>
        /// Determines if the data transfer object's properties
        /// are uniqe in the collection.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="dto"></param>
        /// <returns>True if unique, false with details
        /// otherwise</returns>
        public static (bool, string?) IsProductUniqueInCollection(
            IEnumerable<Product> collection, ProductDTO dto)
        {
            ArgumentNullException.ThrowIfNull(collection, nameof(collection));
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            Product product = CreateNewProduct(dto);

            return IsProductUniqueInCollection(collection, product);
        }

        /// <summary>
        /// Determines if the <see cref="Product"/> properties are
        /// unique in the collection.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="product"></param>
        /// <returns>True if unique, false with details
        /// otherwise</returns>
        public static (bool, string?) IsProductUniqueInCollection(
            IEnumerable<Product> collection, Product product)
        {
            ArgumentNullException.ThrowIfNull(collection, nameof(collection));
            ArgumentNullException.ThrowIfNull(product, nameof(product));

            // If any details in any of the collection's existing
            // products conflict with the passed product, return
            // false.
            foreach (Product p in collection)
            {
                (bool result, string? detail) = p.ContainsDetailConflict(product);
                if (result)
                {
                    return (false, detail);
                }
            }

            return (true, null);
        }

        /// <summary>
        /// Determines if the <see cref="Product"/> properties are
        /// unique in the <see cref="Session.Products"/> collection.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="product"></param>
        /// <returns>True if unique, false with details
        /// otherwise</returns>
        public static (bool, string?) IsProductUniqueInSession(
            Session session, Product product)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));
            ArgumentNullException.ThrowIfNull(product, nameof(product));

            return IsProductUniqueInCollection(
                session.Products, product);
        }
    }
}
