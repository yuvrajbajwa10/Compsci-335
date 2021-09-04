using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            int quotient, remainder;
            bool valid = Divide(20, 3, out quotient, out remainder);
            if (valid)
            {
                Console.WriteLine("quotient: {0}", quotient);
                Console.WriteLine("remainder: {0}", remainder);
            }
        }

        static bool Divide(int dividend, int divisor, out int quotient, out int remainder)
        {
            if (divisor != 0)
            {
                quotient = dividend / divisor;
                remainder = dividend % divisor;
                return true;
            }
            else
            {
                quotient = 0;
                remainder = 0;
                return false;
            }
        }
    }
}
