using System;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace _5.MUTEX_EXAMPLES
{
    class Program
    {
        #region 1. WHAT IS MUTEX?
        /*
         * MUTEX = MUTUAL EXCLUSION
         * -----------------------
         * Meaning:
         *  - Oru time-la oru thread / oru application mattum dhaan
         *    oru shared resource-ah use panna mudiyum.
         *
         * Shared Resource examples:
         *  - File
         *  - Printer
         *  - Hardware device
         *  - Database
         *
         * Daily life example:
         * -------------------
         *  Bathroom lock
         *  - One person inside
         *  - Others must wait
         *  - Lock open panna apram next person
         *
         * Bathroom lock = MUTEX
         */
        #endregion


        #region 2. WHY LOCK & MONITOR ARE NOT ENOUGH
        /*
         * lock / Monitor:
         * ---------------
         *  - Works ONLY inside SAME application (same EXE)
         *  - Controls multiple threads in one process
         *
         * Problem:
         * --------
         *  If two DIFFERENT EXE access same resource,
         *  lock / Monitor CANNOT protect it.
         *
         * Example:
         * --------
         *  Service.exe  ---> app.log
         *  Admin.exe    ---> app.log
         *
         * lock inside Service.exe
         *  -> Admin.exe ku theriyadhu
         *
         * Result:
         * -------
         *  - File corruption
         *  - Access denied error
         *  - Random crashes
         */
        #endregion


        #region 3. WHY MUTEX IS NEEDED
        /*
         * Mutex:
         * ------
         *  - Works across MULTIPLE applications (multiple EXE)
         *  - OS (Kernel) level synchronization
         *
         * Important line to remember:
         * ---------------------------
         *  lock / Monitor = same EXE
         *  Mutex          = different EXE
         */
        #endregion


        #region 4. MUTEX OBJECT CREATION - FULL EXPLANATION
        /*
         * Mutex constructor:
         * ------------------
         * new Mutex(bool initiallyOwned, string name)
         *
         * ARGUMENT 1 : initiallyOwned
         * ---------------------------
         * true  -> Current thread immediately owns the mutex
         * false -> Mutex created, but ownership NOT taken
         *
         * Why we use FALSE?
         * -----------------
         *  - We want to explicitly control ownership
         *  - We call WaitOne() manually
         *
         * ARGUMENT 2 : name
         * -----------------
         *  - Name identifies the mutex
         *  - Same name = SAME mutex across applications
         *
         * Why "Global\\" ?
         * ----------------
         *  - Makes mutex visible to ALL EXE in system
         *  - Required when multiple applications must sync
         *
         * If we DON’T use Global\\ :
         * -------------------------
         *  - Mutex works only inside same user session
         *
         * Real-time meaning:
         * ------------------
         *  Global\\AppLogMutex
         *  -> Any EXE using this name
         *  -> Will compete for SAME shared resource
         */
        #endregion
        static Mutex mutex = new Mutex(false, "Global\\AppLogMutex");


        #region 5. SHARED RESOURCE DETAILS
        /*
         * Shared Resource:
         * ----------------
         *  Same log file accessed by:
         *   - Internal threads (same EXE)
         *   - External threads (another EXE)
         */
        #endregion
        static string logFilePath = @"C:\AppLogs\app.log";


        static void Main(string[] args)
        {
            #region 6. REAL-TIME STEP-BY-STEP FLOW
            /*
             * STEP-1:
             * -------
             *  First EXE starts
             *  - Mutex is FREE
             *  - EXE gets mutex
             *  - Accesses shared file
             *
             * STEP-2:
             * -------
             *  Second EXE starts
             *  - Mutex already owned
             *  - Second EXE WAITS
             *
             * STEP-3:
             * -------
             *  First EXE releases mutex
             *  - Second EXE continues automatically
             *
             * NOTE:
             * -----
             *  Waiting & waking is handled by OS (Kernel)
             */
            #endregion

            Console.WriteLine("Application Started...");
            Console.WriteLine("Trying to access shared log file...");
            Console.WriteLine();


            #region 7. mutex.WaitOne() EXPLANATION
            /*
             * mutex.WaitOne():
             * ----------------
             * Meaning:
             *  - This thread requests OS permission
             *    to enter critical section.
             *
             * CASE 1:
             * -------
             *  Mutex FREE -> enters immediately
             *
             * CASE 2:
             * -------
             *  Mutex OWNED -> thread WAITS
             *
             * CPU waste?
             * ----------
             *  NO. OS handles waiting efficiently.
             */
            #endregion
            mutex.WaitOne();   // BLOCKS until mutex is available

            try
            {
                #region 8. CRITICAL SECTION (PROTECTED BY MUTEX)
                /*
                 * Only ONE thread across ALL EXE
                 * can execute this block at a time.
                 *
                 * Internal thread (same EXE)  -> controlled
                 * External thread (other EXE) -> controlled
                 */
                Console.WriteLine("Mutex Acquired ✅");

                Directory.CreateDirectory(@"C:\AppLogs");

                File.AppendAllText(
                    logFilePath,
                    $"Log written by ProcessId {Process.GetCurrentProcess().Id} at {DateTime.Now}\n"
                );

                // Simulate long file operation
                Thread.Sleep(5000);

                Console.WriteLine("Log write completed.");
                #endregion
            }
            finally
            {
                #region 9. RELEASE MUTEX (MANDATORY)
                /*
                 * ALWAYS release mutex in finally block
                 *
                 * If NOT released:
                 * ----------------
                 *  - Other EXE will wait forever
                 *  - Deadlock situation
                 */
                #endregion
                mutex.ReleaseMutex();
                Console.WriteLine("Mutex Released 🔓");
            }

            Console.ReadLine();
        }


        #region 10. BALANCE INFORMATION (WHEN / WHEN NOT TO USE MUTEX)
        /*
         * USE MUTEX WHEN:
         * ---------------
         *  - Same file used by multiple EXE
         *  - Hardware / COM port access
         *  - Prevent multiple application instances
         *  - Service + Admin tool scenario
         *
         * DO NOT USE MUTEX WHEN:
         * ---------------------
         *  - Threads inside same EXE only
         *  - Performance critical inner loops
         *
         * For same EXE threads:
         * ---------------------
         *  Use lock / Monitor (faster)
         */
        #endregion


        #region 11. FINAL ONE-LINE SUMMARY
        /*
         * lock / Monitor -> same EXE, multiple threads
         * Mutex          -> multiple EXE, shared resource
         *
         * mutex.WaitOne()  -> ASK permission
         * ReleaseMutex()  -> GIVE permission back
         */
        #endregion
    }
}
