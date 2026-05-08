using LicenseTracker.Models;
using LicenseTracker.Models.DTOs;
using LicenseTracker.Services;
using LicenseTracker.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LicenseTracker.UIComponents.Dialogs
{
    /// <summary>
    /// Interaction logic for CreateNewVendorDialog.xaml
    /// </summary>
    public partial class CreateNewVendorDialog : Window
    {
        /// <summary>
        /// Used to manage the app's session state.
        /// </summary>
        private readonly SessionStore _sessionStore;


        /// <summary>
        /// New Vendor instance created, if successful.
        /// </summary>
        public Vendor NewVendor = VendorService.GetDefaultVendor();

        /// <summary>
        /// Text for the Name text box.
        /// </summary>
        public string NameText { get; set; } = string.Empty;


        /// <summary>
        /// Initializes a new instance of the
        /// <seealso cref="CreateNewVendorDialog"/> class.
        /// </summary>
        /// <param name="sessionStore"></param>
        public CreateNewVendorDialog(SessionStore sessionStore)
        {
            _sessionStore = sessionStore;
            DataContext = this;

            InitializeComponent();
        }


        /// <summary>
        /// Handles the Add button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddVendorRequested())
            {
                DialogResult = true;
            }
        }

        /// <summary>
        /// Creates and adds the new Vendor to the current
        /// session's Vendors collection, if valid.
        /// </summary>
        /// <returns>True if successful, false otherwise</returns>
        private bool AddVendorRequested()
        {
            VendorDTO dto = new() { Name = NameText };

            (bool result, string? detail) =
                SessionService.CreateNewVendorInCurrentSession(
                    _sessionStore, dto);
            if (!result)
            {
                string caption = "Vendor Conflict Error";
                string message = $"The selected {detail} is " +
                    $"assigned to another vendor. Vendor " +
                    $"{detail} must be unique.";
                DialogService.PromptUserWithErrorMessageWithOKButtonDialog(
                    caption, message);

                NameTextBox.Focus();

                return false;
            }
            else
            {
                NewVendor = _sessionStore.CurrentSession.Vendors
                    .First(v => v.Name == NameText);

                return true;
            }
        }

        /// <summary>
        /// Handles the Cancel button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        /// <summary>
        /// Handles the Title Bar click to drag event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        /// <summary>
        /// Handles the Title Bar X button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
