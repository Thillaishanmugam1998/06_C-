using System;
using System.Threading;

namespace DeadLOCK
{
    class Program
    {
        // Two shared resources
        static object LockA = new object();
        static object LockB = new object();

        static void Main(string[] args)
        {
            #region DEADLOCK_DEMO_START
            /*
             WHAT IS DEADLOCK?
             ----------------
             Deadlock na:
             - 2 threads irukum
             - Each thread oru lock ah pidichirukum
             - Innum oru lock venum nu wait pannum
             - Aana andha lock vera thread kitta irukum
             - Result: rendu thread-um forever wait pannum
            */

            Thread t1 = new Thread(Thread1Work);
            Thread t2 = new Thread(Thread2Work);

            t1.Start();
            t2.Start();
            #endregion

            Console.ReadLine();
        }

        #region DEADLOCK_EXAMPLE
        // Thread 1: LockA -> LockB
        static void Thread1Work()
        {
            lock (LockA)
            {
                Console.WriteLine("Thread 1 locked LockA");
                Thread.Sleep(100); // small delay

                lock (LockB)
                {
                    Console.WriteLine("Thread 1 locked LockB");
                }
            }
        }

        // Thread 2: LockB -> LockA (REVERSE ORDER)
        static void Thread2Work()
        {
            lock (LockB)
            {
                Console.WriteLine("Thread 2 locked LockB");
                Thread.Sleep(100); // small delay

                lock (LockA)
                {
                    Console.WriteLine("Thread 2 locked LockA");
                }
            }
        }
        #endregion
    }
