using System;
using System.IO;

namespace Task_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string pathOfFile = @"/Users/macbook/Desktop/PP2/Projects/MyFile.txt";
            string text = File.ReadAllText(pathOfFile);
            //text.Trim();

            string check = Polin(text);

            if(CheckToPolin(text, check)) 
            {
                Console.Write("YES\n");
            }
            else
            {
                Console.Write("NO\n");
            }

        }
        public static string Polin(string s)
        {
            string res = "";
            for(int i= s.Length -1; i >= 0; --i)
            {
                res = res + s[i];
            }
            return res;
        }
        public static bool CheckToPolin(string a,string b)
        {
            for(int i=0; i < a.Length; ++i)
            {
                if (a[i] != b[a.Length - 1 - i]) return false;
            }
            return true;
        }
    }
}
