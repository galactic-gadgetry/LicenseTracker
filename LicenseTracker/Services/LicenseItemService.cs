using LicenseTracker.Models;
using LicenseTracker.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Services
{
    public static class LicenseItemService
    {

        public static LicenseItem CreateNewLicenseItem(
            LicenseItemDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            LicenseItem license = new()
            {
                Administrator = dto.Administrator,
                ExpirationDate = dto.ExpirationDate,
                IssueDate = dto.IssueDate,
                LicenseId = dto.LicenseId,
                Product = dto.Product,
                PurchaseDate = dto.PurchaseDate,
                Status = dto.Status,
                User = dto.User,
                Vendor = dto.Vendor,
            };

            return license;
        }

        /// <summary>
        /// Determines if the <see cref="LicenseItem"/> properties
        /// are unique in the collection.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="license"></param>
        /// <returns>True if unique, false with details
        /// otherwise</returns>
        public static (bool, string?) IsLicenseItemUniqueInCollection(
            IEnumerable<LicenseItem> collection, LicenseItem license)
        {
            ArgumentNullException.ThrowIfNull(collection, nameof(collection));
            ArgumentNullException.ThrowIfNull(license, nameof(license));

            // If any details in any of the collection's existing
            // licenses conflict with the passed license, return
            // false.
            foreach (LicenseItem l in collection)
            {
                (bool result, string? detail) = l.ContainsDetailConflict(license);
                if (result)
                {
                    return (false, detail);
                }
            }

            return (true, null);
        }

        /// <summary>
        /// Determines if the <see cref="LicenseItem"/> properties
        /// are unique in the <see cref="Session.Licenses"/>
        /// collection.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="license"></param>
        /// <returns>True if unique, false with details
        /// otherwise</returns>
        public static (bool, string?) IsLicenseItemUniqueInSession(
            Session session, LicenseItem license)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));
            ArgumentNullException.ThrowIfNull(license, nameof(license));

            return IsLicenseItemUniqueInCollection(
                session.Licenses, license);
        }
    }
}
