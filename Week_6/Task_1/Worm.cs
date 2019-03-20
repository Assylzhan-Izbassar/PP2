using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Worm:GameObject
    {
        public Worm(char sign) : base(sign)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            list.Add(new Point { X = 40, Y = 17 });
            list.Add(new Point { X = 41, Y = 17 });
            list.Add(new Point { X = 42, Y = 17 });
        }
        public void Move(int dx,int dy)
        {
            Clear();
            for (int i = list.Count - 1; i > 0; --i)
            {
                list[i].X = list[i - 1].X;
                list[i].Y = list[i - 1].Y;
            }
            list[0].X += dx;
            list[0].Y += dy;
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
        public bool CheckIntersection(List<Point> apple)
        {
            bool res = false;

            foreach(Point p in apple)
            {
                if(list[0].X == p.X && list[0].Y == p.Y)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }
        public void Eat(List<Point> foodbody)
        {
            list.Add(new Point { X = foodbody[0].X, Y = foodbody[0].Y });
        }
    }
}
