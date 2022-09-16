using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Recursion
{
    public static class GenerateParenthesis
    {
        public static List<String> generateParenthesis(int n)
        {
            List<String> combinations = new List<string>();
            generateAll(new char[2 * n], 0, combinations);
            return combinations;
        }

        public static void generateAll(char[] current, int pos, List<String> result)
        {
            if (pos == current.Length)
            {
                if (valid(current))
                    result.Add(new String(current));
            }
            else
            {
                current[pos] = '(';
                generateAll(current, pos + 1, result);
                current[pos] = ')';
                generateAll(current, pos + 1, result);
            }
        }

        public static bool valid(char[] current)
        {
            int balance = 0;
            foreach (char c in current)
            {
                if (c == '(') balance++;
                else balance--;
                if (balance < 0) return false;
            }
            return (balance == 0);
        }

        public static void Test()
        {
            var result=generateParenthesis(5);

            foreach(string res in result)
            {
                Console.WriteLine(res);
            }
        }
    }
}