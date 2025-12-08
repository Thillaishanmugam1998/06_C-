using System;

namespace _5_NUMERIC_WITH_DECIMAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== NUMBERS WITH DECIMAL ===\n");

            #region Simple Explanation
            // ------------------------------------------------------------
            // DECIMAL NUMERIC TYPES:
            //
            // float   → 4 bytes  → single precision   → ~7 digits accuracy
            // double  → 8 bytes  → double precision   → ~15 digits accuracy
            // decimal → 16 bytes → high precision     → ~29 digits accuracy
            //
            // SUFFIX RULES:
            // float   → suffix 'f' or 'F'
            // decimal → suffix 'm' or 'M'
            // double  → default (no suffix needed)
            //
            // ------------------------------------------------------------
            #endregion


            #region Examples with Precision Difference
            float a = 1.78986380830029492956829698978655434342477f;   // ~7 digits
            double b = 1.78986380830029492956829698978655434342477;    // ~15 digits
            decimal c = 1.78986380830029492956829698978655434342477m;  // ~29 digits

            Console.WriteLine("Float (Single Precision):");
            Console.WriteLine(a + "\n");

            Console.WriteLine("Double (Double Precision):");
            Console.WriteLine(b + "\n");

            Console.WriteLine("Decimal (High Precision for Finance):");
            Console.WriteLine(c + "\n");
            #endregion


            #region Storing Values (Simple Examples)
            float price = 99.99f;
            double distance = 12345.6789;
            decimal bankBalance = 12345.67890123456789m;

            Console.WriteLine("Storing Decimal Values:");
            Console.WriteLine(price);
            Console.WriteLine(distance);
            Console.WriteLine(bankBalance + "\n");
            #endregion


            #region Summary (Easy to Remember)
            // ------------------------------------------------------------
            // FLOAT:
            // • 4 bytes
            // • Use when memory matters (graphics, game dev)
            //
            // DOUBLE:
            // • 8 bytes
            // • Default for decimal numbers
            // • Good balance of speed + precision
            //
            // DECIMAL:
            // • 16 bytes
            // • Best for MONEY and FINANCIAL calculations
            // • Very high precision
            //
            // RULE:
            // float → add 'f'
            // decimal → add 'm'
            // double → no suffix
            //
            // ------------------------------------------------------------
            #endregion

            Console.WriteLine("=== END ===");
        }
    }
}
