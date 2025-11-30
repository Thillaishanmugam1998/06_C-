using System;

namespace Exception_Samples
{
    class Class2
    {
        #region --- 01. MULTIPLE CATCH BLOCK ---
        /// <summary>
        /// Demonstrates how multiple catch blocks work.  
        /// - DivideByZeroException: triggered when the divisor is zero.  
        /// - FormatException: triggered when input cannot be converted to an integer.  
        /// - Exception: fallback catch for any other unhandled exception types.
        /// </summary>
        public void MultipleCatchBlock()
        {
            try
            {
                Console.Write("Enter number 1: ");
                int a = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter number 2: ");
                int b = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Result: {a / b}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("You attempted to divide by zero.");
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid number format. Please enter only digits.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region --- 02. TRY / CATCH / FINALLY ---
        /// <summary>
        /// Demonstrates the use of try/catch/finally.  
        /// The 'finally' block always executes regardless of success or exception.  
        /// Used for cleanup like closing DB connections or file streams.
        /// </summary>
        public void Try_Catch_Finally()
        {
            try
            {
                Console.Write("Enter number 1: ");
                int a = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter number 2: ");
                int b = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Result: {a / b}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred.");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("This line always executes (cleanup logic goes here).");
            }
        }
        #endregion

        #region --- 03. TRY / FINALLY ---
        /// <summary>
        /// Demonstrates try/finally without a catch block.  
        /// Often used when you must guarantee cleanup even if exceptions are thrown,
        /// and you're letting the exception bubble up to the caller.
        /// </summary>
        public void Try_Finally()
        {
            try
            {
                Console.Write("Enter number 1: ");
                int a = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter number 2: ");
                int b = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Result: {a / b}");
            }
            finally
            {
                Console.WriteLine("Executing mandatory cleanup (even without catch).");
            }
        }
        #endregion
    }
}
