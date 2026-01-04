using System;
using System.Threading;

namespace SingleThreadKitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            // HH:mm:ss:fff -> Hour:Minute:Second:Millisecond
            string startTime = DateTime.Now.ToString("HH:mm:ss:fff");
            Console.WriteLine($"[{startTime}] I am Main Cook (Single Thread)");

            MakingIdly();
            MakingChutney();

            Console.WriteLine($"\n[{DateTime.Now.ToString("HH:mm:ss:fff")}] Breakfast Ready. Press any key to exit.");
            Console.ReadKey();
        }

        public static void MakingIdly()
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss:fff")}] Main Cook starts steaming Idly...");

            // 🔴 Blocking for 20 seconds (Idly cooking in steam)
            Thread.Sleep(20000);

            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss:fff")}] Idly Cooked.");
        }

        public static void MakingChutney()
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss:fff")}] Start making Chutney");

            CuttingVegetables();
            FryVegetables();
            AddWater();
            CookChutney();

            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss:fff")}] Chutney Finished.");
        }

        static void CuttingVegetables()
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss:fff")}] Cutting vegetables for chutney...");
            Thread.Sleep(3000); // 3 sec cutting
        }

        static void FryVegetables()
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss:fff")}] Frying vegetables...");
            Thread.Sleep(3000); // 3 sec frying
        }

        static void AddWater()
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss:fff")}] Adding water...");
            Thread.Sleep(1000); // 1 sec
        }

        static void CookChutney()
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss:fff")}] Cooking chutney...");
            Thread.Sleep(2000); // 2 sec cooking
        }
    }
}

#region OUTPUT
/*
[10:00:00:100] I am Main Cook (Single Thread)
[10:00:00:105] Main Cook starts steaming Idly...
[10:00:20:110] Idly Cooked.
[10:00:20:115] Start making Chutney
[10:00:20:120] Cutting vegetables for chutney...
[10:00:23:120] Frying vegetables...
[10:00:26:120] Adding water...
[10:00:27:120] Cooking chutney...
[10:00:29:120] Chutney Finished.

[10:00:29:125] Breakfast Ready. Press any key to exit.
*/
#endregion
