using System;
using System.Threading;

namespace _5.MUTEX_EXAMPLES
{
    class Program
    {
        // Named Mutex → shared across applications (processes)
        static Mutex _mutex;

        static void Main(string[] args)
        {
            #region WHY MUTEX ALREADY WE HAVE LOCK & MONITOR
            /*
             * lock / Monitor:
             * ----------------
             * - Works only inside SAME application (In-Process threads)
             * - Cannot control threads from another EXE
             *
             * Mutex:
             * ------
             * - Works across MULTIPLE applications (Out-Process)
             * - Uses OS kernel → slower but powerful
             *
             * Real-Time Use Case:
             * ------------------
             * - Prevent multiple instances of an application
             * - Shared file / hardware access
             * - Admin tools, services, schedulers
             */
            #endregion

            bool isCreatedNew;

            // Global → allows multiple applications to see the same mutex
            _mutex = new Mutex(true, "Global\\FileHostingToolMutex", out isCreatedNew);

            if (!isCreatedNew)
            {
                Console.WriteLine("❌ Another instance is already running.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("✅ Application started successfully.");
            Console.WriteLine("Mutex acquired. Only THIS instance can run.");
            Console.WriteLine();
            Console.WriteLine("Try opening this EXE again from Command Line.");
            Console.WriteLine();
            Console.WriteLine("Press ENTER to release Mutex and exit...");

            Console.ReadLine();

            // Always release the mutex
            _mutex.ReleaseMutex();
            _mutex.Dispose();
        }
    }
}
