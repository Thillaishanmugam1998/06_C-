using System;
using System.Collections.Generic;

namespace _8.SortedListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region What is SortedList<TKey,TValue>?
            /*
             * SortedList<TKey,TValue>:
             * - Stores key-value pairs like Dictionary.
             * - Keys are UNIQUE, values can be duplicates.
             * - Keys are automatically SORTED (ascending by default).
             * - Uses an internal array → index-based access is fast.
             * - Insertion/Deletion in large lists is slower compared to SortedDictionary.
             */
            #endregion

            #region Create SortedList
            SortedList<int, string> products = new SortedList<int, string>();
            #endregion

            #region Add Elements
            // Add key-value pairs
            products.Add(5, "Samsung");
            products.Add(2, "Redmi");
            products.Add(1, "OnePlus");
            products.Add(4, "Nothing");

            Console.WriteLine("✅ SortedList Elements (Auto Sorted by Key):");
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

            #region Access by Index
            // You can access keys/values by index because it's internally array-based
            Console.WriteLine($"\nElement at index 2: Key={products.Keys[2]}, Value={products.Values[2]}");
            // Output: Key=4, Value=Nothing
            #endregion

            #region Check Existence
            Console.WriteLine("Contains Key 2? " + products.ContainsKey(2));     // True
            Console.WriteLine("Contains Value 'Apple'? " + products.ContainsValue("Apple")); // False
            #endregion

            #region Remove Elements
            products.Remove(4); // Remove element by key
            Console.WriteLine("\nAfter removing key=4:");
            foreach (var kvp in products)
                Console.WriteLine($"Key={kvp.Key}, Value={kvp.Value}");
            #endregion

            #region Count & Clear
            Console.WriteLine($"\nTotal Elements: {products.Count}"); // 3
            products.Clear(); // Remove all elements
            Console.WriteLine("After Clear, Count = " + products.Count); // 0
            #endregion
        }
    }
}
