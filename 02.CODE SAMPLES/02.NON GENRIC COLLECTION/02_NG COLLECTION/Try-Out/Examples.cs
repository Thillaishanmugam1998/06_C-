using System;
using System.Collections;
using System.Text;

namespace Try_Out
{
    class Examples
    {
        public void program_1()
        {
            ArrayList cart = new ArrayList();

            // a) Add initial items
            cart.Add("Apple");
            cart.Add("banana");
            cart.Add("Bread");

            // b) Insert "Milk" at the beginning
            cart.Insert(0, "Milk");

            // c) Remove "banana" (FIXED: using correct case)
            string itemToRemove = "banana";
            int countBeforeRemoval = cart.Count;
            cart.Remove(itemToRemove);

            // Check if removal was successful
            if (cart.Count == countBeforeRemoval)
            {
                Console.WriteLine($"Could not remove '{itemToRemove}'. Item not found.");
            }

            // d) Print the final list and total count
            Console.WriteLine("Final Cart Contents:");
            foreach (object item in cart)
            {
                // Use safe casting for clarity, though not strictly needed here
                Console.WriteLine($"  - {item}");
            }
            Console.WriteLine($"Total number of items: {cart.Count}");
        }

        public void program_2()
        {
            string word = "Hello World!";
            Stack charStack = new Stack();

            // Push each character onto the stack
            foreach (char c in word)
            {
                charStack.Push(c);
            }

            // Use StringBuilder for efficient string construction
            StringBuilder reversedBuilder = new StringBuilder();

            // Pop each character to build the reversed string
            while (charStack.Count > 0)
            {
                reversedBuilder.Append(charStack.Pop());
            }

            string reverse = reversedBuilder.ToString();

            // Print the results as required
            Console.WriteLine($"Original string: {word}");
            Console.WriteLine($"Reversed string: {reverse}");
        }

        public void program_3()
        {
            //            Enqueue three print jobs: "Document1.pdf", "Image.png", "Report.docx".

            //Print the next job(Dequeue and print it to console).

            //Enqueue a new job: "Spreadsheet.xlsx".

            //Print all remaining jobs in the queue.

            Queue printerjobs = new Queue();

            printerjobs.Enqueue("Document1.pdf");
            printerjobs.Enqueue("images.png");
            printerjobs.Enqueue("Report.docx");

            Console.WriteLine($"Next Job: {printerjobs.Dequeue()}");
        }
    }
}
