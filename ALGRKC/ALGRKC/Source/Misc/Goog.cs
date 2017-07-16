using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
