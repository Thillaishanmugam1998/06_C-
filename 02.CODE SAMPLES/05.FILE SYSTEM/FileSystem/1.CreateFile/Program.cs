using System;
using System.IO;

namespace _1.CreateFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"T:\Sample.txt";
            FileStream fs = new FileStream(FilePath,FileMode.Create);
            fs.Close();

        }
    }
}
