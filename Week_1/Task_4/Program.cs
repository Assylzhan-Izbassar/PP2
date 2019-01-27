using System;

namespace Task_4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int n = int.Parse(s);

            for(uint i=1; i <= n; ++i)
            {
                for(uint j=1; j <= i; ++j)
                {
                    Console.Write("[*]");
                }
                Console.WriteLine();
            }
        }
    }
}
