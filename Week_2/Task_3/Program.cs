using System;
using System.IO;

namespace Task_3
{
    class MainClass
    {
        public static void PrintInfo(FileSystemInfo fs, int n)
        {
            string line = new string(' ', n);
            line = line + fs.Name;
            Console.WriteLine(line);

            if(fs is DirectoryInfo)
            {
                var items = (fs as DirectoryInfo).GetFileSystemInfos();
                foreach(var i in items)
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
