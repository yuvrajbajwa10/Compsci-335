using System;
using System.Collections.Generic;
using LinqWhereEx;

namespace LingWhereEx
{
    class Program
    {
        static void Main(string[] args)
        {
            MockCustomerRepo repo = new MockCustomerRepo();
            IEnumerable<Customer> customers1 = repo.GetCustomersByLastName("Jones");
            
            foreach (Customer c in customers1)
            {
                Console.WriteLine("Customer {0}: email: {1}", c.FirstName + ' ' + c.LastName, c.Email);
            }
            IEnumerable<Customer> customers2 = repo.GetCustomersByFirstName("Carolyn");

            foreach (Customer c in customers2)
            {
                Console.WriteLine("Customer {0}: email: {1}", c.FirstName + ' ' + c.LastName, c.Email);
            }
        }
    }
}
