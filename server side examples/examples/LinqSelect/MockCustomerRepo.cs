using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqSelectEx
{
    public class MockCustomerRepo : ICustomerRepo
    {
        IEnumerable<Customer> _customers;
        public MockCustomerRepo()
        {
            this._customers = new List<Customer>
            {
                new Customer {Id=1,FirstName="Carolyn",LastName="Smith",Email="CarolynSmith@mail.com"},
                new Customer {Id=2,FirstName="Benjamin",LastName="Sanders",Email="BenjaminSanders@mail.com"},
                new Customer {Id=3,FirstName="Charlotte",LastName="Jones",Email="CharlotteJones@mail.com"},
                new Customer {Id=4,FirstName="William",LastName="Brown",Email="WilliamBrown@mail.com"},
                new Customer {Id=5,FirstName="Olivia",LastName="Jones",Email="OliviaJones@mail.com"}
            };
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public Customer GetCustomerByID(int id)
        {
            //Customer c = _customers.FirstOrDefault(delegate (Customer e) { return e.Id == id; });
            //Customer c = _customers.FirstOrDefault((Customer e) => { return e.Id == id; });
            //Customer c = _customers.FirstOrDefault((e) => { return e.Id == id; });
            //Customer c = _customers.FirstOrDefault(e => { return e.Id == id; });
            Customer c = _customers.FirstOrDefault(e => e.Id == id );
            return c;
        }

        public IEnumerable<Customer> GetCustomersByFirstName(string firstName)
        {
            IEnumerable<Customer> c = _customers.Where(e => e.FirstName == firstName);
            return c;
        }

        public IEnumerable<Customer> GetCustomersByLastName(string lastName)
        {
            IEnumerable<Customer> c = _customers.Where(e=>e.LastName==lastName);
            return c;
        }

        public Customer GetOneCustomerByLastName(string lastName)
        {
            Customer c = _customers.FirstOrDefault(e => e.LastName == lastName);
            return c;
        }
    }
}
