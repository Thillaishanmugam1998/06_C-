using System;

namespace _1.Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Every application have atleast one thread (main thread)

            // ================================
            // What is Multitasking?
            // ================================
            // Multitasking means a computer doing many tasks at the same time.
            // Example in real life: A person listening to music, cooking, and talking on the phone at the same time.
            // Example in computer: Chrome open, Music playing, File downloading all together.
            // The operating system switches between tasks very fast so it looks like everything runs simultaneously.



            // ================================
            // What is a Process?
            // ================================
            // A Process is a running application.
            // Example: When you open Chrome, the OS creates a Chrome Process. Same for Word, Notepad, VLC, etc.
            // Each process has its own memory, its own data, and works independently from other processes.
            // Real world comparison: A Process is like a Shop. Each shop has its own space, items, and rules.
            // Example: Bakery shop, Mobile repair shop, Medical shop — all separate like processes.



            // ================================
            // What is a Thread?
            // ================================
            // A Thread is a worker inside a process (inside the shop).
            // A Process cannot execute tasks on its own — it needs threads (workers) to do the actual work.
            // Every process starts with one thread called the Main Thread.
            // More threads can be added to do more things at the same time.
            // Real world comparison: Threads are like Employees inside the shop.
            // One employee makes bread, another packs items, another handles billing — multiple workers doing tasks.



            // ================================
            // Summary
            // ================================
            // Multitasking = Many tasks running together (many shops doing work).
            // Process = An application (a shop).
            // Thread = A worker inside the process (employee inside the shop).

        }
    }
}
