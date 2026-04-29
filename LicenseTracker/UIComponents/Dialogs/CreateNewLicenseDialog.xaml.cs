using LicenseTracker.Models;
using LicenseTracker.Models.DTOs;
using LicenseTracker.Services;
using LicenseTracker.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Printing;
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
    /// Interaction logic for CreateNewLicenseDialog.xaml
    /// </summary>
    public partial class CreateNewLicenseDialog : Window, INotifyPropertyChanged
    {
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



        public Session CurrentSession =>
            _sessionStore.CurrentSession;


        public string NumberOrID { get; set; } = string.Empty;


        public ObservableCollection<Product> Products =>
            CurrentSession.Products;


        public User SelectedAdministrator
        {
            get => selectedAdministrator;
            set
            {
                selectedAdministrator = value;
                OnPropertyChanged(nameof(SelectedAdministrator));
            }
        }


        public DateTime? SelectedExpirationDate
        {
            get => selectedExpirationDate;
            set
            {
                selectedExpirationDate = value;
                OnPropertyChanged(nameof(SelectedExpirationDate));
            }
        }


        public DateTime? SelectedIssueDate
        {
            get => selectedIssueDate;
            set
            {
                selectedIssueDate = value;
                OnPropertyChanged(nameof(SelectedIssueDate));
            }
        }


        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }


        public DateTime? SelectedPurchaseDate
        {
            get => selectedPurchaseDate;
            set
            {
                selectedPurchaseDate = value;
                OnPropertyChanged(nameof(SelectedPurchaseDate));
            }
        }


        public LicenseItem.LicenseStatus SelectedStatus
        {
            get => selectedStatus;
            set
            {
                selectedStatus = value;
                OnPropertyChanged(nameof(SelectedStatus));
            }
        }


        public User SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }


        public Vendor SelectedVendor
        {
            get => selectedVendor;
            set
            {
                selectedVendor = value;
                OnPropertyChanged(nameof(SelectedVendor));
            }
        }


        public IEnumerable<LicenseItem.LicenseStatus> Statuses =>
            Enum.GetValues(typeof(LicenseItem.LicenseStatus)).
            Cast<LicenseItem.LicenseStatus>();


        public ObservableCollection<User> Users =>
            CurrentSession.Users;


        public ObservableCollection<Vendor> Vendors =>
            CurrentSession.Vendors;



        public event PropertyChangedEventHandler? PropertyChanged;



        public CreateNewLicenseDialog(SessionStore sessionStore)
        {
            _sessionStore = sessionStore;
            DataContext = this;

            InitializeInputFields();

            InitializeComponent();
        }



        private void AddAdministratorButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewUserDialog dlg = DialogService.PromptUserWithNewUserDialog(_sessionStore, this);

            // If the Create New User Dialog result is true,
            // the new user was created, set the selected administrator
            // of the combo box to the new user.
            User? newAdministrator = dlg.NewUser;
            if (newAdministrator != null)
            {
                SelectedAdministrator =
                    Users.FirstOrDefault(u => u.Name == newAdministrator.Name);
            }
        }


        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewProductDialog dlg =
                DialogService.PromptUserWithNewProductDialog(_sessionStore, this);

            // If the Create New Product Dialog result is true,
            // the new product was created, set the selected product
            // of the combo box to the new product.
            Product? newProduct = dlg.NewProduct;
            if (newProduct != null)
            {
                SelectedProduct =
                    Products.FirstOrDefault(p => p.Name == newProduct.Name);
            }
        }


        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewUserDialog dlg =
                DialogService.PromptUserWithNewUserDialog(_sessionStore, this);

            // If the Create New User Dialog result is true,
            // the new user was created, set the selected user
            // of the combo box to the new user.
            User? newUser = dlg.NewUser;
            if (newUser != null)
            {
                SelectedUser =
                    Users.FirstOrDefault(u => u.Name == newUser.Name);
            }
        }


        private void AddVendorButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewVendorDialog dlg =
                DialogService.PromptUserWithNewVendorDialog(_sessionStore, this);

            // If the Create New Vendor Dialog result is true,
            // the new vendor was created, set the selected
            // vendor of the combo box to the new vendor.
            Vendor? newVendor = dlg.NewVendor;
            if (newVendor != null)
            {
                SelectedVendor =
                    Vendors.FirstOrDefault(v => v.Name == newVendor.Name);
                ;
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }


        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (CreateLicenseItemRequested())
            {
                DialogResult = true;
            }
        }


        private bool CreateLicenseItemRequested()
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
                SessionService.CreateNewLicenseItemInCurrentSession(
                    _sessionStore, dto);
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

            throw new NotImplementedException();
        }


        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void InitializeInputFields()
        {
            SelectedAdministrator = Users.FirstOrDefault(u => u.Name == "Unassigned");
            SelectedProduct = Products.FirstOrDefault(p => p.Name == "None");
            SelectedStatus = Statuses.FirstOrDefault(s => s == LicenseItem.LicenseStatus.Active);
            SelectedUser = Users.FirstOrDefault(u => u.Name == "Unassigned");
            SelectedVendor = Vendors.FirstOrDefault(v => v.Name == "None");
        }


        private void OnPropertyChanged(string parameterName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(parameterName));
        }


        private void XButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
