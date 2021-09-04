using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AsyncEx3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int i = GetValue1(2000);
            int j = GetValue2(3000);
            int k = i + j;
            stopWatch.Stop();
            Console.WriteLine("Total time: {0}", stopWatch.ElapsedMilliseconds);
        }
        static int GetValue1(int duration)
        {
            Console.WriteLine("Start GetValue1");
            Task.Delay(duration).Wait();
            Console.WriteLine("GetValue1 completes");
            return 1;
        }
        static int GetValue2(int duration)
        {
            Console.WriteLine("Start GetValue2");
            Task.Delay(duration).Wait();
            Console.WriteLine("GetValue2 completes");
            return 2;
        }
    }
}
