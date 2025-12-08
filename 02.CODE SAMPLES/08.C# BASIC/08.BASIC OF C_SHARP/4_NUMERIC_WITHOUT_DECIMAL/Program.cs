using System;

namespace _4_NUMERIC_WITHOUT_DECIMAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== NUMERIC DATA TYPES (WITHOUT DECIMAL) ===\n");

            #region Simple Explanation
            // --------------------------------------------------------------
            // NUMBERS WITHOUT DECIMAL → 3 MAIN SIGNED TYPES:
            //
            // Int16  → 16-bit  (short)
            // Int32  → 32-bit  (int)
            // Int64  → 64-bit  (long)
            //
            // SIGNED TYPES:
            // - Can store positive + negative numbers
            //
            // SIZE → RANGE FORMULA:
            // 2^bits / 2 = number of positive + negative values
            //
            // SHORT NAMES:   Int16 = short, Int32 = int, Int64 = long
            //
            // UNSIGNED: (positive only)
            // UInt16 = ushort, UInt32 = uint, UInt64 = ulong
            // --------------------------------------------------------------
            #endregion


            #region Min/Max Values of Signed Types
            Console.WriteLine("Signed Numeric Types:");
            Console.WriteLine($"short (Int16) Min : {short.MinValue}   Max : {short.MaxValue}");
            Console.WriteLine($"int   (Int32) Min : {int.MinValue}     Max : {int.MaxValue}");
            Console.WriteLine($"long  (Int64) Min : {long.MinValue}    Max : {long.MaxValue}\n");
            #endregion


            #region Min/Max Values of Unsigned Types
            Console.WriteLine("Unsigned Numeric Types (Positive Only):");
            Console.WriteLine($"ushort (UInt16) Min : {ushort.MinValue}   Max : {ushort.MaxValue}");
            Console.WriteLine($"uint   (UInt32) Min : {uint.MinValue}     Max : {uint.MaxValue}");
            Console.WriteLine($"ulong  (UInt64) Min : {ulong.MinValue}    Max : {ulong.MaxValue}\n");
            #endregion


            #region Size of each Type
            // sizeof → tells size in BYTES
            Console.WriteLine("Size in Bytes:");
            Console.WriteLine($"short : {sizeof(short)} bytes");
            Console.WriteLine($"int   : {sizeof(int)} bytes");
            Console.WriteLine($"long  : {sizeof(long)} bytes\n");
            #endregion


            #region Short Summary
            // --------------------------------------------------------------
            // EASY TO REMEMBER:
            //
            // short → 16-bit   (±32,768)
            // int   → 32-bit   (most commonly used)
            // long  → 64-bit   (very large numbers)
            //
            // Unsigned Versions:
            // ushort / uint / ulong → positive numbers only
            //
            // Check Range   → MinValue / MaxValue
            // Check Size    → sizeof(type)
            //
            // TIP: Always use INT unless you need very small or very large values
            // --------------------------------------------------------------
            #endregion

            Int16 a = 10;
            Int32 b = 10;
            Int64 c = 10;
            int d = 50;
            short e = 5;
            int f = 50;
            long g = 50;
            
            Console.WriteLine("=== END ===");
        }
    }
}
