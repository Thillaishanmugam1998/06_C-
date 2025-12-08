using System;

namespace _2_CHAR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CHAR DATA TYPE (Simple Explanation) ===\n");

            #region What is Char?
            // ----------------------------------------------------------
            // CHAR DATA TYPE (VERY SIMPLE EXPLANATION)
            // ----------------------------------------------------------
            // • char = 2 bytes (16-bit)
            // • Stores Unicode characters → UTF-16 format
            // • Range: 0 to 65535 ('\0' to '\uffff')
            // • Can store characters from ANY language
            //   (Tamil, Hindi, English, Chinese, symbols, etc.)
            // ----------------------------------------------------------
            #endregion

            #region Char Examples
            char english = 'A';
            char tamil = 'அ';
            char hindi = 'क';
            char chinese = '你';
            char symbol = '#';

            Console.WriteLine("Character Examples:");
            Console.WriteLine(english);
            Console.WriteLine(tamil);
            Console.WriteLine(hindi);
            Console.WriteLine(chinese);
            Console.WriteLine(symbol + "\n");
            #endregion

            #region MinMax Char
            // ----------------------------------------------------------
            // C# gives built-in MIN and MAX values for char
            // ----------------------------------------------------------
            Console.WriteLine("Char Min and Max Values:");
            Console.WriteLine($"MinValue (decimal): {(int)char.MinValue}");
            Console.WriteLine($"MaxValue (decimal): {(int)char.MaxValue}\n");
            #endregion

            #region Why Char vs Byte (Short)
            // ----------------------------------------------------------
            // BYTE vs CHAR
            // ----------------------------------------------------------
            // byte:
            // • Size: 1 byte (0–255)
            // • ASCII only
            // • Used for raw data (images, files)
            //
            // char:
            // • Size: 2 bytes (0–65535)
            // • Unicode → any language
            // • Used when showing characters to users
            // ----------------------------------------------------------
            #endregion

            #region Checking Data Type Auto-Detection
            // ----------------------------------------------------------
            // C# AUTO IDENTIFIES TYPE USING LITERALS
            // ----------------------------------------------------------
            var c1 = 'A';      // auto → char
            var c2 = "A";      // auto → string
            var n1 = 100;      // auto → int
            var n2 = 10.5;     // auto → double

            Console.WriteLine("Auto Type Detection:");
            Console.WriteLine($"c1 is {c1.GetType()}");
            Console.WriteLine($"c2 is {c2.GetType()}");
            Console.WriteLine($"n1 is {n1.GetType()}");
            Console.WriteLine($"n2 is {n2.GetType()}\n");
            #endregion

            #region Summary
            // ----------------------------------------------------------
            // SHORT SUMMARY (EASY TO REMEMBER)
            // ----------------------------------------------------------
            // char = 2 bytes (UTF-16)
            // Supports all languages + symbols
            // Range: 0 → 65535
            // Use char → display characters to user
            // Use byte → raw/binary data
            // C# auto detects: 'A' → char, "A" → string
            // ----------------------------------------------------------
            #endregion

            Console.WriteLine("=== END ===");
        }
    }
}
