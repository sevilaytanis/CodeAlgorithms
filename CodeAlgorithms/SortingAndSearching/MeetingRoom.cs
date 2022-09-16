using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.SortingAndSearching
{
    public static class MeetingRoom
    {
        public static int minMeetingRooms(int[,] intervals)
        {

            // Check for the base case. If there are no intervals, return 0
            if (intervals.Length == 0)
            {
                return 0;
            }

            int[] start = new int[intervals.Length];
            int[] end = new int[intervals.Length];

            for (int i = 0; i < intervals.Length/2; i++)
            {
                start[i] = intervals[i, 0];
                end[i] = intervals[i, 1];
            }

            Array.Sort(end);
            Array.Sort(start);
            
            // The two pointers in the algorithm: e_ptr and s_ptr.
            int startPointer = 0, endPointer = 0;

            // Variables to keep track of maximum number of rooms used.
            int usedRooms = 0;

            // Iterate over intervals.
            while (startPointer < intervals.Length)
            {

                // If there is a meeting that has ended by the time the meeting at `start_pointer` starts
                if (start[startPointer] >= end[endPointer])
                {
                    usedRooms -= 1;
                    endPointer += 1;
                }

                // We do this irrespective of whether a room frees up or not.
                // If a room got free, then this used_rooms += 1 wouldn't have any effect. used_rooms would
                // remain the same in that case. If no room was free, then this would increase used_rooms
                usedRooms += 1;
                startPointer += 1;

            }

            return usedRooms;
        }

        public static void Test()
        {

            var testData = new int[,] { { 0, 30}, { 5, 10}, { 15, 20 } };

            var result = minMeetingRooms(testData);

            Console.WriteLine(result);
        }
    }
}