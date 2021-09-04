using System;
using ConsoleApp5.Model;
using ConsoleApp5.Data;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            DataRepoImpl dataRepo = new DataRepoImpl();

            IEnumerable<Person> people = dataRepo.GetPeople();
            foreach (Person p in people)
                Console.WriteLine("Name: {0} {1}",p.FirstName,p.LastName);
        }
    }
}
