//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CodeAlgorithms.ArrayAndStrings
//{
//    public static class MinimumWindowSubstring
//    {
//        public static String minWindow(String s, String t)
//        {

//            if (s.Length == 0 || t.Length == 0)
//            {
//                return "";
//            }

//            Dictionary<Char, int> dictT = new Dictionary<char, int>();

//            for (int i = 0; i < t.Length; i++)
//            {
//                int count = dictT.GetValueOrDefault(t[i], 0);
//                dictT.Add(t[i], count + 1);
//            }

//            int required = dictT.Count();

//            // Filter all the characters from s into a new list along with their index.
//            // The filtering criteria is that the character should be present in t.
//            List<Dictionary<int, char>> filteredS = new List<Dictionary<int, char>>();
//            for (int i = 0; i < s.Length; i++)
//            {
//                char c = s[i];
//                if (dictT.ContainsKey(c))
//                {
//                    filteredS.Add(new Dictionary<int, char> { { i, c } });
//                }
//            }

//            int l = 0, r = 0, formed = 0;
//            Dictionary<char, int> windowCounts = new Dictionary<char, int>();
//            int[] ans = { -1, 0, 0 };

//            // Look for the characters only in the filtered list instead of entire s.
//            // This helps to reduce our search.
//            // Hence, we follow the sliding window approach on as small list.
//            while (r < filteredS.Count())
//            {
//                char c = filteredS[r][r];
//                int count = windowCounts.GetValueOrDefault(c, 0);
//                windowCounts.Add(c, count + 1);

//                if (dictT.ContainsKey(c) && windowCounts.GetValueOrDefault(c) == dictT.GetValueOrDefault(c))
//                {
//                    formed++;
//                }

//                // Try and contract the window till the point where it ceases to be 'desirable'.
//                while (l <= r && formed == required)
//                {
//                    c = filteredS.get(l).getValue();

//                    // Save the smallest window until now.
//                    int end = filteredS.get(r).getKey();
//                    int start = filteredS.get(l).getKey();
//                    if (ans[0] == -1 || end - start + 1 < ans[0])
//                    {
//                        ans[0] = end - start + 1;
//                        ans[1] = start;
//                        ans[2] = end;
//                    }

//                    windowCounts.Add(c, windowCounts.GetValueOrDefault(c) - 1);
//                    if (dictT.ContainsKey(c) && windowCounts.GetValueOrDefault(c) < dictT.GetValueOrDefault(c))
//                    {
//                        formed--;
//                    }
//                    l++;
//                }
//                r++;
//            }
//            return ans[0] == -1 ? "" : s.Substring(ans[1], ans[2] + 1);
//        }

//        public static void Test()
//        {
//            minWindow("ADOBECODEBANC","ABC");
//        }
//    }
//}
