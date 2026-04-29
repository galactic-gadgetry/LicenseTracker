using LicenseTracker.Models;
using LicenseTracker.Stores;
using LicenseTracker.UIComponents.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LicenseTracker.Services
{
    static class DialogService
    {
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
        public static void PromptUserWithNewLicenseDialog(SessionStore sessionStore)
        {
            CreateNewLicenseDialog dlg = new(sessionStore);
            Window mainWindow = Application.Current.MainWindow;
            dlg.Owner = mainWindow;

            dlg.ShowDialog();
        }

        /// <summary>
        /// Displays the <see cref="CreateNewProductDialog"/> to the
        /// user.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="owner"></param>
        /// <returns>The Create New Product Dialog</returns>
        public static CreateNewProductDialog PromptUserWithNewProductDialog(
            SessionStore sessionStore, Window owner)
        {
            CreateNewProductDialog dlg = new(sessionStore);
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
