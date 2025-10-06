using System;
using System.IO;
using System.Text;

namespace _2.WriteDataIntoFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"T:\Sample.txt";
            FileStream fs = new FileStream(FilePath, FileMode.Append);

            byte[] buffer = System.Text.Encoding.Default.GetBytes("Welcome");
            fs.Write(buffer, 0, buffer.Length);
            fs.Close();

        }
    }
}
