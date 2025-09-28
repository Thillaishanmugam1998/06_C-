using System;
using System.Collections.Generic;

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public char Grade { get; set; }
        public int IccRank { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name} ({Country}) - Grade {Grade}, Rank {IccRank}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Create Dictionary with Complex Type
            // Key = PlayerId, Value = Player object
            Dictionary<int, Player> playersDict = new Dictionary<int, Player>();
            #endregion

            #region Add Elements
            playersDict.Add(1, new Player { Id = 1, Name = "Rohit Sharma", Country = "India", Grade = 'A', IccRank = 1 });
            playersDict.Add(2, new Player { Id = 2, Name = "Virat Kohli", Country = "India", Grade = 'A', IccRank = 2 });
            playersDict.Add(3, new Player { Id = 3, Name = "Bumrah", Country = "India", Grade = 'A', IccRank = 3 });
            playersDict.Add(4, new Player { Id = 4, Name = "Maxwell", Country = "Australia", Grade = 'C', IccRank = 10 });
            #endregion

            #region Access Elements
            foreach (var kvp in playersDict)
            {
                Console.WriteLine($"Key={kvp.Key}, Value={kvp.Value}");
            }
            #endregion

            #region Update Element
            playersDict[2] = new Player { Id = 2, Name = "Virat Kohli", Country = "India", Grade = 'A', IccRank = 1 };
            Console.WriteLine("\nAfter Update: " + playersDict[2]);
            #endregion

            #region Safe Access using TryGetValue
            if (playersDict.TryGetValue(3, out Player foundPlayer))
            {
                Console.WriteLine("\nFound Player: " + foundPlayer);
            }
            else
            {
                Console.WriteLine("Player not found.");
            }
            #endregion

            #region Remove Element
            playersDict.Remove(4);
            Console.WriteLine("\nAfter Removing Player with Key=4:");
            foreach (var player in playersDict.Values)
            {
                Console.WriteLine(player);
            }
            #endregion
        }
    }
