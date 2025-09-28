using System;
using System.Collections.Generic;


    #region Definition of Class Players
    /// <summary>
    /// Players is a custom class (complex type) with multiple properties.
    /// We'll use this to demonstrate storing objects in a generic List<T>.
    /// 
    /// Implements IComparable<Players> so we can define a default sorting rule.
    /// </summary>
    public class Players : IComparable<Players>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public char Grade { get; set; }
        public int IccRank { get; set; }

        // Default sorting rule → By ICC Rank (ascending)
        public int CompareTo(Players other)
        {
            if (other == null) return 1;
            return this.IccRank.CompareTo(other.IccRank);
        }

        public override string ToString()
        {
            return $"{Name} ({Country}) - Rank {IccRank}, Grade {Grade}";
        }
    }
    #endregion

    #region Custom Comparers
    /// <summary>
    /// Sort players by Name (Alphabetical)
    /// </summary>
    public class SortByName : IComparer<Players>
    {
        public int Compare(Players x, Players y)
        {
            return string.Compare(x?.Name, y?.Name, StringComparison.OrdinalIgnoreCase);
        }
    }

    /// <summary>
    /// Sort players by Country
    /// </summary>
    public class SortByCountry : IComparer<Players>
    {
        public int Compare(Players x, Players y)
        {
            return string.Compare(x?.Country, y?.Country, StringComparison.OrdinalIgnoreCase);
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            #region Create List of Complex Type
            List<Players> playerList = new List<Players>
            {
                new Players { Id = 1, Name = "Rohit Sharma", Country = "India", Grade = 'A', IccRank = 1 },
                new Players { Id = 2, Name = "Virat Kohli", Country = "India", Grade = 'A', IccRank = 2 },
                new Players { Id = 3, Name = "Bumrah", Country = "India", Grade = 'A', IccRank = 3 },
                new Players { Id = 4, Name = "Suryakumar Yadav", Country = "India", Grade = 'B', IccRank = 4 },
                new Players { Id = 5, Name = "Maxwell", Country = "Australia", Grade = 'C', IccRank = 10 },
                new Players { Id = 6, Name = "Brevis", Country = "South Africa", Grade = 'A', IccRank = 1 }
            };
            #endregion

            #region Default Sorting (By ICC Rank using IComparable)
            Console.WriteLine("---- Sort by ICC Rank (Default CompareTo) ----");
            playerList.Sort();
            foreach (var player in playerList)
                Console.WriteLine(player);
            #endregion

            #region Custom Sorting (By Name using IComparer)
            Console.WriteLine("\n---- Sort by Name ----");
            playerList.Sort(new SortByName());
            foreach (var player in playerList)
                Console.WriteLine(player);
            #endregion

            #region Custom Sorting (By Country using IComparer)
            Console.WriteLine("\n---- Sort by Country ----");
            playerList.Sort(new SortByCountry());
            foreach (var player in playerList)
                Console.WriteLine(player);
            #endregion

            #region Inline Sorting with Lambda Expression
            Console.WriteLine("\n---- Sort by Grade (using Lambda) ----");
            playerList.Sort((x, y) => x.Grade.CompareTo(y.Grade));
            foreach (var player in playerList)
                Console.WriteLine(player);
            #endregion
        }
    }

