using System;

namespace _2_DATA_TYPES
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DATA REPRESENTATION, BYTE & SBYTE ===\n");

            #region Data Representation Example
            // --------------------------------------------------------------
            // HOW DATA IS REPRESENTED IN A COMPUTER?
            // --------------------------------------------------------------
            // A computer only understands binary (0s and 1s).
            // Any data (letters, images, videos, numbers) must be stored
            // in binary format internally.
            //
            // Example:
            // Character 'A' → ASCII Decimal = 65
            // Decimal 65 → Binary (8-bit) = 01000001
            //
            // So internally, 'A' is saved as 01000001 (1 Byte).
            //
            // In C#, we simply write: char letter = 'A';
            // The system handles the binary conversion internally.
            // --------------------------------------------------------------

            char letter = 'A';
            int asciiDecimal = letter;
            string asciiBinary = Convert.ToString(asciiDecimal, 2).PadLeft(8, '0');

            Console.WriteLine($"Character        : {letter}");
            Console.WriteLine($"ASCII (Decimal)  : {asciiDecimal}");
            Console.WriteLine($"Binary (8-bit)   : {asciiBinary}\n");
            #endregion


            #region What Are Data Types
            // --------------------------------------------------------------
            // WHAT IS A DATA TYPE?
            // --------------------------------------------------------------
            // A data type defines:
            // 1. What kind of value can be stored
            // 2. How much memory is required
            // 3. What operations can be applied on that value
            //
            // TYPES OF DATA TYPES:
            // 1) Value Types (int, byte, bool, double, char, struct...)
            // 2) Reference Types (class, string, array, delegate...)
            // --------------------------------------------------------------
            #endregion


            #region Value Type: BYTE (Unsigned 8-bit Integer)
            // --------------------------------------------------------------
            // BYTE DATA TYPE
            // --------------------------------------------------------------
            // • Byte is an 8-bit UNSIGNED integer.
            // • UNSIGNED means -> Only Positive Numbers (No negative allowed)
            // • Size: 1 byte (8 bits)
            // • Range: 0 to 255
            //
            // Why this range?
            // 8 bits => 2^8 = 256 combinations
            //
            // Binary:
            // Lowest: 00000000 = 0
            // Highest: 11111111 = 255
            //
            // Best used for:
            // - ASCII values
            // - File handling
            // - Networking packets
            // - IoT / Microcontroller data
            // --------------------------------------------------------------

            byte minByte = 0;
            byte maxByte = 255;

            Console.WriteLine("BYTE Values:");
            Console.WriteLine($"Minimum Byte : {minByte}");
            Console.WriteLine($"Maximum Byte : {maxByte}\n");
            #endregion


            #region ASCII Example Using Byte
            // --------------------------------------------------------------
            // BYTE WITH ASCII EXAMPLE
            // --------------------------------------------------------------
            byte asciiByte = 65;             // ASCII for 'A'
            char asciiFromByte = (char)asciiByte;

            Console.WriteLine("ASCII Using Byte:");
            Console.WriteLine($"Byte value     : {asciiByte}");
            Console.WriteLine($"Converted char : {asciiFromByte}\n");
            #endregion


            #region Value Type: SBYTE (Signed 8-bit Integer)
            // --------------------------------------------------------------
            // SBYTE DATA TYPE
            // --------------------------------------------------------------
            // • SByte is an 8-bit SIGNED integer.
            // • SIGNED means -> Supports both Positive and Negative numbers
            // • Size: 1 byte (8 bits)
            // • Range: -128 to +127
            //
            // Why negative values?
            // Because the highest bit is used as a SIGN BIT:
            // 0 → Positive
            // 1 → Negative
            //
            // Example (Binary):
            // +3  = 00000011
            // -3  = 11111101  (Two's Complement)
            //
            // Use SByte when:
            // - You need small numbers INCLUDING negative values
            // - Memory saving in performance-critical systems
            // --------------------------------------------------------------

            sbyte minSByte = -128;
            sbyte maxSByte = 127;

            Console.WriteLine("SBYTE Values:");
            Console.WriteLine($"Minimum SByte : {minSByte}");
            Console.WriteLine($"Maximum SByte : {maxSByte}\n");
            #endregion


            #region SByte Example With Binary Display
            // --------------------------------------------------------------
            // SHOWING BINARY VALUES OF SBYTE
            // --------------------------------------------------------------
            sbyte positiveValue = 10;
            sbyte negativeValue = -10;

            string posBin = Convert.ToString(positiveValue, 2).PadLeft(8, '0');
            string negBin = Convert.ToString(negativeValue, 2).PadLeft(8, '0');

            Console.WriteLine("SBYTE Binary Representation:");
            Console.WriteLine($"Positive 10 in Binary : {posBin}");
            Console.WriteLine($"Negative -10 in Binary: {negBin}");
            Console.WriteLine("(Note: Negative numbers use Two's Complement)\n");
            #endregion


            #region Byte vs SByte Comparison
            // --------------------------------------------------------------
            // BYTE vs SBYTE QUICK COMPARISON
            // --------------------------------------------------------------
            // BYTE  : 0 to 255      (Unsigned → Positive only)
            // SBYTE : -128 to +127  (Signed → Negative + Positive)
            //
            // BYTE cannot store negative values:
            // byte b = -10;  ❌ ERROR
            //
            // SBYTE can:
            // sbyte s = -10; ✔ VALID
            // --------------------------------------------------------------

            Console.WriteLine("BYTE vs SBYTE Comparison:");
            Console.WriteLine("BYTE  Range  : 0 to 255");
            Console.WriteLine("SBYTE Range  : -128 to 127\n");
            #endregion

            Console.WriteLine("=== END ===");
        }
    }
}
