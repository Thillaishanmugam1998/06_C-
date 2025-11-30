// ============================================================
// File Name: ErrorTypes.cs
// Author: Thillai Shanmugam
// Description: Explains different types of errors, exceptions,
//              and exception handling in C# with simple examples.
// ============================================================

using System;

namespace ErrorHandlingDemo
{
    /// <summary>
    /// Provides explanations and examples of error types, exceptions,
    /// and exception handling in C#.
    /// </summary>
    public class ErrorTypes
    {
        // ============================================================
        // 1️⃣ COMPILE-TIME ERRORS
        // ============================================================
        // ➤ Meaning:
        //   These errors are detected by the compiler before the program runs.
        //   The code will not compile until you fix them.
        //
        // ➤ Common Causes:
        //   - Missing semicolon or brackets
        //   - Using undeclared variables
        //   - Incorrect type assignment
        //
        // ⚠ Example (commented to avoid breaking compilation):
        // int number = "Hello";   // ❌ Cannot convert string to int
        // int value               // ❌ Missing semicolon

        // ============================================================
        // 2️⃣ RUNTIME ERRORS
        // ============================================================
        // ➤ Meaning:
        //   These occur while the program is running.
        //   The compiler does not detect them in advance.
        //
        // ➤ Common Causes:
        //   - Division by zero
        //   - Null reference access
        //   - File not found
        //
        // ➤ Example:
        public void DemonstrateRuntimeError()
        {
            try
            {
                int x = 10;
                int y = 0;
                int result = x / y;  // ❌ Runtime error: DivideByZeroException
                Console.WriteLine(result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Runtime Error Caught: " + ex.Message);
            }
        }

        // ============================================================
        // 3️⃣ LOGICAL ERRORS
        // ============================================================
        // ➤ Meaning:
        //   The program runs without crashing but gives wrong results
        //   due to mistakes in logic or calculation.
        //
        // ➤ Example:
        public void DemonstrateLogicalError()
        {
            int a = 5, b = 10;
            int wrongSum = a - b; // ❌ Logic mistake: should be a + b
            Console.WriteLine("Incorrect Result (Logical Error): " + wrongSum);
        }

        // ============================================================
        // 4️⃣ WHAT IS AN EXCEPTION?
        // ============================================================
        // ➤ Meaning:
        //   An Exception is an event that occurs during program execution
        //   that interrupts the normal flow of instructions.
        //   In simple words — it’s a runtime problem that tells you
        //   something went wrong (like dividing by zero or accessing null data).
        //
        // ➤ Examples:
        //   - DivideByZeroException
        //   - NullReferenceException
        //   - FileNotFoundException
        //   - IndexOutOfRangeException
        //
        // ➤ Cause of Abnormal Program Stop:
        //   If an exception occurs and is NOT handled properly,
        //   the program will terminate abnormally (crash).
        //   Exception handling helps to stop that from happening.

        // ============================================================
        // 5️⃣ WHAT IS EXCEPTION HANDLING IN C#?
        // ============================================================
        // ➤ Meaning:
        //   The process of catching the exception for converting
        //   the CLR-given (technical) exception message into a
        //   user-understandable message and preventing program crashes
        //   whenever runtime errors occur is called *Exception Handling*.
        //
        // ➤ Advantages:
        //   ✔ Stops abnormal program termination (no crash)
        //   ✔ Allows corrective action (handle or recover from the issue)
        //   ✔ Displays user-friendly error messages to guide the user
        //
        // ➤ Example Demonstration:
        public void DemonstrateExceptionHandling()
        {
            try
            {
                string name = null;
                Console.WriteLine(name.Length); // ❌ Throws NullReferenceException
            }
            catch (NullReferenceException ex)
            {
                // Catch block handles the problem gracefully
                Console.WriteLine("User-Friendly Message: Please make sure the data is not empty.");
                Console.WriteLine("System Message: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally Block: Program ended safely, resources cleaned up.");
            }
        }

        // ============================================================
        // 6️⃣ WHAT ARE TRY, CATCH, AND FINALLY BLOCKS?
        // ============================================================
        // ➤ try block:
        //   - The code that *might* throw an exception is written inside the try block.
        //   - If an error happens, control immediately moves to the catch block.
        //
        // ➤ catch block:
        //   - Used to *catch* and handle the exception.
        //   - You can display a message, log the error, or take corrective action.
        //
        // ➤ finally block:
        //   - This block always executes, whether an exception occurs or not.
        //   - It is used to clean up resources like closing files, database connections, etc.
        //
        // ➤ Simple Real-World Example:
        //   Imagine you’re withdrawing cash from an ATM:
        //   - try → Insert card and request cash.
        //   - catch → Machine detects no balance and shows an error message.
        //   - finally → Machine always returns your card at the end.
        //
        // ➤ Example Code:
        public void ExplainTryCatchFinally()
        {
            try
            {
                Console.WriteLine("Trying to divide numbers...");
                int result = 10 / 0; // ❌ Will throw DivideByZeroException
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Catch Block: Cannot divide by zero!");
                Console.WriteLine("System Info: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally Block: Execution completed. Resources closed safely.");
            }
        }

        // ============================================================
        // ⚔ WHICH IS MORE DANGEROUS?
        // ============================================================
        // ➤ Runtime errors and unhandled exceptions are more dangerous
        //   because they happen after deployment and can cause:
        //   - Program crashes
        //   - Data loss
        //   - Poor user experience
        //   - Security risks
        //
        // Compile-time errors are less dangerous because they are caught
        // early by the compiler before the program even runs.
    }
}
