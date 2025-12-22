using System;
using System.Threading;

namespace ThreadStopDemo
{
    class Program
    {
        static volatile bool stopThread = false;

        static void Main(string[] args)
        {
            Thread worker = new Thread(DoWork);
            worker.Start();

            Thread.Sleep(3000); // let thread run
            Console.WriteLine("Main thread requesting STOP");
            stopThread = true;

            worker.Join(); // wait for thread to exit safely
            Console.WriteLine("Worker thread stopped safely");
        }

        static void DoWork()
        {
            while (!stopThread)
            {
                Console.WriteLine("Thread running...");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Thread exiting gracefully");
        }

        #region OUTPUT
        /*
        Thread running...
        Thread running...
        Thread running...
        Main thread requesting STOP
        Thread exiting gracefully
        Worker thread stopped safely
        */
        #endregion
    }
}
