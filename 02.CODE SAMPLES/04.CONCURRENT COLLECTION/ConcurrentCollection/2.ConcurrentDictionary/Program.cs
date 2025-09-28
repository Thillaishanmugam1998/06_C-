using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentDictionaryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 🔹 Create a thread-safe dictionary
            ConcurrentDictionary<int, string> cd = new ConcurrentDictionary<int, string>();

            // -------------------------------
            // 1. TryAdd (Safe add)
            // -------------------------------
            bool added1 = cd.TryAdd(1, "Apple");
            bool added2 = cd.TryAdd(2, "Banana");
            bool added3 = cd.TryAdd(3, "Orange");

            Console.WriteLine($"TryAdd Results: {added1}, {added2}, {added3}");
            // Output: True, True, True

            // -------------------------------
            // 2. Indexer (Add or Update directly)
            // -------------------------------
            cd[4] = "Grapes";   // adds new key
            cd[2] = "Mango";    // updates existing key

            Console.WriteLine("After indexer updates:");
            foreach (var kv in cd)
                Console.WriteLine($"{kv.Key} => {kv.Value}");
            /*
             Possible Output:
             1 => Apple
             2 => Mango
             3 => Orange
             4 => Grapes
            */

            // -------------------------------
            // 3. TryGetValue (Safe read)
            // -------------------------------
            if (cd.TryGetValue(2, out string val))
            {
                Console.WriteLine("TryGetValue(2): " + val);
                // Output: Mango
            }

            // -------------------------------
            // 4. TryUpdate (Update if value matches)
            // -------------------------------
            bool updated = cd.TryUpdate(2, "Pineapple", "Mango");
            Console.WriteLine("TryUpdate Result: " + updated);
            Console.WriteLine("Updated Value for Key 2: " + cd[2]);
            // Output: True, Pineapple

            // -------------------------------
            // 5. AddOrUpdate (Insert or Update atomically)
            // -------------------------------
            string result = cd.AddOrUpdate(3, "Strawberry", (key, oldValue) => oldValue + " + Kiwi");
            Console.WriteLine("AddOrUpdate Result: " + result);
            Console.WriteLine("Value at Key 3: " + cd[3]);
            // Output: Orange + Kiwi

            // -------------------------------
            // 6. GetOrAdd (Return existing value or insert new)
            // -------------------------------
            string existingOrNew = cd.GetOrAdd(5, "Papaya");
            Console.WriteLine("GetOrAdd(5): " + existingOrNew);
            Console.WriteLine("Value at Key 5: " + cd[5]);
            // Output: Papaya

            // -------------------------------
            // 7. TryRemove (Remove safely)
            // -------------------------------
            bool removed = cd.TryRemove(1, out string removedVal);
            Console.WriteLine($"TryRemove(1): {removed}, Value = {removedVal}");
            // Output: True, Value = Apple

            // -------------------------------
            // 8. Properties
            // -------------------------------
            Console.WriteLine("Count: " + cd.Count);
            Console.WriteLine("IsEmpty: " + cd.IsEmpty);

            // -------------------------------
            // 9. Multi-threaded Example
            // -------------------------------
            ConcurrentDictionary<int, int> numbers = new ConcurrentDictionary<int, int>();

            Task t1 = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    numbers.AddOrUpdate(i, i * 10, (k, old) => old + 1);
                    Console.WriteLine($"Task1 -> Key {i}, Value {numbers[i]}");
                    Thread.Sleep(50);
                }
            });

            Task t2 = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    numbers.AddOrUpdate(i, i * 100, (k, old) => old + 2);
                    Console.WriteLine($"Task2 -> Key {i}, Value {numbers[i]}");
                    Thread.Sleep(50);
                }
            });

            Task.WaitAll(t1, t2);

            Console.WriteLine("\nFinal dictionary content:");
            foreach (var kv in numbers)
                Console.WriteLine($"{kv.Key} => {kv.Value}");
        }
    }
}
