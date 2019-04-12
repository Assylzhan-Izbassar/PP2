using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Task_1
{
    class GameState
    {
        //System.Timers.Timer timer = new System.Timers.Timer(100);
        //System.Timers.Timer GameTimer = new System.Timers.Timer(1000);

        public Worm worm = new Worm('o');
        Apple apple = new Apple('*');
        Wall wall = new Wall('#');
        public int count = 0;

        public GameState()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(80, 35);
            Console.SetBufferSize(80, 35);
            wall.Draw();
            apple.Generate(worm.list, wall.list);
        }


        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            worm.Clear();
            worm.Move1();
            worm.Draw();
            if (CheckCollision() == false)
            {
                //timer.Close();
            }
            CheckCollision();

            apple.Draw();
            //wall.Draw();
        }

        public void PressedKey()
        {
            Add_Tail();
            CheckCollision();
        }

        public List<Point> Tail = new List<Point>();

        public void Add_Tail()
        {
            Tail.Clear();
            for (int i = 2; i < worm.list.Count; ++i)
            {
                Tail.Add(new Point { X = worm.list[i].X, Y = worm.list[i].Y });
            }
        }
        public void Draw()
        {
            worm.Draw();
            apple.Draw();
            Score();
            //if (count == 41 || count == 61)
            //{
            //    count = count - 1;
            //}
            //if (count == 30 || count == 50) 
            //{
            //direction = Direction.LeftArrow;
            //int k = worm.list.Count;
            //worm.list.Clear();
            //worm.Clear();
            //worm.GenerateWorm(k);
            //wall.LoadLevel(count);
            //wall.Draw();
            //count += 1;
            //}

        }
        public bool CheckCollision()
        {
            bool res = true;
            if (worm.CheckIntersection(apple.list))
            {
                count += 10;
                worm.Eat(apple.list);
                apple.Generate(worm.list, wall.list);
            }
            else if (worm.CheckIntersection(wall.list))
            {
                res = false;
            }
            else if (worm.CheckIntersection(Tail))
            {
                res = false;
            }
            return res;
        }
        private void Score()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(2, 32);
            Console.WriteLine("Your score: " + count);
        }
    }
}
