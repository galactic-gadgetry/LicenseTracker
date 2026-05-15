using LicenseTracker.Models;
using LicenseTracker.Models.DTOs;
using LicenseTracker.Services;
using LicenseTracker.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
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
    /// Interaction logic for EditLicenseDialog.xaml
    /// </summary>
    public partial class EditLicenseDialog : Window, INotifyPropertyChanged
    {
        /// <summary>
        /// The license to be edited.
        /// </summary>
        private LicenseItem _license;

        /// <summary>
        /// Used to manage the app's session state.
        /// </summary>
        private readonly SessionStore _sessionStore;


        // Backing Fields
        private User selectedAdministrator = default!;
        private DateTime? selectedExpirationDate = null;
        private DateTime? selectedIssueDate = null;
        private Product selectedProduct = default!;
        private DateTime? selectedPurchaseDate = null;
        private LicenseItem.LicenseStatus selectedStatus;
        private User selectedUser = default!;
        private Vendor selectedVendor = default!;


        /// <summary>
        /// Returns the Session Store's current Session.
        /// </summary>
        public Session CurrentSession =>
            _sessionStore.CurrentSession;

        /// <summary>
        /// Text for the license ID.
        /// </summary>
        public string NumberOrID { get; set; } = string.Empty;

        /// <summary>
        /// Reteurns the current Session's Products collection.
        /// </summary>
        public ObservableCollection<Product> Products =>
            CurrentSession.Products;

        /// <summary>
        /// User instance selected in the Administrator combo box.
        /// </summary>
        public User SelectedAdministrator
        {
            get => selectedAdministrator;
            set
            {
                if (value == null) return;

                selectedAdministrator = value;
                OnPropertyChanged(nameof(SelectedAdministrator));
            }
        }

        /// <summary>
        /// Date selected in the Expiration Date date picker.
        /// </summary>
        public DateTime? SelectedExpirationDate
        {
            get => selectedExpirationDate;
            set
            {
                selectedExpirationDate = value;
                OnPropertyChanged(nameof(SelectedExpirationDate));
            }
        }

        /// <summary>
        /// Date selected in the Issue Date date picker.
        /// </summary>
        public DateTime? SelectedIssueDate
        {
            get => selectedIssueDate;
            set
            {
                selectedIssueDate = value;
                OnPropertyChanged(nameof(SelectedIssueDate));
            }
        }

        /// <summary>
        /// Product instance selected in the Product combo box.
        /// </summary>
        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                if (value == null) return;

                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        /// <summary>
        /// Date selected in the Purchase Date date picker.
        /// </summary>
        public DateTime? SelectedPurchaseDate
        {
            get => selectedPurchaseDate;
            set
            {
                selectedPurchaseDate = value;
                OnPropertyChanged(nameof(SelectedPurchaseDate));
            }
        }

        /// <summary>
        /// Status enum selected in the Status combo box.
        /// </summary>
        public LicenseItem.LicenseStatus SelectedStatus
        {
            get => selectedStatus;
            set
            {
                selectedStatus = value;
                OnPropertyChanged(nameof(SelectedStatus));
            }
        }

        /// <summary>
        /// User instance selected in the User combo box.
        /// </summary>
        public User SelectedUser
        {
            get => selectedUser;
            set
            {
                if (value == null) return;

                selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        /// <summary>
        /// Vendor instance selected in the Vendor combo box.
        /// </summary>
        public Vendor SelectedVendor
        {
            get => selectedVendor;
            set
            {
                if (value == null) return;

                selectedVendor = value;
                OnPropertyChanged(nameof(SelectedVendor));
            }
        }

        /// <summary>
        /// Returns the License Status enum items as a collection.
        /// </summary>
        public IEnumerable<LicenseItem.LicenseStatus> Statuses =>
            Enum.GetValues(typeof(LicenseItem.LicenseStatus)).
            Cast<LicenseItem.LicenseStatus>();

        /// <summary>
        /// Return the current Session's Users collection.
        /// </summary>
        public ObservableCollection<User> Users =>
            CurrentSession.Users;

        /// <summary>
        /// Returns the current Session's Vendors collection.
        /// </summary>
        public ObservableCollection<Vendor> Vendors =>
            CurrentSession.Vendors;


        /// <summary>
        /// Raised upon property changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;



        public EditLicenseDialog(SessionStore sessionStore,
            LicenseItem license)
        {
            _sessionStore = sessionStore;
            _license = license;
            DataContext = this;

            InitializeInputFields();

            InitializeComponent();
        }


        /// <summary>
        /// Handles the Administrator Add button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAdministratorButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewUserDialog dlg = CreateNewUserRequested();

            // If the Create New User Dialog result is true,
            // the new user was created, set the selected administrator
            // of the combo box to the new user.
            if (dlg.DialogResult == true)
            {
                SelectedAdministrator = Users
                    .FirstOrDefault(u => u.Name == dlg.NewUser.Name)!;
            }
        }

        /// <summary>
        /// Handles the Product Add button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewProductDialog dlg =
                DialogService.PromptUserWithNewProductDialog(_sessionStore, this);
            // This bypasses an issue in which the Session's
            // Products collection is actually reset after sorting
            // (because ObservableCollection<T> cannot sort in place),
            // so the ObservableCollection<T>.CollectionChanged event
            // is not raised and we need to alert the UI to refresh
            // the view to reflect the sorted collection.
            OnPropertyChanged(nameof(Products));

            // If the Create New Product Dialog result is true,
            // the new product was created, set the selected product
            // of the combo box to the new product.
            if (dlg.DialogResult == true)
            {
                SelectedProduct = Products
                    .First(p => p.Name == dlg.NewProduct.Name);
            }
        }

        /// <summary>
        /// Handles the User Add button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewUserDialog dlg = CreateNewUserRequested();

            // If the Create New User Dialog result is true,
            // the new user was created, set the selected user
            // of the combo box to the new user.
            if (dlg.DialogResult == true)
            {
                SelectedUser = Users
                    .First(u => u.Name == dlg.NewUser.Name);
            }
        }

        /// <summary>
        /// Handles the Vendor Add button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddVendorButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewVendorDialog dlg =
                DialogService.PromptUserWithNewVendorDialog(_sessionStore, this);
            // This bypasses an issue in which the Session's
            // Vendors collection is actually reset after sorting
            // (because ObservableCollection<T> cannot sort in place),
            // so the ObservableCollection<T>.CollectionChanged event
            // is not raised and we need to alert the UI to refresh
            // the view to reflect the sorted collection.
            OnPropertyChanged(nameof(Vendors));

            // If the Create New Vendor Dialog result is true,
            // the new vendor was created, set the selected
            // vendor of the combo box to the new vendor.
            if (dlg.DialogResult == true)
            {
                SelectedVendor = Vendors
                    .First(v => v.Name == dlg.NewVendor.Name);
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
        /// Creates a new User instance and adds it to the current
        /// session's <see cref="Session.Users"/> collection, if
        /// valid.
        /// </summary>
        /// <returns></returns>
        private CreateNewUserDialog CreateNewUserRequested()
        {
            CreateNewUserDialog dlg =
                DialogService.PromptUserWithNewUserDialog(_sessionStore, this);
            // This bypasses an issue in which the Session's
            // Users collection is actually reset after sorting
            // (because ObservableCollection<T> cannot sort in place),
            // so the ObservableCollection<T>.CollectionChanged event
            // is not raised and we need to alert the UI to refresh
            // the view to reflect the sorted collection.
            OnPropertyChanged(nameof(Users));

            return dlg;
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
        /// Initializes the input fields to the
        /// <seealso cref="_license"/> values.
        /// </summary>
        private void InitializeInputFields()
        {
            NumberOrID = _license.LicenseId;
            SelectedAdministrator = Users
                .First(u => u.Name == _license.Administrator.Name);
            SelectedExpirationDate = _license.ExpirationDate;
            SelectedIssueDate = _license.IssueDate;
            SelectedProduct = Products.
                First(p => p.Name == _license.Product.Name);
            SelectedStatus = _license.Status;
            SelectedUser = Users.
                First(u => u.Name == _license.User.Name);
            SelectedVendor = Vendors.
                First(v => v.Name == _license.Vendor.Name);
        }

        /// <summary>
        /// Handles the <seealso cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Handles the Save button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SaveLicenseDetailsRequested())
            {
                DialogResult = true;
            }
        }

        /// <summary>
        /// Saves the license details to the
        /// <seealso cref="_license"/> instance, if valid.
        /// </summary>
        /// <returns>True if successful, false
        /// otherwise</returns>
        private bool SaveLicenseDetailsRequested()
        {
            LicenseItemDTO dto = new()
            {
                Administrator = SelectedAdministrator,
                ExpirationDate = SelectedExpirationDate,
                IssueDate = SelectedIssueDate,
                LicenseId = NumberOrID,
                Product = SelectedProduct,
                PurchaseDate = SelectedPurchaseDate,
                Status = SelectedStatus,
                User = SelectedUser,
                Vendor = SelectedVendor,
            };

            (bool result, string? detail) =
                SessionService.EditLicenseItemDetailsInCurrentSession(
                    _sessionStore, _license, dto);
            if (!result)
            {

                string caption = "License Conflict Error";
                string message = $"The selected {detail} is " +
                    $"assigned to another license. License " +
                    $"{detail} must be unique.";
                DialogService.PromptUserWithErrorMessageWithOKButtonDialog(
                    caption, message);

                return false;
            }

            return true;
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
