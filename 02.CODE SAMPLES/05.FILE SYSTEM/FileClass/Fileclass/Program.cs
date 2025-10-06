using System;
using System.IO;

namespace Fileclass
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"T:\\Text_1.txt";
            string sourceFile = @"T:\\SourceText.txt";
            string destinationfile = @"T:\\DestinationText.txt";

            //1.Create a File using File class
            FileStream fs = File.Create(filePath);
            FileStream fss = File.Create(sourceFile);
            fs.Close();
            fss.Close();

            //2.Check file exists or not
            bool isexists = File.Exists(filePath);
            Console.WriteLine(isexists);

            //3.File Delete 
            File.Delete(filePath);

            //4.Copy File
            File.Copy(sourceFile, destinationfile);

            //5.Move File 
            File.Move(sourceFile,@"T:\\des.txt");

            //6.Read all text from file as text
            string data = File.ReadAllText(@"T:\Sample.txt");

            //7.Read all text as array
            string[] strarray = File.ReadAllLines(@"T:\Sample.txt");

            //8.Write all text to file
            File.WriteAllText(filePath,"test");
          }
    }
}
