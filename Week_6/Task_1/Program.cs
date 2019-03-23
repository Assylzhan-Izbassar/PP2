using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static void GameStart()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetWindowSize(80, 35);
            Console.SetBufferSize(80, 35);
            Console.SetCursorPosition(20, 20);
            Console.WriteLine("Please, write your name!\n");
            Console.SetCursorPosition(20, 21);
            string Name = Console.ReadLine();
            Console.Clear();
            Console.SetCursorPosition(2, 33);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your nickname: " + Name);
        }

        static void Main(string[] args)
        {
            GameStart();
            GameState game = new GameState();
        
            while (true)
            {
                game.Draw();
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                game.PressedKey(consoleKeyInfo);

                if (game.CheckCollision() == false) break; 
                    //Environment.Exit(0);
            }

            Console.Clear();
            Console.SetCursorPosition(20, 17);
            Console.WriteLine("GAME OVER!");
            Console.SetCursorPosition(20, 18);
        }
    }
}
