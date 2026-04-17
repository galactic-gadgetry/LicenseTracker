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

        private readonly SessionStore _sessionStore;


        // Backing Fields
        private bool isProductSelected = false;
        private LicenseItem? selectedLicenseItem = null;



        public bool IsProductSelected
        {
            get => isProductSelected;
            set
            {
                isProductSelected = value;
                OnPropertyChanged(nameof(IsProductSelected));
            }
        }


        public ObservableCollection<LicenseItem> Licenses =>
            _sessionStore.CurrentSession.Licenses;


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



        public ICommand FilterUpdateButtonClickedCommand { get; }


        public ICommand NewLicenseButtonClickedCommand { get; }


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


        private void OnSelectedLicenseItemChanged()
        {
            IsProductSelected = SelectedLicenseItem != null;
        }
    }
}
