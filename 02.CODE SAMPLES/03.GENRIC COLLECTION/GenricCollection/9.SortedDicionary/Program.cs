using System;
using System.Collections.Generic;

namespace _8.SortedDictionaryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region What is SortedDictionary<TKey,TValue>?
            /*
             * SortedDictionary<TKey,TValue>:
             * - Stores key-value pairs like Dictionary.
             * - Keys are UNIQUE, values can be duplicates.
             * - Keys are automatically SORTED (ascending by default).
             * - Uses a Binary Search Tree internally → better for frequent insertions/deletions.
             * - Does NOT support access by index.
             */
            #endregion

            #region Create SortedDictionary
            SortedDictionary<int, string> products = new SortedDictionary<int, string>();
            #endregion

            #region Add Elements
            products.Add(5, "Samsung");
            products.Add(2, "Redmi");
            products.Add(1, "OnePlus");
            products.Add(4, "Nothing");

            Console.WriteLine("✅ SortedDictionary Elements (Auto Sorted by Key):");
            foreach (var kvp in products)
            {
                Console.WriteLine($"Key={kvp.Key}, Value={kvp.Value}");
            }
            // Output:
            // Key=1, Value=OnePlus
            // Key=2, Value=Redmi
            // Key=4, Value=Nothing
            // Key=5, Value=Samsung
            #endregion

            #region Check Existence
            Console.WriteLine("\nContains Key 2? " + products.ContainsKey(2));   // True
            Console.WriteLine("Contains Value 'Apple'? " + products.ContainsValue("Apple")); // False
            #endregion

            #region Remove & Count
            products.Remove(4); // Remove element by key
            Console.WriteLine("\nAfter removing key=4:");
            foreach (var kvp in products)
                Console.WriteLine($"Key={kvp.Key}, Value={kvp.Value}");

            Console.WriteLine($"\nTotal Elements: {products.Count}"); // 3
            #endregion

            #region Clear
            products.Clear(); // Remove all elements
            Console.WriteLine("After Clear, Count = " + products.Count); // 0
            #endregion
        }
    }
}
