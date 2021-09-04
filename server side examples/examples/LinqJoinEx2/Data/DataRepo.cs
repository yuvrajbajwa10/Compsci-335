using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqJoinEx2.Model;

namespace LinqJoinEx2.Data {
    class DataRepo : IDataRepo {
        private readonly JoinDBContext _dbContext;

        public DataRepo(JoinDBContext dBContext) {
            _dbContext = dBContext;
        }
        public IEnumerable<Customer> GetCustomers() {
            IEnumerable<Customer> customers = _dbContext.Customers.ToList<Customer>();
            return customers;
        }

        public IEnumerable<Order> GetOrders() {
            IEnumerable<Order> orders = _dbContext.Orders.ToList<Order>();
            return orders;
        }

        public IEnumerable<Product> GetProducts() {
            IEnumerable<Product> products = _dbContext.Products.ToList<Product>();
            return products;
        }
    }
}
