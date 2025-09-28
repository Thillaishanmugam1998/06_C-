using System;
using System.Collections;

namespace _5_SortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 01. SortedList Definition
            /*
             * SortedList (Non-Generic Collection)
             * - Namespace: System.Collections
             * - Stores data as Key-Value pairs.
             * - Automatically sorts elements by Key (ascending order).
             * - Key must be unique, Value can be duplicate.
             * - Allows access by:
             *   - Key (like Hashtable/Dictionary)
             *   - Index (like ArrayList)
             * - Similar to Dictionary<TKey, TValue> but keeps sorted order.
             */
            #endregion

            #region 02. Initialization
            SortedList numbers = new SortedList();
            #endregion

            #region 03. Adding Elements
            numbers.Add(10, "Ten");
            numbers.Add(1, "One");
            numbers.Add(2, "Two");
            numbers.Add(0, "Zero"); // Will be placed first since SortedList auto-sorts by Key
            #endregion

            #region 04. Access Elements
            Console.WriteLine("Access by Key [0]: " + numbers[0]);              // Access using key
            Console.WriteLine("Access by Index [2]: " + numbers.GetByIndex(2)); // Access using index
            #endregion

            #region 05. Looping Elements
            Console.WriteLine("\nUsing For Loop:");
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine($"Key: {numbers.GetKey(i)}, Value: {numbers.GetByIndex(i)}");
            }

            Console.WriteLine("\nUsing foreach (DictionaryEntry):");
            foreach (DictionaryEntry item in numbers)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
            #endregion

            #region 06. Remove Elements
            numbers.Remove(10);   // Remove by Key
            numbers.RemoveAt(2);  // Remove by Index
            Console.WriteLine("\nAfter Removal, Count = " + numbers.Count);
            #endregion

            #region 07. Contains (Search)
            Console.WriteLine("\nContains Value 'One'? " + numbers.Contains("One"));        // True
            Console.WriteLine("Contains Key 1? " + numbers.ContainsKey(1));                 // True
            Console.WriteLine("Contains Value 'Two'? " + numbers.ContainsValue("Two"));     // True
            #endregion

            #region 08. Clone
            SortedList list = (SortedList)numbers.Clone(); // Shallow copy
            Console.WriteLine("\nCloned SortedList Count: " + list.Count);
            #endregion

            #region 09. Clear
            numbers.Clear(); // Clears all elements
            Console.WriteLine("Original SortedList Count after Clear(): " + numbers.Count);
            #endregion

            #region 10. CopyTo Example
            object[] objKey = new object[list.Count];
            object[] objValue = new object[list.Count];

            list.Keys.CopyTo(objKey, 0);
            list.Values.CopyTo(objValue, 0);

            Console.WriteLine("\nCopied Keys:");
            foreach (var key in objKey)
                Console.Write(key + " ");

            Console.WriteLine("\nCopied Values:");
            foreach (var val in objValue)
                Console.Write(val + " ");
            Console.WriteLine();
            #endregion
        }
    }
}
