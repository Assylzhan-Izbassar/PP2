using System;
using System.IO;

namespace Task_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string pathOfFile = @"/Users/macbook/Desktop/MyFile.txt";
            if (!File.Exists(pathOfFile))
            {
                File.Create(pathOfFile);
            }
            StreamWriter sw = new StreamWriter(pathOfFile);

            sw.WriteLine(Console.ReadLine());
            sw.Close();
            
            string text = File.ReadAllText(pathOfFile);
            string check = Polin(text);

            if (CheckToPolin(text, check)){
                Console.WriteLine("YES\n");
            }
            else
            {
                Console.WriteLine("NO\n");
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
