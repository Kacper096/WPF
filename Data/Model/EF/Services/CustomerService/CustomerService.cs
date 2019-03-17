using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EF.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        #region Methods
        /// <summary>
        /// Get All Customers From DataBase
        /// </summary>
        /// <returns></returns>
        public ICollection<Customer> GetCustomers(SearchCriteria criteria = null)
        {
            ///Refactor because efficiency is low
            ///To many query to DataBase
            using (var context = new NorthwindEntities())
            {
                
                try
                {
                    if(criteria == null)
                        return context.Customers.ToList();

                    if (!string.IsNullOrWhiteSpace(criteria.CompanyName))
                        return context.Customers
                            .Where(x => x.CompanyName.ToUpperInvariant().Contains(criteria.CompanyName.ToUpperInvariant()))
                            .ToList();

                    if (!string.IsNullOrWhiteSpace(criteria.CustomerID))
                        return context.Customers
                            .Where(x => x.CustomerID.ToUpperInvariant().Contains(criteria.CustomerID.ToUpperInvariant()))
                            .ToList();

                    if (!string.IsNullOrWhiteSpace(criteria.City))
                        return context.Customers
                            .Where(x => x.City.ToUpperInvariant().Contains(criteria.City.ToUpperInvariant()))
                            .ToList();

                    if (!string.IsNullOrWhiteSpace(criteria.Country))
                        return context.Customers
                            .Where(x => x.City.ToUpperInvariant().Contains(criteria.City.ToUpperInvariant()))
                            .ToList();

                    if (!string.IsNullOrWhiteSpace(criteria.Region))
                        return context.Customers
                            .Where(x => x.Region.ToUpperInvariant().Contains(criteria.Region.ToUpperInvariant()))
                            .ToList();
                    return null;
                }
                catch(ArgumentException e)
                {
                    throw new ArgumentException(e.StackTrace);
                }
            }
        }
        /// <summary>
        /// Get Headers Customers
        /// </summary>
        /// <returns></returns>
        public ICollection<Customer> GetCustomerHeaders()
        {
            ICollection<Customer> _customers;

            using (var context = new NorthwindEntities())
            {
                try
                {
                    return _customers = context.Customers.Select(x => new Customer
                    {
                       CustomerID = x.CustomerID,
                       CompanyName = x.CompanyName,
                       Country = x.Country,
                       City = x.City
                    }).ToList();
                }
                catch(ArgumentException e)
                {
                    throw new ArgumentException(e.StackTrace);
                }
                catch (Exception e)
                {

                    throw new Exception(e.StackTrace);
                }
            }
        }

        /// <summary>
        /// Insert customer to the database.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool InsertCustomer(Customer customer)
        {
            using (var context = new NorthwindEntities())
            {
                context.Customers.Add(customer);
                var result = context.SaveChanges();

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Removes customer finded by id
        /// </summary>
        /// <param name="Id">Customer's Id</param>
        public void RemoveCustomer(int Id)
        {
            using (var context = new NorthwindEntities())
            {
                Customer _findedCust = context.Customers.Where(x => x.CustomerID.ToString().ToLowerInvariant().Contains(Id.ToString().ToLowerInvariant()))
                    .SingleOrDefault();

                if(_findedCust != null)
                    context.Customers.Remove(_findedCust);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
