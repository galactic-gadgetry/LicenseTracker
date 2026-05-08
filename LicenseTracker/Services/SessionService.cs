using LicenseTracker.Models;
using LicenseTracker.Models.DTOs;
using LicenseTracker.Stores;
using LicenseTracker.UIComponents.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;

namespace LicenseTracker.Services
{
    static class SessionService
    {
        /// <summary>
        /// Adds the <see cref="LicenseItem"/> instance to the
        /// <see cref="Session.Licenses"/> collection if valid.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="license">LicenseItem to be added</param>
        /// <returns>True if successful, false with details
        /// otherwise</returns>
        public static (bool, string?) AddLicenseItemToSession(
            Session session, LicenseItem license)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));
            ArgumentNullException.ThrowIfNull(license, nameof(license));

            (bool result, string? detail) =
                LicenseItemService.IsLicenseItemUniqueInSession(
                    session, license);

            if (result)
            {
                session.Licenses.Add(license);
                //SortLicensesCollection(session);
            }

            return (result, detail);
        }

        /// <summary>
        /// Adds the <see cref="Product"/> instance to the
        /// <see cref="Session.Products"/> collection if valid.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="product">Product to be added</param>
        /// <returns>True if successful, false with details
        /// otherwise</returns>
        public static (bool, string?) AddProductToSession(
            Session session, Product product)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));
            ArgumentNullException.ThrowIfNull(product, nameof(product));

            (bool result, string? detail) =
                ProductService.IsProductUniqueInSession(
                    session, product);

            if (result)
            {
                session.Products.Add(product);
                SortProductsCollection(session);
            }

            return (result, detail);
        }

        /// <summary>
        /// Adds the <see cref="User"/> instance to the
        /// <see cref="Session.Users"/> collection if valid.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="user">User to be added</param>
        /// <returns>True if successful, false with details
        /// otherwise</returns>
        public static (bool, string?) AddUserToSession(
            Session session, User user)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));
            ArgumentNullException.ThrowIfNull(user, nameof(user));

            (bool result, string? detail) =
                UserService.IsUserUniqueInSession(
                    session, user);

            if (result)
            {
                session.Users.Add(user);
                SortUsersCollection(session);
            }

            return (result, detail);
        }

        /// <summary>
        /// Adds the <see cref="Vendor"/> isntance to the
        /// <see cref="Session.Vendors"/> collection if valid.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="vendor">Vendor to be added</param>
        /// <returns>True if successful, false with details
        /// otherwise</returns>
        public static (bool, string?) AddVendorToSession(
            Session session, Vendor vendor)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));
            ArgumentNullException.ThrowIfNull(vendor, nameof(vendor));

            (bool result, string? detail) =
                VendorService.IsVendorUniqueInSession(
                    session, vendor);

            if (result)
            {
                session.Vendors.Add(vendor);
                SortVendorsCollection(session);
            }

            return (result, detail);
        }

        /// <summary>
        /// Closes the session store's current session.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <returns>False if the user selects the Cancel button,
        /// true otherwise</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool CloseCurrentSession(SessionStore sessionStore)
        {
            ArgumentNullException.ThrowIfNull(sessionStore, nameof(sessionStore));

            // If the session has unsaved changes, prompt the user
            // to save the session before closing.
            Session currentSession = sessionStore.CurrentSession;
            if (currentSession.HasUnsavedChanges)
            {
                MessageBoxResult result =
                    DialogService.PromptUserWithSaveChangesMessage(sessionStore);
                if (result == MessageBoxResult.Cancel)
                {
                    return false;
                }
                else if (result == MessageBoxResult.Yes)
                {
                    SaveCurrentSession(sessionStore);
                    return true;
                }
                else if (result == MessageBoxResult.No)
                {
                    return true;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            return true;
        }

        /// <summary>
        /// Initializes a new instasnce of the
        /// <see cref="LicenseItem"/> class from the DTO, and adds
        /// it to the <see cref="SessionStore.CurrentSession"/>
        /// Licenses collection, if valid.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="dto">Data transfer object from which the
        /// <see cref="LicenseItem"/></param> will be
        /// initialized
        /// <returns>True if successful, false with details
        /// otherwise</returns>
        public static (bool, string?) CreateNewLicenseItemInCurrentSession(
            SessionStore sessionStore, LicenseItemDTO dto)
        {
            ArgumentNullException.ThrowIfNull(sessionStore, nameof(sessionStore));
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            LicenseItem license =
                LicenseItemService.CreateNewLicenseItem(dto);
            return
                AddLicenseItemToSession(
                    sessionStore.CurrentSession, license);
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Product"/> class from the DTO, and adds it to
        /// the <see cref="SessionStore.CurrentSession"/>'s Products
        /// collection, if valid.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="dto">Data transfer object from which the
        /// <see cref="Product"/> will be initialized</param>
        /// <returns>True if successful, false with details
        /// otherwise</returns>
        public static (bool, string?) CreateNewProductInCurrentSession(
            SessionStore sessionStore, ProductDTO dto)
        {
            ArgumentNullException.ThrowIfNull(sessionStore, nameof(sessionStore));
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            Product product = ProductService.CreateNewProduct(dto);
            return
                AddProductToSession(sessionStore.CurrentSession, product);
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="User"/> class from the DTO, and adds it to
        /// the <see cref="SessionStore.CurrentSession"/>'s Users
        /// collection, if valid.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="dto">Data transfer object from which the
        /// <see cref="User"/></param> will be initialized
        /// <returns>True if successful, false with details
        /// otherwise</returns>
        public static (bool, string?) CreateNewUserInCurrentSession(
            SessionStore sessionStore, UserDTO dto)
        {
            ArgumentNullException.ThrowIfNull(sessionStore, nameof(sessionStore));
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            User user = UserService.CreateNewUser(dto);
            return
                AddUserToSession(sessionStore.CurrentSession, user);
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Vendor"/> class from the DTO, and adds it to
        /// the <see cref="SessionStore.CurrentSession"/>'s Vendors
        /// collection, if valid.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="dto">Data transfer object from which the
        /// <see cref="Vendor"/></param> will be initialized
        /// <returns>True if successful, false with details
        /// otherwise</returns>
        public static (bool, string?) CreateNewVendorInCurrentSession(
            SessionStore sessionStore, VendorDTO dto)
        {
            ArgumentNullException.ThrowIfNull(sessionStore, nameof(sessionStore));
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            Vendor vendor = VendorService.CreateNewVendor(dto);
            return
                AddVendorToSession(sessionStore.CurrentSession, vendor);
        }

        /// <summary>
        /// Sets the <see cref="LicenseItem"/> properties
        /// in the current session to that of the
        /// <see cref="LicenseItemDTO"/>, if valid.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="license"></param>
        /// <param name="dto"></param>
        /// <returns>True if successful, false with details
        /// otherwise</returns>
        public static (bool, string?) EditLicenseItemDetailsInCurrentSession(
            SessionStore sessionStore, LicenseItem license, LicenseItemDTO dto)
        {
            ArgumentNullException.ThrowIfNull(sessionStore, nameof(SessionStore));
            ArgumentNullException.ThrowIfNull(license, nameof(license));
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            // Validate that the DTO's details will be valid within
            // the current session's Licenses collection as the
            // license's details will be changed to that of the
            // DTO's.
            // A copy of the list is created and the license that
            // is to be edited is removed so that the DTO's details
            // aren't checked against the license that is wanting
            // to be changed.
            Session currentSession = sessionStore.CurrentSession;
            ObservableCollection<LicenseItem> copy = new(
                currentSession.Licenses);
            copy.Remove(license);
            (bool result, string? detail) =
                LicenseItemService.IsLicenseItemDtoUniqueInCollection(
                    copy, dto);

            if (result)
            {
                LicenseItemService.UpdateLicenseDetails(license, dto);

                // Set the session's HasUnsavedChanges property to
                // reflect that the session has changed.
                currentSession.HasUnsavedChanges = true;
            }

            return (result, detail);
        }


        public static Session GetNewSession()
        {
            Session session = new();

            InitializeSessionCollections(session);

            return session;
        }


        public static void InitializeSessionCollections(Session session)
        {
            if (!session.Products
                .Any(p => p.Name == Product.DefaultName))
            {
                AddProductToSession(
                    session, ProductService.GetDefaultProduct());
            }
            if (!session.Users
                .Any(u => u.Name == User.DefaultName))
            {
                AddUserToSession(
                    session, UserService.GetDefaultUser());
            }
            if (!session.Vendors
                .Any(v => v.Name == Vendor.DefaultName))
            {
                AddVendorToSession(
                    session, VendorService.GetDefaultVendor());
            }
        }

        /// <summary>
        /// Loads a <see cref="Session"/> instance from a JSON file
        /// and sets it as the session store's current session.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static SessionStore LoadSessionToSessionStoreFromJson(
            SessionStore sessionStore, string filePath)
        {
            Session session = JsonService.LoadSessionFromJson(filePath);
            SetSessionStoreCurrentSession(sessionStore, session);

            return sessionStore;
        }

        /// <summary>
        /// Removes the <see cref="LicenseItem"/> instance
        /// from the <see cref="SessionStore.CurrentSession"/>
        /// instance.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="license"></param>
        public static void RemoveLicenseFromCurrentSession(
            SessionStore sessionStore, LicenseItem license)
        {
            ArgumentNullException.ThrowIfNull(sessionStore, nameof(sessionStore));
            ArgumentNullException.ThrowIfNull(license, nameof(license));

            RemoveLicenseFromSession(sessionStore.CurrentSession, license);
        }

        /// <summary>
        /// Removes the <see cref="LicenseItem"/> instance
        /// from the <see cref="Session"/> instance.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="license"></param>
        /// <exception cref="InvalidOperationException">Thrown if
        /// the removal fails</exception>
        public static void RemoveLicenseFromSession(Session session,
            LicenseItem license)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));
            ArgumentNullException.ThrowIfNull(license, nameof(license));

            ObservableCollection<LicenseItem> licenses = session.Licenses;
            if (!licenses.Remove(license))
            {
                throw new InvalidOperationException("Removal of " +
                    "the LicenseItem instance from the collection " +
                    "failed");
            }
        }

        /// <summary>
        /// Saves the session store's current session to file.
        /// </summary>
        /// <param name="sessionStore"></param>
        public static (bool, string) SaveCurrentSession(SessionStore sessionStore)
        {
            ArgumentNullException.ThrowIfNull(sessionStore, nameof(sessionStore));

            SaveCurrentSessionToJson(sessionStore);

            // This is where we would return any errors that might
            // arise during save attempts.
            return (true, string.Empty);
        }

        
        public static void SortLicensesCollection(Session session)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));

            ObservableCollection<LicenseItem> licenses = new(
                session.Licenses.OrderBy(l => l.LicenseId).ToList());

            session.Licenses = licenses;
        }

        /// <summary>
        /// Sorts the <see cref="Session.Products"/> collection by
        /// the <see cref="Product.Name"/> property, then sets the
        /// "None" default Product in the zeroeth index.
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="KeyNotFoundException">Thrown if the
        /// "None" default Product is not found</exception>
        public static void SortProductsCollection(Session session)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));

            ObservableCollection<Product> products = new ObservableCollection<Product>(
                session.Products.OrderBy(p => p.Name).ToList());

            // Return the "None" default product to the top of the
            // collection.
            Product? noneProduct = products
                .FirstOrDefault(p => p.Name == Product.DefaultName);
            int index = 
               noneProduct != null ? products.IndexOf(noneProduct) :
               throw new KeyNotFoundException("The 'None' default " +
               "Product instance was not found");
            products.Move(index, 0);

            session.Products = products;
        }

        /// <summary>
        /// Sorts the <see cref="Session.Users"/> collection by
        /// the <see cref="User.Name"/> property, then sets the
        /// "Unassigned" default User in the zeroeth index.
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="KeyNotFoundException">Thrown if the
        /// "Unassigned" default User is not found</exception>
        public static void SortUsersCollection(Session session)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));

            ObservableCollection<User> users = new ObservableCollection<User>(
                session.Users.OrderBy(u => u.Name).ToList());

            // Return the "Unassigned" default user to the top of the
            // collection.
            User? unassignedUser = users
                .FirstOrDefault(u => u.Name == User.DefaultName);
            int index =
                unassignedUser != null ?
                users.IndexOf(unassignedUser) :
                throw new KeyNotFoundException("The 'Unassigned' " +
                "default user was not found");
            users.Move(index, 0);

            session.Users = users;
        }

        /// <summary>
        /// Sorts the <see cref="Session.Vendors"/> collection by
        /// the <see cref="Vendor.Name"/> property, then sets the
        /// "None" default Vendor in the zeroeth index.
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="KeyNotFoundException">Thrown if the
        /// "None" default User is not found</exception>
        public static void SortVendorsCollection(Session session)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));

            ObservableCollection<Vendor> vendors = new (
                session.Vendors.OrderBy(v => v.Name).ToList());

            // Return the "None" default vendor to the top of the
            // collection.
            Vendor? noneVendor = vendors
                .FirstOrDefault(v => v.Name == Vendor.DefaultName);
            int index =
                noneVendor != null ? vendors.IndexOf(noneVendor) :
                throw new KeyNotFoundException("The 'None' default " +
                "Vendor instance was not found");
            vendors.Move(index, 0);

            session.Vendors = vendors;
        }


        /// <summary>
        /// Saves the session store's current session to a JSON file.
        /// </summary>
        /// <param name="sessionStore"></param>
        private static void SaveCurrentSessionToJson(SessionStore sessionStore)
        {
            ArgumentNullException.ThrowIfNull(sessionStore, nameof(sessionStore));

            SaveSessionToJson(sessionStore.CurrentSession);
        }

        /// <summary>
        /// Saves the session to a JSON file.
        /// </summary>
        /// <param name="session"></param>
        private static void SaveSessionToJson(Session session)
        {
            // Check for null or invalid session state.
            ArgumentNullException.ThrowIfNull(session, nameof(session));

            // Set the Session's HasUnsavedChanges property to
            // false to indicate that the book has no unsaved
            // changes.
            session.HasUnsavedChanges = false;

            FileService.SaveSessionToJson(session);
        }

        /// <summary>
        /// Sets the session store's
        /// <see cref="SessionStore.CurrentSession"/> property to
        /// the session.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="session"></param>
        private static void SetSessionStoreCurrentSession(
            SessionStore sessionStore, Session session)
        {
            ArgumentNullException.ThrowIfNull(sessionStore, nameof(sessionStore));
            ArgumentNullException.ThrowIfNull(session, nameof(session));

            sessionStore.CurrentSession = session;
        }
    }
}
