using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task_2
{
    public class Mark
    {
        public Mark()
        {

        }
        public int Point
        {
            get;
            set;
        }
        public string letter;

        public string GetLetter()
        {
            switch (Point)
            {
                case int n when (n >= 95 && n <= 100):
                    letter = "A";
                    return letter;
                case int n when (n >= 90 && n < 95):
                    letter = "A";
                    return letter;
                case int n when (n >= 85 && n < 90):
                    letter = "B+";
                    return letter;
                case int n when (n >= 80 && n < 85):
                    letter = "B";
                    return letter;
                case int n when (n >= 75 && n < 80):
                    letter = "B-";
                    return letter;
                case int n when (n >= 70 && n < 75):
                    letter = "C+";
                    return letter;
                case int n when (n >= 65 && n < 70):
                    letter = "C";
                    return "C";
                case int n when (n >= 60 && n < 65):
                    letter = "C-";
                    return "C-";
                case int n when (n >= 55 && n < 60):
                    letter = "D+";
                    return letter;
                case int n when (n >= 50 && n < 60):
                    letter = "D";
                    return letter;
                case int n when (n >= 0 && n < 50):
                    letter = "F";
                    return letter;
                default:
                    return "Invalid";
            }
        }
        public override string ToString()
        {
            return string.Format("{0} {1}",Point,letter);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Mark> Marks = new List<Mark>();
            Random random = new Random(DateTime.Now.Second);
            for (int i=0; i < 10; ++i)
            { 
                Marks.Add(new Mark
                {
                    Point = random.Next(0, 100),
                });
            }
            for(int i=0; i < Marks.Count; ++i)
            {
                Marks[i].letter = Marks[i].GetLetter();
            }
            Serialize(Marks);
            Deserialize();
        }
        public static void Serialize(List<Mark> marks)
        {
            string path = @"C:\Users\Brother\Desktop\Test\Marks.txt";
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Mark>));
                xml.Serialize(fs,marks);
            }
        }
        public static void Deserialize()
        {
            string path = @"C:\Users\Brother\Desktop\Test\Marks.txt";
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Mark>));
                List<Mark> deserialize_marks = xml.Deserialize(fs) as List<Mark>;
                for(int i=0; i < deserialize_marks.Count; ++i)
                {
                    Console.WriteLine(deserialize_marks[i].ToString());
                }
            }
        }
    }
}
