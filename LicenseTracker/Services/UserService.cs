using LicenseTracker.Models;
using LicenseTracker.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Services
{
    public static class UserService
    {

        public static User CreateNewUser(UserDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            User user = new()
            {
                Name = dto.Name,
            };

            return user;
        }


        public static User GetDefaultUser()
        {
            User user = new()
            {
                Name = User.DefaultName,
            };

            return user;
        }

        /// <summary>
        /// Determines if the <see cref="User"/> properties are
        /// unique in the collection.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="user"></param>
        /// <returns>True if unique, false with details
        /// otherwise</returns>
        public static (bool, string?) IsUserUniqueInCollection(
            IEnumerable<User> collection, User user)
        {
            ArgumentNullException.ThrowIfNull(collection, nameof(collection));
            ArgumentNullException.ThrowIfNull(user, nameof(user));

            // If any details in any of the collection's existing
            // users conflict with the passed user, return
            // false.
            foreach (User u in collection)
            {
                (bool result, string? detail) = u.ContainsDetailConflict(user);
                if (result)
                {
                    return (false, detail);
                }
            }

            return (true, null);
        }

        /// <summary>
        /// Determines if the <see cref="User"/> properties are
        /// unique in the <see cref="Session.Users"/> collection.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="user"></param>
        /// <returns>True if unique, false with details
        /// otherwise</returns>
        public static (bool, string?) IsUserUniqueInSession(
            Session session, User user)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));
            ArgumentNullException.ThrowIfNull(user, nameof(user));

            return IsUserUniqueInCollection(
                session.Users, user);
        }
    }
}
