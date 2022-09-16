using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.ArrayAndStrings
{
    public static class RomanToInteger
    {
        static Dictionary<string, Int32> values = new Dictionary<string, int>()
        {
        { "I", 1 },
        {"V", 5},
        {"X", 10},
        {"L", 50},
        {"C", 100},
        {"D", 500},
        {"M", 1000},
        {"IV", 4},
        {"IX", 9},
        {"XL", 40},
        {"XC", 90},
        {"CD", 400},
        {"CM", 900}
    };

        public static int romanToInt(String s)
        {

            int sum = 0;
            int i = 0;
            while (i < s.Length)
            {
                if (i < s.Length - 1)
                {
                    String doubleSymbol = s.Substring(i, 2);
                    // Check if this is the length-2 symbol case.
                    if (values.ContainsKey(doubleSymbol))
                    {
                        sum += values.GetValueOrDefault(doubleSymbol);
                        i += 2;
                        continue;
                    }
                }
                // Otherwise, it must be the length-1 symbol case.
                String singleSymbol = s.Substring(i, 1);
                sum += values.GetValueOrDefault(singleSymbol);
                i += 1;
            }
            return sum;
        }

        public static void TestRomanToInt()
        {
            var result = romanToInt("VII");
            Console.WriteLine(result);
        }
    }

}
