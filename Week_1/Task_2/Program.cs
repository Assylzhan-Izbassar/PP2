using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Student
    {
        public string Name, ID;
        public int year;

        //public Student(string n, string id)//we create pramethric constructor
        //{
        //    Name = n;
        //    ID = id;
        //}
        public Student(string Name, string ID)
        {
            this.Name = Name;
            this.ID = ID;
        }

    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            string t = Console.ReadLine();
            string[] student = t.Split();

            Student s = new Student(student[0], student[1])
            {
                year = int.Parse(student[2])
            };

            GetName(s.Name);
            GetID(s.ID);
            IncrementYear(s.year);

        }
        static void GetName(string n)
        {
            Console.Write(n + " ");
        }
        static void GetID(string id)
        {
            Console.Write(id + " ");
        }
        static void IncrementYear(int y)
        {
            Console.Write(++y + " ");
        }
    }
}
