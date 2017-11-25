using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Misc.Leet
{
    class Batch2
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
                    right = mid;
                    bHit = true;
                }
                else if (midVal > target)
                {
                    left = mid;
                    bHit = true;
                }
                else
                    bHit = false;
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
                        leftEnd = midEnd;
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
                        rightEnd = midEnd;
                    else
                        leftEnd = midEnd;
                }
                finalRight = rightEnd;

                
            }

            Console.WriteLine("The range is [" + finalLeft + " , " + finalRight + "]");

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

    }
}
