using System;
using System.Collections;

namespace _4_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 01. Queue Definition
            /*
             * Queue (Non-Generic Collection)
             * - Namespace: System.Collections
             * - Stores objects in FIFO (First In, First Out) order.
             * - Methods:
             *   Enqueue(object) → Add item at the back
             *   Dequeue()       → Remove + return front item
             *   Peek()          → Return front item without removing
             *   Contains(obj)   → Check if item exists
             *   Clear()         → Remove all items
             *   Clone()         → Create shallow copy
             * - Similar to generic Queue<T>, but stores object type.
             */
            #endregion

            #region 02. Initialization
            Queue line = new Queue(); // Empty queue
            #endregion

            #region 03. Adding Items (Enqueue)
            line.Enqueue("First Person");
            line.Enqueue("Second Person");
            line.Enqueue("Third Person");
            #endregion

            #region 04. Remove Item (Dequeue)
            Console.WriteLine("Removed (Dequeue): " + line.Dequeue()); // Removes first item
            #endregion

            #region 05. Peek (Front Element)
            Console.WriteLine("Front Element (Peek): " + line.Peek()); // Shows next item without removing
            #endregion

            #region 06. Count
            Console.WriteLine("Queue Count: " + line.Count);
            #endregion

            #region 07. Printing Queue Elements
            Console.WriteLine("\nQueue Items (Front to Back):");
            foreach (var item in line)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region 08. Contains
            bool isValid = line.Contains("First Person");
            Console.WriteLine("\nContains 'First Person'? " + isValid);
            #endregion

            #region 09. Clone
            Queue line2 = (Queue)line.Clone(); // Creates shallow copy
            Console.WriteLine("Cloned Queue Count: " + line2.Count);
            #endregion

            #region 10. Clear
            line.Clear();
            Console.WriteLine("Original Queue Count after Clear(): " + line.Count);
            #endregion

            #region 11. CopyTo Example
            object[] line3 = new object[line2.Count];
            line2.CopyTo(line3, 0);

            Console.WriteLine("\nCopied Elements from Cloned Queue:");
            foreach (var item in line3)
                Console.WriteLine(item);
            #endregion
        }
    }
}
