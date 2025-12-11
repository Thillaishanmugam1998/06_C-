using System;

namespace ImportantStringFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            #region WHAT IS PROPERTY?
            /*
             * A Property is a special member of a class that looks like a variable, 
             * but works like methods (get/set).
             * It is used to control how data is read or modified inside a class.
             * ✅ WHY DO WE USE PROPERTIES? (MAIN REASONS) 
             * 1️) To Protect Class Fields (Encapsulation) 
             * 2) Properties allow controlled access to private fields.
             * Ex: Allow reading value / BUT block writing OR validate before setting
             */
            #endregion

            string text = "  DotNet Tutorials  ";
            string text2 = "dotnet tutorials";

            #region 1. Length Property
            /*
                Length → returns number of characters.
            */
            Console.WriteLine("1. Length:");
            Console.WriteLine(text.Length);
            // Output: 20 (includes spaces)
            Console.WriteLine();
            #endregion


            #region 2. Trim / TrimStart / TrimEnd
            /*
                Removes whitespace:
                - Trim()        → both sides
                - TrimStart()   → left side
                - TrimEnd()     → right side
            */
            Console.WriteLine("2. Trim Examples:");
            Console.WriteLine($"Original: '{text}'");
            Console.WriteLine($"Trim(): '{text.Trim()}'");
            Console.WriteLine($"TrimStart(): '{text.TrimStart()}'");
            Console.WriteLine($"TrimEnd(): '{text.TrimEnd()}'");
            Console.WriteLine();
            #endregion


            #region 3. ToUpper / ToLower
            Console.WriteLine("3. ToUpper / ToLower:");
            Console.WriteLine(text.ToUpper());   // DOTNET TUTORIALS
            Console.WriteLine(text.ToLower());   //   dotnet tutorials  
            Console.WriteLine();
            #endregion


            #region 4. Equals() (Case Sensitive & Case-Insensitive Compare)
            /*
                Equals → compares two strings
                Option: StringComparison.OrdinalIgnoreCase → ignore case
            */
            Console.WriteLine("4. Equals Example:");
            Console.WriteLine(text.Trim().Equals(text2)); // False
            Console.WriteLine(text.Trim().Equals(text2, StringComparison.OrdinalIgnoreCase)); // True
            Console.WriteLine();
            #endregion


            #region 5. Contains, StartsWith, EndsWith
            Console.WriteLine("5. Contains / StartsWith / EndsWith:");
            string name = "DotNet Tutorials";
            Console.WriteLine(name.Contains("Net"));       // True
            Console.WriteLine(name.StartsWith("Dot"));      // True
            Console.WriteLine(name.EndsWith("rials"));      // True
            Console.WriteLine();
            #endregion


            #region 6. IndexOf() and LastIndexOf()
            /*
                IndexOf → finds FIRST occurrence
                LastIndexOf → finds LAST occurrence
                - Returns -1 if not found
            */
            Console.WriteLine("6. IndexOf / LastIndexOf:");
            string example = "A B C D B E F";
            Console.WriteLine(example.IndexOf("B"));        // Output: 2
            Console.WriteLine(example.LastIndexOf("B"));    // Output: 8
            Console.WriteLine();
            #endregion


            #region 7. Substring()
            /*
                Substring(startIndex)
                Substring(startIndex, length)
            */
            Console.WriteLine("7. Substring Example:");
            string s = "DotNetTutorials";
            Console.WriteLine(s.Substring(6));        // Tutorials
            Console.WriteLine(s.Substring(0, 6));     // DotNet

            //Console.WriteLine(s.Substring(12, 6));     // eRROR 
            //12 + 6 = 18
            //18 > 15(string length)

            Console.WriteLine();
            #endregion


            #region 8. Replace()
            Console.WriteLine("8. Replace Example:");
            string r = "Welcome to DotNet";
            Console.WriteLine(r.Replace("DotNet", "C#"));  // Welcome to C# 
            
            Console.WriteLine();
            #endregion


            #region 9. Split()
            /*
                Splits string based on delimiter and returns array.
            */
            Console.WriteLine("9. Split Example:");
            string sentence = "A,B,C,D";
            string[] parts = sentence.Split(',');
            foreach (var item in parts)
                Console.WriteLine(item);
            /*
                Output:
                A
                B
                C
                D
            */
            Console.WriteLine();
            #endregion


            #region 10. Join()
            /*
                Join → join array into single string
            */
            Console.WriteLine("10. Join Example:");
            string joined = string.Join(" - ", parts);
            Console.WriteLine(joined); // A - B - C - D
            Console.WriteLine();
            #endregion


            #region 11. String.Format / Interpolation
            /*
                Format() → placeholder replacement
                $"{variable}" → interpolation
            */
            Console.WriteLine("11. String.Format & Interpolation:");
            string name1 = "Thillai";
            int age = 27;

            Console.WriteLine(string.Format("Name: {0}, Age: {1}", name1, age));
            Console.WriteLine($"Name: {name1}, Age: {age}");
            Console.WriteLine();
            #endregion


            #region 12. IsNullOrEmpty / IsNullOrWhiteSpace
            Console.WriteLine("12. Null Checks:");
            string check1 = "";
            string check2 = "   ";
            string check3 = null;

            Console.WriteLine(string.IsNullOrEmpty(check1));       // True
            Console.WriteLine(string.IsNullOrWhiteSpace(check2));  // True
            Console.WriteLine(string.IsNullOrWhiteSpace(check3));  // True
            
            //🔸 IsNullOrEmpty() → ONLY "null" OR ""
            //🔸 IsNullOrWhiteSpace() → "null", "", AND spaces
            Console.WriteLine();
            #endregion


            #region 13. Insert() and Remove()
            Console.WriteLine("13. Insert / Remove:");
            string z = "HelloWorld";
            Console.WriteLine(z.Insert(5, " "));  // Hello World
            Console.WriteLine(z.Remove(5));       // Hello
            Console.WriteLine(z.Remove(5, 3));    // Hellold
            Console.WriteLine();
            #endregion


            #region 14. PadLeft() and PadRight()
            Console.WriteLine("14. PadLeft / PadRight:");
            string p = "123";
            Console.WriteLine(p.PadLeft(6, '0')); // 000123
            Console.WriteLine(p.PadRight(6, '*')); // 123***
            Console.WriteLine();
            #endregion


            #region 15. Reverse (Using char array)
            Console.WriteLine("15. Reverse String Example:");
            string rev = "DotNet";
            char[] arr = rev.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine(new string(arr));  // teNtoD
            Console.WriteLine();
            #endregion


            Console.WriteLine("=== END OF STRING FUNCTIONS DEMO ===");
        }
    }
}
