using System;
using System.Collections;

namespace _1_ARRAYLIST
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 01. ArrayList Definition
            /*
             * ArrayList is a non-generic collection in C# that can hold 
             * multiple types of data (objects). 
             * - Namespace: System.Collections
             * - Stores elements as object type.
             * - Dynamic size (grows/shrinks as needed).
             * - Allows duplicate elements.
             * - Index based access (like arrays).
             */
            #endregion

            #region 02. Initialization of ArrayList
            ArrayList cricketPlayer = new ArrayList();                // Empty ArrayList
            ArrayList arrayList_1 = new ArrayList(cricketPlayer);     // Copy from another ArrayList
            ArrayList arrayList_2 = new ArrayList(50);                // Initialize with capacity 50
            #endregion

            #region 03. Adding Elements
            cricketPlayer.Add("Rohit");                // Add string
            cricketPlayer.Add(10);                     // Add int
            cricketPlayer.Add("Sachin");               // Add another string
            cricketPlayer.AddRange(arrayList_1);       // Add all elements from another ArrayList
            #endregion

            #region 04. Access Elements
            Console.WriteLine("First element: " + cricketPlayer[0]); // Direct index access
            #endregion

            #region 05. Looping through ArrayList
            Console.WriteLine("\nUsing for loop:");
            for (int i = 0; i < cricketPlayer.Count; i++)
            {
                Console.WriteLine(cricketPlayer[i]);
            }

            Console.WriteLine("\nUsing foreach loop:");
            foreach (var player in cricketPlayer)
            {
                Console.WriteLine(player);
            }
            #endregion

            #region 06. Clear Elements
            arrayList_1.Clear();
            Console.WriteLine("\nCount of ArrayList 1 after Clear(): " + arrayList_1.Count);
            #endregion

            #region 07. Check Existence
            Console.WriteLine("\nContains 10? " + cricketPlayer.Contains(10)); // True/False
            #endregion

            #region 08. Insert Elements
            cricketPlayer.Insert(0, 45);                      // Insert at index 0
            cricketPlayer.InsertRange(1, new ArrayList()      // Insert range after index 0
            {
                "Virat", "Dhoni"
            });
            #endregion

            #region 09. Remove Elements
            /*
             * Remove(value)     → Removes first occurrence of the given value
             * RemoveAt(index)   → Removes element at given index
             * RemoveRange(start, count) → Removes multiple elements
             */

            Console.WriteLine("\nBefore Removing:");
            foreach (var item in cricketPlayer)
                Console.Write(item + " ");

            cricketPlayer.Remove(10);        // Removes value "10"
            cricketPlayer.RemoveAt(0);       // Removes element at index 0
            if (cricketPlayer.Count >= 2)
                cricketPlayer.RemoveRange(0, 2); // Removes 2 elements starting at index 0

            Console.WriteLine("\n\nAfter Removing:");
            foreach (var item in cricketPlayer)
                Console.Write(item + " ");
            Console.WriteLine();
            #endregion

            #region 10. Clone ArrayList
            ArrayList arrayList_3 = (ArrayList)cricketPlayer.Clone(); // Creates a shallow copy
            Console.WriteLine("\nCloned ArrayList count: " + arrayList_3.Count);
            #endregion

            #region 11. Sort ArrayList
            /*
             * Sorting works only if all elements are of the same type.
             * Otherwise, InvalidOperationException will be thrown.
             * So here, we’ll create a new ArrayList with same-type elements.
             */
            ArrayList numbers = new ArrayList() { 5, 2, 8, 1, 3 };
            numbers.Sort();
            Console.WriteLine("\nSorted Numbers:");
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            #endregion

            #region 12. CopyTo Example
            object[] array = new object[cricketPlayer.Count];
            cricketPlayer.CopyTo(array, 0);
            Console.WriteLine("\nCopied Array Elements:");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            #endregion
        }
    }
}
