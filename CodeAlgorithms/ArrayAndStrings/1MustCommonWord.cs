using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.ArrayAndStrings
{
    public static class _1MustCommonWord
    {
        public static String mostCommonWord(String paragraph, String[] banned)
        {

            List<String> bannedWords = new List<string>();
            foreach (String word in banned)
                bannedWords.Add(word);

            String ans = "";
            int maxCount = 0;

            Dictionary<String, int> wordCount = new Dictionary<string, int>();
            StringBuilder wordBuffer = new StringBuilder();
            //char[] chars = paragraph.toCharArray();

            for (int p = 0; p < paragraph.Length; ++p)
            {
                char currChar = paragraph[p];

                // 1). consume the characters in a word
                if (Char.IsLetter(currChar))
                {
                    wordBuffer.Append(Char.ToLower(currChar));
                    if (p != paragraph.Length - 1)
                        // skip the rest of the processing
                        continue;
                }

                // 2). at the end of one word or at the end of paragraph
                if (wordBuffer.Length > 0)
                {
                    String word = wordBuffer.ToString();
                    // identify the maximum count while updating the wordCount table.
                    if (!bannedWords.Contains(word))
                    {
                        int newCount = wordCount.GetValueOrDefault(word, 0) + 1;
                        if(word.Contains(word))
                        {
                            wordCount[word] = newCount;
                        }
                        else
                        {
                            wordCount.Add(word, newCount);

                        }
                        if (newCount > maxCount)
                        {
                            ans = word;
                            maxCount = newCount;
                        }
                    }
                    // reset the buffer for the next word
                    wordBuffer = new StringBuilder();
                }
            }
            return ans;
        }

        public static void Test()
        {
            var result=mostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", new string[] { "hit" });
            Console.WriteLine(result);
        }
    }
}
