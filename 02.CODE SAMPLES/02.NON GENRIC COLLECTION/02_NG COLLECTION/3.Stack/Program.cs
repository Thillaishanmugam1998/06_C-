using System;
using System.Collections;

namespace StackCollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 01. Stack Definition
            /*
             * Stack (Non-Generic Collection)
             * - Namespace: System.Collections
             * - Stores objects in LIFO (Last In, First Out) order.
             * - Methods:
             *   Push(object)  → Add item to top of stack
             *   Pop()         → Remove + return top item
             *   Peek()        → Return top item without removing
             *   Contains(obj) → Check if an item exists
             *   Clear()       → Remove all items
             *   Clone()       → Create shallow copy
             * - Similar to generic Stack<T> but stores object type.
             */
            #endregion

            #region 02. Initialization
            Stack history = new Stack(); // Empty Stack
            #endregion

            #region 03. Adding Items (Push)
            history.Push("www.google.com");
            history.Push("www.amazon.in");
            history.Push("www.flipkart.in");
            history.Push("www.grok.ae");
            #endregion

            #region 04. Count of Items
            Console.WriteLine("Total items in stack: " + history.Count);
            #endregion

            #region 05. Printing Stack Elements
            Console.WriteLine("\nStack Elements (Top to Bottom):");
            foreach (object item in history)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region 06. Remove Elements (Pop)
            Console.WriteLine($"\nDeleted Element (Pop): {history.Pop()}"); // Removes top element
            Console.WriteLine($"Stack Count after Deletion: {history.Count}");
            #endregion

            #region 07. Peek (View Top Element)
            Console.WriteLine($"Topmost Element (Peek): {history.Peek()}");
            #endregion

            #region 08. Contains
            Console.WriteLine("\nCheck Contains 'www.google.com': " + history.Contains("www.google.com"));
            #endregion

            #region 09. Clone
            Stack webHistory = (Stack)history.Clone(); // Shallow copy
            Console.WriteLine("\nCloned Stack Count: " + webHistory.Count);
            #endregion

            #region 10. Clear
            history.Clear();
            Console.WriteLine("Original Stack Count after Clear(): " + history.Count);
            #endregion

            #region 11. CopyTo Example
            object[] objectHistory = new object[webHistory.Count];
            webHistory.CopyTo(objectHistory, 0);

            Console.WriteLine("\nCopied Elements from Cloned Stack:");
            foreach (var item in objectHistory)
                Console.WriteLine(item);
            #endregion
        }
    }
}
