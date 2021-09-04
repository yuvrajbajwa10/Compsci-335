using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Carolyn", "Smith");
            person.SetLastName("Jones");
            Console.WriteLine("New Lastname {0}", person.GetLastName());
        }
    }
}
