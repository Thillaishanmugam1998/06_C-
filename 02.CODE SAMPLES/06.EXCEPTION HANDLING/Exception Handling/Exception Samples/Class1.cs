using System;
using System.Collections.Generic;
using System.Text;

namespace Exception_Samples
{
    class Class1
    {
        #region Example for unhandled exception
        //Here exception occur while divide a/b after this line nox execute because we not 
        //Handle the exception properly.
        public void WithException()
        {
            int a = 20;
            int b = 0;
            int c = a/b;
            Console.WriteLine("After Division Values:" + c); //This line Not execute because program exit
        }
        #endregion

        #region Example for Exception handling simple
        public void WithExceptionHandling()
        {
            try
            {
                int a = 20;
                int b = 0;
                int c = a / b;
                Console.WriteLine("After Division Values:" + c); //This line Not execute because program exit
            }
            catch
            {
                Console.WriteLine("Exception occur");
            }
        }
        #endregion

        #region Example With Exception Handling With Property
        public void ExceptionHandling()
        {
            int Number1, Number2, Result;
            try
            {
                Console.WriteLine("Enter First Number:");
                Number1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Second Number:");
                Number2 = int.Parse(Console.ReadLine());
                Result = Number1 / Number2;
                Console.WriteLine($"Result = {Result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Source: {ex.Source}");
                Console.WriteLine($"HelpLink: {ex.HelpLink}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
            Console.ReadKey();
        }
        #endregion

    }
}
