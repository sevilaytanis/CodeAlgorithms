using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.SortingAndSearching
{
    public static class ClosestPointToOrigin
    {
        // private readonly Random rand = new Random();
        public static int[][] KClosest(int[][] points, int K)
        {
            var result = new List<int[]>();
            KClosestHelper(points, 0, points.Count() - 1, K);
            return points.Take(K).ToArray();
        }

        private static void KClosestHelper(int[][] points,
                                        int left,
                                        int right,
                                        int k)
        {
            if (left >= right) return;

            var partitionIndex = Partition(points, left, right);
            int leftLength = partitionIndex - left + 1;
            if (k < leftLength)
            {
                KClosestHelper(points, left, partitionIndex - 1, k);
            }
            else if (k > leftLength)
            {
                KClosestHelper(points, partitionIndex + 1, right, k - leftLength);
            }
        }

        private static int Partition(int[][] arr, int left, int right)
        {
            //var randomIndex = rand.Next(left, right+1);
            //swap(arr, left, randomIndex);
            var pivot = arr[left];
            left--;
            right++;

            while (true)
            {
                do
                {
                    left++;
                } while (AIsCloserThanB(arr[left], pivot));

                do
                {
                    right--;
                } while (AIsFartherThanB(arr[right], pivot));

                if (left >= right) return right;

                swap(arr, left, right);
            }
        }

        private static bool AIsCloserThanB(int[] a, int[] b)
        {
            return a[0] * a[0] - b[0] * b[0] + a[1] * a[1] - b[1] * b[1] < 0;
        }

        private static bool AIsFartherThanB(int[] a, int[] b)
        {
            return a[0] * a[0] - b[0] * b[0] + a[1] * a[1] - b[1] * b[1] > 0;
        }

        private static void swap(int[][] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void Test()
        {
            var arr = new int[10][];
            arr[0] = new[] { 68, 97 };
            arr[1] = new[] { 34, -84 };
            arr[2] = new[] { 60, 100 };
            arr[3] = new[] { 2, 31 };
            arr[4] = new[] { -27, -38 };
            arr[5] = new[] { -73, -74 };
            arr[6] = new[] { -55, -39 };
            arr[7] = new[] { 62, 91 };
            arr[8] = new[] { 62, 92 };
            arr[9] = new[] { -57, -67 };
            var closest = KClosest(arr, 5);

            foreach (var item in closest)
            {
                Console.Out.WriteLine(string.Join(",", item));
            }
        }
    }
}