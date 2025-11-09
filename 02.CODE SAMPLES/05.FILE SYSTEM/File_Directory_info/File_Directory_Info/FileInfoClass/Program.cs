using System;
using System.IO;

namespace FileInfoClass
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileName = @"T:\02.GIT REPO\01.COURSE-DOCUMENT\1_SAR ZIPFILE\SARZIP.zip";
            FileInfo fi = new FileInfo(FileName);

            Console.WriteLine(fi.Name);
            Console.WriteLine(fi.FullName);
            Console.WriteLine(fi.Length);
            Console.WriteLine(fi.DirectoryName);
            Console.WriteLine(fi.CreationTime);
            Console.WriteLine(fi.LastAccessTime);
            Console.WriteLine(fi.Attributes);

            fi.Delete();
            fi.Create();
            
        }
    }
}
