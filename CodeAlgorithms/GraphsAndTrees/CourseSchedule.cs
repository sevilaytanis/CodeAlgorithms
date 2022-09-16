using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.GraphsAndTrees
{
    public class Course_Schedule
    {

        public bool canFinish(int courses, int[][] pre)
        {
            //indegree
            //hashmap
            //queue

            if (pre == null || pre.Length == 0) return true;
            int[] indegree = new int[courses];
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

            for (int i = 0; i <= pre.Length; i++)
            {
                indegree[pre[i][0]]++;
                if (map.ContainsKey(pre[i][1]))
                {
                    List<int> cur = new List<int>();
                    cur.Add(pre[i][0]);
                    map.Add(pre[i][1], cur);

                }else
                {
                    map[pre[i][1]].Add(pre[i][0]);
                }
            }

            Queue<int> queue = new Queue<int>();
            for(int i= 0; i< indegree.Length; i++)
            {
                if(indegree[i]==0)
                {
                    queue.Enqueue(i);
                }

            }
            while(queue.Count>0)
            {
                int cur = queue.Dequeue();
                List<int> list = map[cur];

                for (int x = 0; x < list.Count; x++)
                {
                    indegree[list[x]]--;
                    if(indegree[list[x]]==0)
                    {
                        queue.Enqueue(indegree[list[x]]);
                    }

                }
            }

            foreach(int i in indegree)
            {
                if (i != 0)
                    return false;
            }

            return true;
        }
    }
}
