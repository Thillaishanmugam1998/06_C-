using System;
using System.IO;
using System.Threading;


namespace ThreadJoin
{
    class Program
    {
        static string fileData;

        static void ReadFile()
        {
            Console.WriteLine("File reading started...");
            Thread.Sleep(2000); // simulate delay
            fileData = File.ReadAllText("data.txt");
            Console.WriteLine("File reading completed");
        }

        static void Main()
        {
            Thread t = new Thread(ReadFile);
            t.Start();

            t.Join(); // 🔥 WAIT here

            Console.WriteLine("Processing file data...");
            Console.WriteLine($"File length: {fileData.Length}");
        }
    }

}

#region
/*
 * என்ன advantage?

✔ File read finish ஆன பிறகே process
✔ No exception
✔ Execution order guaranteed
 */
#endregion