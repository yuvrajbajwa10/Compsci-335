using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqJoinEx2.Model;

namespace LinqJoinEx2.Data {
    interface IDataRepo {
        public IEnumerable<Customer> GetCustomers();
        public IEnumerable<Order> GetOrders();
        public IEnumerable<Product> GetProducts();
    }
}
