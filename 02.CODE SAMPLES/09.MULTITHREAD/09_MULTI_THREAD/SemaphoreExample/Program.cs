using System;
using System.Threading;

namespace SemaphoreDemo
{
    class Program
    {
        // Semaphore reference
        // This will hold a named semaphore that can be shared
        // across MULTIPLE applications (processes)
        public static Semaphore semaphore = null;

        static void Main(string[] args)
        {
            try
            {
                // Try to OPEN an existing semaphore with the name "SemaphoreDemo"
                // ---------------------------------------------------------------
                // Real-time meaning:
                // "Is there already a gate controller named 'SemaphoreDemo'
                // created by another running application?"
                //
                // If YES  -> connect to the same semaphore
                // If NO   -> an exception will be thrown
                semaphore = Semaphore.OpenExisting("SemaphoreDemo");
            }
            catch (Exception)
            {
                // This block runs ONLY if the semaphore does NOT exist
                // ----------------------------------------------------
                // Create a NEW named semaphore
                //
                // First 2  -> Initial count (how many can enter immediately)
                // Second 2 -> Maximum count (maximum allowed at the same time)
                // "SemaphoreDemo" -> Global name shared across applications
                //
                // Real-time meaning:
                // "Create a gate that allows ONLY 2 external applications
                // to enter this critical section at the same time"
                semaphore = new Semaphore(2, 2, "SemaphoreDemo");
            }

            // This line means:
            // "This application is trying to enter the limited resource"
            Console.WriteLine("External Thread Trying to Acquiring");

            // WaitOne():
            // ----------
            // If a slot is available -> enter immediately
            // If NO slot available   -> WAIT until someone exits
            //
            // Real-time meaning:
            // "Wait at the gate until permission is given"
            semaphore.WaitOne();

            // This line means:
            // "This application has ENTERED the critical section"
            Console.WriteLine("External Thread Acquired");

            // Pause the application
            // ---------------------
            // This simulates:
            // - Using the shared resource
            // - Holding the semaphore slot
            //
            // While this app is paused:
            // - One semaphore slot is OCCUPIED
            // - Other apps may have to WAIT
            Console.ReadKey();

            // Release():
            // ----------
            // Frees ONE slot in the semaphore
            //
            // Real-time meaning:
            // "Application is leaving the resource
            //  and returning the access pass"
            semaphore.Release();
        }
    }
}
