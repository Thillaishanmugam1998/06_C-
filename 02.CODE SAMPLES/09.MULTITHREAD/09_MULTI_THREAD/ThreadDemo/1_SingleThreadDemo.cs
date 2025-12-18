using System;
using System.Threading;

namespace ThreadDemo
{
    public class _1_SingleThreadDemo
    {
        #region METHOD 1
        public void Method1()
        {
            Console.WriteLine($"Method-1 Started : {DateTime.Now:HH:mm:ss}");

            Thread.Sleep(10000); // 10 seconds

            Console.WriteLine($"Method-1 Ended   : {DateTime.Now:HH:mm:ss}");
        }
        #endregion

        #region METHOD 2
        public void Method2()
        {
            Console.WriteLine($"Method-2 Started : {DateTime.Now:HH:mm:ss}");

            Thread.Sleep(20000); // 20 seconds

            Console.WriteLine($"Method-2 Ended   : {DateTime.Now:HH:mm:ss}");
        }
        #endregion

        #region METHOD 3
        public void Method3()
        {
            Console.WriteLine($"Method-3 Started : {DateTime.Now:HH:mm:ss}");

            Thread.Sleep(1000); // 1 second

            Console.WriteLine($"Method-3 Ended   : {DateTime.Now:HH:mm:ss}");
        }
        #endregion
    }
}
