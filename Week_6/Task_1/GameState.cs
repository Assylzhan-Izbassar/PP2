using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{ 
    class GameState
    {
        Worm worm = new Worm('o');
        Apple apple = new Apple('*');
        Wall wall = new Wall('#');
        public int count = 0;

        Direction direction = Direction.LeftArrow;

        public GameState()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(80, 35);
            Console.SetBufferSize(80, 35);
            wall.Draw();
            apple.InputWall(wall);
        }
        public void PressedKey(ConsoleKeyInfo consoleKeyInfo)
        {
            Add_Tail();
            
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (direction == Direction.DownArrow)
                    {
                        direction = Direction.DownArrow;
                    }
                    else
                    {
                        direction = Direction.UpArrow;
                        worm.Move(0, -1);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (direction == Direction.UpArrow)
                    {
                        direction = Direction.UpArrow;
                    }
                    else
                    {
                        direction = Direction.DownArrow;
                        worm.Move(0, 1);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (direction == Direction.RightArrow)
                    {
                        direction = Direction.RightArrow;
                    }
                    else
                    {
                        direction = Direction.LeftArrow;
                        worm.Move(-1, 0);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (direction == Direction.LeftArrow)
                    {
                        direction = Direction.LeftArrow;
                    }
                    else
                    {
                        direction = Direction.RightArrow;
                        worm.Move(1, 0);
                    }
                    break;
            }
            CheckCollision();
        }
        
        public List<Point> Tail = new List<Point>();

        protected void Add_Tail()
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
            if (count == 41 || count == 61)
            {
                count = count - 1;
            }
            if (count == 30 || count == 50) 
            {
                direction = Direction.LeftArrow;
                int k = worm.list.Count;
                worm.list.Clear();
                worm.Clear();
                worm.GenerateWorm(k);
                wall.LoadLevel(count);
                wall.Draw();
                count += 1;
            }
            
        }
        public bool CheckCollision()
        {
            bool res = true;
            if (worm.CheckIntersection(apple.list))
            {
                worm.Eat(apple.list);
                count += 10;
                apple.InputWall(wall);
                apple.Generate();
            }
            if (worm.CheckIntersection(wall.list))
            {
                res = false;
            }
            if (worm.CheckIntersection(Tail))
            {
                res = false;
            }
            apple.InputWorm(worm);
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
