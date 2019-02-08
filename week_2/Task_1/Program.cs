using System;
using System.IO;

namespace Task_1
{
    class MainClass
    {
        public static bool IsPolin(string s,int n)
        {
            if (n == s.Length / 2) return true;
            else
            {
                if (s[n] != s[s.Length - n - 1]) return false;
                return IsPolin(s, n + 1);
            }
        }
        public static void Main(string[] args)
        {
            string pathOfFile = @"/Users/macbook/Desktop/PP2/Projects/MyFile.txt";
            string text = File.ReadAllText(pathOfFile);
            //text.Trim();

            string check = Polin(text);

            if(IsPolin(text, 0)) 
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
