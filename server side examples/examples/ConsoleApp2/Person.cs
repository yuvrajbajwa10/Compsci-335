using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Person
    {
        string firstName;
        string lastName;

        public Person(string fn, string ln)
        {
            firstName = fn;
            lastName = ln;
        }

        public void SetLastName(string ln)
        {
            lastName = ln;
        }

        public string GetLastName()
        {
            return lastName;
        }
    }
}
