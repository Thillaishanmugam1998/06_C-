using System;

namespace _6_SUMMARY_DATA_TYPES
{
    class Program
    {
        static void Main(string[] args)
        {
            // ============================================================
            // C# DATA TYPES SUMMARY (Value, Reference, Pointer)
            // ============================================================

            #region Value Types
            // ------------------------------------------------------------
            // VALUE TYPES
            // ------------------------------------------------------------
            // • Stored in STACK
            // • Store the ACTUAL value
            // • Fast and lightweight
            // • Cannot be null (unless nullable type: int?)
            //
            // PREDEFINED VALUE TYPES:
            // Integer Types:
            //   byte, sbyte, short (Int16), int (Int32), long (Int64)
            //
            // Floating Types:
            //   float, double, decimal
            //
            // Other Types:
            //   bool, char
            //
            // USER-DEFINED VALUE TYPES:
            //   struct, enum
            //
            // ----------------- EXAMPLE -----------------
            // Value Type Example:
            int a = 10;     // Stores 10 directly in STACK
            int b = a;      // b gets a COPY of value 10
            // Here:
            // a = 10 (stack)
            // b = 10 (separate copy)
            // Changing 'a' will NOT affect 'b'
            #endregion


            #region Reference Types
            // ------------------------------------------------------------
            // REFERENCE TYPES
            // ------------------------------------------------------------
            // • Stored in HEAP
            // • Variable holds ONLY the ADDRESS (reference)
            // • Multiple variables can point to the same object
            // • Can be null
            //
            // PREDEFINED REFERENCE TYPES:
            //   string, object, dynamic, array[]
            //
            // USER-DEFINED REFERENCE TYPES:
            //   class, interface, delegate
            //
            // ----------------- EXAMPLE -----------------
            // Reference Type Example:
            int[] numbers1 = new int[] { 1, 2, 3 };
            int[] numbers2 = numbers1;
            // Both variables point to SAME array in HEAP
            // If numbers2[0] = 99 → numbers1[0] will also become 99
            #endregion


            #region Pointer Types (Advanced / Unsafe)
            // ------------------------------------------------------------
            // POINTER TYPES (Rarely Used in C#)
            // ------------------------------------------------------------
            // • Used only inside 'unsafe' code blocks
            // • Hold memory addresses directly
            //
            // Example: int* p;  (not allowed in safe mode)
            // ------------------------------------------------------------
            #endregion


            #region C# Data Types Full List (Easy to Remember)
            // ------------------------------------------------------------
            // COMPLETE C# DATA TYPES LIST
            // ------------------------------------------------------------
            //
            // VALUE TYPES:
            // • Integers  : byte, sbyte, short, ushort, int, uint, long, ulong
            // • Floating  : float, double, decimal
            // • Other     : char, bool
            // • User Def  : struct, enum
            //
            // REFERENCE TYPES:
            // • string
            // • object
            // • dynamic
            // • arrays  []
            // • class
            // • interface
            // • delegate
            //
            // POINTER TYPES:
            // • int*, char*, float* (used only in unsafe context)
            //
            // INTERVIEW TIP:
            // > Value Types → Stack → Actual Value
            // > Reference Types → Heap → Address to the value
            // > String is Reference Type but Immutable
            // ------------------------------------------------------------
            #endregion


            #region Quick Comparison (Comment Only)
            // ------------------------------------------------------------
            // VALUE TYPE vs REFERENCE TYPE
            //
            // VALUE TYPE:
            // • Stack memory
            // • Holds actual value
            // • Fast
            // • Example: int a = 10;
            //
            // REFERENCE TYPE:
            // • Heap memory
            // • Holds address (pointer) to data
            // • Changing one reference affects another
            // • Example:
            //     int[] x = new int[] {1,2,3};
            //     int[] y = x;  (both point to same array)
            //
            // ------------------------------------------------------------
            #endregion


            // END OF PROGRAM
        }
    }
}
