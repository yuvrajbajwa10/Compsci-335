using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationEx2.Model;

namespace AuthenticationEx2.Data
{
    public interface IAuthRepo
    {
        public IEnumerable<Customer> GetAllCustomers();
        public bool ValidLogin(string userName, string password);
        public Customer GetCustomerByEmail(string e);
    }
}
