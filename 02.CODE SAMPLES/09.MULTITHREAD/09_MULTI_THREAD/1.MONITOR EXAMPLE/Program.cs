using System;
using System.Threading;

namespace _1.MONITOR_EXAMPLE
{
    class Program
    {
        #region 1. WHAT IS THREAD SYNCHRONIZATION?
        /*
         * THREAD SYNCHRONIZATION:
         * ----------------------
         * When multiple threads access SAME shared resource
         * at the SAME time, data inconsistency may happen.
         *
         * To prevent this:
         * ----------------
         * We allow ONLY ONE thread at a time
         * to enter the critical section.
         */
        #endregion


        #region 2. REAL-WORLD SCENARIO (BANK ACCOUNT)
        /*
         * SCENARIO:
         * ---------
         * Bank account balance = 1000
         *
         * Two customers try to withdraw 800 at SAME time.
         *
         * WITHOUT synchronization:
         * ------------------------
         * Both threads read balance = 1000
         * Both withdraw 800
         * Final balance becomes WRONG (negative or invalid)
         *
         * WITH synchronization:
         * ---------------------
         * One thread withdraws first
         * Second thread sees updated balance
         */
        #endregion


        #region 3. SHARED RESOURCE
        /*
         * SHARED RESOURCE:
         * ----------------
         * balance is shared by multiple threads.
         * This MUST be protected.
         */
        #endregion
        static int balance = 1000;


        #region 4. LOCK OBJECT
        /*
         * LOCK OBJECT:
         * ------------
         * All threads must lock on SAME object.
         * This object acts like a KEY.
         */
        #endregion
        static object lockObj = new object();


        #region 5. WHAT IS MONITOR IN C#?
        /*
         * MONITOR:
         * --------
         * - Low-level synchronization class.
         * - Requires EXPLICIT calls:
         *      Monitor.Enter()
         *      Monitor.Exit()
         *
         * Responsibility is on DEVELOPER.
         *
         * If Exit() is forgotten:
         * -----------------------
         * - Deadlock occurs
         * - Other threads wait forever
         */
        #endregion


        #region 6. WITHDRAW USING MONITOR (MANUAL CONTROL)
        /*
         * FLOW:
         * -----
         * 1) Thread enters Monitor.Enter()
         * 2) Other threads WAIT
         * 3) Work is done
         * 4) Monitor.Exit() MUST be called
         */
        #endregion
        static void Withdraw_WithMonitor(int amount)
        {
            Monitor.Enter(lockObj);   // 🔒 Explicitly enter monitor
            try
            {
                if (balance >= amount)
                {
                    Thread.Sleep(1000);   // simulate delay
                    balance -= amount;
                    Console.WriteLine($"[Monitor] {Thread.CurrentThread.Name} withdrew {amount}. Balance: {balance}");
                }
                else
                {
                    Console.WriteLine($"[Monitor] {Thread.CurrentThread.Name} Insufficient balance");
                }
            }
            finally
            {
                Monitor.Exit(lockObj);    // 🔓 MUST exit
            }
        }


        #region 7. WHAT IS LOCK KEYWORD?
        /*
         * lock:
         * -----
         * - High-level, SAFE abstraction.
         * - Internally uses Monitor.
         *
         * lock(obj)
         * {
         *    // critical section
         * }
         *
         * Internally compiled as:
         * -----------------------
         * Monitor.Enter(obj);
         * try { ... }
         * finally { Monitor.Exit(obj); }
         *
         * RECOMMENDED:
         * ------------
         * Use lock instead of Monitor directly.
         */
        #endregion


        #region 8. WITHDRAW USING LOCK (RECOMMENDED)
        /*
         * ADVANTAGE:
         * ----------
         * - No chance of forgetting Exit
         * - Cleaner code
         * - Less error-prone
         */
        #endregion
        static void Withdraw_WithLock(int amount)
        {
            lock (lockObj)   // 🔒 Monitor.Enter internally
            {
                if (balance >= amount)
                {
                    Thread.Sleep(1000);
                    balance -= amount;
                    Console.WriteLine($"[Lock] {Thread.CurrentThread.Name} withdrew {amount}. Balance: {balance}");
                }
                else
                {
                    Console.WriteLine($"[Lock] {Thread.CurrentThread.Name} Insufficient balance");
                }
            }   // 🔓 Monitor.Exit internally
        }


        static void Main(string[] args)
        {
            #region 9. MONITOR EXECUTION FLOW
            /*
             * Two threads try to withdraw at SAME time.
             * Monitor ensures only ONE thread executes
             * the critical section at a time.
             */
            #endregion
            Console.WriteLine("=== MONITOR EXAMPLE ===");

            Thread t1 = new Thread(() => Withdraw_WithMonitor(800)) { Name = "Thread-1" };
            Thread t2 = new Thread(() => Withdraw_WithMonitor(800)) { Name = "Thread-2" };

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();


            #region 10. RESET DATA FOR LOCK EXAMPLE
            /*
             * Reset balance for fair comparison.
             */
            #endregion
            balance = 1000;


            #region 11. LOCK EXECUTION FLOW
            /*
             * Same scenario as Monitor
             * but using safer lock keyword.
             */
            #endregion
            Console.WriteLine("\n=== LOCK EXAMPLE ===");

            Thread t3 = new Thread(() => Withdraw_WithLock(800)) { Name = "Thread-3" };
            Thread t4 = new Thread(() => Withdraw_WithLock(800)) { Name = "Thread-4" };

            t3.Start();
            t4.Start();

            t3.Join();
            t4.Join();

            Console.ReadLine();
        }


        #region 12. FINAL SUMMARY (VERY IMPORTANT)
        /*
         * Monitor:
         * --------
         * - Manual Enter / Exit
         * - More control
         * - More risk (deadlock if Exit missed)
         *
         * lock:
         * -----
         * - Built on top of Monitor
         * - Automatically handles Enter / Exit
         * - SAFER and RECOMMENDED
         *
         * INTERVIEW LINE:
         * ---------------
         * lock is a syntactic sugar over Monitor.
         */
        #endregion
    }
}
