using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Algorithms
{
    public static class SumOfEqualInteger
    {
        public static Boolean FindSum(List<int> numberList, int currentNumber)
        {
            HashSet<int> foundValues = new HashSet<int>();
            foreach (int a in numberList)
            {
                if (foundValues.Contains(currentNumber - a))
                {
                    return true;
                }

                foundValues.Add(a);
            }
            return false;

        }

        public static void TestSumOfEqualInteger()
        {
            List<int> v = new List<int> { 5, 7, 1, 2, 8, 4, 3 };
            List<int> test = new List<int> { 3, 20, 1, 2, 7 };

            for (int i = 0; i < test.Count; i++)
            {
                Boolean output = FindSum(v, test[i]);
                Console.WriteLine("findSumOfTwo(v, " + test[i] + ") = " + (output ? "true" : "false"));
            }

        }
    }
}
