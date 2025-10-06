using System;
using System.IO;
using System.Text;

namespace _4.ReadDataFromFileStreamReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"T:\Sample.txt";
            FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            using (StreamReader sr = new StreamReader(fs))
            {
                string data = sr.ReadToEnd();
            }
        }
    }
}
