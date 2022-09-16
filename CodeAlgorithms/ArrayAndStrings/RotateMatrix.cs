using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.ArrayAndStrings
{
    public static class RotateMatrix
    {

        public static void rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < (n + 1) / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int temp = matrix[n - 1 - j][i];
                    matrix[n - 1 - j][i] = matrix[n - 1 - i][n - j - 1];
                    matrix[n - 1 - i][n - j - 1] = matrix[j][n - 1 - i];
                    matrix[j][n - 1 - i] = matrix[i][j];
                    matrix[i][j] = temp;

                }
            }

            for (int i = 0; i < (n + 1) / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    Console.WriteLine("i,j:" + matrix[i][j]);
                }
            }
        }
        public static void Test()
        {
            var dataset = new int[][] { new Int32[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            rotate(dataset);
        }



    }
}
