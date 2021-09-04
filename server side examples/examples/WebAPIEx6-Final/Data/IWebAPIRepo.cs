using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIEx6.Models;

namespace WebAPIEx6.Data
{
    public interface IWebAPIRepo
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerByID(int id);
        Customer AddCustomer(Customer customer);
        void DeleteCustomer(int id);
        void SaveChanges();
    }
}
