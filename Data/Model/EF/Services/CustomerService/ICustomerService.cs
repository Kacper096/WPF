using System.Collections.Generic;
using EF.Services.Model;

namespace EF.Services.CustomerService
{
    internal interface ICustomerService
    {
        ICollection<Customer> GetCustomers(SearchCriteria criteria = null);
        ICollection<CustomerHeader> GetCustomerHeaders();
    }
}