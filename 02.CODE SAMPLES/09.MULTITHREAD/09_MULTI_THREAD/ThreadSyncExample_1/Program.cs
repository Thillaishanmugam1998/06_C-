using System;
using System.Threading;

namespace ThreadSyncExample_1
{
    class Program
    {
        static int balance = 1000;
        static object lockObj = new object();

        static void Withdraw(int amount)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} trying to withdraw {amount}");

            lock (lockObj) // 🔒 synchronization starts
            {
                if (balance >= amount)
                {
                    Thread.Sleep(1000);
                    balance -= amount;
                    Console.WriteLine($"{Thread.CurrentThread.Name} completed withdrawal. Balance: {balance}");
                }
                else
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} - Insufficient balance");
                }
            } // 🔓 synchronization ends
        }

        static void Main()
        {
            Thread t1 = new Thread(() => Withdraw(800)) { Name = "Thread1" };
            Thread t2 = new Thread(() => Withdraw(800)) { Name = "Thread2" };

            t1.Start();
            t2.Start();
        }
    }
}

#region OUTPUT
/*
 * Thread1 trying to withdraw 800
Thread1 completed withdrawal. Balance: 200
Thread2 trying to withdraw 800
Thread2 - Insufficient balance
என்ன advantage?

✔ Only one thread inside lock at a time
✔ No data corruption
✔ Business rule maintained
 */
#endregion
