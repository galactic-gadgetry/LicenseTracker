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
        /// <summary>
        /// Reads string data from a JSON file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if
        /// the file path is not of type JSON</exception>
        public static string GetJsonStringFromFile(string filePath)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(filePath, nameof(filePath));
            if (Path.GetExtension(filePath) != ".json")
            {
                throw new ArgumentOutOfRangeException(nameof(filePath));
            }

            return File.ReadAllText(filePath);
        }

        /// <summary>
        /// Creates a <see cref="Session"/> instance from a JSON
        /// file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="FileLoadException">Thrown if the string
        /// found in the JSON file cannot be
        /// deserialized</exception>
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

        /// <summary>
        /// Saves the object as a serialized JSON file.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        public static void SaveObject(object obj, string filePath)
        {
            string jsonString = JsonConvert.SerializeObject(obj,
                Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
