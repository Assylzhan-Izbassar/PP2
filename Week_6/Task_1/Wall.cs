using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    enum Level
    {
        Level_1,
        Level_2,
        Level_3
    }
    class Wall:GameObject
    {
        public Wall(char sign) : base(sign)
        {
            LoadLevel(0);
        }

        Level Level = Level.Level_1;
        public void LoadLevel(int count)
        {
            if (count == 30)
            {
                Level = Level.Level_2;
                list.Clear();
            }
                
            else if (count >= 40)
            {
                Level = Level.Level_3;
                list.Clear();
            }
                
            string path = @"C:\Users\Brother\Desktop\PP2\Week_6\Task_1\" + Level.ToString() + ".txt";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(fs))
            {
                int r=0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    for(int c = 0; c < line.Length; ++c)
                    {
                        if(line[c] == '#')
                        {
                            list.Add(new Point { X = c, Y = r });
                        }
                    }
                    r++;
                }
            }
            fs.Close();
        }
        public void Draw()
        {
            Console.Clear();
            foreach (Point p in list)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
        }
    }
}
