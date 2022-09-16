using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.ArrayAndStrings
{
    public static class StringToInteger
    {


        public static int myAtoi(String input)
        {
            int sign = 1;
            int result = 0;
            int index = 0;
            int n = input.Length;

            // Discard all spaces from the beginning of the input string.
            while (index < n && input[index] == ' ')
            {
                index++;
            }

            // sign = +1, if it's positive number, otherwise sign = -1. 
            if (index < n && input[index] == '+')
            {
                sign = 1;
                index++;
            }
            else if (index < n && input[index] == '-')
            {
                sign = -1;
                index++;
            }

            // Traverse next digits of input and stop if it is not a digit
            while (index < n && Char.IsDigit(input[index]))
            {
                int digit = input[index] - '0';

                // Check overflow and underflow conditions. 
                if ((result > Int32.MaxValue / 10) ||
                    (result == Int32.MaxValue / 10 && digit > Int32.MaxValue % 10))
                {
                    // If integer overflowed return 2^31-1, otherwise if underflowed return -2^31.    
                    return sign == 1 ? Int32.MaxValue : Int32.MinValue;
                }

                // Append current digit to the result.
                result = 10 * result + digit;
                index++;
            }

            // We have formed a valid number without any overflow/underflow.
            // Return it after multiplying it with its sign.
            return sign * result;
        }

        public static void TestStringToInteger()
        {
            var response = myAtoi("457");

            Console.WriteLine(response);

        }
    }
}

