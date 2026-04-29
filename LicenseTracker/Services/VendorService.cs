using LicenseTracker.Models;
using LicenseTracker.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Services
{
    public static class VendorService
    {

        public static Vendor CreateNewVendor(VendorDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            Vendor vendor = new()
            {
                Name = dto.Name,
            };

            return vendor;
        }

        /// <summary>
        /// Determines if the <see cref="Vendor"/> properties are
        /// unique in the collection.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="vendor"></param>
        /// <returns>True if unique, false with details
        /// otherwise</returns>
        public static (bool, string?) IsVendorUniqueInCollection(
            IEnumerable<Vendor> collection, Vendor vendor)
        {
            ArgumentNullException.ThrowIfNull(collection, nameof(collection));
            ArgumentNullException.ThrowIfNull(vendor, nameof(vendor));

            // If any details in any of the collection's existing
            // vendors conflict with the passed vendor, return
            // false.
            foreach (Vendor v in collection)
            {
                (bool result, string? detail) = v.ContainsDetailConflict(vendor);
                if (result)
                {
                    return (false, detail);
                }
            }

            return (true, null);
        }

        /// <summary>
        /// Determines if the <see cref="Vendor"/> properties are
        /// unique in the <see cref="Session.Products""/> collection.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="vendor"></param>
        /// <returns>True if unique, false with details
        /// otherwise</returns>
        public static (bool, string?) IsVendorUniqueInSession(
            Session session, Vendor vendor)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));
            ArgumentNullException.ThrowIfNull(vendor, nameof(vendor));

            return IsVendorUniqueInCollection(
                session.Vendors, vendor);
        }
    }
}
