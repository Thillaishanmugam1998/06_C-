using System;
using System.Threading;

namespace MultiThreadKitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"[{Now()}] Main Cook: Kitchen Started");

            // Helper cook (separate worker / thread) for Idly
            Thread helperCook = new Thread(MakingIdly);

            // Helper starts Idly steaming (long running work)
            helperCook.Start();

            // Main cook does Chutney work parallelly
            MakingChutney();

            Console.WriteLine($"[{Now()}] Main Cook: Chutney work finished");

            // Kitchen close panna munnaadi
            // Idly complete aaganum nu wait pannrom
            helperCook.Join();

            Console.WriteLine($"[{Now()}] Breakfast Ready. Kitchen Closed.");
            Console.ReadKey();
        }

        // ================= HELPER THREAD =================
        static void MakingIdly()
        {
            Console.WriteLine($"[{Now()}] Helper Cook: Idly steaming started (20 sec)");

            // 🔴 BLOCKING CALL
            // Helper thread 20 sec full-ah idle-aa irukkum
            // Indha time-la helper thread vera velai panna mudiyadhu
            Thread.Sleep(20000);

            Console.WriteLine($"[{Now()}] Helper Cook: Idly Cooked");
        }

        // ================= MAIN THREAD =================
        static void MakingChutney()
        {
            Console.WriteLine($"[{Now()}] Main Cook: Making Chutney started");

            CuttingVegetables();
            FryVegetables();
            AddWater();
            CookChutney();

            Console.WriteLine($"[{Now()}] Main Cook: Chutney Finished");
        }

        static void CuttingVegetables()
        {
            Console.WriteLine($"[{Now()}] Cutting vegetables...");
            Thread.Sleep(3000);
        }

        static void FryVegetables()
        {
            Console.WriteLine($"[{Now()}] Frying vegetables...");
            Thread.Sleep(3000);
        }

        static void AddWater()
        {
            Console.WriteLine($"[{Now()}] Adding water...");
            Thread.Sleep(1000);
        }

        static void CookChutney()
        {
            Console.WriteLine($"[{Now()}] Cooking chutney...");
            Thread.Sleep(2000);
        }

        static string Now()
        {
            return DateTime.Now.ToString("HH:mm:ss:fff");
        }
    }
}

#region WHAT_THIS_EXAMPLE_ACTUALLY_DOES_AND_DRAWBACKS
/*
====================================================
MULTI THREAD IDLY + CHUTNEY – CONCEPT NOTES
====================================================

WHAT IS HAPPENING HERE?
----------------------
1) We created TWO THREADS (2 workers):
   - Main Thread  -> Making Chutney
   - Helper Thread -> Steaming Idly

2) Both works start at the SAME TIME:
   - Idly steaming (20 sec)
   - Chutney preparation (~9 sec)

3) Main thread is NOT blocked by Idly work.
   So Chutney is completed while Idly is still cooking.

4) Join() ensures kitchen closes only AFTER Idly is done.


ADVANTAGE OVER SINGLE THREAD:
-----------------------------
- Single thread:
  Idly ready aana apram dhaan Chutney start pannum.
  Total time = 20 + 9 = ~29 sec

- Multi thread:
  Idly & Chutney parallel-aa nadakkum.
  Total time = max(20, 9) = ~20 sec


IMPORTANT DRAWBACK (VERY IMPORTANT):
-----------------------------------
1) Helper thread uses Thread.Sleep(20000)
2) During these 20 seconds:
   - Helper thread is COMPLETELY IDLE
   - CPU use illa
   - Vera work panna mudiyadhu
   - Thread resource (memory + stack) waste aagudhu

3) If many such long-running Sleep threads irundha:
   - System slow aagum
   - Thread starvation varum
   - Scalability problem varum


KEY INTERVIEW POINT:
-------------------
Multi-threading gives parallelism,
BUT blocking calls like Thread.Sleep
WASTE THREAD RESOURCES.

Best solution for such waiting work:
➡ ASYNC / AWAIT (non-blocking)
====================================================
*/
#endregion
