using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPIEx6.Models;

namespace WebAPIEx6.Data
{
    public class DBWebAPIRepo : IWebAPIRepo
    {
        private readonly WebAPIDBContext _dbContext;

        public DBWebAPIRepo(WebAPIDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            ValueTask<EntityEntry<Customer>> t = _dbContext.Customers.AddAsync(customer);
            await t;
            await _dbContext.SaveChangesAsync();
            return t.Result.Entity;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            Customer customer = _dbContext.Customers.FirstOrDefault(e => e.Id == id);
            if (customer!=null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            IEnumerable<Customer> customers = _dbContext.Customers.ToList<Customer>(); 
            return customers;
        }

        public async Task<Customer> GetCustomerByIDAsync(int id)
        {
            Customer customer = _dbContext.Customers.FirstOrDefault(e => e.Id == id);
            return customer;
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
