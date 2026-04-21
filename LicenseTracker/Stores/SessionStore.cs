using LicenseTracker.Models;
using LicenseTracker.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Stores
{
    class SessionStore
    {
        public Session CurrentSession;



        public SessionStore()
        {
            CurrentSession = SessionService.GetNewSession();
        }


        public SessionStore(Session session)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));
            CurrentSession = session;
        }
    }
}
