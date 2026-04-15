using LicenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Services
{
    static class FileService
    {
        // Constants
        public const string SaveFileDirectory =
            "C:\\Users\\nbspangl\\Documents\\coding\\WPF\\LicenseTracker\\dv\\testData";



        public static void SaveSession(Session? session)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));

            // Set the Session instance's HasUnsavedChanges property
            // to false to indicate that the book has no unsaved
            // changes in the save file.
            session.HasUnsavedChanges = false;

            JsonService.SaveObject(session, session.SaveFilePath);
        }
    }
}
