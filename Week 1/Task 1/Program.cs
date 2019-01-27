using System;

namespace Task_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string t = Console.ReadLine();
            int a = int.Parse(s);
            string[] num = t.Split();

            for(int i=0; i < num.Length; ++i)
            {
                int x = int.Parse(num[i]);

                Console.Write(x + " " + x + " ");
            }
        }
    }
}
