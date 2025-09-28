using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentQueueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 🔹 ConcurrentQueue is thread-safe for multiple readers and writers
            ConcurrentQueue<int> cq = new ConcurrentQueue<int>();

            // -------------------------------
            // 1. Enqueue items (Add to queue)
            // -------------------------------
            cq.Enqueue(10);
            cq.Enqueue(20);
            cq.Enqueue(30);

            Console.WriteLine("After Enqueue: Count = " + cq.Count);
            // Output: 3

            // -------------------------------
            // 2. TryPeek (See next item without removing)
            // -------------------------------
            if (cq.TryPeek(out int peekItem))
            {
                Console.WriteLine("TryPeek: " + peekItem);
                // Output: 10 (first element, queue order preserved)
            }

            // -------------------------------
            // 3. TryDequeue (Remove and return next item)
            // -------------------------------
            if (cq.TryDequeue(out int dequeuedItem))
            {
                Console.WriteLine("TryDequeue: " + dequeuedItem);
                // Output: 10 (removed from queue)
            }

            Console.WriteLine("After Dequeue: Count = " + cq.Count);
            // Output: 2

            // -------------------------------
            // 4. Enqueue more items (for demo)
            // -------------------------------
            cq.Enqueue(40);
            cq.Enqueue(50);
            cq.Enqueue(60);

            Console.WriteLine("After adding more: Count = " + cq.Count);
            // Output: 5

            // -------------------------------
            // 5. Iterate over queue (snapshot, no modification)
            // -------------------------------
            Console.WriteLine("Iterating over items:");
            foreach (var item in cq)
            {
                Console.WriteLine(item);
                // Output: 20,30,40,50,60
            }

            // -------------------------------
            // 6. ToArray (Convert queue to array safely)
            // -------------------------------
            int[] arr = cq.ToArray();
            Console.WriteLine("ToArray result: " + string.Join(", ", arr));
            // Output: 20,30,40,50,60

            // -------------------------------
            // 7. Clear (Not available in ConcurrentQueue ❌)
            // -------------------------------
            // Instead, you must dequeue all items manually
            while (cq.TryDequeue(out _)) { }
            Console.WriteLine("After manual clear: Count = " + cq.Count);
            // Output: 0

            // -------------------------------
            // 8. Multi-threaded example (safe!)
            // -------------------------------
            ConcurrentQueue<int> sharedQueue = new ConcurrentQueue<int>();

            Task t1 = Task.Run(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    sharedQueue.Enqueue(i);
                    Console.WriteLine($"Task1 enqueued {i}");
                    Thread.Sleep(50); // simulate work
                }
            });

            Task t2 = Task.Run(() =>
            {
                for (int i = 6; i <= 10; i++)
                {
                    sharedQueue.Enqueue(i);
                    Console.WriteLine($"Task2 enqueued {i}");
                    Thread.Sleep(50); // simulate work
                }
            });

            Task t3 = Task.Run(() =>
            {
                Thread.Sleep(100); // wait for some items to appear
                while (!sharedQueue.IsEmpty)
                {
                    if (sharedQueue.TryDequeue(out int item))
                    {
                        Console.WriteLine($"Task3 dequeued {item}");
                    }
                }
            });

            Task.WaitAll(t1, t2, t3);

            Console.WriteLine("Final Count: " + sharedQueue.Count);
        }
    }
}
