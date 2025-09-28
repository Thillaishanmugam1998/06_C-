using System;
using System.Collections.Generic;

namespace _6.SortedSetExample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region What is SortedSet<T>?
            /*
             * SortedSet<T>:
             * - Stores UNIQUE elements (like HashSet).
             * - Automatically keeps items SORTED (ascending by default).
             * - Can use a custom comparer for custom sorting.
             * 
             * Real-world Example:
             * - A list of unique student roll numbers in ascending order.
             */
            #endregion

            #region Create a SortedSet
            SortedSet<int> numbers = new SortedSet<int>();
            #endregion

            #region Add Elements
            numbers.Add(50);
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(40);
            numbers.Add(30);
            numbers.Add(20); // Duplicate → ignored

            Console.WriteLine("✅ SortedSet Elements (Auto Sorted):");
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
            // Output:
            // 10
            // 20
            // 30
            // 40
            // 50
            #endregion

            #region Properties (Min & Max)
            Console.WriteLine("\nMin: " + numbers.Min);  // 10
            Console.WriteLine("Max: " + numbers.Max);    // 50
            #endregion

            #region Check Existence
            Console.WriteLine("\nContains 30? " + numbers.Contains(30)); // True
            Console.WriteLine("Contains 99? " + numbers.Contains(99));   // False
            #endregion

            #region Remove Elements
            numbers.Remove(20);
            Console.WriteLine("\nAfter removing 20: " + string.Join(", ", numbers));
            // Output: 10, 30, 40, 50
            #endregion

            #region Get Range (View Between)
            var range = numbers.GetViewBetween(15, 40);
            Console.WriteLine("\nRange (15-40): " + string.Join(", ", range));
            // Output: 30, 40
            #endregion

            #region Set Operations
            SortedSet<int> setA = new SortedSet<int>() { 1, 2, 3, 4, 5 };
            SortedSet<int> setB = new SortedSet<int>() { 4, 5, 6, 7 };

            // Union
            setA.UnionWith(setB);
            Console.WriteLine("\nUnion: " + string.Join(",", setA));
            // Output: 1,2,3,4,5,6,7

            // Reset setA
            setA = new SortedSet<int>() { 1, 2, 3, 4, 5 };

            // Intersection
            setA.IntersectWith(setB);
            Console.WriteLine("Intersection: " + string.Join(",", setA));
            // Output: 4,5

            // Reset setA
            setA = new SortedSet<int>() { 1, 2, 3, 4, 5 };

            // Difference
            setA.ExceptWith(setB);
            Console.WriteLine("ExceptWith: " + string.Join(",", setA));
            // Output: 1,2,3

            // Reset setA
            setA = new SortedSet<int>() { 1, 2, 3, 4, 5 };

            // Symmetric Difference
            setA.SymmetricExceptWith(setB);
            Console.WriteLine("SymmetricExceptWith: " + string.Join(",", setA));
            // Output: 1,2,3,6,7
            #endregion

            #region Clear
            numbers.Clear();
            Console.WriteLine("\nSortedSet cleared. Count = " + numbers.Count);
            // Output: 0
            #endregion
        }
    }
}
