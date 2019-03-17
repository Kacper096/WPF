using System;
using System.Collections.Generic;
using EF;
using EF.Services.CustomerService;
using NorthView.Helpers;

namespace NorthView
{
    public class CustomerView : ObservableObject
    {
        #region Fields
        private readonly CustomerService cs = new CustomerService();
        private ICollection<Customer> _custs;
        
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
        #endregion

        #region Ctors
        /// <summary>
        /// Creates new instance ViewModel
        /// </summary>
        public CustomerView()
        {
            Customers = cs.GetCustomers();
        }
        #endregion
    }
}
