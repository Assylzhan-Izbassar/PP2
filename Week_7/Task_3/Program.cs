using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Threading;

namespace Task_1
{
    enum Direction
    {
        None,
        UpArrow,
        DownArrow,
        LeftArrow,
        RightArrow
    };

    class Program
    {
        static GameState game;
        static ConsoleKeyInfo consoleKeyInfo;
        static Direction direction = Direction.LeftArrow;
        static int x = -1, y = 0;

        public static void GameStart()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetWindowSize(80, 35);
            Console.SetBufferSize(80, 35);
            Console.SetCursorPosition(20, 20);
            Console.WriteLine("Please, write your name!\n");
            Console.SetCursorPosition(20, 21);
            
        }

        static void Main(string[] args)
        {
            GameStart();
            string Name = Console.ReadLine();
            Console.Clear();
            game = new GameState();

            ThreadStart threadStart = new ThreadStart(DoIt);
            Thread thread = new Thread(threadStart);
            thread.Start();
           
            bool res = true;
            while (res)
            {
                Console.SetCursorPosition(2, 33);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your nickname: " + Name);
                game.worm.Move(x, y);
                game.Draw();
               
                if (consoleKeyInfo.Key == ConsoleKey.Escape)
                {
                    string path = @"C:\Users\Brother\Desktop\Test\YourScore.txt";
                    Serialize(path, game);
                    res = false;
                    thread.Abort();
                    //Environment.Exit(0);
                }
                game.PressedKey();

                if (game.CheckCollision() == false)
                {
                    res = false;
                }
                Thread.Sleep(120);
            }

            thread.Abort();
            Console.Clear();
            Console.SetCursorPosition(20, 17);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER!");
            Console.SetCursorPosition(20, 18);
            Console.ForegroundColor = ConsoleColor.Green;
        }

        private static void DoIt()
        {
            while (true)
            {
                consoleKeyInfo = Console.ReadKey();

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
                            x = 0;
                            y = -1; //Move(0, -1);
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
                            x = 0;
                            y = 1; //Move(0, 1);
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
                            x = -1;
                            y = 0; //Move(-1, 0);
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
                            x = 1;
                            y = 0;// Move(1, 0);
                        }
                        break;
                }
                Thread.Sleep(150);
            }
        }

        public static void Serialize(string path, GameState game)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer xs = new XmlSerializer(typeof(int));
                xs.Serialize(fs, game.count);
            }
        }
    }
}
