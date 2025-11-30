using System;

namespace _3_CUSTOM_EXCEPTION
{
    class Program
    {
        static void Main(string[] args)
        {
            #region --- EXCEPTION TYPES AND EXPLANATION ---
            /*
             * ============================
             *      TYPES OF EXCEPTIONS
             * ============================
             *
             * In C#, exceptions fall into two categories:
             * 
             * 1. **System Exceptions**
             *    - These are built-in exceptions provided by .NET.
             *    - Thrown automatically by the CLR when common runtime errors occur.
             *    - Examples:
             *        - DivideByZeroException
             *        - NullReferenceException
             *        - FormatException
             *        - IndexOutOfRangeException
             *    - Purpose:
             *        They handle all standard, generic, and low-level errors.
             *
             *
             * 2. **Custom Exceptions**
             *    - These are user-defined exceptions created using class inheritance.
             *    - Used when your application needs to report domain-specific errors.
             *    - Example:
             *        - "InsufficientFundsException" in Banking System
             *        - "InvalidLoanNumberException" in your Loan Management System
             *    - Purpose:
             *        They provide meaningful, business-related error messages,
             *        making debugging easier and enforcing business rules properly.
             *
             *
             * ============================
             *      WHY WE NEED BOTH?
             * ============================
             *
             * ✔ System Exceptions:
             *   - Cover all generic runtime errors.
             *   - Already implemented & optimized by .NET.
             *
             * ✔ Custom Exceptions:
             *   - Used when system exceptions do NOT describe your business problem.
             *   - Help developers understand exactly what failed in your logic.
             *   - Make applications more maintainable and readable.
             *   
             * Example Scenario:
             * -----------------
             * If a loan number is invalid:
             *   - System exceptions don’t explain business meaning.
             *   - Custom exception (InvalidLoanNumberException) clearly tells the cause.
             *
             */
            #endregion

            BankAccount account = new BankAccount("Thillai", 5000);

            try
            {
                Console.WriteLine("Enter withdrawal amount:");
                decimal amount = Convert.ToDecimal(Console.ReadLine());

                account.Withdraw(amount);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine("Bank Error: " + ex.Message);
                Console.WriteLine("Debug Info: " + ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
        }

    }
}
