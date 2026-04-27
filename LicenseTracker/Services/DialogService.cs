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

        public static void PromptUserWithNewLicenseDialog()
        {
            CreateNewLicenseDialog dlg = new();
            Window mainWindow = Application.Current.MainWindow;
            dlg.Owner = mainWindow;

            dlg.ShowDialog();
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
