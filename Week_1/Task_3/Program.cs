using System;

namespace Task_3
{
    class MainClass
    {
        public static int[] DoubleArray(int[] a)
        {
            int[] arr = new int[2 * a.Length];
            for(int i=0; i < a.Length; ++i)
            {
                arr[2 * i] = arr[2 * i + 1] = a[i]; 
            }
            return arr;
        }
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();//Вводим строку s.
            int n = int.Parse(s);//метод Parse() превращает из цифра символа в цифру числа.
            string t = Console.ReadLine();//Вводим строку t.
            string[] nums = t.Split();//Убираем пробелы из строки t.

            int[] arr = new int[n];//Создаем новый массив из n элементов.

            for (int i = 0; i < nums.Length; ++i)//Пробегаемся по массиву nums.
            {
                arr[i] = int.Parse(nums[i]);//Превращаем i-ты элемент из nums в integer и преравневаем его значение на i место массива arr.
            }
            int[] arr2 = DoubleArray(arr);//Вызываем метод DoubleArray чтобы дать значение массиву arr2. 

            for (int i = 0; i < arr2.Length; ++i)//Пробегаемся  по массиву arr2.
            {
                Console.Write(arr2[i] + " ");//Выводим элементы arr2.
            }
        }
    }
}
