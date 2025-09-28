using System;
using System.Collections.Generic;

namespace _1.LIST
{
    #region Definition of Class Players
    /// <summary>
    /// Players is a custom class (complex type) with multiple properties.
    /// We'll use this to demonstrate storing objects in a generic List<T>.
    /// </summary>
    public class Players
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public char Grade { get; set; }
        public int IccRank { get; set; }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            #region What is Generic Type?
            /*
             * A "generic type" means we can create a type (like List<T>) 
             * where 'T' can be replaced with any data type (int, string, class, etc.).
             * It provides type-safety and reusability.
             */
            #endregion

            #region What is List<T>?
            /*
             * List<T> is a generic collection class in C#.
             * It is used to store multiple elements of the same type dynamically.
             * It grows/shrinks automatically (unlike arrays which are fixed size).
             */
            #endregion

            #region Example: List with Simple Type (string)
            List<string> players = new List<string>();

            // Initialize with collection
            List<string> indianPlayers = new List<string>
            {
                "M.S. Dhoni", "Sachin", "Bumrah"
            };

            // Add elements
            players.Add("Rohit Sharma");
            players.Add("Virat Kohli");
            players.Add("Pollard");

            // Add multiple items
            players.AddRange(indianPlayers);

            // Insert at specific index
            players.Insert(0, "Shami");
            players.InsertRange(0, indianPlayers);

            // Check existence
            Console.WriteLine("Is 'Virat Kohli' in IndianPlayers? " + indianPlayers.Contains("Virat Kohli"));

            // Remove elements
            indianPlayers.Remove("Sachin");            // value based
            players.RemoveAt(0);                      // index based
            players.RemoveRange(0, 2);                // index + count
            players.RemoveAll(x => x.Length > 10);    // predicate (condition)

            // Clear list
            players.Clear();

            // Count property
            Console.WriteLine("Total Indian Players: " + indianPlayers.Count);

            // Sort and reverse
            indianPlayers.Sort();    // ascending
            indianPlayers.Reverse(); // descending

            // Update
            indianPlayers[0] = "Suryakumar Yadav";

            // Access elements (index based)
            for (int i = 0; i < indianPlayers.Count; i++)
            {
                Console.WriteLine($"indianPlayers[{i}] = {indianPlayers[i]}");
            }

            // Access elements (foreach)
            foreach (string player in indianPlayers)
            {
                Console.WriteLine(player);
            }
            #endregion

            #region Example: List with Complex Type (Players class)
            // Create objects of Players class
            Players p1 = new Players { Id = 1, Name = "Rohit Sharma", Country = "India", Grade = 'A', IccRank = 1 };
            Players p2 = new Players { Id = 2, Name = "Virat Kohli", Country = "India", Grade = 'A', IccRank = 2 };
            Players p3 = new Players { Id = 3, Name = "Bumrah", Country = "India", Grade = 'A', IccRank = 3 };
            Players p4 = new Players { Id = 4, Name = "Suryakumar Yadav", Country = "India", Grade = 'B', IccRank = 4 };
            Players p5 = new Players { Id = 5, Name = "Maxwell", Country = "Australia", Grade = 'C', IccRank = 10 };
            Players p6 = new Players { Id = 6, Name = "Brevis", Country = "South Africa", Grade = 'A', IccRank = 1 };

            // Create list of complex type
            List<Players> playerList = new List<Players> { p1, p2, p3, p4, p5, p6 };

            // Find examples
            var firstIndian = playerList.Find(x => x.Country == "India"); // first match
            Console.WriteLine("First Indian Player: " + firstIndian.Name);

            var allIndians = playerList.FindAll(x => x.Country == "India"); // all matches
            Console.WriteLine("All Indian Players:");
            foreach (var player in allIndians)
            {
                Console.WriteLine(player.Name);
            }

            int indexOfBumrah = playerList.FindIndex(x => x.Name == "Bumrah");
            Console.WriteLine("Index of Bumrah: " + indexOfBumrah);

            var lastGradeA = playerList.FindLast(x => x.Grade == 'A');
            Console.WriteLine("Last Grade A Player: " + lastGradeA.Name);

            int lastIndexIndia = playerList.FindLastIndex(x => x.Country == "India");
            Console.WriteLine("Last Index of Indian Player: " + lastIndexIndia);

            bool existsMaxwell = playerList.Exists(x => x.Name == "Maxwell");
            Console.WriteLine("Does Maxwell exist? " + existsMaxwell);
            #endregion
        }
    }
}
