using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.ArrayAndStrings
{
    public static class ThreeSumClosest
    {

        public static int threeSumClosest(int[] nums, int target)
        {
            int diff = Int32.MaxValue;
            int sz = nums.Length;
            Array.Sort(nums);
            for (int i = 0; i < sz && diff != 0; ++i)
            {
                for (int j = i + 1; j < sz - 1; ++j)
                {
                    int complement = target - nums[i] - nums[j];
                    var idx = Array.BinarySearch(nums, j + 1, sz - 1 - j, complement);
                    int hi = idx >= 0 ? idx : ~idx, lo = hi - 1;
                    if (hi < sz && Math.Abs(complement - nums[hi]) < Math.Abs(diff))
                        diff = complement - nums[hi];
                    if (lo > j && Math.Abs(complement - nums[lo]) < Math.Abs(diff))
                        diff = complement - nums[lo];
                }
            }
            return target - diff;
        }

        public static void TestthreeSumClosest()
        {
            var testData = new int[] { -1, 2, 1, -4 };
            var result = threeSumClosest(testData, 1);

            Console.WriteLine(result);
        }
    }
}
