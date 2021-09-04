using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationEx2.Model;

namespace AuthenticationEx2.Data
{
    public class DbAuthRepo : IAuthRepo
    {
        private readonly AuthDbContext _dbContext;

        public DbAuthRepo(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer GetCustomerByEmail(string e)
        {
            Customer customer = _dbContext.Customers.FirstOrDefault(o => o.Email == e);
            return customer;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            IEnumerable<Customer> customers = _dbContext.Customers.ToList();
            return customers;
        }

        public bool ValidLogin(string userName, string password)
        {
            Customer c = _dbContext.Customers.FirstOrDefault(e => e.Email == userName && e.Password == password);
            if (c == null)
                return false;
            else
                return true;
        }
    }
}
