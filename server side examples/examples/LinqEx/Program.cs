using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqEx
{
    
    class Program
    {
        public delegate IEnumerable<Customer> Foo(IEnumerable<Customer> customers);
        static void Main(string[] args)
        {
            Console.WriteLine("=====use MockCustomerRepoV2=====");
            MockCustomerRepoV2 repo2 = new MockCustomerRepoV2();
            Customer c = repo2.GetCustomer(2);
            if (c != null)
            {
                Console.WriteLine("ID: {0}  Name: {1} {2}  email: {3}", c.Id, c.FirstName, c.LastName, c.Email);
            }
        }
    }
}
