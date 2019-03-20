using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Wall:GameObject
    {
        public Wall(char sign) : base(sign)
        {
            LoadLevel(1);
        }

        private void LoadLevel(int level)
        {
            string s = @"C:\Users\Brother\Desktop\PP2\Week_6\Task_1\Level_1.txt";
            FileStream fs = new FileStream(s, FileMode.Open, FileAccess.Read);
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
            foreach (Point p in list)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
        }
    }
}
