using System;
using System.Threading;

namespace _1.MONITOR_EXAMPLE
{
    class Program
    {
        #region WHAT IS MONITOR IN C#?
        /*
         * Monitor is a low-level synchronization class that requires explicit Enter and Exit calls. 
         * The lock keyword is a higher-level, 
         * safer abstraction built on top of Monitor that automatically handles Enter and Exit using try-finally.
         */
        #endregion

        // Shared resource
        static int balance = 1000;

        // Lock object (common for both)
        static object lockObj = new object();

        // =========================
        // 1️⃣ USING MONITOR (Manual)
        // =========================
        static void Withdraw_WithMonitor(int amount)
        {
            Monitor.Enter(lockObj); // 🔒 explicit enter
            try
            {
                if (balance >= amount)
                {
                    Thread.Sleep(1000);
                    balance -= amount;
                    Console.WriteLine($"[Monitor] {Thread.CurrentThread.Name} Balance: {balance}");
                }
                else
                {
                    Console.WriteLine($"[Monitor] {Thread.CurrentThread.Name} Insufficient balance");
                }
            }
            finally
            {
                Monitor.Exit(lockObj); // 🔓 MUST exit
            }
        }

        // =========================
        // 2️⃣ USING LOCK (Recommended)
        // =========================
        static void Withdraw_WithLock(int amount)
        {
            lock (lockObj) // 🔒 internally Monitor.Enter
            {
                if (balance >= amount)
                {
                    Thread.Sleep(1000);
                    balance -= amount;
                    Console.WriteLine($"[Lock] {Thread.CurrentThread.Name} Balance: {balance}");
                }
                else
                {
                    Console.WriteLine($"[Lock] {Thread.CurrentThread.Name} Insufficient balance");
                }
            } // 🔓 internally Monitor.Exit
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== MONITOR EXAMPLE ===");

            Thread t1 = new Thread(() => Withdraw_WithMonitor(800)) { Name = "Thread1" };
            Thread t2 = new Thread(() => Withdraw_WithMonitor(800)) { Name = "Thread2" };

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            // Reset balance for lock example
            balance = 1000;

            Console.WriteLine("\n=== LOCK EXAMPLE ===");

            Thread t3 = new Thread(() => Withdraw_WithLock(800)) { Name = "Thread3" };
            Thread t4 = new Thread(() => Withdraw_WithLock(800)) { Name = "Thread4" };

            t3.Start();
            t4.Start();
        }
    }
}
