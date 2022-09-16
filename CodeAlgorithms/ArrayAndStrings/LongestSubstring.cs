using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.ArrayAndStrings
{
    public static class LongestSubstring
    {
        public static int LengthOfLongestSubstring(String s)
        {
            Int32[] chars = new Int32[128];
            int res = 0;

            int left = 0;
            int right = 0;

            while (right < s.Length)
            {
                char r = s[right];

                int index = chars[r];

                if (index >= left && index < right)
                {
                    left = index + 1;
                }

                res = Math.Max(res, right - left + 1);
                chars[r] = right;

                right++;
            }

            return res;
        }

        public static void TestLengthOfLongestSubstring()
        {
            string name = "abcabcbb";
            int length = LengthOfLongestSubstring(name);

            Console.WriteLine(length);
        }
    }
}
