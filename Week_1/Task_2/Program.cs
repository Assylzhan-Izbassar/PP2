using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Student//I create a class Student
    {
        public string Name, ID;
        public int year;

        /*public Student(string Name, string ID)//I create pramethric constructor
        //{
        //    this.Name = Name;//method "this" works like pointer, which save the address of the type string ot etc. 
        //    this.ID = ID;
        }*/
        public Student(string n, string id)
        {
            Name = n;
            ID = id;
        }

        public string GetName()
        {
            return Name;
        }
        public string GetID()
        {
            return ID;
        }
        public int GetYear()
        { 
            return ++year;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            string t = Console.ReadLine();//input the name,id,and year
            string[] student = t.Split();//clean the spaces in string t

            Student s = new Student(student[0], student[1])
            {
                year = int.Parse(student[2])
            };
            //Student s2 = new Student("Assylzhan", "18BD");

            Console.Write(s.GetName() + " " + s.GetID() + " " + s.GetYear());

            /*s2.year = Convert.ToInt32(Console.ReadLine());
            Console.Write(s2.getName() + " " + s2.getID() + " " + s2.GetYear());
            
            GetName(s.Name); //call method
            GetID(s.ID); //call method
            IncrementYear(s.year); //call method*/

        }
        static void GetName(string n)//method to output the name
        {
            Console.Write(n + " ");
        }
        static void GetID(string id)//method to output the ID
        {
            Console.Write(id + " ");
        }
        static void IncrementYear(int y)//method to output the increment of the year of study
        {
            Console.Write(++y + " ");
        }
    }
}
