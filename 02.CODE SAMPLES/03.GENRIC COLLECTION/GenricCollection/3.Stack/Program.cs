using System;
using System.Collections.Generic;

namespace _3.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            #region What is Stack<T>?
            /*
             * Stack<T> is a generic collection that works on the principle:
             * LIFO = Last In, First Out.
             * 
             * Example in real life: 
             * - Think of a stack of plates. 
             *   The last plate kept is the first one you take out.
             * 
             * Key Methods:
             * - Push() → Add element to top of stack
             * - Pop()  → Remove and return top element
             * - Peek() → Return top element (without removing)
             * - Contains() → Check if an item exists
             * - Count → Number of items
             * - Clear() → Remove all items
             */
            #endregion

            #region Create a Generic Stack
            Stack<string> webHistory = new Stack<string>();
            #endregion

            #region Add Elements (Push)
            webHistory.Push("www.google.com");
            webHistory.Push("www.amazon.in");
            webHistory.Push("www.youtube.com");
            Console.WriteLine("Pages pushed into history.");
            #endregion

            #region Retrieve Elements
            // Pop → removes and returns the top element
            string lastVisited = webHistory.Pop();
            Console.WriteLine("Last Visited (Pop): " + lastVisited);

            // Peek → returns top element but does not remove
            string currentPage = webHistory.Peek();
            Console.WriteLine("Current Page (Peek): " + currentPage);
            #endregion

            #region Check Existence
            Console.WriteLine("Contains www.youtube.com? " + webHistory.Contains("www.youtube.com"));
            #endregion

            #region Count
            Console.WriteLine("Total Pages in History: " + webHistory.Count);
            #endregion

            #region Iterate Stack
            Console.WriteLine("Browsing History (Top to Bottom):");
            foreach (string page in webHistory)
            {
                Console.WriteLine(page);
            }
            #endregion

            #region Clear Stack
            webHistory.Clear();
            Console.WriteLine("History cleared. Count = " + webHistory.Count);
            #endregion
        }
    }
}
