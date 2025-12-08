using System;

namespace _3_STRING
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== STRING DATA TYPE IN C# ===\n");

            #region Why String is Needed
            // -------------------------------------------------------------
            // WHY STRING?
            // -------------------------------------------------------------
            // • char stores ONLY ONE character → 'A'
            // • If we try to store more than one character → ERROR
            //
            // Example: char x = 'AB';  ❌ Too many characters in character literal
            //
            // So, to store MULTIPLE characters → use STRING.
            //
            // string = series of char values
            // -------------------------------------------------------------
            #endregion

            #region String Examples
            string name = "Thillai";
            string sentence = "Welcome to C# String Demo!";

            Console.WriteLine("String Examples:");
            Console.WriteLine(name);
            Console.WriteLine(sentence + "\n");
            #endregion

            #region String Memory Size Explanation
            // -------------------------------------------------------------
            // HOW TO KNOW STRING SIZE IN MEMORY?
            // -------------------------------------------------------------
            // char = 2 bytes (UTF-16)
            // string = collection of chars
            //
            // So:
            // Memory (in bytes) = string.Length * 2
            //
            // Example:
            // "ABC" → length = 3
            // Memory size = 3 * 2 = 6 bytes
            // -------------------------------------------------------------
            #endregion

            string word = "ABC";
            int length = word.Length;
            int memorySize = length * sizeof(char);   // char = 2 bytes

            Console.WriteLine("String Memory Calculation:");
            Console.WriteLine($"String Value : {word}");
            Console.WriteLine($"Length       : {length}");
            Console.WriteLine($"Memory (bytes): {memorySize}\n");

            #region String is a Reference Type
            // -------------------------------------------------------------
            // STRING IS A REFERENCE TYPE
            // -------------------------------------------------------------
            // • In C#, string is actually a CLASS
            // • All classes → Reference Types
            // • Reference types store their data on HEAP (not stack)
            //
            // Meaning:
            // string message = "Hello";
            // The variable stores a REFERENCE (address), not the actual text
            //
            // That's why:
            // - Strings are immutable (cannot be changed directly)
            // - New memory is allocated when you modify or append strings
            // -------------------------------------------------------------
            #endregion

            Console.WriteLine("Type Information:");
            Console.WriteLine($"name.GetType(): {name.GetType()}\n"); // System.String (class)

            #region Summary
            // -------------------------------------------------------------
            // QUICK SUMMARY (EASY TO REMEMBER)
            // -------------------------------------------------------------
            // • char → 1 character, 2 bytes
            // • string → multiple characters (sequence of char)
            // • Memory = Length * 2 bytes
            // • string is a REFERENCE TYPE (class)
            // • char 'AB' → ERROR (must be exactly ONE character)
            // -------------------------------------------------------------
            #endregion

            Console.WriteLine("=== END ===");
        }
    }
}
