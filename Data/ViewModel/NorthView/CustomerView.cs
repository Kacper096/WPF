using System;
using System.Collections.Generic;
using System.Windows.Input;
using EF;
using EF.Services.CustomerService;
using EF.Services.Model;
using NorthView.Helpers;

namespace NorthView
{
    public class CustomerView : ObservableObject
    {
        #region Fields
        private readonly CustomerService cs = new CustomerService();
        private ICollection<Customer> _custs;
        private ICollection<CustomerHeader> _cHeader;
        #endregion

        #region Public Properties / Commands
        
        /// <summary>
        /// Set or get Customer.
        /// </summary>
        public ICollection<Customer> Customers
        {
            get => _custs;
            set
            {
                SetProperty<ICollection<Customer>>(ref _custs, value);
            }
        }

        /// <summary>
        /// Gets the Customer Headers
        /// </summary>
        public ICollection<CustomerHeader> CustomerHeaders
        {
            get => _cHeader;
            set
            {
                SetProperty<ICollection<CustomerHeader>>(ref _cHeader, value);
            }
        }

        #endregion

        #region Ctors
        /// <summary>
        /// Creates new instance ViewModel
        /// </summary>
        public CustomerView()
        {
            Customers = cs.GetCustomers(); 
            CustomerHeaders = cs.GetCustomerHeaders();
        }
        #endregion
        #region Public Methods
        public void AddCustomer(Customer customer)
        {
            cs.InsertCustomer(customer);
        }
        #endregion
    }
}
