using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Misc.Leet
{
    public class Batch2
    {

        //Leetcode #34 Search for a Range.
        //Given an array of integers sorted in ascending order, find the starting and ending position of a given target value.
        //Your algorithm's runtime complexity must be in the order of O(log n).
        //If the target is not found in the array, return [-1, -1].
        //For example,
        // Given[5, 7, 7, 8, 8, 10] and target value 8,
        // return [3, 4]. 
        public static void FindRange(int[] org, int target)
        {
            int left = 0, right = org.Length - 1, mid=(left + right) / 2; ;
            bool bHit = false; ;
            int midVal;
            while((left<right) && !bHit)
            {
                mid = (left + right) / 2;
                midVal = org[mid];
                if (midVal < target)
                {
                    left = mid;
         
                }
                else if (midVal > target)
                {
                    right = mid;
                    
                }
                else
                    bHit = true;
            }

            int finalLeft=-1, finalRight=-1;
            if (bHit)// we found the mid that hit target, now need to find the left end and right end to form the range
            {
                
                int leftEnd = left, rightEnd = mid, midEnd;
                //first find the left end between mid and left
                while((org[leftEnd] <target)&&(leftEnd<rightEnd))
                {
                    midEnd = (leftEnd + rightEnd) / 2;
                    if (org[midEnd] < target)
                    {
                        if (leftEnd != midEnd)
                            leftEnd = midEnd;
                        else //leftend==midend means check ends here, righEnd is the left most item equals the target
                            leftEnd = rightEnd;
                    }
                    else
                        rightEnd = midEnd;
                }
                finalLeft = leftEnd;

                //second find the right end between mid and right
                leftEnd = mid;
                rightEnd = right;
                while ((org[rightEnd] > target) && (leftEnd < rightEnd))
                {
                    midEnd = (leftEnd + rightEnd) / 2;
                    if (org[midEnd] > target)
                    {
                        rightEnd = midEnd;
                    }
                    else
                    {
                        if (midEnd != leftEnd)
                            leftEnd = midEnd;
                        else//leftend==midend means check ends here, leftEnd is the right most item equals the target
                            rightEnd = leftEnd;

                     
                    }
                }
                finalRight = rightEnd;

                
            }

            Console.WriteLine("The range is [" + finalLeft + " , " + finalRight + "]");

        }


        //this is the 2nd FindRange method that is simpler
        public static void FindRange2(int[] org, int target)
        {
            //leverage the helper function FindExtreme to find left/right bound
            //we will call FindExtreme twice, each costs lgN

            int leftBound = -1, rightBound = -1;

            leftBound = FindExtreme(org, 0, org.Length, target, true);

            if (leftBound < 0 || org[leftBound] != target)
                throw new Exception("no hit");

            rightBound = FindExtreme(org, 0, org.Length, target, false)-1;

        }

        private static int FindExtreme(int[] org, int low, int high, int target, bool bForLEft)
        {
            int mid;
            while(low<=high)
            {
                mid = (low + high) / 2;
                if ((org[mid] > target) || ((org[mid]==target) && bForLEft))
                    high = mid ;
                else
                    low = mid+1;

            }

            return low;
        }

        //#leetcode #49 Group Anagrams
        //Given an array of strings, group anagrams together.

        //For example, given: ["eat", "tea", "tan", "ate", "nat", "bat"], 
        // Return: 
        //[
        //  ["ate", "eat","tea"],
        //  ["nat","tan"],
        //  ["bat"]
        //]
        public Dictionary<int,IList<string>> GroupAnagrams(string[] strs)
        {
            //assuming there is 26 characters with lower case to simplify the case.
            //if the lengh of the string is short (say <=5), we use prime number.
            //the complexity is O(KN), k is the max lengh of string, N is the number of the strings

            int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103 };
            HashSet<int> hash = new HashSet<int>();
            Dictionary<int, IList<string>> dict = new Dictionary<int, IList<string>>();

            int currentKey;
            for(int i=0;i<strs.Length;i++)
            {
                currentKey = 1;
                for (int j=0;j<strs[i].Length;j++)
                {
                    currentKey *= primes[strs[i][j] - 'a'];
                }
                if (!dict.ContainsKey(currentKey))
                {
                    IList<string> list = new List<string>();
                    list.Add(strs[i]);
                    dict.Add(currentKey, list);
                }
                else
                    dict[currentKey].Add(strs[i]);
                
            }
            return dict;

        }

        //LeetCode 55
        //Jump Games
        //Given an array of non-negative integers, you are initially positioned at the first index of the array.
        //Each element in the array represents your maximum jump length at that position. 
        //Determine if you are able to reach the last index. 
        //For example:
        //A = [2, 3, 1, 1, 4], return true. 
        //A = [3, 2, 1, 0, 4], return false. 
        public bool CanJump(int[] nums)
        {
            int length = nums.Length;
           // bool[] bCanReach = new bool[length];
            //bCanReach[0] = true;
            int lastReachable = length - 1; // the key point is to record the lastreachable index at all time
            if (length == 1)
                return true;
            //loop from the last to the first
            for(int i=length-2;i>=0;i--)
            {
                if (nums[i] + i >=lastReachable)
                {
                    lastReachable = i;
                   

                }
                    
            }

            return lastReachable == 0;
        }

        //LeetCode 56
        //Merge Interval
        //Given a collection of intervals, merge all overlapping intervals.
        //For example,
        //Given[1, 3], [2,6], [8,10], [15,18],
        //return [1,6], [8,10], [15,18]. 
        //Idea: sorted the intervals on the open element of each interval, then merge.
        //Complexity O(NlgN)
        public IList<Interval> MergeInterval(Interval[] intervals )
        {
            IntervalComarator IC = new IntervalComarator();
            Array.Sort<Interval>(intervals, IC);

            List<Interval> list = new List<Interval>();
            Interval current = list[0];
            if (intervals.Length > 1)
            {
                for (int i = 1; i < intervals.Length; i++)
                {
                    if (current.end >= intervals[i].start)//this is an overlap, we can expand the current
                        current.end = intervals[i].end;
                    else
                    {
                        list.Add(current);
                        current = intervals[i];
                    }
                }
            }
            list.Add(current);

            return list;

        }

        //LeetCode #64: Minimum path sum
        //Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.
        //Note: You can only move either down or right at any point in time.
        //Example 1:
        //[[1,3,1],
        // [1,5,1],
        // [4,2,1]]
        //Given the above grid map, return 7. Because the path 1→3→1→1→1 minimizes the sum. 
        //Idea: Dp. from bottom-right to the upper-left
        public int MinPathSum(int[,] grid)
        {
            int rowNumber = grid.GetLength(0), colNumber = grid.GetLength(1);
            int[,] path = new int[rowNumber, colNumber];

            //set the lower right corner
            path[rowNumber - 1, colNumber - 1] = grid[rowNumber - 1, colNumber - 1];

            //calculate the value of the last row
            for (int j = colNumber - 2; j >= 0; j--)
            {
                path[rowNumber - 1, j] = path[rowNumber - 1, j + 1] + grid[rowNumber - 1, j];
            }

            //calculate the value of the last column
            for (int i = rowNumber - 2; i >= 0; i--)
            {
                path[i, colNumber - 1] = path[i + 1, colNumber - 1] + grid[i + 1, colNumber - 1];
            }

            //now, we loop through from lower to upper and right to left
            for (int row = rowNumber - 2; row >= 0; row--)
                for (int col = colNumber - 2; col >= 0; col--)
                {
                    //compare the right and lower, and pick the smaller
                    if (path[row, col + 1] > path[row + 1, col])
                        path[row, col] = grid[row, col] + path[row + 1, col];
                    else
                        path[row, col] = grid[row, col] + path[row, col + 1];
                }

            return path[0, 0];
        }


    }

    public class IntervalComarator : IComparer<Interval>
    {
        public int Compare(Interval x, Interval y)
        {
            if ((x.start == y.start) && (x.end == y.end))
                return 0;

            if (x.start < y.start)
                return -1;

            if ((x.start > y.start) || ((x.start == y.start) && (x.end > y.end)))
                return 1;
            else
                return -1;
        }
    }
    public  class Interval
    {
        public int start, end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e)
        {
            start = s;
            end = e;

        }

    }

    
}
