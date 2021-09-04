using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncEx4
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Task<int> t1 = GetValue1(2000);
            Task<int> t2 = GetValue2(3000);
            await t1;
            int i = t1.Result;
            await t2;
            int j = t2.Result;
            int k = i + j;
            stopWatch.Stop();
            Console.WriteLine("Total time: {0}", stopWatch.ElapsedMilliseconds);
        }
        async static Task<int> GetValue1(int duration)
        {
            Console.WriteLine("Start GetValue1");
            await Task.Delay(duration);
            Console.WriteLine("GetValue1 completes");
            return 1;
        }
        async static Task<int> GetValue2(int duration)
        {
            Console.WriteLine("Start GetValue2");
            Task.Delay(duration).Wait();
            Console.WriteLine("GetValue2 completes");
            return 2;
        }
    }
}
