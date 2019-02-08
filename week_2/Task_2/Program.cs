using System;
using System.IO;
using System.Text;

namespace Task_2
{
    class MainClass
    {
        public static bool IsPrime(int n)
        {
            if (n == 2) return true;
            if (n < 2) return false;

            for (int i = 2; i * i <= n; ++i)
            {
                if (n % i == 0) return false;
            }
            return true;

        }
        public static string Prime_array(string[] s)
        {
            string res = "";
            for(int i=0; i < s.Length; ++i)
            {
                if (IsPrime(int.Parse(s[i]))){
                    res = res + " " + s[i];
                }
            }
            return res.Trim();
        }

        public static void Main(string[] args)
        {
            string PathofFile = @"/Users/macbook/Desktop/PP2/Projects/MyFile.txt";
            StreamReader sr = new StreamReader(PathofFile);
            string numbers = sr.ReadToEnd();
            sr.Close();
            //string Numbers = File.ReadAllText(PathofFile);
            string[] nums = numbers.Split(' ');
             
            bool res = false;

            for(int i=0; i < nums.Length; ++i)
            {
                int a = int.Parse(nums[i]);
                if (IsPrime(a))
                {
                    res = true;
                    break;
                }
            }
            FileStream fs = new FileStream(@"/Users/macbook/Desktop/PP2/Projects/Output.txt", FileMode.Create, FileAccess.Write);
            StreamWriter write = new StreamWriter(fs);

            if (res == true)
            {
                string Primes = Prime_array(nums);
                write.WriteLine(Primes);
                write.Close();
                fs.Close();
            }
            else
            {
                write.Write("Sorry, there was not prime mumbers");
                write.Close();
                fs.Close();
            }
        }
    }
}
