﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.ArrayAndStrings
{
    public static class _1TrappingRainWater
    {
        public static int trap(int[] height)
        {
            // time : O(n)
            // space : O(1)
            if (height.Length == 0)
                return 0;

            int left = 0,
                right = height.Length - 1;

            int leftMax = 0,
                rightMax = 0;
            int ans = 0;

            while (left < right)
            {
                if (height[left] > leftMax)
                    leftMax = height[left];
                if (height[right] > rightMax)
                    rightMax = height[right];

                if (leftMax < rightMax)
                {
                    ans += Math.Max(0, leftMax - height[left]);
                    left++;
                }
                else
                {
                    ans += Math.Max(0, rightMax - height[right]);
                    right--;
                }
            }

            return ans;
        }

        public static void Test()
        {
            var testData = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var result = trap(testData);

            Console.WriteLine(result);
        }

    }
}
