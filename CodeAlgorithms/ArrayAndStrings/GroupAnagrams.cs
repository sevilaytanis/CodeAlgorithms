using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.ArrayAndStrings
{
    public static class GroupAnagrams
    {

        public static List<List<String>> groupAnagrams(String[] strs)
        {
            if (strs.Length == 0)
                return new List<List<string>>();

            Dictionary<String, List<string>> ans = new Dictionary<String, List<string>>();
            int[] count = new int[26];
            foreach (String s in strs)
            {
                // Arrays.fill(count, 0);
                count = new int[26];
                foreach (char c in s)
                    count[c - 'a']++;

                StringBuilder sb = new StringBuilder("");
                for (int i = 0; i < 26; i++)
                {
                    sb.Append('#');
                    sb.Append(count[i]);
                }
                String key = sb.ToString();
                if (!ans.ContainsKey(key)) 
                ans.Add(key, new List<string>());
                ans.GetValueOrDefault(key).Add(s);
            }
            return ans.Values.ToList();
        }

        public static void Test()
        {
            var result=groupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });

        }

    }
}
