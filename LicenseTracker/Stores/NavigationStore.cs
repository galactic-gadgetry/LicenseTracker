using LicenseTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseTracker.Stores
{
    internal class NavigationStore
    {
        // Backing Fields
        private ViewModelBase? currentLayoutContentViewModel;
        private ViewModelBase? currentMainContentViewModel;



        public ViewModelBase? CurrentLayoutContentViewModel
        {
            get => currentLayoutContentViewModel;
            set
            {
                currentLayoutContentViewModel = value;
                OnCurrentLayoutContentViewModelChanged();
            }
        }


        public ViewModelBase? CurrentMainContentViewModel
        {
            get => currentMainContentViewModel;
            set
            {
                currentMainContentViewModel = value;
                OnCurrentMainContentViewModelChanged();
            }
        }



        public Action? CurrentLayoutContentViewModelChanged;


        public Action? CurrentMainContentViewModelChanged;


        public event EventHandler<string>? InfoUpdated;



        private void OnCurrentLayoutContentViewModelChanged()
        {
            if (CurrentLayoutContentViewModel != null)
            {
                CurrentLayoutContentViewModel.InfoUpdated +=
                    OnInfoUpdated;
            }
            CurrentLayoutContentViewModelChanged?.Invoke();
        }


        private void OnCurrentMainContentViewModelChanged()
        {
            if (CurrentMainContentViewModel != null)
            {
                CurrentMainContentViewModel.InfoUpdated +=
                    OnInfoUpdated;
            }
            CurrentMainContentViewModelChanged?.Invoke();
        }


        private void OnInfoUpdated(object? sender, string info)
        {
            InfoUpdated?.Invoke(this, info);
        }
    }
}
