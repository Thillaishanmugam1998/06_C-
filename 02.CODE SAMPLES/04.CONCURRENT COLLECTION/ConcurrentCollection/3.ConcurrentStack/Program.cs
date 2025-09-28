using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentStackExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 🔹 Create a thread-safe stack
            ConcurrentStack<string> stack = new ConcurrentStack<string>();

            // -------------------------------
            // 1. Push (add item on top)
            // -------------------------------
            stack.Push("Google");
            stack.Push("Amazon");
            stack.Push("YouTube");

            // 🔹 PushRange (add multiple items atomically)
            stack.PushRange(new string[] { "Netflix", "Twitter" });

            Console.WriteLine("After Push & PushRange:");
            foreach (var item in stack)
                Console.WriteLine(item);
            /*
             Output order (LIFO):
             Twitter
             Netflix
             YouTube
             Amazon
             Google
            */

            // -------------------------------
            // 2. TryPeek (look at top without removing)
            // -------------------------------
            if (stack.TryPeek(out string peekItem))
                Console.WriteLine("TryPeek: " + peekItem); // Twitter

            // -------------------------------
            // 3. TryPop (remove top safely)
            // -------------------------------
            if (stack.TryPop(out string poppedItem))
                Console.WriteLine("TryPop: " + poppedItem); // Twitter

            // -------------------------------
            // 4. TryPopRange (pop multiple items atomically)
            // -------------------------------
            string[] poppedItems = new string[2];
            int poppedCount = stack.TryPopRange(poppedItems);

            Console.WriteLine($"TryPopRange popped {poppedCount} items:");
            foreach (var item in poppedItems)
                Console.WriteLine(item);
            /*
             Output:
             Netflix
             YouTube
            */

            // -------------------------------
            // 5. Properties
            // -------------------------------
            Console.WriteLine("Count: " + stack.Count);
            Console.WriteLine("IsEmpty: " + stack.IsEmpty);

            // -------------------------------
            // 6. Multi-threaded Example
            // -------------------------------
            ConcurrentStack<int> numStack = new ConcurrentStack<int>();

            Task t1 = Task.Run(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    numStack.Push(i);
                    Console.WriteLine($"Task1 Pushed: {i}");
                    Thread.Sleep(50);
                }
            });

            Task t2 = Task.Run(() =>
            {
                for (int i = 6; i <= 10; i++)
                {
                    numStack.Push(i);
                    Console.WriteLine($"Task2 Pushed: {i}");
                    Thread.Sleep(50);
                }
            });

            Task.WaitAll(t1, t2);

            Console.WriteLine("\nFinal ConcurrentStack:");
            while (numStack.TryPop(out int val))
            {
                Console.WriteLine("Popped: " + val);
            }
        }
    }
}
