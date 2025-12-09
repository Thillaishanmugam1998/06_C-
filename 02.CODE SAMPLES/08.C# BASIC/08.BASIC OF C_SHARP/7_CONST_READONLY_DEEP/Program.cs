using System;

namespace _8_CONST_READONLY_DEEP
{
    class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------------
            // CONST vs READONLY — IN-DEPTH EXPLANATION
            // -------------------------------------------------------------------

            #region CONST EXAMPLE
            // CONST:
            //  - Must assign at declaration time.
            //  - Cannot change after compile.
            //  - Compiler replaces constant everywhere in code.
            //  - ALWAYS same value for ALL objects.

            Console.WriteLine("CONST PI: " + ConstExample.PI);

            // ❌ Try changing const → This is NOT allowed.
            // ConstExample.PI = 3.15;   // ERROR: Cannot assign to PI because it is constant

            #endregion


            #region READONLY EXAMPLE
            // READONLY:
            //  - Can assign:
            //      a) at declaration, or
            //      b) inside constructor
            //  - Value CANNOT change AFTER object is created.
            //  - Different objects can have DIFFERENT readonly values.

            ReadonlyExample r1 = new ReadonlyExample(100);
            ReadonlyExample r2 = new ReadonlyExample(200);

            Console.WriteLine("Readonly r1 ID: " + r1.Id);  // 100
            Console.WriteLine("Readonly r2 ID: " + r2.Id);  // 200

            // ❌ Try changing readonly after object creation → Not allowed
            // r1.Id = 500;   // ERROR: A readonly field cannot be assigned to

            #endregion


            #region CONST vs READONLY OUTPUT SUMMARY (Interview Quick View)

            Console.WriteLine("\n--- CONST vs READONLY Summary ---");
            Console.WriteLine("ConstExample.PI (same for all): " + ConstExample.PI);
            Console.WriteLine("ReadonlyExample r1.Id: " + r1.Id);
            Console.WriteLine("ReadonlyExample r2.Id: " + r2.Id);

            // Const → Same value for whole application.
            // Readonly → Different value for each object.

            #endregion

            Console.WriteLine("\nProgram completed. Check comments above for deep understanding.");
        }
    }


    // =======================================================================
    // CONST EXAMPLE CLASS
    // =======================================================================
    static class ConstExample
    {
        // CONST MUST BE ASSIGNED HERE → compile-time fixed value
        public const double PI = 3.14;

        // Once compiled, PI cannot change anywhere in code.
    }


    // =======================================================================
    // READONLY EXAMPLE CLASS
    // =======================================================================
    class ReadonlyExample
    {
        public readonly int Id; // Value can be set ONLY once

        public ReadonlyExample(int value)
        {
            // Allowed: readonly can be assigned INSIDE constructor
            Id = value;
        }

        // ❌ If we try to modify Id anywhere else → error
        // Example:
        // public void ChangeID()
        // {
        //     Id = 999;    // ERROR: readonly cannot be assigned here
        // }
    }
}
