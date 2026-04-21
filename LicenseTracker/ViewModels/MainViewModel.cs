using LicenseTracker.Services;
using LicenseTracker.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LicenseTracker.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Used to manage the app's navigation state.
        /// </summary>
        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// Used to manage the app's session state.
        /// </summary>
        public SessionStore _sessionStore;


        /// <summary>
        /// The Main view's current content view-model.
        /// </summary>
        public ViewModelBase? CurrentContentViewModel =>
            _navigationStore.CurrentMainContentViewModel;


        
        public MainViewModel(NavigationStore navigationStore,
            SessionStore sessionStore)
        {
            _navigationStore = navigationStore;
            _sessionStore = sessionStore;

            _navigationStore.CurrentMainContentViewModelChanged +=
                OnCurrentContentViewModelChanged;
        }


        /// <summary>
        /// Handles the window closing event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>True if the user wishes to close the window,
        /// false otherwise</returns>
        public bool OnWindowClosing(object? sender, CancelEventArgs e)
        {
            // Save the app settings.
            SettingsService.SetAppSettings(_sessionStore);

            // The session service's CloseCurrentSession method
            // return true if the user wishes to continue closing
            // the window, false otherwise.
            return SessionService.CloseCurrentSession(_sessionStore);
        }


        /// <summary>
        /// Handles the main content view-model change event.
        /// </summary>
        private void OnCurrentContentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentContentViewModel));
        }
    }
}
