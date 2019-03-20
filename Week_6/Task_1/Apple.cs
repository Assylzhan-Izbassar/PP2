using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Apple:GameObject
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
                X = random.Next(0, 78),
                Y = random.Next(0, 30)
            };
            while (!GoodPoint(p))
            {
                p = new Point
                {
                    X = random.Next(0, 78),
                    Y = random.Next(0, 33)
                };
            }
            list.Add(p);
        }

        private bool GoodPoint(Point p)
        {
            return true;
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
