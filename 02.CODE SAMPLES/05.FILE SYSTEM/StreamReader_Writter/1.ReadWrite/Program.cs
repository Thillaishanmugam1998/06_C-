using System;
using System.IO;

namespace _1.ReadWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"T:\\Sample.txt";

            //1.Write data into file using streamwritter class
            StreamWriter sw = new StreamWriter(FilePath);
            sw.Write("Single Line");
            sw.WriteLine("New Line");
            sw.Flush();
            sw.WriteLine("Save new line after flush");
            sw.Close();


            //2.Read data from the text file 
            StreamReader sr = new StreamReader(FilePath);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
            sr.Dispose();

            Console.WriteLine("\nReading Approach 2: using ReadLine Method");
            StreamReader streamReader = new StreamReader(FilePath);
            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            string strData = streamReader.ReadLine();
            while (strData != null)
            {
                Console.WriteLine(strData);
                strData = streamReader.ReadLine();
            }
        }
    }
}
