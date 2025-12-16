using System;
using System.Threading;

namespace LoggingSynchronizationCases
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             NOTE:
             -----
             This file is ONLY for understanding CONCEPTS.
             Actual logging code is NOT written.
             Focus ONLY on WHEN and WHY we use
             lock / Monitor / Mutex / Semaphore.
            */
        }

        #region CASE-1 : Single Application + Single Thread (NO SYNCHRONIZATION NEEDED)

        /*
         SCENARIO:
         ---------
         - One application running on my PC
         - Inside that application ONLY ONE THREAD
         - That thread writes logs into a file

         REALITY:
         --------
         - Only one execution path
         - No race condition
         - No parallel access

         CONCLUSION:
         -----------
         ✔ No need for lock
         ✔ No need for Monitor
         ✔ No need for Mutex
         ✔ No need for Semaphore

         WHY:
         ----
         Because there is NO competition.
         Single thread is ALWAYS safe.
        */

        #endregion


        #region CASE-2 : Single Application + Multiple Threads (IN-PROCESS SYNCHRONIZATION)

        /*
         SCENARIO:
         ---------
         - One application running on my PC
         - Inside the application:
             * Thread-1 : Writes log file
             * Thread-2 : Reads log file
         - Both access SAME log file

         PROBLEM:
         --------
         - If write happens while read is in progress
         - Log file can be corrupted or inconsistent

         THREAD TYPE:
         ------------
         ✔ In-Process Threads (created by SAME EXE)

         SOLUTION:
         ---------
         ✔ Use lock OR Monitor

         RECOMMENDATION:
         ----------------
         ✔ Use lock (simpler and safer)

         BEHAVIOR:
         ---------
         - If WRITE is running → READ must WAIT
         - If READ is running → WRITE must WAIT

         IMPORTANT:
         ----------
         Mutex and Semaphore are NOT recommended here
         because they are slow (kernel-level).

         CONCLUSION:
         -----------
         ✔ lock / Monitor = BEST choice
        */

        #endregion


        #region CASE-3 : Multiple Applications + Same Log File (CROSS-PROCESS SYNCHRONIZATION)

        /*
         SCENARIO:
         ---------
         - Application-1:
             * Has multiple threads
             * Reads and writes the log file
         - Application-2:
             * Deletes the SAME log file
         - Both apps run on SAME PC
         - Same physical log file

         IMPORTANT CLARIFICATION:
         ------------------------
         Application-2 is NOT an external THREAD
         ✔ It is an EXTERNAL PROCESS

         PROBLEM:
         --------
         - lock / Monitor works ONLY inside ONE EXE
         - App-1 cannot control App-2 using lock
         - File access conflict occurs

         SOLUTION:
         ---------
         ✔ Use Named Mutex (Global)

         WHY MUTEX:
         ----------
         - Works across PROCESSES
         - Only ONE process can access log file at a time

         BEHAVIOR:
         ---------
         - App-1 WRITE finishes
         - App-2 DELETE starts
         - App-2 DELETE finishes
         - App-1 READ starts

         CONCLUSION:
         -----------
         ✔ Mutex is CORRECT and REQUIRED
        */

        #endregion


        #region CASE-4 : Multiple Applications + Limited Parallel Access (SEMAPHORE)

        /*
         SCENARIO:
         ---------
         - Application-1:
             * Read + Write log
         - Application-2:
             * Delete log
         - Application-3:
             * Edit log
         - All access SAME log file
         - All run on SAME PC

         REQUIREMENT QUESTION:
         ---------------------
         Do we want:
         A) ONLY ONE app at a time?
         OR
         B) LIMITED apps at a time?

         OPTION-A:
         ---------
         If ONLY ONE app should access log:
         ✔ Use Mutex
         (Strict, safe, slow)

         OPTION-B:
         ---------
         If LIMITED access is allowed (example: 2 at a time):
         ✔ Use Semaphore

         IMPORTANT TRUTH (VERY IMPORTANT):
         --------------------------------
         Semaphore DOES NOT guarantee ORDER

         ❌ It does NOT ensure:
             Read → Delete → Edit (sequence)

         ✔ It ONLY ensures:
             Max N processes at same time

         EXAMPLE:
         --------
         Semaphore count = 2

         Possible execution:
         - App-1 and App-3 enter
         - App-2 waits
         - Any one exits → App-2 enters

         ORDER IS DECIDED BY OS
         NOT BY SEMAPHORE

         CONCLUSION:
         -----------
         ✔ Semaphore = limited parallel access
         ❌ Semaphore ≠ execution order control
        */

        #endregion
    }
}
