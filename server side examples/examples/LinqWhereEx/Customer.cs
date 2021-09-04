using System;
using System.Collections.Generic;
using System.Text;

namespace LinqWhereEx
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Customer() { }

        public Customer(int id)
        {
            this.Id = id;
        }
    }
}
