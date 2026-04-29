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
    /// Interaction logic for CreateNewProductDialog.xaml
    /// </summary>
    public partial class CreateNewProductDialog : Window
    {
        /// <summary>
        /// Used to manage the app's session state.
        /// </summary>
        private readonly SessionStore _sessionStore;


        /// <summary>
        /// New Product instance created, if successful.
        /// </summary>
        public Product? NewProduct = null;

        /// <summary>
        /// Text for the Name text box.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;


        /// <summary>
        /// Initializes a new instance of the
        /// <seealso cref="CreateNewProductDialog"/> class.
        /// </summary>
        /// <param name="sessionStore"></param>
        public CreateNewProductDialog(SessionStore sessionStore)
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
            ProductDTO dto = new() { Name = ProductName };

            (bool result, string? detail) =
                SessionService.CreateNewProductInCurrentSession(
                    _sessionStore, dto);
            if (!result)
            {
                string caption = "Product Conflict Error";
                string message = $"The selected {detail} is assigned " +
                    $"to another product. Product {detail} must be " +
                    $"unique.";
                DialogService.PromptUserWithErrorMessageWithOKButtonDialog(
                    caption, message);

                NameTextBox.Focus();
            }
            else
            {
                NewProduct =
                    _sessionStore.CurrentSession.Products.
                    FirstOrDefault(p => p.Name == ProductName);
                DialogResult = true;
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
