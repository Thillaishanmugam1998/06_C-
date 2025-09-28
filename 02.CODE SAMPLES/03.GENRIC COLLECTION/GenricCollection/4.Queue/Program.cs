using System;
using System.Collections.Generic;

namespace _4.Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            #region What is Queue<T>?
            /*
             * Queue<T> is a generic collection that works on the principle:
             * FIFO = First In, First Out.
             * 
             * Example in real life: 
             * - Think of a line at a ticket counter.
             *   The first person in line gets served first.
             * 
             * Key Methods:
             * - Enqueue() → Add element to end of queue
             * - Dequeue() → Remove and return element from front
             * - Peek()    → Return front element (without removing)
             * - Contains() → Check if an item exists
             * - Clear() → Remove all items
             * - Count → Number of items
             */
            #endregion

            #region Create a Queue
            Queue<int> numbers = new Queue<int>();
            #endregion

            #region Add Elements (Enqueue)
            numbers.Enqueue(10);
            numbers.Enqueue(5);
            numbers.Enqueue(2);
            numbers.Enqueue(1);
            numbers.Enqueue(3);
            numbers.Enqueue(4);
            Console.WriteLine("Numbers enqueued into the queue.");
            #endregion

            #region Retrieve Elements
            // Dequeue → removes and returns the element from the front
            int first = numbers.Dequeue();
            Console.WriteLine("First Removed (Dequeue): " + first);

            // Peek → returns the element at the front without removing
            int front = numbers.Peek();
            Console.WriteLine("Current Front (Peek): " + front);
            #endregion

            #region Check Existence
            Console.WriteLine("Contains 4? " + numbers.Contains(4));
            #endregion

            #region Iterate Queue
            Console.WriteLine("Remaining Queue (Front to End):");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
            #endregion

            #region Count
            Console.WriteLine("Total Elements in Queue: " + numbers.Count);
            #endregion

            #region Clear Queue
            numbers.Clear();
            Console.WriteLine("Queue cleared. Count = " + numbers.Count);
            #endregion
        }
    }
}
