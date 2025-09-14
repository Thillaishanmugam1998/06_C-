using System;

namespace ArrayFunctionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ARRAY FUNCTIONS DEMO ===\n");

            #region 1. Length
            Console.WriteLine("Length → Gets the total number of elements in the array.");
            int[] numbers = { 10, 20, 30, 40 };
            Console.WriteLine("Output: " + numbers.Length + "\n");
            #endregion

            #region 2. GetLength, GetLowerBound, GetUpperBound
            Console.WriteLine("GetLength → Gets the number of elements in the specified dimension.");
            Console.WriteLine("GetLowerBound → Gets the smallest valid index of a dimension.");
            Console.WriteLine("GetUpperBound → Gets the largest valid index of a dimension.");
            int[,] matrix = new int[3, 5]; // 3 rows, 5 cols
            Console.WriteLine("Output: GetLength(0) = " + matrix.GetLength(0)); // rows
            Console.WriteLine("Output: GetLength(1) = " + matrix.GetLength(1)); // cols
            Console.WriteLine("Output: GetLowerBound(0) = " + matrix.GetLowerBound(0));
            Console.WriteLine("Output: GetUpperBound(1) = " + matrix.GetUpperBound(1) + "\n");
            #endregion

            #region 3. IndexOf & LastIndexOf
            Console.WriteLine("IndexOf → Finds the first occurrence of a value.");
            Console.WriteLine("LastIndexOf → Finds the last occurrence of a value.");
            int[] arr1 = { 10, 20, 30, 20, 40, 20 };
            Console.WriteLine("Output: IndexOf(20) = " + Array.IndexOf(arr1, 20));
            Console.WriteLine("Output: LastIndexOf(20) = " + Array.LastIndexOf(arr1, 20) + "\n");
            #endregion

            #region 4. Sort
            Console.WriteLine("Sort → Sorts the elements of the array in ascending order.");
            int[] arr2 = { 5, 3, 8, 1, 2 };
            Array.Sort(arr2);
            Console.WriteLine("Output: " + string.Join(", ", arr2) + "\n");
            #endregion

            #region 5. Reverse
            Console.WriteLine("Reverse → Reverses the order of elements in the array.");
            int[] arr3 = { 1, 2, 3, 4, 5 };
            Array.Reverse(arr3);
            Console.WriteLine("Output: " + string.Join(", ", arr3) + "\n");
            #endregion

            #region 6. Clear
            Console.WriteLine("Clear → Sets a range of elements in the array to the default value (0, null, false).");
            int[] arr4 = { 1, 2, 3, 4, 5 };
            Array.Clear(arr4, 1, 2); // clear index 1 & 2
            Console.WriteLine("Output: " + string.Join(", ", arr4) + "\n");
            #endregion

            #region 7. Resize
            Console.WriteLine("Resize → Changes the size of the array (creates a new one internally).");
            int[] arr5 = { 1, 2, 3 };
            Array.Resize(ref arr5, 5);
            Console.WriteLine("Output: " + string.Join(", ", arr5) + "\n");
            #endregion

            #region 8. Copy
            Console.WriteLine("Copy → Copies elements from one array to another.");
            int[] src = { 1, 2, 3 };
            int[] dest = new int[3];
            Array.Copy(src, dest, 3);
            Console.WriteLine("Output: " + string.Join(", ", dest) + "\n");
            #endregion

            #region 9. Clone
            Console.WriteLine("Clone → Creates a shallow copy of the array.");
            int[] clone = (int[])src.Clone();
            Console.WriteLine("Output: " + string.Join(", ", clone) + "\n");
            #endregion

            #region 10. Exists
            Console.WriteLine("Exists → Checks if any element matches a condition (uses Predicate).");
            int[] arr6 = { 1, 2, 3, 4, 5 };
            bool exists = Array.Exists(arr6, n => n > 3);
            Console.WriteLine("Output: " + exists + "\n");
            #endregion

            #region 11. Find
            Console.WriteLine("Find → Returns the first element that matches a condition.");
            int first = Array.Find(arr6, n => n > 3);
            Console.WriteLine("Output: " + first + "\n");
            #endregion

            #region 12. FindAll
            Console.WriteLine("FindAll → Returns all elements that match a condition.");
            int[] all = Array.FindAll(arr6, n => n > 2);
            Console.WriteLine("Output: " + string.Join(", ", all) + "\n");
            #endregion

            #region 13. FindIndex
            Console.WriteLine("FindIndex → Returns the index of the first element that matches a condition.");
            int idx = Array.FindIndex(arr6, n => n % 2 == 0);
            Console.WriteLine("Output: " + idx + "\n");
            #endregion

            #region 14. TrueForAll
            Console.WriteLine("TrueForAll → Checks if all elements match a condition.");
            bool allPositive = Array.TrueForAll(arr6, n => n > 0);
            Console.WriteLine("Output: " + allPositive + "\n");
            #endregion

            #region 15. ForEach
            Console.WriteLine("ForEach → Performs an action on each element of the array.");
            Console.Write("Output: ");
            Array.ForEach(arr6, n => Console.Write(n + " "));
            Console.WriteLine("\n");
            #endregion
        }
    }
}
