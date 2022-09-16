using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Algorithms
{
    public static class MissingNumberInArray
    {

        public static int FindMissingNumber(List<int> input)
        {
            int sumOfInput = 0;
            sumOfInput = input.Sum();
            int length = input.Count;

            int actualSum = ((length + 1) * (length + 2)) / 2;

            return actualSum - sumOfInput;
        }

        public static List<int> GenerateMissingArray(int range)
        {
            List<Int32> vector = new List<Int32>();
            var missingElement = RandomNumberGenerator.GetInt32(range);

            for (int v = 1; v < range + 1; v++)
            {
                if (v == missingElement)
                    continue;
                vector.Add(v);
            }

            return vector;
        }

        public static void TestMissingNumber()
        {
            var array = GenerateMissingArray(10);

            var response = FindMissingNumber(array);

            Console.WriteLine(response);

        }
    }
}

