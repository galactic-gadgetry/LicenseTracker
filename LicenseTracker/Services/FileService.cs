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



        public static void SaveSessionToJson(Session session)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));

            JsonService.SaveObject(session, session.SaveFilePath);
        }
    }
}
