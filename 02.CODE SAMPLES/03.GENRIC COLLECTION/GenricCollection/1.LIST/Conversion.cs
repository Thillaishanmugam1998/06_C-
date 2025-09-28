using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _9.CollectionConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1️⃣ Array to List
            int[] numbersArray = { 1, 2, 3, 4, 5 };
            List<int> numbersList = numbersArray.ToList(); // Using LINQ
            Console.WriteLine("Array to List:");
            numbersList.ForEach(n => Console.Write(n + " "));
            Console.WriteLine(); // Output: 1 2 3 4 5
            #endregion

            #region 2️⃣ List to Array
            int[] arrayFromList = numbersList.ToArray();
            Console.WriteLine("\nList to Array:");
            foreach (var n in arrayFromList)
                Console.Write(n + " ");
            Console.WriteLine(); // Output: 1 2 3 4 5
            #endregion

            #region 3️⃣ Array to ArrayList
            ArrayList arrayList = new ArrayList(numbersArray); // Non-generic collection
            Console.WriteLine("\nArray to ArrayList:");
            foreach (var n in arrayList)
                Console.Write(n + " ");
            Console.WriteLine(); // Output: 1 2 3 4 5
            #endregion

            #region 4️⃣ List to Dictionary
            // Suppose list has tuples or key-value data
            List<(int Id, string Name)> listData = new List<(int, string)>
            {
                (1, "Alice"),
                (2, "Bob"),
                (3, "Charlie")
            };

            Dictionary<int, string> dictFromList = listData.ToDictionary(x => x.Id, x => x.Name);
            Console.WriteLine("\nList to Dictionary:");
            foreach (var kvp in dictFromList)
                Console.WriteLine($"Key={kvp.Key}, Value={kvp.Value}");
            /*
            Output:
            Key=1, Value=Alice
            Key=2, Value=Bob
            Key=3, Value=Charlie
            */
            #endregion

            #region 5️⃣ Array to Dictionary
            string[] names = { "Alice", "Bob", "Charlie" };
            // Using index as key
            Dictionary<int, string> dictFromArray = names.Select((value, index) => new { index, value })
                                                         .ToDictionary(x => x.index, x => x.value);
            Console.WriteLine("\nArray to Dictionary:");
            foreach (var kvp in dictFromArray)
                Console.WriteLine($"Key={kvp.Key}, Value={kvp.Value}");
            /*
            Output:
            Key=0, Value=Alice
            Key=1, Value=Bob
            Key=2, Value=Charlie
            */
            #endregion

            #region 6️⃣ Dictionary to List
            Dictionary<int, string> dict = new Dictionary<int, string>
            {
                {1,"One"},{2,"Two"},{3,"Three"}
            };

            // Convert keys to List
            List<int> keysList = dict.Keys.ToList();
            // Convert values to List
            List<string> valuesList = dict.Values.ToList();

            Console.WriteLine("\nDictionary Keys to List:");
            keysList.ForEach(k => Console.Write(k + " ")); // Output: 1 2 3
            Console.WriteLine("\nDictionary Values to List:");
            valuesList.ForEach(v => Console.Write(v + " ")); // Output: One Two Three
            #endregion

            #region 7️⃣ Dictionary to Array
            int[] keysArray = dict.Keys.ToArray();
            string[] valuesArray = dict.Values.ToArray();

            Console.WriteLine("\n\nDictionary Keys to Array:");
            foreach (var k in keysArray) Console.Write(k + " "); // Output: 1 2 3
            Console.WriteLine("\nDictionary Values to Array:");
            foreach (var v in valuesArray) Console.Write(v + " "); // Output: One Two Three
            #endregion
        }
    }
}
