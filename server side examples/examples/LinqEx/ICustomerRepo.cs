using System;
using System.Collections.Generic;
using System.Text;

namespace LinqEx
{
    public interface ICustomerRepo
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
    }
}
