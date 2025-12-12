using System;
using System.Threading;

namespace _2_Single_Thread_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //By Default, the Thread does not have any name
            //if you want then you can provide the name explicitly
            Thread thread_instance = Thread.CurrentThread;
            thread_instance.Name = "Main Thread";
            Console.WriteLine($"Thread Name: {Thread.CurrentThread.Name}");
        }
    }
}
