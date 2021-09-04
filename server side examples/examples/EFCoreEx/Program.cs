using System;
using System.Collections.Generic;
using EFCoreEx.Model;
using EFCoreEx.Data;
using System.Linq;

namespace EFCoreEx
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddRecords();
            //GetRecords();
            //UpdateRecord();
            DeleteRecord();
        }
        private static void AddRecords()
        {
            //create records for the Customers table

            List<Customer> customers = new List<Customer>
           {
                new Customer {Id=1,FirstName="Carolyn",LastName="Smith",Email="CarolynSmith@mail.com"},
                new Customer {Id=2,FirstName="Benjamin",LastName="Sanders",Email="BenjaminSanders@mail.com"},
                new Customer {Id=3,FirstName="Charlotte",LastName="Jones",Email="CharlotteJones@mail.com"},
                new Customer {Id=4,FirstName="William",LastName="Brown",Email="WilliamBrown@mail.com"},
                new Customer {Id=5,FirstName="Olivia",LastName="Jones",Email="OliviaJones@mail.com"}
           };
            using (MyDbContext dbContext = new MyDbContext())
            {
                foreach (Customer c in customers)
                    dbContext.Customers.Add(c);
                dbContext.SaveChanges();
                Console.WriteLine("insertion completed.");
            }
        }
        private static void GetRecords()
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                IEnumerable<Customer> customers = dbContext.Customers.Where(c => c.Id < 4);
                foreach (Customer c in customers)
                    Console.WriteLine("ID: {0}  Name: {1} {2}", c.Id, c.FirstName, c.LastName);
            }
        }
        private static void UpdateRecord()
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                Customer c = dbContext.Customers.FirstOrDefault<Customer>(c => c.Id == 5);
                if (c != null)
                {
                    Console.WriteLine("Id: {0}  Name: {1} {2}", c.Id, c.FirstName, c.LastName);
                    c.FirstName = "Amy";
                    dbContext.SaveChanges();
                }
                else
                    Console.WriteLine("No such record");
            }
        }
        private static void DeleteRecord()
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                Customer c = dbContext.Customers.FirstOrDefault<Customer>(c => c.Id == 5);
                if (c != null)
                {
                    Console.WriteLine("Id: {0}  Name: {1} {2}", c.Id, c.FirstName, c.LastName);
                    dbContext.Remove(c);
                    dbContext.SaveChanges();
                }
                else
                    Console.WriteLine("No such record");
            }
        }
    }
}
