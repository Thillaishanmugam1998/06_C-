using System;

namespace _1_CONSOLE_EXAMPLE
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * The Console class in C# (found in the System namespace)
             * provides basic input/output (I/O) operations for console applications.
             */

            #region Output Methods (Write & WriteLine)

            // We can access Write and WriteLine using the class name (Console)
            // because these methods are static.

            // WriteLine prints text and moves cursor to next line.
            Console.WriteLine("Thillai");

            // Write prints text but keeps cursor on same line.
            Console.Write("Shanmugam");

            #endregion

            #region Reading Input from User

            // ReadLine reads a string from the keyboard.
            Console.WriteLine("Enter the age");
            string age = Console.ReadLine();

            // Reading integer input from user.
            Console.WriteLine("Enter the mark");
            int mark = Convert.ToInt32(Console.ReadLine());

            #endregion

            #region Read and ReadKey Methods Explanation

            /*
             * Read() -> Allows user to enter a single character.
             *           Returns the ASCII value of that character.
             *
             * ReadKey() -> Reads a key press and returns key details such as:
             *              - The key pressed
             *              - The character
             *              - ASCII value of the character
             */

            Console.WriteLine("Enter the key");
            int value = Console.Read();
            Console.WriteLine("ASCII value of entered key is: " + value);

            Console.WriteLine("Enter another key");
            ConsoleKeyInfo values = Console.ReadKey();
            Console.WriteLine(
                $"\nEntered key: {values.Key} | Character: {values.KeyChar} | ASCII: {Convert.ToInt32(values.KeyChar)}"
            );

            #endregion

            #region Console Properties Demonstration

            // Changing console background and text color.
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Understanding Console Class";

            Console.WriteLine("BackgroundColor: Blue");
            Console.WriteLine("ForegroundColor: White");
            Console.WriteLine("Title: Understanding Console Class");

            // Makes a beep sound.
            Console.Beep();

            #endregion

            #region Program Termination

            // Waits for a key before closing the program.
            Console.ReadKey();

            #endregion
        }
    }
}
