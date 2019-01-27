using System;

namespace Task_1
{
    class MainClass
    {
        public static bool isPrime(int a)//a function that check is the element in array arr prime or not
        {
            if (a < 2) return false;
            if (a == 2) return true;
            for(uint i = 2; i*i <= a; ++i)
            {
                if (a % i == 0) return false;
            }
            return true;
        }
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int n = int.Parse(s);//Parse() is a method that convert string that contain exactly number to intager
            string t = Console.ReadLine();
            string[] nums = t.Split();/*Split is polymorphic method that continue chars like ',', '.' , etc. and space.
                                        So in our case method is continue just spaces between elements of string and nums become new string that is not contain spaces*/

            int[] arr = new int[n];

            for(int i=0; i < nums.Length; ++i)
            {
                arr[i] = int.Parse(nums[i]);
            }

            for(int i=0; i < arr.Length; ++i)
            {
                if (isPrime(arr[i]))//if our element come from the function with ture then we Write this element.
                {
                    Console.Write(arr[i] + " ");
                }
                else continue;//else just continue
            }
        }
        
    }
}
