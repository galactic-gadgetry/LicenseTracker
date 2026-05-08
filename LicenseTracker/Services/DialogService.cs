using LicenseTracker.Models;
using LicenseTracker.Stores;
using LicenseTracker.UIComponents.Dialogs;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Text;
using System.Windows;

namespace LicenseTracker.Services
{
    static class DialogService
    {
        /// <summary>
        /// Displays a delete confirmation message box to the user.
        /// </summary>
        /// <param name="name">Name of the item to be deleted</param>
        /// <param name="id">Optional ID string</param>
        /// <returns>True if the user confirms delete action,
        /// false otherwise</returns>
        public static bool PromptUserWithDeleteConfirmationMessage(
            string name, string id = "")
        {
            string message = "Are you sure that you want to delete " +
                $"the license for ('{name}', ID: {id})? " +
                $"This action can't be undone.";
            string caption = $"Delete '{name}' license";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Exclamation;

            MessageBoxResult result = MessageBox.Show(
                message, caption, button, icon);
            return result == MessageBoxResult.Yes ? true : false;
        }

        /// <summary>
        /// Displays a delete license confirmation message box to the
        /// user.
        /// </summary>
        /// <param name="license"></param>
        /// <returns>True if user confirms delete action,
        /// false otherwise</returns>
        public static bool PromptUserWithDeleteConfirmationMessage(
            LicenseItem license)
        {
            ArgumentNullException.ThrowIfNull(license, nameof(license));

            string productName = license.Product != null ? license.Product.Name : string.Empty;
            string id = license.LicenseId;

            return PromptUserWithDeleteConfirmationMessage(productName, id);
        }

        /// <summary>
        /// Displays a error message box to the user.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        public static void PromptUserWithErrorMessageWithOKButtonDialog(
            string caption, string message)
        {
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBox.Show(
                message, caption, button, icon);
        }

        /// <summary>
        /// Displays the <see cref="CreateNewLicenseDialog"/> to the
        /// user.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <returns>True if license was created, false
        /// otherwise</returns>
        public static bool PromptUserWithNewLicenseDialog(SessionStore sessionStore)
        {
            CreateNewLicenseDialog dlg = new(sessionStore);
            Window mainWindow = Application.Current.MainWindow;
            dlg.Owner = mainWindow;

            dlg.ShowDialog();

            return dlg.DialogResult ?? false;
        }

        /// <summary>
        /// Displays the <see cref="CreateNewProductDialog"/> to the
        /// user.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static CreateNewProductDialog PromptUserWithNewProductDialog(
            SessionStore sessionStore, Window owner)
        {
            CreateNewProductDialog dlg = new(sessionStore);
            dlg.Owner = owner;

            dlg.ShowDialog();

            return dlg;
        }

        /// <summary>
        /// Displays the <see cref="CreateNewUserDialog"/> to the
        /// user.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static CreateNewUserDialog PromptUserWithNewUserDialog(
            SessionStore sessionStore, Window owner)
        {
            CreateNewUserDialog dlg = new(sessionStore);
            dlg.Owner = owner;

            dlg.ShowDialog();

            return dlg;
        }

        /// <summary>
        /// Displays the <see cref="CreateNewVendorDialog"/> to the
        /// user.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static CreateNewVendorDialog PromptUserWithNewVendorDialog(
            SessionStore sessionStore, Window owner)
        {
            CreateNewVendorDialog dlg = new(sessionStore);
            dlg.Owner = owner;

            dlg.ShowDialog();

            return dlg;
        }

        /// <summary>
        /// Displays a save changes message box.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <returns></returns>
        public static MessageBoxResult PromptUserWithSaveChangesMessage(
            SessionStore sessionStore)
        {
            string message = "Do you want to save changes?";
            string caption = "Save current session";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Question;

            return MessageBox.Show(
                message, caption, button, icon);
        }
    }
}
