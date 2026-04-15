using LicenseTracker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LicenseTracker.Services
{
    static class SessionService
    {

        public static Session GetNewSession()
        {
            return new Session();
        }
    }
}
