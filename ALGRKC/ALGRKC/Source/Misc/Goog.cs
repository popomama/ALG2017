using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALGRKC.Source.Sort;

namespace ALGRKC.Source.Misc
{
    public class Goog
    {
        //Design and implement an efficient program to find a contiguous subarray within 
        //a one-dimensional array of integers which has the largest sum.
        //Please note that there is at least one positive integer in the input array.
        public static int LargestSubArraySum(int[] arr)
        {
            int max = 0, currMax = 0;

            int currIndex = 0;
            // int temp;
            while (currIndex < arr.Length)
            {
                currMax = currMax + arr[currIndex];
                if (currMax < 0)
                {
                    currMax = 0;
                }
                else if (currMax > max)
                {
                    max = currMax;

                }
                currIndex++;


            }

            return max;
        }


        //Design and implement an efficient program to find a contiguous subarray within 
        //a one-dimensional array of integers which has the largest sum. It also finds the start/end index
        //Please note that there is at least one positive integer in the input array.
        public static Tuple<int, int, int> LargestSubArraySum2(int[] arr)
        {
            int max = 0, currMax = 0, startIndex = 0, endIndex = 0, currStart = 0;

            int currIndex = 0;
            // int temp;
            while (currIndex < arr.Length)
            {
                currMax = currMax + arr[currIndex];
                if (currMax < 0)
                {
                    currMax = 0;
                    currStart = currIndex + 1;
                }
                else if (currMax > max)
                {
                    max = currMax;
                    startIndex = currStart;
                    endIndex = currIndex;
                }
                currIndex++;


            }

            return new Tuple<int, int, int>(max, startIndex, endIndex);
        }

        //Find a sub-array whose sum is closest to zero rather than that with maximum sum. 
        //Please note that closest to zero doesn’t mean minimum sum
        //solution: The idea is to (1) calculate the sum of the prefix array
        //(2) order the sums 
        //(3) pick up the smallest difference of the two adjacent sums
        //Complexity is O(N)
        public static int SubArrayClosestToZero(int[] arr)
        {
            int[] prefixSum = new int[arr.Length];

            //calculate the prefix sum
            prefixSum[0] = arr[0];
            for(int i =1;i<arr.Length;i++)
            {
                prefixSum[i] = prefixSum[i - 1] + arr[i];
            }

            //sort the sums
            QuickSort qc = new QuickSort();
            qc.QC(prefixSum, 0, prefixSum.Length - 1);

            int min = Int32.MaxValue;
            int currDiff = 0;
            //find the min difference
            for(int i=1;i<prefixSum.Length;i++)
            {
                currDiff = (prefixSum[i] - prefixSum[i - 1]);
                if (currDiff < min)
                    min = currDiff;
            }

            return min;

        }
    }
}
