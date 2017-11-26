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

    }
}
