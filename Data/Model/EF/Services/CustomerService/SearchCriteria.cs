using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Services.CustomerService
{
    public class SearchCriteria
    {
        #region Public Fields
        public string CustomerID{ get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        #endregion
    }
}
