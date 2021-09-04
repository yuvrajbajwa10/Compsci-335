using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp5.Model;

namespace ConsoleApp5.Data
{
    class DataRepoImpl : IDataRepo
    {
        List<Person> dataStore;
        public DataRepoImpl()
        {
            Person p1 = new Person { FirstName = "Carolyn", LastName = "Smith" };
            Person p2 = new Person { FirstName = "Benjamin", LastName = "Sanders" };
            dataStore = new List<Person>();
            dataStore.Add(p1);
            dataStore.Add(p2);
        }

        public IEnumerable<Person> GetPeople()
        {
            return dataStore;
        }
    }
}
