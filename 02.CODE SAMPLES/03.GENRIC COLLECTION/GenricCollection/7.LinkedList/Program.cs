using System;
using System.Collections.Generic;

namespace _7.LinkedListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region What is LinkedList<T>?
            /*
             * LinkedList<T>:
             * - Doubly-linked list storing nodes with pointers to previous & next nodes.
             * - Fast insertion/removal anywhere in the list.
             * - Maintains order of elements.
             */
            #endregion

            #region Create LinkedList
            LinkedList<string> fruits = new LinkedList<string>();
            #endregion

            #region Add Elements
            fruits.AddLast("Apple");    // Add at end
            fruits.AddLast("Banana");
            fruits.AddFirst("Mango");   // Add at start
            fruits.AddLast("Orange");

            Console.WriteLine("LinkedList after AddFirst & AddLast:");
            foreach (var fruit in fruits)
                Console.WriteLine(fruit);
            // Output: Mango, Apple, Banana, Orange
            #endregion

            #region Add Before / After
            var node = fruits.Find("Banana");
            fruits.AddBefore(node, "Pineapple");
            fruits.AddAfter(node, "Grapes");

            Console.WriteLine("\nLinkedList after AddBefore & AddAfter:");
            foreach (var fruit in fruits)
                Console.WriteLine(fruit);
            // Output: Mango, Apple, Pineapple, Banana, Grapes, Orange
            #endregion

            #region Remove Elements
            fruits.Remove("Apple");        // Remove by value
            fruits.RemoveFirst();          // Remove first node
            fruits.RemoveLast();           // Remove last node

            Console.WriteLine("\nLinkedList after Remove operations:");
            foreach (var fruit in fruits)
                Console.WriteLine(fruit);
            // Output: Pineapple, Banana, Grapes
            #endregion

            #region Check Existence
            Console.WriteLine("\nContains 'Banana'? " + fruits.Contains("Banana")); // True
            Console.WriteLine("Contains 'Mango'? " + fruits.Contains("Mango"));     // False
            #endregion

            #region Properties
            Console.WriteLine("\nFirst Node: " + fruits.First.Value); // Pineapple
            Console.WriteLine("Last Node: " + fruits.Last.Value);     // Grapes
            Console.WriteLine("Count: " + fruits.Count);             // 3
            #endregion

            #region Clear LinkedList
            fruits.Clear();
            Console.WriteLine("\nLinkedList cleared. Count = " + fruits.Count);
            // Output: 0
            #endregion
        }
    }
}
