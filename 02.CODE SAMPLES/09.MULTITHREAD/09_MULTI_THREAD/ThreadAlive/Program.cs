using System;
using System.IO;
using System.Threading;


namespace ThreadAlive
{
    class Program
    {
        static void ReadLargeFile()
        {
            Console.WriteLine("File read started...");
            Thread.Sleep(5000); // simulate big file
            Console.WriteLine("File read finished");
        }

        static void Main()
        {
            Thread fileThread = new Thread(ReadLargeFile);
            fileThread.Start();

            while (fileThread.IsAlive)
            {
                Console.WriteLine("Waiting for file read to complete...");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Now safe to process file");
        }
    }
}

#region OUTPUT
/*
 * File read started...
Waiting for file read to complete...
Waiting for file read to complete...
Waiting for file read to complete...
File read finished
Now safe to process file

 */
#endregion