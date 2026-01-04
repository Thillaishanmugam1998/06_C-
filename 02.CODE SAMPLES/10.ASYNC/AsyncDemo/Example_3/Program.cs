using System;
using System.Threading.Tasks;

namespace Example_Async_Idly_Chutney
{
    class Program
    {
        // 1️⃣ Main method-ah 'async Task' ah mathanum
        // Appo dhaan await use panna mudiyum
        static async Task Main(string[] args)
        {
            string startTime = DateTime.Now.ToString("HH:mm:ss:fff");
            Console.WriteLine($"[{startTime}] Main Cook: Kitchen started.");

            // 2️⃣ Idly steaming start pannrom
            // Idhu background-la nadakkum (NON-BLOCKING)
            Task idlyTask = SteamIdlyAsync();

            // 3️⃣ Idly steam aagura gappula
            // Main Cook chutney prepare pannuvaaru
            await MakeChutneyAsync();

            // 4️⃣ Kitchen close panna munnaadi
            // Idly ready aaganum la?
            await idlyTask;

            string endTime = DateTime.Now.ToString("HH:mm:ss:fff");
            Console.WriteLine($"[{endTime}] Main Cook: Breakfast Ready. Kitchen Closed.");

            Console.ReadKey();
        }

        // 5️⃣ Always use 'async Task' (never async void)
        public static async Task SteamIdlyAsync()
        {
            Console.WriteLine($"[{Now()}] Idly steaming started (20 sec)");

            // 🔥 NON-BLOCKING WAIT
            // Thread free-aagum, waste illa
            await Task.Delay(20000);

            Console.WriteLine($"[{Now()}] Idly Cooked");
        }

        // 6️⃣ Chutney preparation steps (Sequential but async)
        public static async Task MakeChutneyAsync()
        {
            Console.WriteLine($"[{Now()}] Chutney preparation started");

            await CuttingVegetablesAsync();
            await FryVegetablesAsync();
            await AddWaterAsync();
            await CookChutneyAsync();

            Console.WriteLine($"[{Now()}] Chutney Finished");
        }

        static async Task CuttingVegetablesAsync()
        {
            Console.WriteLine($"[{Now()}] Cutting vegetables...");
            await Task.Delay(3000);
        }

        static async Task FryVegetablesAsync()
        {
            Console.WriteLine($"[{Now()}] Frying vegetables...");
            await Task.Delay(3000);
        }

        static async Task AddWaterAsync()
        {
            Console.WriteLine($"[{Now()}] Adding water...");
            await Task.Delay(1000);
        }

        static async Task CookChutneyAsync()
        {
            Console.WriteLine($"[{Now()}] Cooking chutney...");
            await Task.Delay(2000);
        }

        static string Now()
        {
            return DateTime.Now.ToString("HH:mm:ss:fff");
        }
    }
}

#region WHAT_THIS_ASYNC_EXAMPLE_ACTUALLY_DOES
/*
====================================================
ASYNC IDLY + CHUTNEY – ACTUAL BEHAVIOR NOTES
====================================================

1️⃣ Idly steaming uses Task.Delay(20000)
   - Thread block aagadhu
   - Thread free-aagi runtime-ku thirumba kudukkum
   - Waiting time-la thread waste aagadhu

2️⃣ Idly steam nadakkum bodhu:
   - Main Cook chutney prepare pannuvaaru
   - Cut -> Fry -> Add Water -> Cook
   - All steps async-aa, but order maintain pannum

3️⃣ await idlyTask:
   - Idly ready aagura varaikum kitchen close aagathu
   - Proper execution flow maintain pannum

4️⃣ Compared to Multi-Thread + Sleep:
   - No extra thread created
   - No thread idle-aa wait pannadhu
   - Memory & CPU efficient
   - Scalable (100s / 1000s of such tasks possible)

IMPORTANT KEY POINT:
--------------------
Async DOES NOT mean new thread.
Async means NON-BLOCKING execution.

BEST USE CASE:
--------------
- Waiting operations (I/O, delay, network, timer)
- Long running wait without CPU work
====================================================
*/
#endregion
