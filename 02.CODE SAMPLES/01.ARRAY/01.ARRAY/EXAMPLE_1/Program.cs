using System;

namespace EXAMPLE_1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1. Invalid Example
            // ❌ Invalid array creation (Uncommenting below line will cause Error CS1586)
            // int[] intArray = new int[];
            #endregion

            #region 2. Array Declaration & Initialization
            int[] intArray = new int[6];  // Declared with fixed size (default values will be 0)
            string[] stringArray = { "Thillai", "Tamizh", "Shanmugam" }; // Declared and initialized directly
            #endregion

            #region 3. Assigning Values to Array
            intArray[0] = 0;
            intArray[1] = 1;
            intArray[2] = 2;

            // Assign values using a for loop (from index 3 to end)
            for (int i = 3; i < intArray.Length; i++)
            {
                intArray[i] = i;
            }
            #endregion

            #region 4. Accessing Values without Loop
            Console.WriteLine($"stringArray[0] = {stringArray[0]}");
            Console.WriteLine($"stringArray[1] = {stringArray[1]}");
            #endregion

            #region 5. Accessing Values using For Loop
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine($"intArray[{i}] = {intArray[i]}");
            }
            #endregion
        }
    }
}
