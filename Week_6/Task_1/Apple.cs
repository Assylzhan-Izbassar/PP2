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

        List<Point> worm = new List<Point>();
        public void InputWorm(Worm anotherWorm)
        {
            worm.Clear();
            for(int i=0; i < anotherWorm.list.Count; ++i)
            {
                worm.Add(new Point { X = anotherWorm.list[i].X, Y = anotherWorm.list[i].Y });
            }
        }
        List<Point> wall = new List<Point>();
        public void InputWall(Wall anotherWall)
        {
            wall.Clear();
            for (int i = 0; i < anotherWall.list.Count; ++i)
            {
                wall.Add(new Point { X = anotherWall.list[i].X, Y = anotherWall.list[i].Y });
            }
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
            while (!GoodPoint(p))
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
            for(int i=0; i < wall.Count; ++i)
            {
                if (p.X == wall[i].X && p.Y == wall[i].Y) return false;
                else res = true;
            }
            for (int i = 0; i < worm.Count; ++i)
            {
                if (p.X == worm[i].X && p.Y == worm[i].Y) return false;
                else res = true;
            }
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
