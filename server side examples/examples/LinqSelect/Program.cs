using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqSelectEx
{
    class Program
    {
        static void Main(string[] args)
        {
            MockCustomerRepo repo = new MockCustomerRepo();
            IEnumerable<Customer> customers = repo.GetAllCustomers();
            IEnumerable<string> c1 = customers.Select(e => e.Email);
            foreach (string email in c1)
                Console.WriteLine("email: {0}", email);
            var c2 = customers.Select(e =>
            new { FirstName = e.FirstName, Email = e.Email });
            foreach (var e in c2)
                Console.WriteLine("firstName: {0}  email: {1}",e.FirstName, e.Email);
            var c3 = customers.Select(e =>
            new { FirstName = e.FirstName, LastName = e.LastName });
            foreach (var e in c3)
                Console.WriteLine("Name: {0} {1}", e.FirstName, e.LastName);
        }
    }
}
