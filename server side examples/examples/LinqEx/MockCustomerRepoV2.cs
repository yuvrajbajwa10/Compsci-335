using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqEx
{
    public class MockCustomerRepoV2 : ICustomerRepo
    {
        List<Customer> _customers;
        public MockCustomerRepoV2()
        {
            this._customers = new List<Customer>
            {
                new Customer {Id=2,FirstName="Carolyn",LastName="Smith",Email="CarolynSmith@mail.com"},
                new Customer {Id=1,FirstName="Benjamin",LastName="Sanders",Email="BenjaminSanders@mail.com"},
                new Customer {Id=5,FirstName="Olivia",LastName="Jones",Email="CharlotteJones@mail.com"},
                new Customer {Id=4,FirstName="William",LastName="Brown",Email="WilliamBrown@mail.com"},
                new Customer {Id=3,FirstName="Charlotte",LastName="Jones",Email="OliviaJones@mail.com"}
            };
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public Customer GetCustomer(int id)
        {
            //Customer c = _customers.FirstOrDefault(delegate (Customer e) { return e.Id == id; });
            //Customer c = _customers.FirstOrDefault((Customer e) => { return e.Id == id; });
            //Customer c = _customers.FirstOrDefault((e) => { return e.Id == id; });
            //Customer c = _customers.FirstOrDefault(e => { return e.Id == id; });
            Customer c = _customers.FirstOrDefault(e => e.Id == id);
            return c;
        }

    }
}
