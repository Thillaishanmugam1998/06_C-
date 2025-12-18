using System;
using System.IO;
using System.Threading;

namespace ThreadWithoutJoin
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

            Console.WriteLine("Processing file data...");
            Console.WriteLine($"File length: {fileData.Length}");
        }
    }
}

#region output
/*
 * என்ன problem?

Main thread wait பண்ணல

fileData இன்னும் read ஆகல

❌ NullReferenceException
 */
#endregion
