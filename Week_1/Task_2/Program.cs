using System;

namespace Task_2
{
    class MainClass
    {
        class Student
        {
            public string Name, ID;
            public int year;

            //public Student()//constructor
            //{
            //}

            public Student(string n, string id,int y)//constructor
            {
                Name = n;
                ID = id;
                year = y;
            }

        };

        public static void Main(string[] args)
        {
            Student s = new Student(GetName(), GetID(), IncrementYear());

            Console.WriteLine(s.Name + " " + s.ID + " " + (s.year));

        }
        static string GetName()
        {
            string t = Console.ReadLine();
            return t;
        }
        static string GetID()
        {
            string id = Console.ReadLine();
            return id;
        }
        static int IncrementYear()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            return (++n);
        }
    }
}
