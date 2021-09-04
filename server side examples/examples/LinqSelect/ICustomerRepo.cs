using System;
using System.Collections.Generic;
using System.Text;

namespace LinqSelectEx
{
    public interface ICustomerRepo
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerByID(int id);
        Customer GetOneCustomerByLastName(string lastName);
        IEnumerable<Customer> GetCustomersByLastName(string lastName);
        IEnumerable<Customer> GetCustomersByFirstName(string firstName);
    }
}
