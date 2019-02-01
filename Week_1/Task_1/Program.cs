using System;

namespace Task_1
{
    class MainClass
    {
        public static bool IsPrime(int a)//a function that check is the element in array arr prime or not
        {
            if (a < 2) return false;
            if (a == 2) return true;
            for(uint i = 2; i <= Math.Sqrt(a); ++i)//by checking prime number, if number is not divisible to the prime numbers before sqrt(a) then the number is prime
            {
                if (a % i == 0) return false;//if our element is divided to i, then it is not prime number and we return false;
            }
            return true;//if element a go out from the loop, it is provide that element a is prime number, and return true;
        }
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int n = int.Parse(s);//Parse() is a method that convert string that contain exactly number to intager
            string t = Console.ReadLine();
            string[] nums = t.Split();/*Split is polymorphic method that continue chars like ',', '.' , etc. and space.
                                        So in our case method is continue just spaces between elements of string and nums become new string that is not contain spaces*/

            int[] arr = new int[n];//Create new int array arr 

            for(int i=0; i < nums.Length; ++i)//loop for array string nums 
            {
                arr[i] = int.Parse(nums[i]);//each element of the string of array nums create to type int and push it like element of array arr
            }

            for(int i=0; i < arr.Length; ++i)
            {
                if (IsPrime(arr[i]))//if our element come from the function with ture then we Write this element.
                {
                    Console.Write(arr[i] + " ");
                }
                else continue;//else just continue
            }
        }
        
    }
}
