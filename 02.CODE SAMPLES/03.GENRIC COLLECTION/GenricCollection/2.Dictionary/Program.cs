using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            #region What is Dictionary<TKey, TValue>?
            /*
             * Dictionary<TKey, TValue> is a generic collection that stores data as key-value pairs.
             * - Key: must be unique.
             * - Value: can be duplicate.
             * - Provides fast lookup (search by key).
             */
            #endregion

            #region Create a Dictionary
            Dictionary<int, string> products = new Dictionary<int, string>();
            #endregion

            #region Add Elements
            products.Add(1, "OnePlus");
            products.Add(5, "Samsung");
            products.Add(2, "Redmi");
            products.Add(4, "Nothing");
            #endregion

            #region Update Element
            // Update value for a given key
            products[2] = "Apple"; // Key=2 updated from Redmi → Apple
            #endregion

            #region Access Elements
            // Access using for loop (via Keys collection)
            for (int i = 0; i < products.Count; i++)
            {
                var key = products.Keys.ElementAt(i);
                var value = products[key];
                Console.WriteLine($"Key={key}, Value={value}");
            }

            // Access using foreach (recommended)
            foreach (KeyValuePair<int, string> kvp in products)
            {
                Console.WriteLine($"Key={kvp.Key}, Value={kvp.Value}");
            }
            #endregion

            #region Check Existence
            Console.WriteLine("Contains Key 1? " + products.ContainsKey(1)); // True
            Console.WriteLine("Contains Value 'OnePlus'? " + products.ContainsValue("OnePlus")); // True
            #endregion

            #region Remove Elements
            bool removed = products.Remove(4); // Remove key=4, returns true if successful
            Console.WriteLine("Was key 4 removed? " + removed);

            // Clear all elements
            products.Clear();
            #endregion

            #region Count Property
            Console.WriteLine("Total Products: " + products.Count);
            #endregion

            #region Get All Keys and Values
            // Keys property
            foreach (var key in products.Keys)
            {
                Console.WriteLine("Key: " + key);
            }

            // Values property
            foreach (var val in products.Values)
            {
                Console.WriteLine("Value: " + val);
            }
            #endregion

            #region Safe Access using TryGetValue
            // TryGetValue avoids exception if key does not exist
            if (products.TryGetValue(1, out string value))
            {
                Console.WriteLine("Key 1 Value: " + value);
            }
            else
            {
                Console.WriteLine("Key 1 not found.");
            }
            #endregion
        }
    }
}
