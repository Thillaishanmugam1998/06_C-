using System;
using System.Collections.Generic;

namespace _5.HashSetExample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region What is HashSet<T>?
            /*
             * HashSet<T>:
             * - A collection that stores UNIQUE values only (no duplicates).
             * - Fast lookups using hashing.
             * - Order of elements is NOT guaranteed.
             * 
             * Example: 
             * - Storing unique roll numbers of students.
             */
            #endregion

            #region Create a HashSet
            HashSet<int> numbers = new HashSet<int>();
            #endregion

            #region Add Elements
            bool added1 = numbers.Add(10);  // true
            bool added2 = numbers.Add(20);  // true
            bool added3 = numbers.Add(10);  // false (duplicate ignored)

            Console.WriteLine("10 added first time? " + added1);
            Console.WriteLine("10 added second time? " + added3);
            #endregion

            #region Access & Iterate
            Console.WriteLine("Elements in HashSet:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
            #endregion

            #region Check Existence
            Console.WriteLine("Contains 20? " + numbers.Contains(20));
            #endregion

            #region Remove Elements
            numbers.Remove(20);
            Console.WriteLine("After removing 20, count = " + numbers.Count);
            #endregion

            #region Set Operations
            HashSet<int> setA = new HashSet<int>() { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new HashSet<int>() { 4, 5, 6, 7 };

            // Union
            setA.UnionWith(setB); // {1,2,3,4,5,6,7}
            Console.WriteLine("Union: " + string.Join(",", setA));

            // Reset setA
            setA = new HashSet<int>() { 1, 2, 3, 4, 5 };

            // Intersection
            setA.IntersectWith(setB); // {4,5}
            Console.WriteLine("Intersection: " + string.Join(",", setA));

            // Reset setA
            setA = new HashSet<int>() { 1, 2, 3, 4, 5 };

            // Difference (ExceptWith)
            setA.ExceptWith(setB); // {1,2,3}
            Console.WriteLine("ExceptWith: " + string.Join(",", setA));

            // Reset setA
            setA = new HashSet<int>() { 1, 2, 3, 4, 5 };

            // Symmetric Difference
            setA.SymmetricExceptWith(setB); // {1,2,3,6,7}
            Console.WriteLine("SymmetricExceptWith: " + string.Join(",", setA));
            #endregion

            #region Clear HashSet
            numbers.Clear();
            Console.WriteLine("HashSet cleared. Count = " + numbers.Count);
            #endregion
        }
    }
}
