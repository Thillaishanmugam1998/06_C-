using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            // ============================================================
            // ========== 01. LATEST DIRECT THREAD CREATION ===============
            // Manager → Directly gives work to employee
            // ============================================================
            Thread T1 = new Thread(p.Method_NoParams);
            T1.Start();



            // ============================================================
            // ========== 02. OLD STYLE USING THREADSTART =================
            // Manager → HR (ThreadStart Delegate) → Employee
            // ============================================================
            ThreadStart TS = new ThreadStart(p.Method_NoParams);
            Thread T2 = new Thread(TS);
            T2.Start();



            // ============================================================
            // ========== 03. PASSING PARAMETER (OLD & NOT RECOMMENDED) ===
            // ParameterizedThreadStart can pass ONLY ONE object parameter.
            // Method must accept EXACTLY ONE object parameter.
            // ============================================================
            ParameterizedThreadStart PTSD = new ParameterizedThreadStart(p.Method_OneParam);
            Thread T3 = new Thread(PTSD);
            T3.Start(5);   // Passing int as object



            // ============================================================
            // ========== 04. CLASS + CONSTRUCTOR PARAMETER PASSING =======
            // Clean way when method needs parameters (simple scenarios).
            // ============================================================
            NumberHelper helper = new NumberHelper(10);
            Thread T4 = new Thread(helper.DisplayNumbers);
            T4.Start();



            // ============================================================
            // ========== 05. MODERN LAMBDA PARAMETER THREAD (BEST) =======
            // Supports any number of parameters. Safe & clean.
            // ============================================================
            Thread T5 = new Thread(() => p.Method_MultiParams(10, 20, "HI"));
            T5.Start();



            // ============================================================
            // ========== 06. BEST PRACTICE: TASK.RUN (RECOMMENDED) =======
            // Microsoft recommended method for threading.
            // Automatically uses thread pool.
            // ============================================================
            Task.Run(() => p.Method_NoParams());
            Task.Run(() => p.Method_MultiParams(5, 15, "TASK CALL"));



            Console.ReadLine();
        }



        // ============================================================
        // ========== METHOD FOR THREAD WITH NO PARAMS =================
        // ============================================================
        public void Method_NoParams()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("[NoParam Thread] : " + i);
                Thread.Sleep(200);
            }
        }



        // ============================================================
        // ========== METHOD FOR PARAMETERIZEDTHREADSTART ==============
        // Must accept exactly ONE object parameter.
        // ============================================================
        public void Method_OneParam(object value)
        {
            int number = Convert.ToInt32(value);

            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine("[OneParam Thread] : " + i);
                Thread.Sleep(200);
            }
        }



        // ============================================================
        // ========== METHOD WITH MULTIPLE PARAMETERS ==================
        // Used in lambda threads and tasks.
        // ============================================================
        public void Method_MultiParams(int a, int b, string message)
        {
            Console.WriteLine($"[MultiParam Thread] A={a}, B={b}, Message={message}");
        }
    }



    // ============================================================
    // =================== NUMBERHELPER CLASS ======================
    // Constructor method of passing parameters to thread.
    // Clean for simple single-parameter cases.
    // ============================================================
    public class NumberHelper
    {
        private int _Max;

        public NumberHelper(int max)
        {
            _Max = max;
        }

        public void DisplayNumbers()
        {
            for (int i = 1; i <= _Max; i++)
            {
                Console.WriteLine("[Constructor Param Thread] : " + i);
            }
        }
    }
}
