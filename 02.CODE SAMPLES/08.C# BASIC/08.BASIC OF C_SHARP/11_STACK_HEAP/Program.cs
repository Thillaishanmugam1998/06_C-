using System;

#region STACK vs HEAP – FULL EXPLANATION INSIDE CODE

/* 
 ───────────────────────────────────────────────────────────────
   WHAT GOES TO STACK?
   • Value types: int, bool, double, struct
   • Method parameters
   • Local variables
   • References (addresses) that point to objects in HEAP

   WHAT GOES TO HEAP?
   • Objects created using new
   • Class instances
   • Arrays, List<T>, string (special but stored on heap)
   • Anything reference type

   IMPORTANT:
   • Stack stores ACTUAL VALUES
   • Heap stores OBJECTS
   • Stack only stores the REFERENCE (address) to heap objects
 ───────────────────────────────────────────────────────────────
*/

#endregion

class Person
{
    // These fields live INSIDE the Person object (which is stored in HEAP)
    public string Name;   // string is REFERENCE TYPE → stored in HEAP
    public int Age;       // AGE is value, but stored INSIDE a HEAP object
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== STACK EXAMPLE (Value Types) ===");

        // VALUE TYPE → stored in STACK
        int a = 10;

        // This copies the VALUE, not the variable
        int b = a;   // both independent on STACK
        b = 20;

        Console.WriteLine($"a = {a}"); // 10
        Console.WriteLine($"b = {b}"); // 20

        /*  
            STACK (simple diagram)
            ┌───────────────┐
            │ a = 10        │
            │ b = 20        │
            └───────────────┘
        */

        Console.WriteLine("\n=== HEAP EXAMPLE (Reference Types) ===");

        // p1 is on STACK (reference)
        // new Person() → object stored in HEAP
        Person p1 = new Person();
        p1.Name = "John";
        p1.Age = 30;

        // p2 is another STACK reference
        // It POINTS to the SAME HEAP OBJECT
        Person p2 = p1;

        // Changing p2 modifies the same object p1 points to
        p2.Age = 50;

        Console.WriteLine($"p1.Age = {p1.Age}"); // 50
        Console.WriteLine($"p2.Age = {p2.Age}"); // 50

        /*
            STACK (references only)
            ┌────────────────────┐
            │ p1 → address 0x101 │───────────┐
            │ p2 → address 0x101 │───────────┘  BOTH point to same heap object
            └────────────────────┘

            HEAP (actual object)
            ┌────────────────────────────┐
            │ Person @ 0x101            │
            │ Name = "John"             │
            │ Age = 50                  │
            └────────────────────────────┘
        */

        Console.WriteLine("\n=== ARRAY EXAMPLE (Reference Type) ===");

        int[] arr1 = new int[] { 10 };   // arr1 reference stored in STACK, array in HEAP
        int[] arr2 = arr1;               // arr2 points to SAME HEAP array

        arr2[0] = 99;                    // modifies same heap memory

        Console.WriteLine($"arr1[0] = {arr1[0]}"); // 99
        Console.WriteLine($"arr2[0] = {arr2[0]}"); // 99

        /*
            STACK
            ┌────────────────────┐
            │ arr1 → 0x201       │────┐
            │ arr2 → 0x201       │────┘
            └────────────────────┘

            HEAP
            ┌────────────────────┐
            │ Array @ 0x201      │
            │ [0] = 99           │
            └────────────────────┘
        */

        Console.WriteLine("\n=== END OF DEMO ===");
    }
}
