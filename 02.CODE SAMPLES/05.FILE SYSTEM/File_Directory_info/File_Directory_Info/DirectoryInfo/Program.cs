using System;
using System.IO;

namespace DirectoryInfoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = @"T:\02.GIT REPO\01.COURSE-DOCUMENT\1_SAR ZIPFILE";
            DirectoryInfo di = new DirectoryInfo(directory);

            Console.WriteLine(di.Name);
            Console.WriteLine(di.FullName);
            Console.WriteLine(di.Exists);
            Console.WriteLine(di.Attributes);
            Console.WriteLine(di.LastAccessTime);


            FileInfo[] Files = di.GetFiles();
            DirectoryInfo[] df= di.GetDirectories();
        }
    }
}
