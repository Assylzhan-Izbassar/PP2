using System;

namespace Task_4
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            string s = Console.ReadLine();
            int n = int.Parse(s);
            string[,] str = Getstr(n);
    
            for(uint i=0; i < n; ++i)
            {
                for(uint j=0; j <=i; ++j)
                {
                    Console.Write(str[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static string[,] Getstr(int n)
        {
            string[,] result = new string[n, n];
            for(int i=0; i < n; ++i)
            {
                for(int j=0; j < n; ++j)
                {
                    result[i, j] = "[*]";
                }
            }
            return result;
        }
    }
}
