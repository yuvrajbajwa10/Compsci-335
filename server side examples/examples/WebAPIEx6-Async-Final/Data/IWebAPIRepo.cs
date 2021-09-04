using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIEx6.Models;

namespace WebAPIEx6.Data
{
    public interface IWebAPIRepo
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIDAsync(int id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
        Task SaveChangesAsync();
    }
}
