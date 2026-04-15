using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LicenseTracker.Services
{
    class JsonService
    {

        public static void SaveObject(object obj, string path)
        {
            string jsonString = JsonConvert.SerializeObject(obj,
                Formatting.Indented);
            File.WriteAllText(path, jsonString);
        }
    }
}
