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

            for (int i = 0; i < length; i++)
            {
                currentChar = s[i];
                if (visited[currentChar] == -1 || visited[currentChar] < currentStart) // either the currChar never hit or hit outside of the slidewindow
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

            bool[,] isPalindrome = new bool[length, length];

            int maxLengh = 1;
            int start = 0;

            //initialize the basic case
            for (int i = 0; i < length - 1; i++)
            {
                isPalindrome[i, i] = true;
                isPalindrome[i, i + 1] = s[i] == s[i + 1] ? true : false;
                if (isPalindrome[i, i + 1])
                {
                    maxLengh = 2;
                    start = i;
                }

            }
            isPalindrome[length - 1, length - 1] = true;

            //now handle the string with lengh of 3 or longer;
            for (int step = 2; step < length; step++)
                for (int leftIndex = 0; leftIndex < length - step; leftIndex++)
                {
                    isPalindrome[leftIndex, leftIndex + step] =
                        s[leftIndex] == s[leftIndex + step] && isPalindrome[leftIndex + 1, leftIndex + step - 1];
                    if (isPalindrome[leftIndex, leftIndex + step])
                    {
                        maxLengh = step + 1;
                        start = leftIndex;
                    }
                }

            return s.Substring(start, maxLengh);
        }

        //Leet Code #10 -- Regular Expression Matching
        //'.' Matches any single character.
        //'*' Matches zero or more of the preceding element.
        //The matching should cover the entire input string (not partial).
        //The function prototype should be:
        //bool isMatch(const char* s, const char* p)
        //Some examples:
        //isMatch("aa","a") → false
        //isMatch("aa","aa") → true
        //isMatch("aaa","aa") → false
        //isMatch("aa", "a*") → true
        //isMatch("aa", ".*") → true
        //isMatch("ab", ".*") → true
        //isMatch("aab", "c*a*b") → true
        public static bool IsMatch(string s, string pattern)
        {
            //To Be implmented
            return false;
        }

        //Leet code #11 -- Container With Most Water 
        //Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate(i, ai). n vertical lines are drawn such that 
        //the two endpoints of line i is at(i, ai) and(i, 0). Find two lines, which together with x-axis forms a container, such that the container 
        //contains the most water. Note: You may not slant the container and n is at least 2. 
        public static int MaxArea(int[] height)
        {
            int left = 0, right = height.Length - 1; // set the left and right index;
            int maxArea = 0, currentArea = 0, currentHeight = 0;

            while (left < right)
            {
                currentHeight = height[left] > height[right] ? height[left] : height[right];

                currentArea = (right - left) * currentHeight;

                if (currentArea > maxArea)
                    maxArea = currentArea;

                if (height[left] > height[right])
                    right--;
                else
                    left++;
            }


            return maxArea;
        }


        //Largest Rectangular Area in a Histogram
        //Find the largest rectangular area possible in a given histogram where the largest rectangle can be made of a number 
        //of contiguous bars.For simplicity, assume that all bars have same width and the width is 1 unit.
        //For example, consider the following histogram with 7 bars of heights { 6, 2, 5, 4, 5, 1, 6}. The largest 
        //possible rectangle possible is 12 (see the below figure, the max area rectangle is highlighted in red)
        // The main function to find the maximum rectangular area under given
        // histogram with n bars
        public static int GetMaxArea(int[] hist)
        {
            int length = hist.Length;
            Stack<int> s = new Stack<int>(length);

            int currentIndex = 0;
            int topValue;
            int maxArea = 0, tempArea;

            while(currentIndex<length)
            {
                if(s.Count==0)
                {
                    s.Push(currentIndex);
                    currentIndex++;
                }
                else
                {
                    topValue = hist[s.Peek()];
                    if(topValue<hist[currentIndex]) //top value < currentValue, keep pushing
                    {
                        s.Push(currentIndex);
                        currentIndex++;
                    }
                    else //top value> current Value
                    {
                        s.Pop();
                        if (s.Count == 0)
                            tempArea = topValue * (currentIndex+1);
                        else
                            tempArea = topValue * (currentIndex - s.Peek() - 1);
                        if (tempArea > maxArea)
                            maxArea = tempArea;
                    }
                }
            }

            while(s.Count>0)//stack is not empty;
            {
                currentIndex = s.Pop();
                if(s.Count>0)
                {

                    tempArea = hist[currentIndex] * (length - s.Peek()-1);
                    if (maxArea < tempArea)
                        maxArea = tempArea;
                }
                else
                {
                    tempArea = hist[currentIndex] * length;
                }
            }
            return maxArea;

            

        }

        //LeetCode #19-- Remove the nth node in the list
        //Given a linked list, remove the nth node from the end of list and return its head.
        //For example,
        //   Given linked list: 1->2->3->4->5, and n = 2.
        //   After removing the second node from the end, the linked list becomes 1->2->3->5.
        //Note:
        //Given n will always be valid.
        //Try to do this in one pass.

       public static LinkedListNode<int> RemoveNthFromEnd(LinkedListNode<int> org, int n)
        {
            LinkedListNode<int> current = org;
            LinkedListNode<int> nthApart=org;

            for (int i = 0; i < n; i++)
                nthApart = nthApart.Next;

            //now current and nthApart are n-1th appart, move both until nthAppart to null
            
  
            while(nthApart!=null)
            {
               // nParent = nParent.Next;
                current = current.Next;
                nthApart = nthApart.Next;
            }

            //current.Next = current.Next.Next; // C# doesn't allow to modify the next node, but it should be set to null in order to remove it.
            return current;
        }

        //Leetcode #22 -- Generate parenthese
        //Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
        //For example, given n = 3, a solution set is:
        //[
        //  "((()))",
        //  "(()())",
        //  "(())()",
        //  "()(())",
        //  "()()()"
        //]
        public static void GenerateParenthese(int n)
        {
            //idea is to use recursive call
            //challenge is to avoid duplicates.
            //in order to avoid the conflict, we record the # of remaining left and right parenthesis 
            //we append left or right, but alway make sure the ramaining left is fewer than remaining right.
            char[] result = new char[2*n];
            //string s = new string()
            
            GenerateParHelp(result,0, n, n);

        }

        private static void GenerateParHelp(char[] result,int currentIndex, int leftRemaning, int rightRemaining)
        {
            if (leftRemaning == 0 && rightRemaining == 0)
            {
                string r = new string(result);
                Console.WriteLine(r);
            }
            if (rightRemaining < leftRemaning || leftRemaning < 0 || rightRemaining < 0 || currentIndex>result.Length-1)
                return;
            //first try the left
            result[currentIndex] = '(';
            GenerateParHelp(result, currentIndex + 1, leftRemaning - 1, rightRemaining);
            //second try the right
            result[currentIndex] = ')';
            GenerateParHelp(result, currentIndex + 1, leftRemaning, rightRemaining - 1);


        }

        //Leetode #23-- Merge K Sorted array
        //Merge k sorted linked lists and return it as one sorted list.Analyze and describe its complexity.
        public static List<int> MergeKSortedArray(List<int>[] orgList)
        {
            return null;
        }

        //Leetcode #31 -- Next Permutation.
        //Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.
        //If such arrangement is not possible, it must rearrange it as the lowest possible order(ie, sorted in ascending order).
        //The replacement must be in-place, do not allocate extra memory.
        //Here are some examples.Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
        //1,2,3 → 1,3,2
        //3,2,1 → 1,2,3
        //1,1,5 → 1,5,1
        //We use two passes, the complexity is O(N)
        public static int[] NextPermutation(int[] org)
        {
            int length = org.Length;
            //we need 2-passes here
            //first pass, scan from right to left, and find the first i where a[i-1]<a[i]
            int cur = length - 1;
            while ((cur >= 1) && (org[cur - 1] >= org[cur]))
                cur--;

            if (cur == 0) // the original array is an ascending array, so need to reverse the whole array to get the smallest
                reverseArray(org,0, length-1);

            //second pass, scan from the right to left and find the first i where a[i]>a[cur-1]
            int i = length - 1;
            while (org[i] <= org[cur - 1])
                i--;
            //now swap i and cur-1;
            swap(org, i, cur - 1);

            //last step, reverse the array from right until cur;
            reverseArray(org, cur, length - 1);
            return org;
        }

        private static void swap(int[] org, int i, int v)
        {
            int temp = org[i];
            org[i] = org[v];
            org[v] = temp;
        }

        private static void reverseArray(int[] org, int start, int end)
        {
            int i = start, j = end;
            while(i<j)
            {
                swap(org, i, j);
                i++;
                j--;
            }
        }

        //Leetcode #32 -- Longest valid Parenthese
        // Given a string containing just the characters '(' and ')', find the length of the longest valid(well-formed) parentheses substring.
        //For "(()", the longest valid parentheses substring is "()", which has length = 2.
        //Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.
        public static string LongestValidPar(string orgString)
        {
            return "";
        }
    }
}
