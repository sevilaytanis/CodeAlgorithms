using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.ArrayAndStrings
{
    public static class ContainerWithMostWater
    {
        public static int maxArea(int[] height)
        {
            int maxarea = 0;
            int left = 0;
            int right = height.Length - 1;
            while (left < right)
            {
                int width = right - left;
                maxarea = Math.Max(maxarea, Math.Min(height[left], height[right]) * width);
                if (height[left] <= height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return maxarea;
        }

        public static void TestMaxArea()
        {

            int[] heights = new Int32[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

            var result = maxArea(heights);

            Console.WriteLine(result);
        }
    }
}
