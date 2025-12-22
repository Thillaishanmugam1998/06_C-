using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadPoolApplication
{
    class Program
    {
        #region WHAT IS THREAD LIFE CYCLE & THREAD POOL (IMPORTANT)

        /*
        ================================
        THREAD LIFE CYCLE IN C#
        ================================

        1) Unstarted
           - Thread object is created using new Thread()
           - Thread is NOT yet scheduled by OS

        2) Running
           - thread.Start() is called
           - OS scheduler assigns CPU time
           - Thread executes the method

        3) Waiting / Blocked
           - Thread.Sleep()
           - Waiting for lock / monitor / IO
           - Waiting for another thread (Join)

        4) Terminated (Dead)
           - Method execution completes
           - Thread is destroyed
           - Thread CANNOT be restarted again

        IMPORTANT:
        ----------
        - Every "new Thread()" follows full life cycle
        - Creation + destruction is COSTLY
        - Memory + context switching overhead is HIGH


        ================================
        WHAT IS THREAD POOL?
        ================================

        ThreadPool is a collection of REUSABLE background threads
        managed by the CLR (Common Language Runtime).

        - Threads are CREATED ONCE
        - Tasks are QUEUED
        - Threads are REUSED after execution

        Think like:
        Taxi Stand 🧾
        - Taxi already exists (thread)
        - Passenger comes (task)
        - Drop passenger
        - Taxi returns to stand (reuse)


        ================================
        THREAD POOL THREAD LIFE CYCLE
        ================================

        1) Thread is already created by CLR
        2) Your task is queued (QueueUserWorkItem)
        3) Free thread picks the task
        4) Executes method
        5) Returns back to pool (NOT destroyed)

        ⚠ Thread is NOT terminated after task completion


        ================================
        WHY THREAD POOL IS FASTER?
        ================================

        new Thread():
        - Create OS thread ❌
        - Allocate stack memory ❌
        - Context switching ❌
        - Destroy thread ❌

        ThreadPool:
        - No creation cost ✅
        - No destruction cost ✅
        - Reuse existing threads ✅
        - Less memory usage ✅


        ================================
        WHEN TO USE THREAD POOL?
        ================================

        USE ThreadPool WHEN:
        --------------------
        ✔ Short-running tasks
        ✔ Background operations
        ✔ Logging
        ✔ File read/write
        ✔ Network calls
        ✔ Parallel small jobs

        DO NOT USE ThreadPool WHEN:
        ----------------------------
        ❌ Long-running tasks
        ❌ Need thread priority
        ❌ Need thread name
        ❌ Dedicated thread required


        ================================
        WHAT YOUR STOPWATCH TEST PROVES
        ================================

        MethodWithThread():
        - Creates 10 NEW threads every time
        - High overhead
        - More time consumed

        MethodWithThreadPool():
        - Reuses existing threads
        - Low overhead
        - Faster execution

        That is why:
        ThreadPool elapsed ticks < Thread elapsed ticks

        ================================
        IMPORTANT INTERVIEW POINT
        ================================

        Modern C# internally uses ThreadPool via:
        - Task
        - async / await
        - Parallel.ForEach

        So learning ThreadPool = understanding async performance

        */

        #endregion

        static void Main(string[] args)
        {
            // Warmup Code start (JIT + ThreadPool initialization)
            for (int i = 0; i < 10; i++)
            {
                MethodWithThread();
                MethodWithThreadPool();
            }
            // Warmup Code end

            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Execution using Thread");
            stopwatch.Start();
            MethodWithThread();
            stopwatch.Stop();
            Console.WriteLine("Time consumed by MethodWithThread is : " +
                                 stopwatch.ElapsedTicks.ToString());

            stopwatch.Reset();

            Console.WriteLine("Execution using Thread Pool");
            stopwatch.Start();
            MethodWithThreadPool();
            stopwatch.Stop();
            Console.WriteLine("Time consumed by MethodWithThreadPool is : " +
                                 stopwatch.ElapsedTicks.ToString());

            Console.Read();
        }

        public static void MethodWithThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(Test);
                thread.Start();
            }
        }

        public static void MethodWithThreadPool()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Test));
            }
        }

        public static void Test(object obj)
        {
            Thread thread = Thread.CurrentThread;
            string message =
                $"Background: {thread.IsBackground}, " +
                $"Thread Pool: {thread.IsThreadPoolThread}, " +
                $"Thread ID: {thread.ManagedThreadId}";

            Console.WriteLine(message);
        }
    }
}
