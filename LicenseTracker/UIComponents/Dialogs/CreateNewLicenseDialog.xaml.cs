using LicenseTracker.Models;
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
        public enum LicenseStatus
        {
            Active,
            Expired,
            Archived,
            Removed,
        }



        private readonly SessionStore _sessionStore;


        // Backing Fields
        private User? administrator;
        private DateTime? expirationDate;
        private DateTime? issueDate;
        private string numberOrID = string.Empty;
        private string? product = string.Empty;
        private DateTime? purchaseDate;
        private Product? selectedProduct = null;
        private LicenseStatus status = LicenseStatus.Active;
        private User? user;
        private Vendor? vendor;



        public User? Administrator { get; set; }


        public Session CurrentSession =>
            _sessionStore.CurrentSession;


        public DateTime? ExpirationDate { get; set; }


        public DateTime? IssueDate { get; set; }


        public string NumberOrID { get; set; }


        public ObservableCollection<Product> Products =>
            CurrentSession.Products;


        public DateTime? PurchaseDate { get; set; }


        public Product? SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }


        public LicenseStatus SelectedStatus { get; set; }


        public IEnumerable<LicenseStatus> Statuses =>
            Enum.GetValues(typeof(LicenseStatus)).Cast<LicenseStatus>();


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



        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewProductDialog dlg = DialogService.PromptUserWithNewProductDialog(_sessionStore, this);

            // If the Create New Product Dialog result is true,
            // the new product was created, set the selected product
            // of the combo box to the new product.
            Product? newProduct = dlg.NewProduct;
            if (newProduct != null)
            {
                SelectedProduct =
                    CurrentSession.Products.FirstOrDefault(p => p.Name == newProduct.Name);
            }
        }


        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void InitializeInputFields()
        {
            SelectedProduct = Products.FirstOrDefault(p => p.Name == "None");
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
