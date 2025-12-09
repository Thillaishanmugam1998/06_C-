using System;

namespace _6_STATIC_KEYWORD
{
    // -----------------------------------------------------------------------
    // STATIC KEYWORD IN C#
    //
    // SIMPLE MEANING:
    //  - "static" means: this member belongs to the CLASS itself,
    //    NOT to an individual OBJECT.
    //
    //  - Non-static (instance) means: this member belongs to each OBJECT.
    //
    // INTERVIEW ONE-LINERS:
    //  - Static members are shared by ALL objects.
    //  - Non-static members are different for EACH object.
    //  - Static members are accessed using ClassName.MemberName.
    //  - Non-static members are accessed using objectReference.MemberName.
    // -----------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            #region 1. STATIC vs NON-STATIC METHODS (UTILITY EXAMPLE)

            // STATIC METHOD CALL:
            // We can call Add() directly using class name.
            int sum = MathHelper.Add(10, 20); // no object needed

            // NON-STATIC (INSTANCE) METHOD CALL:
            // We must create an object to call Multiply().
            MathHelper math = new MathHelper();
            int product = math.Multiply(10, 20); // object required

            // Why? 
            // - Add() is general calculation, no need to store object-specific data.
            // - Multiply() here is just to show syntax difference.

            #endregion

            #region 2. STATIC vs NON-STATIC FIELDS (SHARED vs INDIVIDUAL DATA)

            // VisitCounter example:
            // Static field: TotalVisits (shared by ALL users)
            // Instance field: MyVisits (private per user)

            VisitCounter user1 = new VisitCounter();
            VisitCounter user2 = new VisitCounter();

            user1.Visit(); // user1 visits once
            user1.Visit(); // user1 visits again

            user2.Visit(); // user2 visits once

            int totalVisitsAllUsers = VisitCounter.TotalVisits; // static → same for all
            int user1Visits = user1.MyVisits;       // 2
            int user2Visits = user2.MyVisits;       // 1

            // THINK:
            // - TotalVisits = 3 (1+1+1) → SHARED (static)
            // - Each user has their OWN MyVisits value → NON-STATIC

            #endregion

            #region 3. STATIC CLASS (ONLY STATIC MEMBERS, CANNOT CREATE OBJECT)

            // AppConfig is a static class:
            // - Use it for SETTINGS / CONFIGURATION / CONSTANTS.
            // - You CANNOT do: new AppConfig();

            string appName = AppConfig.ApplicationName;
            string env = AppConfig.Environment;
            AppConfig.PrintConfig();

            #endregion

            #region 4. STATIC CONSTRUCTOR (RUNS ONLY ONCE)

            // Logger has a static constructor:
            // - Runs ONLY ONE TIME in entire program.
            // - Used to initialize static fields (e.g., config, file paths).
            // We don't call it directly. It runs automatically when:
            //   - First time we access Logger.Log()
            //   - OR first time we create Logger object (if it were not static).

            Logger.Log("Application started.");
            Logger.Log("Static example running.");

            #endregion

            #region 5. WHEN TO USE STATIC? (SUMMARY FOR INTERVIEW)

            // GOOD USE CASES FOR STATIC:
            // 1) Utility/Helper methods
            //    - Example: MathHelper.Add, String utilities, Date utilities, etc.
            //
            // 2) Global configuration / settings
            //    - Example: AppConfig.ApplicationName, AppConfig.Environment
            //
            // 3) Shared counters or caches
            //    - Example: VisitCounter.TotalVisits
            //
            // 4) Logger, Common services where we don't need multiple objects
            //    - Example: Logger.Log()
            //
            // WHEN NOT TO USE STATIC:
            // 1) When data is different for each object
            //    - Example: Employee Name, Salary, Age, Address.
            //
            // 2) When you want to use OOP features like:
            //    - Inheritance, polymorphism, interfaces on instance level.
            //
            // 3) When you need to store STATE per user / per object
            //    - Example: shopping cart per customer, bank account balance, etc.
            #endregion

            Console.WriteLine("Static vs Non-Static examples loaded. Read comments inside code for full understanding.");
        }
    }

    #region CLASS: MathHelper (Static vs Non-Static Methods)

    class MathHelper
    {
        // STATIC METHOD:
        // - Belongs to CLASS, not object.
        // - Can be called as MathHelper.Add(…)
        // - Good for simple utility functions.
        public static int Add(int a, int b)
        {
            return a + b;
        }

        // NON-STATIC (INSTANCE) METHOD:
        // - Belongs to OBJECT.
        // - Need object: new MathHelper().Multiply(…)
        // - Good when method depends on object data (fields/properties).
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    #endregion

    #region CLASS: VisitCounter (Static vs Instance Fields Example)

    class VisitCounter
    {
        // STATIC FIELD:
        // - Shared by ALL objects.
        // - One copy for the entire class.
        public static int TotalVisits = 0;

        // INSTANCE FIELD (NON-STATIC):
        // - Each object gets its own copy.
        public int MyVisits = 0;

        public void Visit()
        {
            // Every time any object calls Visit():
            TotalVisits++; // Update shared count
            MyVisits++;    // Update this object's own count
        }
    }

    #endregion

    #region STATIC CLASS: AppConfig (Realistic Static Use Case)

    // STATIC CLASS:
    // - Cannot be instantiated (no "new AppConfig()").
    // - Can ONLY contain static members.
    // - Good for configuration, constants, common shared settings.
    static class AppConfig
    {
        public static string ApplicationName = "Factory Settings Tool";
        public static string Environment = "Development"; // e.g., Dev, Test, Prod

        public static void PrintConfig()
        {
            Console.WriteLine("App Name      : " + ApplicationName);
            Console.WriteLine("Environment   : " + Environment);
        }
    }

    #endregion

    #region CLASS: Logger (Static Method + Static Constructor Example)

    class Logger
    {
        // STATIC FIELD: Shared log prefix
        private static string _logPrefix;

        // STATIC CONSTRUCTOR:
        // - No access modifier, no parameters.
        // - Runs AUTOMATICALLY ONCE before first use of the class.
        static Logger()
        {
            // Imagine reading from config or building common format
            _logPrefix = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ";
        }

        // STATIC METHOD:
        // - We don't need an object to log messages.
        // - Called as: Logger.Log("message");
        public static void Log(string message)
        {
            Console.WriteLine(_logPrefix + message);
        }
    }

    #endregion
}
