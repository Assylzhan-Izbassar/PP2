using System;

namespace Task_4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int a = int.Parse(s);

            for(int i=1; i <= a; ++i)
            {
                for(int j = 1; j <= i; ++j)
                {
                    Console.Write("[*]");
                }
                Console.WriteLine();
            }
        }
    }
}
