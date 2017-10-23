using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Misc.Leet
{
    public class Batch1
    {

        //Leetcode #3
        //Given a string, find the length of the longest substring without repeating characters.
        //Examples:
        //Given "abcabcbb", the answer is "abc", which the length is 3.
        //Given "bbbbb", the answer is "b", with the length of 1.
        //Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
        public static int LengthOfLongestSubstring(string s)
        {
            int length = s.Length;

            int start = 0, end = -1, maxStart = 0, maxEnd = 0, tempStart = 0;
            int currentMax = 1;
            int[] visited = new int[26]; //we assume only the lower case character a-z is allowed, this is the hashtable, we can also use hashset here
            for (int i = 0; i < 26; i++)
                visited[i] = -1; //initialize to -1 , which means the character is not encounterd in the current slide window

            int index = -1;

            for (int i = 0; i < length; i++)
            {
                index = s[i] - 97;
                if (visited[index] == -1) //in the current slide window, the character being visisted has never been hit before. 
                                          //We can potentially allow the character the current character to be counted even if we hit it before 
                                          //as long as the last hit is before the current start. Later we just need to update the visited[index] to be the index of the last one visited. 
                {
                    visited[index] = i;
                    end++;

                }
                else// the ith elment has appeared before in the current range
                {
                    if (end - start + 1 > currentMax) //caculate the max and update max, start, end if needed. 
                    {
                        currentMax = end - start + 1;
                        maxStart = start;
                        maxEnd = end;

                    }
                    //now we need to do the clean up, 


                    tempStart = visited[index] + 1;

                    //1. reset the visisted to -1 from start to visted index. 
                    for (int j = start; j <= visited[index]; j++)
                        visited[s[j] - 97] = -1;

                    //2. reset start and i
                    start = tempStart;
                    end = i;

                    //3. update visited[index] to i;
                    visited[index] = i;

                }

            }

            if (end - start + 1 > currentMax) //caculate the max and update max, start, end if needed as this is the last window
            {
                currentMax = end - start + 1;
                maxStart = start;
                maxEnd = end;

            }

            return currentMax;
        }

        //Leetcode #3
        //This is a simplified version of LengthOfLongestSubstring
        //Given a string, find the length of the longest substring without repeating characters.
        //Examples:
        //Given "abcabcbb", the answer is "abc", which the length is 3.
        //Given "bbbbb", the answer is "b", with the length of 1.
        //Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
        public static int LengthOfLongestSubstring2(string s)
        {
            int length = s.Length;

            int currentStart = 0, currentEnd = -1, maxStart = 0, maxEnd = 0;
            int maxLength = 1;

            int[] visited = new int[256]; //we assume ascii 0-255
            for (int i = 0; i < 256; i++)
                visited[i] = -1; //initialize to -1 , which means the character is not encounterd in the current slide window

            int currentChar = -1;

            for(int i=0;i<length;i++)
            {
                currentChar = s[i];
                if( visited[currentChar]==-1 || visited[currentChar]<currentStart ) // either the currChar never hit or hit outside of the slidewindow
                {
                    currentEnd++;

                }
                else
                {
                    if (maxLength < currentEnd - currentStart + 1) // get the new Max
                    {
                        maxLength = currentEnd - currentStart + 1;
                        maxEnd = currentEnd;
                        maxStart = currentStart;
                    }

                    currentStart = visited[currentChar] + 1;
                    currentEnd = i;
                }
                //update the index where currentChar is hit
                visited[currentChar] = i;

            }

            if (maxLength < currentEnd - currentStart + 1) // get the new Max
            {
                maxLength = currentEnd - currentStart + 1;
                maxEnd = currentEnd;
                maxStart = currentStart;
            }

            return maxLength;

        }

        //Leetcode #5 
        //Longest Palindromic Substring 
        //Given a string s, find the longest palindromic substring in s.You may assume that the maximum length of s is 1000.
        //Example: 
        //Input: "babad"
        //Output: "bab"
        //Note: "aba" is also a valid answer.
        public static string LongestPalindrome(string s)
        {
            //Brute force method takes O(N^3). loop through(left bound, right bound), to each it takes O(N) to scan
            //Use dynamic programming.
            //IsPalindrome(i,j) = s[i]==s[j] && OsPalindrome(i+1,j+1);
            //loop through step from 2 to n-2; send loop is left from 0 to N, each takes O(1), so total cost is O(N^2)

            int length = s.Length;
            //corner case
            if (length <= 1)
                return s;
            if (length == 2)
                return s[0] == s[1] ? s : s.Substring(1);

            bool[, ] isPalindrome = new bool[length, length];

            int maxLengh = 1;
            int start = 0;

            //initialize the basic case
            for(int i=0;i<length-1;i++)
            {
                isPalindrome[i, i] = true;
                isPalindrome[i, i + 1] = s[i] == s[i + 1]?true:false;
                if(isPalindrome[i,i+1])
                {
                    maxLengh = 2;
                    start = i;
                }

            }
            isPalindrome[length - 1, length - 1] = true;

            //now handle the string with lengh of 3 or longer;
            for(int step=2;step<length; step++)
                for(int leftIndex=0;leftIndex<length-step;leftIndex++)
                {
                    isPalindrome[leftIndex, leftIndex + step] =
                        s[leftIndex] == s[leftIndex + step] && isPalindrome[leftIndex + 1, leftIndex + step - 1];
                    if(isPalindrome[leftIndex, leftIndex + step])
                    {
                        maxLengh = step + 1;
                        start = leftIndex;
                    }
                }

            return s.Substring(start, maxLengh);
        }
    }

}
