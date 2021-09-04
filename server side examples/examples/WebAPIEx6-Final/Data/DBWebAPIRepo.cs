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

        public Customer AddCustomer(Customer customer)
        {
            EntityEntry<Customer> e = _dbContext.Customers.Add(customer);
            Customer c = e.Entity;
            _dbContext.SaveChanges();
            return c;
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = _dbContext.Customers.FirstOrDefault(e => e.Id == id);
            if (customer!=null)
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            IEnumerable<Customer> customers = _dbContext.Customers.ToList<Customer>(); 
            return customers;
        }

        public Customer GetCustomerByID(int id)
        {
            Customer customer = _dbContext.Customers.FirstOrDefault(e => e.Id == id);
            return customer;
        }


        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
