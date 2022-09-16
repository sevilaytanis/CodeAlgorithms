using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.ArrayAndStrings
{
    public static class _1ThreeSum
    {

        public static List<List<Int32>> threeSum(int[] nums)
        {
            List<List<Int32>> res = new List<List<int>>();
            List<Int32> dups = new List<int>();
            Dictionary<Int32, Int32> seen = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; ++i)
            {
                dups.Add(nums[i]);

                for (int j = i + 1; j < nums.Length; ++j)
                {
                    int complement = -nums[i] - nums[j];
                    if (seen.ContainsKey(complement) && seen.GetValueOrDefault(complement) == i)
                    {
                        List<Int32> triplet = new List<int> { nums[i], nums[j], complement };
                        var sorted = triplet.OrderBy(x => x);
                        res.Add(triplet);
                    }
                    seen.Add(nums[j], i);
                }
            }

            return res;
        }

        public static void TestThreeSum()
        {
            var testSet = new int[] { -1, 0, 1, 2, -1, -4 };

            var result = threeSum(testSet);

            Console.WriteLine(result);
        }
    }
}

