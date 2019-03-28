using EF.Services.Model;
using Logs;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
        public ICollection<CustomerHeader> GetCustomerHeaders()
        {
            ICollection<CustomerHeader> _customers;

            using (var context = new NorthwindEntities())
            {
                try
                {
                    return _customers = context.Customers.Select(x => new CustomerHeader
                    {
                       ID = x.CustomerID,
                       FullName = x.CompanyName,
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
                finally
                {
                    context.Dispose();
                }
            }
        }

        /// <summary>
        /// Finds customer in the database
        /// </summary>
        /// <param name="Id">Input parameter Id from UI</param>
        /// <returns></returns>
        public Customer FindById(int Id)
        {
            Customer _findedCust;
            using (var context = new NorthwindEntities())
            {
                try
                {
                    _findedCust = context.Customers.Where(x => x.CustomerID.ToString().ToLowerInvariant().Contains(Id.ToString().ToLowerInvariant()))
                         .SingleOrDefault();

                }
                catch (ArgumentNullException e)
                {
                    //Logs
                    throw;
                }
                catch (InvalidOperationException e)
                {
                    throw;
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    context.Dispose();
                }
                
            }

            return _findedCust;
        }

        /// <summary>
        /// Insert customer to the database.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool InsertCustomer(Customer customer)
        {
            try
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
            catch(DbEntityValidationException db)
            {
                foreach(var eve in db.EntityValidationErrors)
                {
                    
                    foreach (var ve in eve.ValidationErrors)
                    {
                        StringBuilder exception = new StringBuilder("Property: ").Append(ve.PropertyName).Append("Error: ").Append(ve.ErrorMessage).AppendLine(" " + DateTime.Now.Date);
                        File.WriteToFile("ef_except",exception.ToString());
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Removes customer finded by id
        /// </summary>
        /// <param name="Id">Customer's Id</param>
        public void RemoveCustomer(int Id)
        {
            Customer _findedCust = this.FindById(Id: Id);

            using (var context = new NorthwindEntities())
            {
                try
                {
                   
                    if (_findedCust != null)
                        context.Customers.Remove(_findedCust);
                    context.SaveChanges();
                    
                }
                catch(NotSupportedException e)
                {
                    //Here would be write in logs
                    throw;
                }
                catch(ObjectDisposedException e)
                {
                    throw;
                }
                catch(InvalidOperationException e)
                {
                    throw;
                }
                finally
                {
                    context.Dispose();
                }
            }
        }

        /// <summary>
        /// Updates customer in the database
        /// </summary>
        /// <param name="Id"></param>
        public void UpdateCustomer(Customer customer)
        {
            Customer _findedCust;

            
            if(int.TryParse(customer.CustomerID, out int result))
            {
                _findedCust = this.FindById(result);

                if(!customer.Equals(_findedCust))
                {

                    using (var context = new NorthwindEntities())
                    {
                        try
                        {
                            context.Entry(_findedCust).CurrentValues.SetValues(customer);
                            context.SaveChanges();
                        }
                        catch(Exception e)
                        {
                            throw;
                        }
                        finally
                        {
                            context.Dispose();
                        }
                     }
                }
            }

        }
        #endregion

        
    }
}
