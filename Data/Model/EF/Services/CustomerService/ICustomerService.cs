using System.Collections.Generic;

namespace EF.Services.CustomerService
{
    internal interface ICustomerService
    {
        ICollection<Customer> GetCustomers(SearchCriteria criteria = null);
        ICollection<Customer> GetCustomerHeaders();
    }
}