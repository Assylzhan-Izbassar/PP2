using System;

namespace Task_3
{
    class MainClass
    {
        public static int[] DoubleArray(int[] arr)//Метод принимающий массив и удваивает его каждый элемент и пишет на другой массив.
        {
            int[] res = new int[2 * arr.Length];//Создаем новый массив res, у которого длина 2 раза больше чем длина нынешнего массива.
            for(int i=0; i < arr.Length; ++i)
            {
                res[2*i] = res[2*i + 1] = arr[i];//Приравневаем i элементам массива res, значение i-го элемента из массива arr.
            }
            return res;//Возвращаем массив res.
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
