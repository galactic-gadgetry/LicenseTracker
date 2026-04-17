using LicenseTracker.Models;
using LicenseTracker.Stores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace LicenseTracker.Services
{
    static class SessionService
    {
        /// <summary>
        /// Closes the session store's current session.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <returns>False if the user selects the Cancel button,
        /// true otherwise</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool CloseCurrentSession(SessionStore sessionStore)
        {
            ArgumentNullException.ThrowIfNull(sessionStore, nameof(sessionStore));

            // If the session has unsaved changes, prompt the user
            // to save the session before closing.
            Session currentSession = sessionStore.CurrentSession;
            if (currentSession.HasUnsavedChanges)
            {
                MessageBoxResult result =
                    DialogService.PromptUserWithSaveChangesMessage(sessionStore);
                if (result == MessageBoxResult.Cancel)
                {
                    return false;
                }
                else if (result == MessageBoxResult.Yes)
                {
                    SaveCurrentSession(sessionStore);
                    return true;
                }
                else if (result == MessageBoxResult.No)
                {
                    return true;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            return true;
        }


        public static Session GetNewSession()
        {
            return new Session();
        }

        /// <summary>
        /// Loads a <see cref="Session"/> instance from a JSON file
        /// and sets it as the session store's current session.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static SessionStore LoadSessionToSessionStoreFromJson(
            SessionStore sessionStore, string filePath)
        {
            Session session = JsonService.LoadSessionFromJson(filePath);
            SetSessionStoreCurrentSession(sessionStore, session);

            return sessionStore;
        }

        /// <summary>
        /// Saves the session store's current session to file.
        /// </summary>
        /// <param name="sessionStore"></param>
        public static (bool, string) SaveCurrentSession(SessionStore sessionStore)
        {
            ArgumentNullException.ThrowIfNull(sessionStore, nameof(sessionStore));

            SaveCurrentSessionToJson(sessionStore);

            // This is where we would return any errors that might
            // arise during save attempts.
            return (true, string.Empty);
        }


        /// <summary>
        /// Saves the session store's current session to a JSON file.
        /// </summary>
        /// <param name="sessionStore"></param>
        private static void SaveCurrentSessionToJson(SessionStore sessionStore)
        {
            ArgumentNullException.ThrowIfNull(sessionStore, nameof(sessionStore));

            SaveSessionToJson(sessionStore.CurrentSession);
        }

        /// <summary>
        /// Saves the session to a JSON file.
        /// </summary>
        /// <param name="session"></param>
        private static void SaveSessionToJson(Session session)
        {
            // Check for null or invalid session state.
            ArgumentNullException.ThrowIfNull(session, nameof(session));

            // Set the Session's HasUnsavedChanges property to
            // false to indicate that the book has no unsaved
            // changes.
            session.HasUnsavedChanges = false;

            FileService.SaveSessionToJson(session);
        }

        /// <summary>
        /// Sets the session store's
        /// <see cref="SessionStore.CurrentSession"/> property to
        /// the session.
        /// </summary>
        /// <param name="sessionStore"></param>
        /// <param name="session"></param>
        private static void SetSessionStoreCurrentSession(
            SessionStore sessionStore, Session session)
        {
            ArgumentNullException.ThrowIfNull(sessionStore, nameof(sessionStore));
            ArgumentNullException.ThrowIfNull(session, nameof(session));

            sessionStore.CurrentSession = session;
        }
    }
}
