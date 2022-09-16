using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Trainer.ArrayAndStrings
{
    public static class General
    {
        public static void main()
        {
            char[] name = new char[] { 's', 'e', 'v', 'i', 'l', 'a', 'y' };

            reverse(name);
            checkPalindrome("abba");

            compress("aaabbcddkkk");
            int[,] matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            FindDiagonalOrder(matrix);

            SpiralOrder(matrix);

            PascalTriangle(4);

            int[] numbers = new int[] { 1,1,2 };

           var result= RemoveDuplicates(numbers);
        }

        #region reverse

        static void Swap(ref char x, ref char y)
        {

            char tempswap = x;
            x = y;
            y = tempswap;
        }
        public static void reverse(char[] name)
        {
            int s = 0;
            int e = name.Length - 1;


            while (s < e)
            {
                Swap(ref name[s++], ref name[e--]);
            }

            string reverse = new string(name);
            Console.WriteLine(reverse);

        }

        #endregion

        #region palindrome
        public static bool checkPalindrome(string name)
        {
            int start = 0;
            int end = name.Length - 1;

            while (start <= end)
            {
                if (name[start] != name[end])
                {
                    Console.WriteLine("Not Palindrome");

                    return false;
                }
                start++;
                end--;
            }


            Console.WriteLine("Palindrome");
            return true;
        }
        #endregion

        #region compress

        public static void compress(string s)
        {
            string result = "";
            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                j = i + 1;

                int charCount = 1;
                while (j < s.Length && s[j] == s[i])
                {
                    charCount++;
                    j++;
                }

                i = j - 1;
                j--;

                if (charCount > 1)
                {
                    result = result + s[i] + charCount;
                }
                else
                {
                    result = result + s[i];

                }

            }

            Console.WriteLine(result);
        }

        public static int[] FindDiagonalOrder2(int[,] mat)
        {

            int row = 0, column = 0;
            row = mat.GetLength(0);
            column = mat.GetLength(1);

            int[] result = new int[row * column];
            int direction = 1;

            int current_row = 0, current_column = 0;
            int index = 0;

            while (result.Count() == row * column)
            {

                int new_row = current_row + (direction == 1 ? -1 : 1);
                int new_column = current_column + (direction == 1 ? 1 : -1);

                while (current_row < row && current_column < column)
                {

                    if (direction == 1) //direction up
                    {
                        current_row = current_row == row - 1 ? 1 : 0;
                        current_column = current_column < column - 1 ? 1 : 0;
                    }
                    else //direction down
                    {
                        current_row = current_row == row - 1 ? 1 : 0;
                        current_column = current_column < column - 1 ? 1 : 0;
                    }
                    result[index] = mat[current_row, current_column];
                    index++;

                    if (current_column == column - 1)
                    {

                    }

                }

                row = new_row;
                column = new_column;

                direction = 1 - direction;
            }
            return result;
        }
        public static int[] FindDiagonalOrder(int[,] mat)
        {

            int d1 = 0, d2 = 0;
            d1 = mat.GetLength(0);
            d2 = mat.GetLength(1);

            int[] result = new int[d1 * d2];
            int index = 0;
            int row = 0, column = 0;
            int direction = 1;



            while (row < d1 && column < d2)
            {
                result[index] = mat[row, column];
                index++;

                int new_row = row + (direction == 1 ? -1 : 1);
                int new_column = column + (direction == 1 ? 1 : -1);

                if (new_row < 0 || new_row == d1 || new_column < 0 || new_column == d2)
                {

                    if (direction == 1)
                    {
                        row += (column == d1 - 1 ? 1 : 0);
                        column += (column < d2 - 1 ? 1 : 0);
                    }

                    else
                    {
                        column += (row == d1 - 1 ? 1 : 0);
                        row += (row < d2 - 1 ? 1 : 0);
                    }
                    direction = 1 - direction;
                }
                else
                {
                    row = new_row;
                    column = new_column;
                }

            }
            return result;


        }

        public static List<int> SpiralOrder(int[,] matrix)
        {
            List<int> result = new List<int>();
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);

            int up = 0;
            int left = 0;
            int right = column - 1;
            int down = row - 1;

            while (result.Count < (row * column) - 1)
            {
                //right
                for (int i = left; i <= right; i++)
                {
                    result.Add(matrix[up, i]);
                }

                //down
                for (int i = up + 1; i <= down; i++)
                {
                    result.Add(matrix[i, right]);
                }
                //left
                if (up != down)
                {
                    for (int i = right - 1; i >= left; i--)
                    {
                        result.Add(matrix[down, i]);
                    }
                }
                if (left != right)
                {
                    //up
                    for (int i = down - 1; i > up; i--)
                    {
                        result.Add(matrix[i, left]);
                    }
                }
            }

            right--;
            left++;
            up++;
            down--;

            return new List<int>();
        }

        public static void PascalTriangle(int rows)
        {
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < rows; i++)
            {
                List<int> newList = new List<int>();
                newList.Add(1);

                var prevList = result.LastOrDefault();

                if (prevList == null)
                {
                    result.Add(newList);
                    continue;
                }
                if (prevList.Count == 1)
                {
                    newList.Add(1);
                    result.Add(newList);
                    continue;
                }

                for (int j = 0; j < result.LastOrDefault().Count - 1; j++)
                {
                    newList.Add(prevList[j] + prevList[j + 1]);
                }
                newList.Add(1);

                result.Add(newList);
            }

            var response = result;
        }

        public static string LongestPrefix(string[] stringList)
        {
            string prefix = "";

            foreach (string currentWord in stringList)
            {
                if (prefix == "")
                {
                    prefix = currentWord;
                    continue;
                }

                while (currentWord.IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);

                }
            }
            return prefix;
        }

        public static int RemoveDuplicates(int[] nums)
        {

            Array.Sort(nums);

            if (nums.Length == 0)
            {
                return 0;
            }

            int count = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[count] != nums[i])
                {
                    count++;
                    nums[count] = nums[i];
                }
            }
            return count + 1;
        }
        #endregion

    }
}
