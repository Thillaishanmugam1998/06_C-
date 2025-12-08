using System;

namespace _3_LITERALS
{
    class Program
    {
        static void Main(string[] args)
        {
            // --------------------------------------------------------------------
            // WHAT ARE LITERALS?
            // Literals are FIXED values written directly in code.
            // Example: 10, 3.14, 'A', "Hello", true
            // They cannot change while program is running.
            // --------------------------------------------------------------------

            #region INTEGER LITERALS
            int decimalValue = 100;        // Decimal literal (base 10)
            int hexValue = 0x1A3F;         // Hexadecimal literal (base 16)
            int binaryValue = 0b1010;      // Binary literal (only 0 & 1)
            #endregion

            #region FLOATING-POINT LITERALS
            double d1 = 10.55;             // Default floating literal = double
            float f1 = 10.55f;             // Float literal → must end with 'f'
            decimal money = 99.99m;        // Decimal literal → must end with 'm'
            #endregion

            #region CHARACTER LITERALS
            char letter = 'A';             // Normal character
            char escapeChar = '\n';        // Escape character literal (newline)
            char unicodeChar = '\u0041';   // Unicode literal → 'A'
            #endregion

            #region STRING LITERALS
            string normalString = "Hello\nWorld";
            // Above: \n works because normal strings allow escape sequences

            // VERBATIM STRING LITERAL (@)
            // @ keeps the text EXACTLY as typed. No escape sequences.
            // Useful for FILE PATHS and COMMAND-LINE ARGUMENTS.
            string filePath = @"C:\Users\MyFolder\Docs";
            // No need for \\ (double backslashes)

            // COMMAND-LINE EXAMPLE using verbatim string
            // Quotes inside @ string must be doubled ("")
            string command =
                @"dotnet run --config=""C:\Program Files\MyApp\config.json""";
            #endregion

            #region BOOLEAN LITERALS
            bool isActive = true;          // Only true or false allowed
            bool isValid = false;          // Must be lower-case
            #endregion

            Console.WriteLine("Literal examples executed.");
        }
    }
}
