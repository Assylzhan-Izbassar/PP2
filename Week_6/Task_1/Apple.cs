using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Apple : GameObject
    {
        public Apple(char sign) : base(sign)
        {
            Generate();
        }
      
        public void Generate()
        {
            list.Clear();

            Random random = new Random(DateTime.Now.Second);
            Point p = new Point
            {
                X = random.Next(0, Console.WindowWidth - 4),
                Y = random.Next(0, Console.WindowHeight-10)
            };
            while (GoodPoint(p) != true)
            {
                p = new Point
                {
                    X = random.Next(0, Console.WindowWidth-4),
                    Y = random.Next(0, Console.WindowHeight-3)
                };
            }
            list.Add(p);
        }

        public bool GoodPoint(Point p)
        {
            bool res = true;
            return res;
        }
        public void Draw()
        {
            foreach (Point p in list)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
        }
    }
}
