using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Point
    {
        int x, y;
        int Filter_x_axis(int v)
        {
            if (v > Console.WindowWidth-1) v = 0;
            if (v < 0) v = Console.WindowHeight-1;
            return v;
        }
        int Filter_y_axis(int v)
        {
            if (v > 30) v = 0;
            if (v < 0) v = 30;
            return v;
        }
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = Filter_x_axis(value);
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = Filter_y_axis(value);
            }
        }
        public Point()
        {

        }
    }
}
