using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    abstract class GameObject
    {
        public List<Point> list = new List<Point>();
        protected char sign;
        public GameObject(char sign)
        {
            this.sign = sign;
        }
        //public void Draw()
        //{
        //    foreach(Point p in list)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.SetCursorPosition(p.X, p.Y);
        //        Console.Write(sign);
        //    }
        //}
        public void Clear()
        {
            foreach(Point p in list)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(' ');
            }
        }

    }
}
