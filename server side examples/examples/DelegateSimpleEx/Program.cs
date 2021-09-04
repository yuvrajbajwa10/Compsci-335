using System;

namespace DelegateSimpleEx
{
    class Program
    {
        public delegate int Foo1(int x, int y);
        public delegate int Foo2(int x, int y, int z);

        static void Main(string[] args)
        {
            //Foo1 f1 = new Foo1(add2);
            Foo1 f1 = add2;
            int result1 = f1(1, 2);
            Console.WriteLine("result1 = {0}", result1);
            //Foo2 f2 = new Foo2(add3);
            Foo2 f2 = add3;
            int result2 = f2(1, 2, 3);
            Console.WriteLine("result2 = {0}", result2);
        }
        public static int add2(int i, int j)
        {
            return i + j;
        }
        public static int add3(int i, int j, int k)
        {
            return i + j + k;
        }
    }


}
