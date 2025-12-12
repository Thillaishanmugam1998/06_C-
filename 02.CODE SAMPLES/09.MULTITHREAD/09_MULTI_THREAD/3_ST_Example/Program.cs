//Example for Multi Thread?

using System.Threading;
using System;
namespace ThreadingDemo
{
    class Program_SingleThread
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Method1) { Name = "Thread-1"};
            Thread t2 = new Thread(Method2) { Name = "Thread2"};
            Thread t3 = new Thread(Method3) { Name = "Thread3" };

            t1.Start();
            t2.Start();
            t3.Start();

            Console.WriteLine("Main Thread Finshed");
        }
        static void Method1()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method1 :" + i);
            }
        }
        static void Method2()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method2 :" + i);
                if (i == 3)
                {
                    Console.WriteLine("Performing the Database Operation Started");
                    //Sleep for 10 seconds
                    Thread.Sleep(10000);
                    Console.WriteLine("Performing the Database Operation Completed");
                }
            }
        }
        static void Method3()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method3 :" + i);
            }
        }
    }
}

/*output of above
Method2 :1
Method2 :2
Method3 :1
Method3 :2
Method3 :3
Method3 :4
Method3 :5
Method1 :1
Method1 :2
Method1 :3
Method1 :4
Method1 :5
Method2 :3
Performing the Database Operation Started
Main Thread Finshed
Performing the Database Operation Completed
Method2 :4
Method2 :5
*/