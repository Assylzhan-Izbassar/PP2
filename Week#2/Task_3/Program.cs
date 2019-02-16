using System;
using System.IO;

namespace Task_3
{
    class MainClass
    {
        public static void PrintInfo(FileSystemInfo fs,int n)
        {
            string l = new string(' ', n);
            l = l + fs.Name;
            Console.WriteLine(l);

            if(fs is DirectoryInfo)
            {
                var item = (fs as DirectoryInfo).GetFileSystemInfos();
                foreach(var i in item)
                {
                    PrintInfo(i, n + 4);
                }
            }
        }
        public static void Main(string[] args)
        {
            string path = @"/Users/macbook/Desktop/PP2/Projects/PP2/Week_1/Task_1";
            DirectoryInfo dir = new DirectoryInfo(path);
            PrintInfo(dir, 0);
        }
    }
}
