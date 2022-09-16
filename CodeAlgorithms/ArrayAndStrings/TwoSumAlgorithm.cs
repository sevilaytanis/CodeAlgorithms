using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.ArrayAndStrings
{
    public static class TwoSumAlgorithm
    {

        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        return new int[] { i, j };
                    }
                }

            }
            return new int[] { 0, 0 };
        }

        public static void TestTwoSum()
        {
            int[] nums = new int[] { 2, 7, 11, 15 };
            int target = 9;

            var result = TwoSum(nums, target);

            foreach (int res in result)
            {
                Console.WriteLine(res);

            }


        }
    }
}
