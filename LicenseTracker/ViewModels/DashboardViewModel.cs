using LicenseTracker.Commands;
using LicenseTracker.Models;
using LicenseTracker.Services;
using LicenseTracker.Stores;
using LicenseTracker.UIComponents.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace LicenseTracker.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        /// <summary>
        /// Used to the manage the app's session state.
        /// </summary>
        private readonly SessionStore _sessionStore;


        // Backing Fields
        private bool isLicenseSelected = false;
        private LicenseItem? selectedLicenseItem = null;


        /// <summary>
        /// Returns the session store's current session instance.
        /// </summary>
        public Session CurrentSession =>
            _sessionStore.CurrentSession;

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
            CurrentSession.Licenses;

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
        /// Executed when the License Info Delete button is clicked.
        /// </summary>
        public ICommand LicenseInfoDeleteButtonClickedCommand { get; }

        /// <summary>
        /// Executed when the License Info Edit button is clicked.
        /// </summary>
        public ICommand LicenseInfoEditButtonClickedCommand { get; }

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

            FilterUpdateButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnFilterUpdateButtonClicked));
            LicenseInfoDeleteButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnLicenseInfoDeleteButtonClicked));
            LicenseInfoEditButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnLicenseInfoEditButtonClicked));
            NewLicenseButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnNewLicenseButtonClicked));
            SaveButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnSaveButtonClicked));
        }


        /// <summary>
        /// Removes the selected license from the current session.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown if the
        /// <seealso cref="SelectedLicenseItem"/> is null</exception>
        private void DeleteLicenseRequested()
        {
            LicenseItem license = SelectedLicenseItem ??
                throw new NullReferenceException("The license to " +
                "be deleted cannot be null");

            string productName = license.Product != null ? license.Product.Name
                : Product.DefaultName;

            SessionService.RemoveLicenseItemFromCurrentSession(_sessionStore,
                license);

            string infoText = $"The license for '{productName}' has " +
                $"been deleted";
            OnInfoUpdated(infoText);

            SelectedLicenseItem = null;
        }

        /// <summary>
        /// Prompts the user with a dialog to allow them edit the
        /// selected License Item's details.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown if the
        /// <seealso cref="SelectedLicenseItem"/> is null</exception>
        private void EditLicenseRequested()
        {
            LicenseItem license = SelectedLicenseItem ??
                throw new NullReferenceException("The license to " +
                "be delted cannot be null");

            EditLicenseDialog dlg =
                DialogService.PromptUserWithEditLicenseDialog(
                    _sessionStore, SelectedLicenseItem);

            string infoText = $"License updated";
            OnInfoUpdated(infoText);
        }


        private void OnFilterUpdateButtonClicked(object? obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles the License Info Delete button click event.
        /// </summary>
        /// <param name="obj"></param>
        private void OnLicenseInfoDeleteButtonClicked(object? obj)
        {
            if (SelectedLicenseItem == null)
            {
                return;
            }

            bool result =
                DialogService.PromptUserWithDeleteConfirmationMessage(
                    SelectedLicenseItem);
            if (result)
            {
                DeleteLicenseRequested();
            }
        }

        /// <summary>
        /// Handles the License Info Edit button click event.
        /// </summary>
        /// <param name="obj"></param>
        private void OnLicenseInfoEditButtonClicked(object? obj)
        {
            EditLicenseRequested();
        }


        private void OnNewLicenseButtonClicked(object? obj)
        {
            bool result =
                DialogService.PromptUserWithNewLicenseDialog(
                    _sessionStore);
        }

        
        private void OnSaveButtonClicked(object? obj)
        {
            (bool, string) result =
                SessionService.SaveCurrentSession(_sessionStore);
            if (result.Item1)
            {
                OnInfoUpdated("Session saved");
            }
            else
            {
                throw new NotImplementedException();
            }
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
