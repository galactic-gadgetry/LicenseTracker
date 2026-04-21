using LicenseTracker.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.ViewModels
{
    internal class LayoutViewModel : ViewModelBase
    {
        // Backing Fields
        private string infoText = string.Empty;


        /// <summary>
        /// Used to manage the app's navigation state.
        /// </summary>
        private readonly NavigationStore _navigationStore;


        /// <summary>
        /// The layout's current content view-model.
        /// </summary>
        public ViewModelBase? CurrentContentViewModel =>
            _navigationStore.CurrentLayoutContentViewModel;


        public string InfoText
        {
            get => infoText;
            set
            {
                infoText = value;
                OnPropertyChanged(nameof(InfoText));
            }
        }



        public LayoutViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentLayoutContentViewModelChanged +=
                OnCurrentContentViewModelChanged;
            _navigationStore.InfoUpdated += OnInfoUpdated;
        }


        /// <summary>
        /// Handles the content view-model's change event.
        /// </summary>
        private void OnCurrentContentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentContentViewModel));
        }


        private void OnInfoUpdated(object? sender, string info)
        {
            InfoText = info;
        }
    }
}
