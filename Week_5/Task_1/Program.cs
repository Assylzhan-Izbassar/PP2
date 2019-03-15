using System;
using System.IO;
using System.Xml.Serialization;

namespace Task_1
{
    public class Complex_number
    {
        public double a, b;

        public Complex_number()
        {

        }
        public void PrintInfo()
        {
            Console.WriteLine(string.Format("{0} {1}", a, b));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string Complex = Console.ReadLine();

            Complex_number number = new Complex_number();

            number.a = Real_part(Complex);
            number.b = Image_part(Complex);

            Serialize(number);
            Deserialize(number);
            Console.ReadKey();
        }

        private static void Deserialize(Complex_number number)
        {
            using(FileStream fileStream = new FileStream(@"C:\Users\Brother\Desktop\Test\Number.txt", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Complex_number));
                Complex_number another_number = xmlSerializer.Deserialize(fileStream) as Complex_number;
                another_number.PrintInfo();
            }
        }

        private static void Serialize(Complex_number number)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Complex_number));

            using (FileStream fileStream = new FileStream(@"C:\Users\Brother\Desktop\Test\Number.txt", FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fileStream, number);
            }
        }

        static public double Real_part(string s)
        {
            string res = "";
            for(int i = 0; i < s.Length; ++i)
            {
                if (s[i] == '+') break;
                res += s[i];
            }
            res.Trim();

            double a = int.Parse(res);

            return a;
        }
        static public double Image_part(string s)
        {
            string res = "";
            int k = s.LastIndexOf('+');
            for (int i = k+1; i < s.Length; ++i)
            {
                if (s[i] == 'i') break;
                res += s[i];
            }
            res.Trim();

            double b = int.Parse(res);

            return b;
        }

    }
}
