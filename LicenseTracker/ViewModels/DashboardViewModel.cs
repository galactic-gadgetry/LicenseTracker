using LicenseTracker.Commands;
using LicenseTracker.Models;
using LicenseTracker.Services;
using LicenseTracker.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace LicenseTracker.ViewModels
{
    internal class DashboardViewModel : ViewModelBase
    {
        /// <summary>
        /// Used to the manage the app's session state.
        /// </summary>
        private readonly SessionStore _sessionStore;


        // Backing Fields
        private bool isLicenseSelected = false;
        private LicenseItem? selectedLicenseItem = null;


        /// <summary>
        /// True if a license is selected by the user.
        /// </summary>
        public bool IsLicenseSelected
        {
            get => isLicenseSelected;
            set
            {
                isLicenseSelected = value;
                OnPropertyChanged(nameof(IsLicenseSelected));
            }
        }

        /// <summary>
        /// Returns the current session's license collection.
        /// </summary>
        public ObservableCollection<LicenseItem> Licenses =>
            _sessionStore.CurrentSession.Licenses;

        /// <summary>
        /// The currently selected license.
        /// </summary>
        public LicenseItem? SelectedLicenseItem
        {
            get => selectedLicenseItem;
            set
            {
                selectedLicenseItem = value;
                OnSelectedLicenseItemChanged();
                OnPropertyChanged(nameof(SelectedLicenseItem));
            }
        }


        /// <summary>
        /// Executed when the filter area's Update button is clicked.
        /// </summary>
        public ICommand FilterUpdateButtonClickedCommand { get; }

        /// <summary>
        /// Executed when the New License button is clicked.
        /// </summary>
        public ICommand NewLicenseButtonClickedCommand { get; }

        /// <summary>
        /// Executed when the Save button is clicked.
        /// </summary>
        public ICommand SaveButtonClickedCommand { get; }



        public DashboardViewModel(SessionStore sessionStore)
        {
            _sessionStore = sessionStore;

            // DELETE ME!!!!!!!!!!!!!!!
            _sessionStore.CurrentSession.Licenses = Licenses;

            FilterUpdateButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnFilterUpdateButtonClicked));
            NewLicenseButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnNewLicenseButtonClicked));
            SaveButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnSaveButtonClicked));
        }



        private void OnFilterUpdateButtonClicked(object? obj)
        {
            throw new NotImplementedException();
        }


        private void OnNewLicenseButtonClicked(object? obj)
        {
            throw new NotImplementedException();
        }


        private void OnSaveButtonClicked(object? obj)
        {
            SessionService.SaveCurrentSession(_sessionStore);
        }

        /// <summary>
        /// Handles the selected license item changed event.
        /// </summary>
        private void OnSelectedLicenseItemChanged()
        {
            IsLicenseSelected = SelectedLicenseItem != null;
        }
    }
}
