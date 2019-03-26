using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
            
        }

        static void Main(string[] args)
        {
            GameStart();
            string Name = Console.ReadLine();
            Console.Clear();
            
            GameState game = new GameState();

            bool res = true;
            while (res)
            {
                Console.SetCursorPosition(2, 33);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your nickname: " + Name);
                game.Draw();
                
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.Escape)
                {
                    string path = @"C:\Users\Brother\Desktop\Test\YourScore.txt";
                    Serialize(path, game);
                    res = false;
                    //Environment.Exit(0);
                }
                game.PressedKey(consoleKeyInfo);

                if (game.CheckCollision() == false) res = false;
                //Environment.Exit(0);
            }

            Console.Clear();
            Console.SetCursorPosition(20, 17);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER!");
            Console.SetCursorPosition(20, 18);
            Console.ForegroundColor = ConsoleColor.Green;
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
