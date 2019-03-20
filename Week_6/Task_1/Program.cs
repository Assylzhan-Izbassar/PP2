using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    enum Direction
    {
        UpArrow,
        DownArrow,
        LeftArrow,
        RightArrow
    };
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 35);
            
            Console.SetBufferSize(80, 35);
            Console.SetCursorPosition(20, 20);
            Console.WriteLine("Please, write your name!\n");
            Console.SetCursorPosition(20, 21);
            string Name = Console.ReadLine();
            Direction direction = Direction.UpArrow;
            Console.Clear();
            Worm worm = new Worm('o');
            Apple apple = new Apple('*');
            Wall wall = new Wall('#');
            ConsoleKeyInfo consoleKeyInfo;
            wall.Draw();

            while (true)
            {
                Console.SetCursorPosition(2, 33);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your name:" + Name);
                Console.CursorVisible = false;

                worm.Draw();
                apple.Draw();
                

                consoleKeyInfo = Console.ReadKey();
                
                if (consoleKeyInfo.Key == ConsoleKey.Escape) break;

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
                
                if (CheckCollision(worm, apple, wall) == true)
                {
                    break;
                }
                else continue;
            }
            Console.Clear();
            Console.SetCursorPosition(20, 17);
            Console.WriteLine("Game Over!");
            Console.SetCursorPosition(20, 18);
        }
        public static bool CheckCollision(Worm worm, Apple apple, Wall wall)
        {
            bool res = false;
            if(worm.CheckIntersection(apple.list) == true)
            {
                worm.Eat(apple.list);
                apple.Generate();
            }
            if(worm.CheckIntersection(wall.list) == true)
            {
                res = true;
            }
            
            return res;
        }
    }
}
