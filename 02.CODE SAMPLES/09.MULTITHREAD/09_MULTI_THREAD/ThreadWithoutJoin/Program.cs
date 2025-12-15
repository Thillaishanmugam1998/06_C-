using System;
using System.Threading;

namespace ThreadWithoutJoin
{
    class Program
    {
        static void Worker()
        {
            Console.WriteLine("Worker started");
            Thread.Sleep(2000);
            Console.WriteLine("Worker finished");
        }

        static void Main()
        {
            Thread t = new Thread(Worker);
            t.Start();

            Console.WriteLine("Main thread finished");
        }
    }
}

#region output
/*
 * என்ன problem?

Main thread wait பண்ணல

fileData இன்னும் read ஆகல

❌ NullReferenceException
 */
#endregion
