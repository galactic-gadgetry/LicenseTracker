using LicenseTracker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LicenseTracker.Services
{
    class JsonService
    {

        public static string GetJsonStringFromFile(string filePath)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(filePath, nameof(filePath));
            if (Path.GetExtension(filePath) != ".json")
            {
                throw new ArgumentOutOfRangeException(nameof(filePath));
            }

            return File.ReadAllText(filePath);
        }


        public static Session LoadSessionFromJson(string filePath)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(filePath, nameof(filePath));
            string jsonString = GetJsonStringFromFile(filePath);
            Session session = JsonConvert.DeserializeObject<Session>(jsonString) ??
                throw new FileLoadException("Unable to load session " +
                "from JSON file");

            // Deserializing the Session object sets the properties
            // and thus the session's HasUnsavedChanges property.
            // Since this session is newly loaded, we manually set
            // the HasUnsavedChanges property to false to
            // indicate that the session hasn't been changed.
            session.HasUnsavedChanges = false;
            return session;
        }


        public static void SaveObject(object obj, string filePath)
        {
            string jsonString = JsonConvert.SerializeObject(obj,
                Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
