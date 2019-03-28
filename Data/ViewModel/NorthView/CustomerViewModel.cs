using EF;
using NorthView.Helpers;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace NorthView
{
    public class CustomerViewModel : ObservableObject
    {
        #region Field
        private Customer customer = new Customer();
        private string tempLastName;
        private string tempFirstName;
        #endregion
        private CustomerView customers;
        #region Public Properties
        public Customer NewCustomer
        {
            get => customer;
            set
            {
                var newCust = value;
                SetProperty<Customer>(ref customer, newCust, this.NewCustomer.ToString());
            }
        }
        public string LastName
        {
            get => tempLastName;
            set
            {
                value.Trim();
                tempLastName = value;
            }
        }
        public string FirstName
        {
            get => tempFirstName;
            set
            {
                value.Trim();
                tempFirstName = value;
            }
        }
        #endregion
        
        #region Command
        public ICommand SaveCommand { get; set; }
        #endregion
        #region Constructors
        public CustomerViewModel()
        {
            NewCustomer = new Customer();
            customers = new CustomerView();
            SaveCommand = new RelayCommand(param => this.SaveCustomer());
        }
        #endregion
        #region Private Methods
        private void SaveCustomer()
        {
            CreateID();
            CreateContactName();
            customers.AddCustomer(NewCustomer);
        }
        private void CreateID()
        {
            if(FirstName.Count() > 3 && LastName.Count() > 3)
            {
                NewCustomer.CustomerID = FirstName.ToUpper().Substring(0, 3) + LastName.ToUpper().Substring(0, 2);
            }
        }
        private void CreateContactName()
        {
            StringBuilder tempText = new StringBuilder(FirstName.ToString()).Append(LastName.ToString());
            NewCustomer.ContactName = tempText.ToString();
        }
        #endregion
    }
}
