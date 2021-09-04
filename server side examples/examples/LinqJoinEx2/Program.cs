using System;
using LinqJoinEx2.Model;
using LinqJoinEx2.Data;
using System.Collections.Generic;
using System.Linq;

namespace LinqJoinEx2 {
    class Program {
        static void Main(string[] args) {
            JoinDBContext joinDBContext = new JoinDBContext();
            DataRepo dataRepo = new DataRepo(joinDBContext);
            IEnumerable<Order> orders = dataRepo.GetOrders();
            IEnumerable<Customer> customers = dataRepo.GetCustomers();
            var custOrder = customers.Join(orders, c => c.ID, o => o.CustomerID,
                (c, o) => new
                {
                    CustomerName = c.FirstName + ' ' + c.LastName,
                    ProductId = o.ProductID
                });
            foreach (var e in custOrder)
                Console.WriteLine("Name: {0}  Product ID: {1}", e.CustomerName, e.ProductId);

            IEnumerable<Product> products = dataRepo.GetProducts();
            var custProd = custOrder.Join(products, co => co.ProductId, p => p.ProductID,
                (co, p) => new { CustomerName = co.CustomerName, ProductName = p.Name });
            foreach (var cp in custProd)
                Console.WriteLine("Customer Name: {0}   Product Name: {1}", cp.CustomerName, cp.ProductName);
        }
    }
}
