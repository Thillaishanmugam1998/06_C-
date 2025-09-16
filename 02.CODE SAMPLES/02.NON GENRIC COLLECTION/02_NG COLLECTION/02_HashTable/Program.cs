using System;
using System.Collections;

namespace _02_HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 01. Hashtable Definition
            /*
             * Hashtable (Non-Generic Collection)
             * - Namespace: System.Collections
             * - Stores data as Key-Value pairs (object type).
             * - Key must be unique, Value can be duplicate.
             * - Unordered collection → items are not stored in insertion order.
             * - Allows different data types for Key & Value (since object type).
             * - Similar to Dictionary<TKey, TValue> but non-generic.
             */
            #endregion

            #region 02. Initialization of Hashtable
            Hashtable Country = new Hashtable(); // Empty Hashtable
            #endregion

            #region 03. Adding Elements
            Country.Add("IND", "India");                     // Add key-value
            Country.Add("USA", "United States of America");
            Country.Add("PAK", "Pakistan");
            Country.Add("AUS", "Australia");
            Country["ENG"] = "England";                      // Another way to insert/update
            #endregion

            #region 04. Count of Elements
            Console.WriteLine("Total Countries: " + Country.Count);
            #endregion

            #region 05. Existence Check
            Console.WriteLine("\nCheck existence:");
            Console.WriteLine("Contains 'IND'? " + Country.Contains("IND"));         // True
            Console.WriteLine("ContainsKey 'AUS'? " + Country.ContainsKey("AUS"));   // True
            Console.WriteLine("ContainsValue 'India'? " + Country.ContainsValue("India")); // True
            #endregion

            #region 06. Remove Elements
            Country.Remove("USA"); // Remove by Key
            Console.WriteLine("\nAfter removing 'USA', total count: " + Country.Count);
            #endregion

            #region 07. Access Elements by Key
            Console.WriteLine("\nAccess element by key 'IND': " + Country["IND"]);
            #endregion

            #region 08. Looping Through Hashtable
            Console.WriteLine("\nLoop using foreach (DictionaryEntry):");
            foreach (DictionaryEntry entry in Country)
            {
                Console.WriteLine("Key = " + entry.Key + ", Value = " + entry.Value);
            }

            Console.WriteLine("\nLoop through Keys:");
            foreach (var key in Country.Keys)
            {
                Console.WriteLine("Key = " + key + ", Value = " + Country[key]);
            }

            Console.WriteLine("\nLoop through Values:");
            foreach (var val in Country.Values)
            {
                Console.WriteLine("Value = " + val);
            }
            #endregion

            #region 09. Clone Hashtable
            Hashtable IPL = (Hashtable)Country.Clone(); // Shallow copy
            Console.WriteLine("\nCloned Hashtable count: " + IPL.Count);
            #endregion

            #region 10. CopyTo Example
            object[] keys = new object[Country.Count];
            object[] values = new object[Country.Count];

            Country.Keys.CopyTo(keys, 0);
            Country.Values.CopyTo(values, 0);

            Console.WriteLine("\nCopied Keys:");
            foreach (var key in keys)
                Console.Write(key + " ");

            Console.WriteLine("\nCopied Values:");
            foreach (var val in values)
                Console.Write(val + " ");
            Console.WriteLine();
            #endregion
        }
    }
}
