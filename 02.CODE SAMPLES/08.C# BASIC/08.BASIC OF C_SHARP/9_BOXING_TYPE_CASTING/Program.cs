using System;

namespace _10_BOXING_UNBOXING_TYPE_CONVERSION
{
    class Program
    {
        static void Main(string[] args)
        {
            // ===================================================================
            // BOXING & UNBOXING (VERY IMPORTANT INTERVIEW TOPIC)
            // ===================================================================

            #region BOXING (Value Type → Reference Type)
            // Boxing = Converting VALUE TYPE into REFERENCE TYPE (object)
            // Why? To store value types in places expected as object (ArrayList, methods)

            int x = 10;
            object obj = x;   // BOXING → int stored inside object

            // Memory: value copied from Stack → Heap (object)
            #endregion


            #region UNBOXING (Reference Type → Value Type)
            // Unboxing = Convert object back into VALUE TYPE
            // MUST cast to ORIGINAL type, otherwise error

            int y = (int)obj;     // UNBOXING → from object back to int
            #endregion


            // ===================================================================
            // TYPE CONVERSION (Casting)
            // ===================================================================

            #region IMPLICIT CONVERSION (Safe → No Data Loss)
            // Smaller to Larger → automatic conversion

            int small = 100;
            long big = small;         // int → long (safe)
            float f1 = small;         // int → float
            double d1 = f1;           // float → double

            // int → long → float → double → decimal (Not always auto)
            #endregion


            #region EXPLICIT CONVERSION (Manual Cast → Data Loss Possible)
            // Larger to Smaller → MUST cast manually

            double bigNum = 123.456;

            int smallNum = (int)bigNum;   // 123 (decimal removed)
            byte b1 = (byte)smallNum;     // possible overflow
            #endregion


            #region CONVERT CLASS (Safe Conversion Methods)
            // Converts between all base types safely (throws exception if fails)

            string n1 = "123";
            int number1 = Convert.ToInt32(n1);

            double number2 = Convert.ToDouble("45.67");

            bool status = Convert.ToBoolean("true");
            #endregion


            #region PARSE & TRYPARSE (String → Number)
            // Parse → Throws error if string invalid
            int parsedValue = int.Parse("500");

            // TryParse → SAFE, no error, returns true/false
            bool isSuccess = int.TryParse("999", out int parsedValue2);
            // if invalid: parsedValue2 = 0
            #endregion


            // ===================================================================
            // DATA TYPE CONVERSION TABLE (INTERVIEW QUICK GUIDE)
            // ===================================================================
            #region CONVERSION TABLE (COMMENTS ONLY)

            /*
             IMPLICIT (SAFE → NO CAST NEEDED)
             --------------------------------
             byte → short → int → long → float → double
             char → int
             int → float, double, decimal

             EXPLICIT (CAST REQUIRED)
             --------------------------------
             double → float → long → int → short → byte
             decimal → double / float / long / int
             long → int
             float → int

             STRING CONVERSIONS
             --------------------------------
             string → int    → int.Parse(), Convert.ToInt32()
             string → double → double.Parse(), Convert.ToDouble()
             string → bool   → bool.Parse(), Convert.ToBoolean()

             OBJECT CONVERSIONS
             --------------------------------
             object → int (UNBOXING)
             object → double (UNBOXING)
             */

            #endregion


            // ===================================================================
            // PRINT RESULTS (Just to Confirm Execution)
            // ===================================================================
            Console.WriteLine("Boxing, Unboxing & Type Conversion Examples Executed.");
        }
    }
}
