//1) WHAT IS THREAD SYNCHRONIZATION? 
//2) WITHOUT THREAD SYNCHRONIZATION?
using System;
using System.Threading;

class Program
{
    static int balance = 1000;

    static void Withdraw(int amount)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} trying to withdraw {amount}");

        if (balance >= amount)
        {
            Thread.Sleep(1000); // simulate processing delay
            balance -= amount;
            Console.WriteLine($"{Thread.CurrentThread.Name} completed withdrawal. Balance: {balance}");
        }
        else
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} - Insufficient balance");
        }
    }

    static void Main()
    {
        //Error CS1503  Argument 1: cannot convert from 'void' to 'System.Threading.ParameterizedThreadStart' 
        //Thread t1 = new Thread(Withdraw(800)); //Error 

        Thread t1 = new Thread(() => Withdraw(800)) { Name = "Thread1" };
        Thread t2 = new Thread(() => Withdraw(800)) { Name = "Thread2" };


        t1.Start();
        t2.Start();
    }
}

#region OUTPUT 
/*
 * Thread1 trying to withdraw 800
Thread2 trying to withdraw 800
Thread1 completed withdrawal. Balance: 200
Thread2 completed withdrawal. Balance: -600
என்ன problem?

Both threads same time-ல balance check

Both think balance enough

❌ Negative balance → Data inconsistency

👉 Race Condition
 */
#endregion