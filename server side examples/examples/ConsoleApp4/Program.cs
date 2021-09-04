using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student { FirstName = "Carolyn", LastName = "Smith", Id = 123456 };
            Console.WriteLine("Name: {0} {1}",student.FirstName, student.LastName);
            Console.WriteLine("ID: {0}", student.Id);
        }
    }
}
