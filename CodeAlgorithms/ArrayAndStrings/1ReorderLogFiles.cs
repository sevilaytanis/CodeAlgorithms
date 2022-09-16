using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.ArrayAndStrings
{
    public static class _1ReorderLogFiles
    {
        public static String[] reorderLogFiles(String[] logs)
        {

            if (logs == null || logs.Length == 0) return logs;

            int len = logs.Length;
            List<String> letterList = new List<string>();
            List<String> digitList = new List<string>();
            foreach (String log in logs)
            {
                if (log.Split(" ")[1][0] < 'a')
                {
                    digitList.Add(log);
                }
                else
                {
                    letterList.Add(log);
                }
            }

            InsertionSort(letterList);
            InsertionSort(digitList);

            //compare(letterList[0], letterList[1]);
            //Collections.sort(letterList, (o1, o2)-> {
            //    String[] s1 = o1.split(" ");
            //    String[] s2 = o2.split(" ");
            //    int len1 = s1.Length;
            //    int len2 = s2.Length;
            //    for (int i = 1; i < Math.Min(len1, len2); i++)
            //    {
            //        if (!s1[i].Equals(s2[i]))
            //        {
            //            return s1[i].CompareTo(s2[i]);
            //        }
            //    }
            //    return s1[0].CompareTo(s2[0]);
            //});

            int count = 0;

            while (count < letterList.Count())
            {
                logs[count] = letterList[count];
                count++;
            }

            int i = 0;

            while (i < digitList.Count())
            {
                logs[count] = digitList[i];
                count++;
                i++;
            }

            return logs;

        }

        public static void InsertionSort(List<int> input)
        {
            for (int i = 0; i < input.Count(); i++)
            {
                var item = input[i];
                var currentIndex = i;
                while (currentIndex > 0 && input[currentIndex - 1] > item)
                {
                    input[currentIndex] = input[currentIndex - 1];
                    currentIndex--;
                }
                input[currentIndex] = item;
            }
        }

        public static void InsertionSort(List<string> input)
        {
            for (int i = 0; i < input.Count(); i++)
            {
                var item = input[i];
                var currentIndex = i;
                while (currentIndex > 0 && input[currentIndex - 1].CompareTo(item) < 0)
                {
                    input[currentIndex] = input[currentIndex - 1];
                    currentIndex--;
                }
                input[currentIndex] = item;
            }
        }

        public static int compare(String log1, String log2)
        {
            // split each log into two parts: <identifier, content>
            String[] split1 = log1.Split(" ", 2);
            String[] split2 = log2.Split(" ", 2);

            bool isDigit1 = Char.IsDigit(split1[1][0]);
            bool isDigit2 = Char.IsDigit(split2[1][0]);

            // case 1). both logs are letter-logs
            if (!isDigit1 && !isDigit2)
            {
                // first compare the content
                int cmp = split1[1].CompareTo(split2[1]);
                if (cmp != 0)
                    return cmp;
                // logs of same content, compare the identifiers
                return split1[0].CompareTo(split2[0]);
            }

            // case 2). one of logs is digit-log
            if (!isDigit1 && isDigit2)
                // the letter-log comes before digit-logs
                return -1;
            else if (isDigit1 && !isDigit2)
                return 1;
            else
                // case 3). both logs are digit-log
                return 0;
        }

        public static void Test()
        {

            var testData = new String[] {  "dig1 8 1 5 1", "let1 art can", "let3 art zero" ,"dig2 3 6", "let2 own kit dig"};

            var result = reorderLogFiles(testData);
        }

    }
}


