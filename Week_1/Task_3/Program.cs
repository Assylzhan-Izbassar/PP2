using System;

namespace Task_3
{
    class MainClass
    {
        public static int[] DoubleArray(int[] arr)
        {
            int[] a = new int[2 * arr.Length];
            for(int i=0; i < arr.Length; ++i)
            {
                a[2*i] = a[2*i + 1] = arr[i];
            }
            return a;
        }
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int n = int.Parse(s);//метод Parse() превращает из цифра символа в цифру числа
            string t = Console.ReadLine();
            string[] nums = t.Split();

            int[] arr = new int[n];

            for (int i = 0; i < nums.Length; ++i)
            {
                arr[i] = int.Parse(nums[i]);
            }
            int[] arr2 = DoubleArray(arr);

            for (int i = 0; i < arr2.Length; ++i)
            {
                Console.Write(arr2[i] + " ");
            }
        }
    }
}
