using System;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphoreVsLockDemo
{
    class Program
    {
        #region 1_GLOBAL_VARIABLES
        // SemaphoreSlim : only 3 threads/tasks allowed at same time
        static SemaphoreSlim semaphore = new SemaphoreSlim(3);

        // lock object : only ONE thread allowed
        static object lockObj = new object();
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("========== SEMAPHORESLIM DEMO ==========\n");

            #region 2_SEMAPHORESLIM_THREAD_DEMO
            /*
             We start 5 THREADS
             SemaphoreSlim count = 3
             So:
             - First 3 threads ENTER immediately
             - Remaining 2 threads WAIT
            */
            for (int i = 1; i <= 5; i++)
            {
                int count = i;
                Thread t = new Thread(() =>
                    SemaphoreSlimFunction("Thread " + count, 1000 * count)
                );
                t.Start();
            }

            Thread.Sleep(8000); // wait before next demo
            #endregion

            Console.WriteLine("\n========== LOCK DEMO ==========\n");

            #region 3_LOCK_THREAD_DEMO
            /*
             We start 5 THREADS
             lock allows ONLY ONE thread at a time
             So:
             - Thread 1 ENTERS
             - Thread 2,3,4,5 all WAIT
             - One-by-one execution
            */
            for (int i = 1; i <= 5; i++)
            {
                int count = i;
                Thread t = new Thread(() =>
                    LockFunction("Thread " + count, 1000 * count)
                );
                t.Start();
            }
            #endregion

            Console.ReadLine();
        }

        #region 4_SEMAPHORESLIM_FUNCTION
        static void SemaphoreSlimFunction(string name, int milliseconds)
        {
            Console.WriteLine($"{name} WAITING for SemaphoreSlim");

            semaphore.Wait(); // COUNT--

            try
            {
                Console.WriteLine($"{name} ENTERED (SemaphoreSlim)");
                Thread.Sleep(milliseconds); // simulate work
                Console.WriteLine($"{name} COMPLETED (SemaphoreSlim)");
            }
            finally
            {
                semaphore.Release(); // COUNT++
            }
        }
        #endregion

        #region 5_LOCK_FUNCTION
        static void LockFunction(string name, int milliseconds)
        {
            Console.WriteLine($"{name} WAITING for lock");

            lock (lockObj) // ONLY ONE thread allowed
            {
                Console.WriteLine($"{name} ENTERED (lock)");
                Thread.Sleep(milliseconds); // simulate work
                Console.WriteLine($"{name} COMPLETED (lock)");
            }
        }
        #endregion

        #region 6_EXPECTED_OUTPUT_EXPLANATION
        /*
        ================= SEMAPHORESLIM OUTPUT =================

        Thread 1 WAITING for SemaphoreSlim
        Thread 1 ENTERED (SemaphoreSlim)

        Thread 2 WAITING for SemaphoreSlim
        Thread 2 ENTERED (SemaphoreSlim)

        Thread 3 WAITING for SemaphoreSlim
        Thread 3 ENTERED (SemaphoreSlim)

        Thread 4 WAITING for SemaphoreSlim
        Thread 5 WAITING for SemaphoreSlim

        ---- after someone finishes ----
        Thread 1 COMPLETED (SemaphoreSlim)
        Thread 4 ENTERED (SemaphoreSlim)

        Thread 2 COMPLETED (SemaphoreSlim)
        Thread 5 ENTERED (SemaphoreSlim)

        👉 At MAXIMUM 3 threads run at same time

        ================= LOCK OUTPUT =================

        Thread 1 WAITING for lock
        Thread 1 ENTERED (lock)

        Thread 2 WAITING for lock
        Thread 3 WAITING for lock
        Thread 4 WAITING for lock
        Thread 5 WAITING for lock

        Thread 1 COMPLETED (lock)
        Thread 2 ENTERED (lock)

        Thread 2 COMPLETED (lock)
        Thread 3 ENTERED (lock)

        👉 ONLY ONE thread at a time (serial execution)

        ========================================================

        FINAL DIFFERENCE:
        -----------------
        SemaphoreSlim(3) -> 3 threads parallel
        lock             -> 1 thread only
        */
        #endregion
    }
}
