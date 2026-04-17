using LicenseTracker.Models;
using LicenseTracker.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Services
{
    static class SettingsService
    {

        public static string? GetLastOpenSessionPath()
        {
            return LicenseTracker.Properties.Settings.Default.lastOpenSessionPath;
        }


        public static void SetAppSettings(SessionStore sessionStore)
        {
            ArgumentNullException.ThrowIfNull(sessionStore, nameof(sessionStore));

            Properties.Settings settings = Properties.Settings.Default;
            Session currentSession = sessionStore.CurrentSession;

            settings.lastOpenSessionPath = currentSession.SaveFilePath;

            SaveSettings();
        }



        private static void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
}
