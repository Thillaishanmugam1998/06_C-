using System;
using System.IO;
using System.Text;

namespace _3.ReadDataFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"T:\Sample.txt";
            FileStream fs = new FileStream(FilePath,FileMode.OpenOrCreate,FileAccess.ReadWrite);

            byte[] data = new byte[fs.Length];
            int dataread = fs.Read(data, 0, data.Length);
            string orginaldata = Encoding.UTF8.GetString(data);
        }
    }
}
