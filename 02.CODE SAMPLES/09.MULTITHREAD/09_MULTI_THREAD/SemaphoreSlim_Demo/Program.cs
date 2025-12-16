using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphoreSlim_Demo
{
    class Program
    {
        #region 1_WHAT_IS_SEMAPHORESLIM
        /*
        SemaphoreSlim:
        --------------
        SemaphoreSlim is a lightweight synchronization mechanism in C#.

        It is used to CONTROL how many THREADS / TASKS can access
        a SHARED RESOURCE at the SAME TIME.

        It works using a simple COUNT (permission system).

        Example:
        --------
        SemaphoreSlim sem = new SemaphoreSlim(1, 1);

        Meaning:
        - Only ONE permission available
        - Only ONE task/thread can enter
        - Others must WAIT
        */
        #endregion

        #region 2_WHY_SEMAPHORESLIM_EXISTS
        /*
        Why SemaphoreSlim?
        ------------------
        1) lock can handle ONLY ONE thread at a time
        2) lock HOLDS the thread (blocking)
        3) lock CANNOT be used with async/await

        SemaphoreSlim:
        --------------
        - Does NOT hold a thread
        - Holds only a PERMISSION (COUNT)
        - Thread is released back to ThreadPool
        - Supports async/await (WaitAsync)
        */
        #endregion

        #region 3_HOW_SEMAPHORESLIM_WORKS_INTERNAL
        /*
        Internal working (simple):
        --------------------------
        SemaphoreSlim maintains an integer COUNT.

        Initial:
        COUNT = 1

        Task calls WaitAsync():
        ----------------------
        IF COUNT > 0
            COUNT--
            Task ENTERS
        ELSE
            Task WAITS (no thread blocked)

        Task calls Release():
        --------------------
        COUNT++
        Next waiting task is allowed to enter
        */
        #endregion

        #region 4_PERMISSION_MEANING
        /*
        Permission means:
        -----------------
        ONE AVAILABLE SLOT to access a resource.

        It is NOT a thread.
        It is NOT a lock.
        It is just a COUNT value.

        Permission = COUNT
        */
        #endregion

        #region 5_SEMAPHORESLIM_WITH_ASYNC
        /*
        Why SemaphoreSlim is PERFECT for async:
        --------------------------------------
        - async/await releases the thread
        - SemaphoreSlim does NOT depend on thread
        - Permission stays held even when thread changes
        - Safe for file, DB, API, logging operations
        */
        #endregion

        #region 6_COMPARE_WITH_LOCK
        /*
        lock:
        -----
        - Works with THREAD
        - Holds thread until work finishes
        - Async NOT allowed
        - Simple but blocking

        SemaphoreSlim:
        --------------
        - Works with PERMISSION (COUNT)
        - Thread can come and go
        - Async allowed
        - Scalable and efficient
        */
        #endregion

        #region 7_WHEN_TO_USE_SEMAPHORESLIM
        /*
        Use SemaphoreSlim when:
        ----------------------
        - Using async/await
        - Limiting concurrent access (N users)
        - Controlling DB connections
        - Throttling API calls
        - Async logging / background services

        DO NOT use when:
        ----------------
        - Simple sync code
        - Only one thread and no async needed
        */
        #endregion

        #region 8_ONE_LINE_INTERVIEW_DEFINITION
        /*
        SemaphoreSlim controls concurrent access to a shared resource
        using a count-based permission system and supports async/await.
        */
        #endregion


        #region 1_THREAD_vs_TASK_BASIC_CONCEPT
        /*
        THREAD:
        -------
        - Thread = real OS worker
        - CPU-la actual-aa run aagum
        - Heavy (stack, memory, scheduling)
        - Thread block aana → CPU waste

        TASK:
        -----
        - Task = work description (job / promise)
        - Task itself thread illa
        - Runtime (ThreadPool) decide pannum
          endha free thread use pannanum nu
        - Async/await Task mela work pannum
        */
        #endregion

        #region 2_SHARED_RESOURCE_LOG_FILE
        // Shared file (realtime example)
        static string logFilePath = "app.log";

        // lock → sync world
        static object logLock = new object();

        // SemaphoreSlim → async world
        static SemaphoreSlim logSemaphore = new SemaphoreSlim(1, 1);
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("===== DEMO START =====");

            #region 3_SYNC_THREAD_LOCK_DEMO
            /*
            Scenario:
            ---------
            - CPU-la 3 threads irundhaalum
            - lock use pannina
            - Only ONE thread dhaan inside
            */
            Console.WriteLine("\n--- SYNC : Thread + lock ---");

            Thread t1 = new Thread(WriteLog_Sync);
            Thread t2 = new Thread(ReadLog_Sync);
            Thread t3 = new Thread(WriteLog_Sync);

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            #endregion

            #region 4_ASYNC_TASK_SEMAPHORESLIM_DEMO
            /*
            Scenario:
            ---------
            - Same work
            - But async + SemaphoreSlim
            - Thread HOLD illa
            - Permission (COUNT) dhaan control
            */
            Console.WriteLine("\n--- ASYNC : Task + SemaphoreSlim ---");

            Task task1 = WriteLog_Async();
            Task task2 = ReadLog_Async();
            Task task3 = WriteLog_Async();

            Task.WaitAll(task1, task2, task3);
            #endregion

            #region 5_THREADPOOL_DEMO
            /*
            THREAD POOL SCENARIO:
            --------------------
            - Assume ThreadPool has 10 threads
            - 20 Tasks varudhu
            - SemaphoreSlim(2) → only 2 tasks inside
            - Remaining tasks WAIT (cheap)
            */
            Console.WriteLine("\n--- THREADPOOL + SemaphoreSlim DEMO ---");

            SemaphoreSlim poolSemaphore = new SemaphoreSlim(2, 2);

            for (int i = 1; i <= 10; i++)
            {
                int taskNo = i;

                Task.Run(async () =>
                {
                    Console.WriteLine($"Task {taskNo} waiting for permission");

                    await poolSemaphore.WaitAsync(); // COUNT--

                    try
                    {
                        Console.WriteLine($"Task {taskNo} ENTERED (ThreadId: {Thread.CurrentThread.ManagedThreadId})");

                        // simulate async work
                        await Task.Delay(2000);

                        Console.WriteLine($"Task {taskNo} WORK DONE");
                    }
                    finally
                    {
                        poolSemaphore.Release(); // COUNT++
                        Console.WriteLine($"Task {taskNo} EXITED (Thread returned to pool)");
                    }
                });
            }

            Thread.Sleep(15000); // wait for demo
            #endregion

            Console.WriteLine("\n===== DEMO END =====");
            Console.ReadLine();
        }

        #region 6_SYNC_WRITE_LOCK_HOLDS_THREAD
        static void WriteLog_Sync()
        {
            lock (logLock) // THREAD is HELD here
            {
                Console.WriteLine($"[SYNC WRITE] Thread {Thread.CurrentThread.ManagedThreadId} ENTER");

                Thread.Sleep(3000); // slow I/O simulation

                File.AppendAllText(logFilePath, "SYNC WRITE\n");

                Console.WriteLine($"[SYNC WRITE] Thread {Thread.CurrentThread.ManagedThreadId} EXIT");
            }
        }
        #endregion

        #region 7_SYNC_READ_LOCK_HOLDS_THREAD
        static void ReadLog_Sync()
        {
            lock (logLock) // another thread MUST WAIT
            {
                Console.WriteLine($"[SYNC READ] Thread {Thread.CurrentThread.ManagedThreadId} ENTER");

                Thread.Sleep(1500);

                if (File.Exists(logFilePath))
                {
                    File.ReadAllText(logFilePath);
                }

                Console.WriteLine($"[SYNC READ] Thread {Thread.CurrentThread.ManagedThreadId} EXIT");
            }
        }
        #endregion

        #region 8_WHY_LOCK_FAILS_WITH_ASYNC
        /*
        ❌ ILLEGAL CODE:

        lock(logLock)
        {
            await File.AppendAllTextAsync(...);
        }

        WHY?
        ----
        - lock expects SAME THREAD to stay
        - await releases thread to pool
        - lock still held
        - thread mismatch
        - compile time error
        */
        #endregion

        #region 9_ASYNC_WRITE_SEMAPHORE_PERMISSION
        static async Task WriteLog_Async()
        {
            await logSemaphore.WaitAsync(); // TAKE PERMISSION (COUNT--)

            try
            {
                Console.WriteLine($"[ASYNC WRITE] Permission taken (Thread {Thread.CurrentThread.ManagedThreadId})");

                await Task.Delay(3000); // async I/O

                await File.AppendAllTextAsync(logFilePath, "ASYNC WRITE\n");

                Console.WriteLine("[ASYNC WRITE] Work finished");
            }
            finally
            {
                logSemaphore.Release(); // RETURN PERMISSION (COUNT++)
                Console.WriteLine("[ASYNC WRITE] Permission released");
            }
        }
        #endregion

        #region 10_ASYNC_READ_SEMAPHORE_PERMISSION
        static async Task ReadLog_Async()
        {
            await logSemaphore.WaitAsync(); // WAITS if COUNT == 0

            try
            {
                Console.WriteLine($"[ASYNC READ] Permission taken (Thread {Thread.CurrentThread.ManagedThreadId})");

                await Task.Delay(1500);

                if (File.Exists(logFilePath))
                {
                    await File.ReadAllTextAsync(logFilePath);
                }

                Console.WriteLine("[ASYNC READ] Work finished");
            }
            finally
            {
                logSemaphore.Release();
                Console.WriteLine("[ASYNC READ] Permission released");
            }
        }
        #endregion

        #region 11_FINAL_MENTAL_MODEL_SUMMARY
        /*
        LOCK:
        -----
        - Thread-ai HOLD pannum
        - CPU free irundhaalum waste
        - Many threads → heavy memory
        - Async NOT allowed

        TASK + SemaphoreSlim:
        ---------------------
        - Thread-ai release pannum
        - Permission (COUNT) dhaan control
        - Same thread reuse aagum
        - ThreadPool friendly
        - Async PERFECT

        GOLDEN RULE:
        ------------
        Sync code        -> lock
        Async code       -> SemaphoreSlim(1,1)
        Limit concurrency-> SemaphoreSlim(N)
        */
        #endregion
    }
}
