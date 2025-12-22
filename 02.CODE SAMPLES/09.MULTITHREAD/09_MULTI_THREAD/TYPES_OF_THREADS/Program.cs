using System;
using System.Threading;

namespace ThreadTypesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            =====================================================
            CONCEPT: FOREGROUND vs BACKGROUND THREAD
            =====================================================

            Foreground Thread:
            - Keeps application alive
            - CLR waits until it finishes

            Background Thread:
            - Does NOT keep application alive
            - Automatically stopped when all foreground threads end

            RULE:
            -----
            When ALL foreground threads complete,
            CLR terminates the process even if background threads are running.
            */

            Console.WriteLine("Main thread started (Foreground)");

            // Foreground Thread
            Thread fgThread = new Thread(ForegroundWork);
            fgThread.IsBackground = false; // default
            fgThread.Start();

            // Background Thread
            Thread bgThread = new Thread(BackgroundWork);
            bgThread.IsBackground = true;  // important
            bgThread.Start();

            // Main thread ends early
            Thread.Sleep(2000);
            Console.WriteLine("Main thread completed");
        }

        static void ForegroundWork()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"[FOREGROUND] Working... {i}");
                Thread.Sleep(1000);
            }

            Console.WriteLine("[FOREGROUND] Completed");
        }

        static void BackgroundWork()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"[BACKGROUND] Working... {i}");
                Thread.Sleep(1000);
            }

            // This will never print
            Console.WriteLine("[BACKGROUND] Completed");
        }

        #region OUTPUT

        /*
        =========================
        FINAL OUTPUT (Console)
        =========================

        Main thread started (Foreground)
        [FOREGROUND] Working... 1
        [BACKGROUND] Working... 1
        [FOREGROUND] Working... 2
        [BACKGROUND] Working... 2
        Main thread completed
        [FOREGROUND] Working... 3
        [FOREGROUND] Working... 4
        [FOREGROUND] Working... 5
        [FOREGROUND] Completed

        =========================
        OUTPUT EXPLANATION
        =========================

        1) Main thread starts first (Foreground thread).
        2) Foreground and Background threads run together.
        3) Main thread finishes after 2 seconds.
        4) CLR waits because Foreground thread is still running.
        5) Foreground thread completes fully.
        6) Background thread is TERMINATED automatically.
        7) So "[BACKGROUND] Completed" is NOT printed.

        CONCLUSION:
        -----------
        ✔ Foreground thread keeps app alive
        ✔ Background thread dies when foreground ends

        */

        #endregion
    }
}
