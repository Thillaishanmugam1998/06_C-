using System;
using System.Threading;
using System.Diagnostics;

namespace ThreadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 01. SINGLE THREAD APPLICATION WITH STOPWATCH
            ///*
            // PURPOSE:
            // --------
            // - Demonstrates single-thread execution
            // - Measures total execution time using Stopwatch

            // EXPECTED TIME:
            // Method1 = 10 seconds
            // Method2 = 20 seconds
            // Method3 =  1 second
            // --------------------
            // TOTAL   ≈ 31 seconds
            //*/

            //Console.WriteLine("Main Method Started");

            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            //_1_SingleThreadDemo singleThread = new _1_SingleThreadDemo();

            //singleThread.Method1();
            //singleThread.Method2();
            //singleThread.Method3();

            //stopwatch.Stop();

            //Console.WriteLine("----------------------------------");
            //Console.WriteLine("All methods completed");
            //Console.WriteLine($"Total Execution Time : {stopwatch.Elapsed.TotalSeconds} seconds");
            //Console.WriteLine("----------------------------------");

            //Console.ReadLine();
            #endregion

            #region 02. MULTI THREAD APPLICATION WITH STOPWATCH
            /*
             PURPOSE:
             --------
             - Demonstrates single-thread execution
             - Measures total execution time using Stopwatch

             EXPECTED TIME:
             Method1 = 10 seconds
             Method2 = 20 seconds
             Method3 =  1 second
             --------------------
             TOTAL   ≈ 31 seconds
            */

            //Console.WriteLine("Main Method Started");

            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            //_1_SingleThreadDemo MultiThread = new _1_SingleThreadDemo();

            //Thread t1 = new Thread(MultiThread.Method1);
            //Thread t2 = new Thread(MultiThread.Method2);
            //Thread t3 = new Thread(MultiThread.Method3);

            //t1.Start();
            //t2.Start();
            //t3.Start();

            //t1.Join();
            //t2.Join();
            //t3.Join();   //Here why join used?  see the region 3 
            //stopwatch.Stop();

            //Console.WriteLine("----------------------------------");
            //Console.WriteLine("All methods completed");
            //Console.WriteLine($"Total Execution Time : {stopwatch.Elapsed.TotalSeconds} seconds");
            //Console.WriteLine("----------------------------------");


            #endregion

            #region 03. WHY USE JOIN? WITH JOIN VS WITHOUT JOIN
            /*
             * Dependency irundha → WAIT (Join / await)
             * Dependency illena → NO NEED to wait
             * Multiple Threads Are Running but No one Thread output dont read, dont depend => Threads are independent
             * Multiple Threads Are Running one Thread will depend on another thread output or after main thread some crictical
             * --Work based on any other thread => Threads are dependent. (MUST USE JOIN)
             */

            ATMOperations atm = new ATMOperations();

            Thread t1 = new Thread(atm.ReadCard);
            Thread t2 = new Thread(atm.FetchBalance); // IMPORTANT
            Thread t3 = new Thread(atm.PrintReceipt);

            t1.Start();
            t2.Start();
            t3.Start();

            #region CASE 1 : WITHOUT JOIN (❌ WRONG)
            /*
            REAL LIFE:
            ---------
            Balance innum varala
            ATM tries to give cash
            → Transaction failed
            */

            Console.WriteLine("\nCASE-1 : WITHOUT JOIN");
            atm.DispenseCash();   // ❌ Wrong
            #endregion

            #region CASE 2 : WITH JOIN (✅ CORRECT)
            /*
            REAL LIFE:
            ---------
            ATM waits till balance fetched
            Then gives cash
            */

            t2.Join(); // WAIT ONLY FOR BALANCE THREAD

            Console.WriteLine("\nCASE-2 : WITH JOIN");
            atm.DispenseCash();   // ✅ Correct
            #endregion

            #endregion

        }
    }
}
