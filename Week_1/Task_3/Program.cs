using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int n = int.Parse(s);//метод Parse() превращает из цифра символа в цифру числа
            string t = Console.ReadLine();
            string[] nums = t.Split();

            int[] arr = new int[n];
            int[] arr2 = new int[n];

            for(int i=0; i < nums.Length; ++i)
            {
                arr[i] = int.Parse(nums[i]);
                arr2[i] = int.Parse(nums[i]);
            }

            for(int i=0; i < arr.Length; ++i)
            {
                Console.Write(arr[i] + " " + arr2[i] + " ");
            }
        }
    }
}
