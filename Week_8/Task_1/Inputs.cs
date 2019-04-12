using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Inputs
    {
        static bool Check(char[] nums, string msg)
        {
            return nums.Contains(msg[0]);
        }
        public static bool IsZero(string msg)
        {
            char[] Zero = { '0' };
            return Check(Zero, msg);
        }
        public static bool NonZeroDigit(string msg)
        {
            char[] Digit = { '1', '2', '3', '4', '5', '6', '7', '8', '9', };
            return Check(Digit, msg);
        }
        public static bool DecimalSeperator(string msg)
        {
            char[] Dot = { '.' };
            return Check(Dot, msg);
        }
        public static bool MathOp(string msg)
        {
            char[] Operators = { '+', '-', '*', '/' };
            return Check(Operators, msg);
        }
        public static bool Equals(string msg)
        {
            char[] Equal = { '=' };
            return Check(Equal, msg);
        }
        public static bool Clear(string msg)
        {
            char[] Clear = { 'C' };
            return Check(Clear, msg);
        }
    }
}
