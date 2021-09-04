using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp5.Model;

namespace ConsoleApp5.Data
{
    interface IDataRepo
    {
        IEnumerable<Person> GetPeople();
    }
}
