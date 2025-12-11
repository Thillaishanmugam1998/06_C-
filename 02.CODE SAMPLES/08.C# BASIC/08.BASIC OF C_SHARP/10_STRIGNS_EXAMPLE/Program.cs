using System;
using System.Diagnostics;
using System.Text;

namespace StringConcepts_InterviewReady
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1. MUTABLE VS IMMUTABLE – BASIC IDEA
            /*
                Mutable   = Can be changed (same memory reused).
                Immutable = Cannot be changed (new memory created).

                Example:
                - string → Immutable
                - int, array, StringBuilder → Mutable
            */
            #endregion



            #region 2. WHY STRING IS IMMUTABLE (REAL MEMORY STORY)
            /*
                string str = "DotNet";       // Memory Block A created
                str = "Tutorials";           // Memory Block B created

                IMPORTANT:
                - First object ("DotNet") does NOT change.
                - Second assignment creates a brand-new object.
                - "str" now points to new memory.
                - Old object → becomes garbage.

                This is why:
                ⭐ Every modification creates NEW string object.
            */
            #endregion



            #region 3. DEMO: STRING IMMUTABILITY USING HEAVY LOOP
            Console.WriteLine("IMMUTABILITY DEMO WITH STRING");
            string s = "";
            var sw1 = new Stopwatch();
            sw1.Start();

            for (int i = 0; i < 3_000_000; i++)
            {
                // Every loop creates NEW string object → VERY SLOW
                s = Guid.NewGuid().ToString();
            }

            sw1.Stop();
            Console.WriteLine("Time (ms) with string mutations: " + sw1.ElapsedMilliseconds);
            Console.WriteLine();
            #endregion



            #region 4. DEMO: INT (VALUE TYPE) IS MUTABLE
            Console.WriteLine("MUTABILITY DEMO WITH INT");
            int count = 0;
            var sw2 = new Stopwatch();
            sw2.Start();

            for (int i = 0; i < 3_000_000; i++)
            {
                // Same memory used → FAST
                count = count + 1;
            }

            sw2.Stop();
            Console.WriteLine("Time (ms) with int update: " + sw2.ElapsedMilliseconds);
            Console.WriteLine();
            #endregion



            #region 5. STRING INTERNING – SAME VALUE DOES NOT CREATE NEW MEMORY
            /*
                string interning:
                ------------------
                - If SAME STRING VALUE appears again,
                  .NET uses EXISTING memory block instead of creating a new one.

                So repeating exact same value is FAST.
            */

            Console.WriteLine("STRING INTERNING DEMO (same string assigned repeatedly)");
            string fixedStr = "";
            var sw3 = new Stopwatch();
            sw3.Start();

            for (int i = 0; i < 3_000_000; i++)
            {
                // SAME VALUE → Same memory reused → FAST
                fixedStr = "DotNet Tutorials";
            }

            sw3.Stop();
            Console.WriteLine("Time (ms) with identical string assignment: " + sw3.ElapsedMilliseconds);
            Console.WriteLine();
            #endregion



            #region 6. STRING CONCATENATION PROBLEM (VERY SLOW)
            /*
               Each concatenation creates NEW string → multiplies memory usage.

               Example:
               str = "A" + str;  
               Loop repeats → thousands of wasted objects → extremely slow.
            */

            Console.WriteLine("STRING CONCATENATION PROBLEM DEMO");
            string concatStr = "";
            var sw4 = new Stopwatch();
            sw4.Start();

            for (int i = 0; i < 30000; i++)
            {
                concatStr = "DotNet Tutorials " + concatStr; // NEW object created every time
            }

            sw4.Stop();
            Console.WriteLine("Time (ms) using string concatenation: " + sw4.ElapsedMilliseconds);
            Console.WriteLine();
            #endregion



            #region 7. STRINGBUILDER – MUTABLE & FAST (BEST FOR CONCATENATION)
            /*
                StringBuilder:
                --------------
                - Mutable → Same memory used
                - No new object created repeatedly
                - Extremely fast compared to string

                Best for:
                - Loops
                - Dynamic string building
                - Logging
                - Large text
            */

            Console.WriteLine("STRINGBUILDER DEMO – FAST & MUTABLE");
            StringBuilder sb = new StringBuilder();
            var sw5 = new Stopwatch();
            sw5.Start();

            for (int i = 0; i < 30000; i++)
            {
                sb.Append("DotNet Tutorials");
            }

            sw5.Stop();
            Console.WriteLine("Time (ms) using StringBuilder: " + sw5.ElapsedMilliseconds);
            Console.WriteLine();
            #endregion



            #region 8. WHY MICROSOFT MADE STRING IMMUTABLE?
            /*
                ⭐ THREAD SAFETY
                Multiple threads reading same string → no corruption.

                If strings were mutable:
                - Thread A changes the string → Thread B sees corrupted value.
                - Would break security & stability.

                Immutability ensures:
                - Safe sharing of strings
                - No accidental changes
                - Safe usage in dictionary keys, connection strings, config keys
            */
            #endregion



            Console.WriteLine("DEMO COMPLETE – PRESS ANY KEY");
            Console.ReadKey();
        }
    }
}
