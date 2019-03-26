using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Worm:GameObject
    {
        public void GenerateWorm(int k)
        {
            for(int i=0; i < k; ++i)
            {
                list.Add(new Point { X = 40 + i, Y = 17 });
            }
        }
        public Worm(char sign) : base(sign)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            GenerateWorm(3);
        }
        public void Move(int dx, int dy)
        {
            int n = dx, m = dy;
            Clear();
            if (dx == 0)
            {
                if (dy < 0)
                    dy += 1;
                else
                    dy -= 1;
            }
            else if (dy == 0)
            {
                if (dx < 0)
                    dx += 1;
                else
                    dx -= 1;
            }
            for (int i = list.Count - 1; i > 0; --i)
            {
                list[i].X = list[i - 1].X;//+ dx;
                list[i].Y = list[i - 1].Y; //+ dy;
            }
            list[0].X += n;
            list[0].Y += m;

        }
        
        public void Draw()
        {
            //list.Clear();
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

            foreach(Point point in list)
            {
                foreach(Point p in apple)
                {
                    if (point.X == p.X && point.Y == p.Y)
                    {
                        res = true;
                        break;
                    }
                }
                return res;
            }
            //foreach(Point p in apple)
            //{
            //  if(list[0].X == p.X && list[0].Y == p.Y)
            //    {
            //        res = true;
            //        break;
            //    }
            //}
            return res;
        }
        public void Eat(List<Point> foodbody)
        {
            list.Add(new Point { X = foodbody[0].X, Y = foodbody[0].Y });
        }
    }
}
