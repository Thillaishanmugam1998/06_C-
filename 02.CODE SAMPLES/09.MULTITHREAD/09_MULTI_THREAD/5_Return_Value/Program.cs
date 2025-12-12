using System;
using System.Threading;

namespace ThreadReturnDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // ============================================================
            // ========== 01. SHARED VARIABLE METHOD =======================
            // Thread writes a value → Main thread reads after Join().
            // ============================================================
            #region 01_SHARED_VARIABLE

            int sharedResult = 0;

            Thread t1 = new Thread(() =>
            {
                // Thread does some work
                sharedResult = 10 + 20;

                // Simulating long work (10 seconds)
                Thread.Sleep(10000);
            });

            t1.Start();

            // ------------------------------------------------------------
            // IMPORTANT:
            // t1.Join() means MAIN THREAD will wait until t1 finishes.
            // இங்க 10 seconds wait ஆகும், ஏன்னா t1 thread Sleep(10000) பண்ணுது.
            // அந்த thread முழுக்க முடிஞ்சதுக்குப்பிறகு தானே Main thread கீழே போகும்.
            // ------------------------------------------------------------
            t1.Join();

            Console.WriteLine("Shared Variable Result: " + sharedResult);

            #endregion



            // ============================================================
            // ========== 02. CALLBACK METHOD ==============================
            // Thread sends result back using a callback function.
            // ============================================================
            #region 02_CALLBACK_METHOD

            void ReceiveResult(int value)
            {
                Console.WriteLine("Callback Result: " + value);
            }

            Thread t2 = new Thread(() =>
            {
                int calculation = 5 * 5;

                // Sending data back using callback method
                ReceiveResult(calculation);
            });

            t2.Start();

            #endregion



            // ============================================================
            // ========== END =============================================
            // ============================================================
            Console.ReadLine();
        }
    }
}
