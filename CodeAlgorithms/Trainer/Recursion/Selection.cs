using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Trainer.Recursion
{

    //find all valid combination...
    //knapsack problem
    //word break
    //n queens
    //phonespell
    public static class Selection
    {

        public static bool wordBreak(String word)
        {
            List<string> wordList = new List<string>();

            int size = word.Length;

            if (size == 0)
                return true;

            for (int i = 1; i <= size; i++)
            {
                if (wordList.Contains(word.Substring(0, i)) && wordBreak(word.Substring(i, size))) ;
                return true;
            }
            return false;
        }
    }
}
