using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{       
    class Window
    {
        public FileSystemInfo[] Content
        {
            get;
            set;
        }
        int selectedItem;
        public int SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {   if (value >= Content.Length) selectedItem = 0;
                else if (value < 0) selectedItem = Content.Length - 1;
                else selectedItem = value;
            }
        }

        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for(int i=0; i < Content.Length; ++i)
            {
                if(i == SelectedItem)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(Content[i].Name);
            }
        }
    }
    enum FarMode
    {
        FileView,
        DirectoryView
    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo root = new DirectoryInfo(@"\\Mac\Home\Desktop\Calculus II");
            Stack<Window> history = new Stack<Window>();

            FarMode farMode = FarMode.DirectoryView;

            history.Push(new Window { Content = root.GetFileSystemInfos(), SelectedItem = 0 });

            while (true)
            {
                if(farMode == FarMode.DirectoryView)
                {
                    history.Peek().Draw();
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedItem--;
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedItem++;
                        break;
                    case ConsoleKey.Enter:
                        int x = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo = history.Peek().Content[x];
                        if(fileSystemInfo is DirectoryInfo)
                        {
                            DirectoryInfo dir = fileSystemInfo as DirectoryInfo;
                            history.Push(new Window { Content = dir.GetFileSystemInfos(), SelectedItem = 0 });
                        }
                        else
                        {
                            farMode = FarMode.FileView;
                            using (FileStream fs = new FileStream(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read))
                            {
                                using(StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Tab:
                        if(farMode == FarMode.DirectoryView)
                        {
                            history.Pop();
                        }
                        else
                        {
                            farMode = FarMode.DirectoryView;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        int x2 = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo2 = history.Peek().Content[x2];
                        if(fileSystemInfo2 is DirectoryInfo)
                        {
                            DirectoryInfo dir2 = fileSystemInfo2 as DirectoryInfo;
                            Directory.Delete(fileSystemInfo2.FullName, true);
                            history.Peek().Content = dir2.Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            FileInfo fi = fileSystemInfo2 as FileInfo;
                            File.Delete(fileSystemInfo2.FullName);
                            history.Peek().Content = fi.Directory.GetFileSystemInfos();
                        }
                        history.Peek().SelectedItem--;
                        break;
                }
            }
            

            //Console.ReadKey();

        }
    }
}
