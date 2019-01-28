using System;

namespace Task_2
{
    class MainClass
    {
        class Student
        {
            public string Name, ID;
            public int year;

            public Student()//constructor
            {
            }

            public Student(string n, string id)
            {
                Name = n;
                ID = id;
            }

            public void Print()
            {
                Console.WriteLine(Name + " " + ID + " " + (++year));
            }
        };
        public static void Main(string[] args)
        {
            Student s = new Student("Assylzhan", "18BD")
            {
                year = Convert.ToInt32(Console.ReadLine())
            };

            s.Print();
        }
    }
}
