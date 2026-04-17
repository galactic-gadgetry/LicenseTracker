using LicenseTracker.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LicenseTracker.Services
{
    static class DialogService
    {

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
