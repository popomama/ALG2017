using ALGRKC.Source.Basic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Misc.Leet
{
    public class Batch4
    {
        //Leetcode 102: Binary Tree Level Order Traversal
        //Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

        //For example:
        //Given binary tree[3, 9, 20, null, null, 15, 7],

        //    3
        //   / \
        //  9  20
        //    /  \
        //   15   7

        //return its level order traversal as:
        //[
        //  [3],
        //  [9,20],
        //  [15,7]
        //]

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> list = new List<IList<int>>();
            LevelOrder(root, list, 0);

            return (IList<IList<int>>)list;



        }

        private void LevelOrder(TreeNode nd, List<IList<int>> list, int level)
        {
            if (nd != null)
            {
                if (list.Count <= level)
                {
                    list.Add(new List<int>());
                    //                    list[level] = new List<int>();
                }
                list[level].Add(nd.val);
                if (nd.left != null)
                    LevelOrder(nd.left, list, level + 1);
                if (nd.right != null)
                    LevelOrder(nd.right, list, level + 1);
            }
            return;

        }

        //LeetCode 671. Second Minimium node in a Binary tree
        //Given a non-empty special binary tree consisting of nodes with the non-negative value, where each node in this tree has exactly two or zero sub-node. If the node has two sub-nodes, then this node's value is the smaller value among its two sub-nodes.
        //Given such a binary tree, you need to output the second minimum value in the set made of all the nodes' value in the whole tree.        //If no such second minimum value exists, output -1 instead.

        //Example 1:
        //Input: 
        //    2
        //   / \
        //  2   5
        //     / \
        //    5   7

        //Output: 5
        //Explanation: The smallest value is 2, the second smallest value is 5.

        //Example 2:
        //Input: 
        //    2
        //   / \
        //  2   2

        //Output: -1
        //Explanation: The smallest value is 2, but there isn't any second smallest value.

        public int FindSecondMinimumValue(TreeNode root)
        {
            int rootVal = root.val;
            int leftSecond, rightSecond;
            if (root.left == null)
                return -1;
            leftSecond = FindHelp(root.left, rootVal);
            rightSecond = FindHelp(root.right, rootVal);
            if ((leftSecond == rightSecond))
            {
                if (leftSecond == root.val)
                    return -1;
                else
                    return leftSecond;
            }
            else
            {
                if (Math.Min(leftSecond, rightSecond) == root.val)
                    return Math.Max(leftSecond, rightSecond);
                else
                    return Math.Min(leftSecond, rightSecond);
            }
        }

        private int FindHelp(TreeNode nd, int rootVal)
        {
            if (nd.left == null)
                return nd.val;

            if (nd.val > rootVal)
                return nd.val;

            int leftV = FindHelp(nd.left, rootVal);
            int rightV = FindHelp(nd.right, rootVal);
            if (Math.Min(leftV, rightV) == rootVal)
                return Math.Max(leftV, rightV);
            else
                return Math.Min(leftV, rightV);
        }

        int rootVal;
        int secondMin = Int32.MaxValue;
        public int FindSecondMinimumValue2(TreeNode root)
        {
            rootVal = root.val;

            //int left, right;
            //if (root.left != null)
            //     DFSS(root.left);
            //if (root.right != null)
            //    DFSS(root.right);

            DFSS(root);
            if (secondMin == rootVal)
                return -1;
            else if (root.left == null && root.right == null)
            {
                return -1;
            }
            else if (root.left.val == root.right.val && root.left.val == rootVal) //check if the 3 values are the same
            {
                return -1;
            }
            return secondMin;


        }

        private void DFSS(TreeNode nd)
        {
            if (nd == null)
                return;
            if (nd.val != rootVal && nd.val < secondMin)
            {
                secondMin = nd.val;
                return;
            }

            DFSS(nd.left);
            DFSS(nd.right);


        }

        //Leetcode 669 Trim Binary Search tree
        //Given a binary search tree and the lowest and highest boundaries as L and R, trim the tree so that all its elements lies in [L, R] (R >= L). You might need to change the root of the tree, so the result should return the new root of the trimmed binary search tree.
        //Example 1:
        //Input: 
        //    1
        //   / \
        //  0   2
        //  L = 1
        //  R = 2

        //Output: 
        //    1
        //      \
        //       2

        //        Example 2:
        //Input: 
        //    3
        //   / \
        //  0   4
        //   \
        //    2
        //   /
        //  1

        //  L = 1
        //  R = 3
        //Output: 
        //      3
        //     / 
        //   2   
        //  /
        // 1

        public TreeNode TrimBST(TreeNode root, int L, int R)
        {
            if (root == null)
                return null;

            if (root.val < L)
            {
                return TrimBST(root.right, L, R);
            }

            if (root.val > R)
            {
                return TrimBST(root.left, L, R);
            }

            root.left = TrimBST(root.left, L, R);
            root.right = TrimBST(root.right, L, R);

            return root;


        }


        //Leetcode 654 Maximum Binary Tree
        // Given an integer array with no duplicates. A maximum tree building on this array is defined as follow:

        // 1. The root is the maximum number in the array.
        // 2. The left subtree is the maximum tree constructed from left part subarray divided by the maximum number.
        // 3. The right subtree is the maximum tree constructed from right part subarray divided by the maximum number.

        //    Construct the maximum tree by the given array and output the root node of this tree.

        //    Example 1:

        //    Input: [3,2,1,6,0,5]
        //Output: return the tree root node representing the following tree:

        //      6
        //    /   \
        //   3     5
        //    \    / 
        //     2  0   
        //       \
        //        1

        //    Note: The size of the given array will be in the range [1,1000].
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            TreeNode root = ConstructMaximumBinaryTreeHelper(nums, 0, nums.Length - 1);
            return root;
        }

        private TreeNode ConstructMaximumBinaryTreeHelper(int[] nums, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex)
                return null;
            if (leftIndex == rightIndex)
                return new TreeNode(nums[leftIndex]);

            int tempMaxIndex = leftIndex;
            //find the max, O(N)
            for (int i = leftIndex + 1; i <= rightIndex; i++)
                if (nums[tempMaxIndex] < nums[i])
                    tempMaxIndex = i;

            TreeNode nd = new TreeNode(nums[tempMaxIndex]);
            nd.left = ConstructMaximumBinaryTreeHelper(nums, leftIndex, tempMaxIndex - 1);
            nd.right = ConstructMaximumBinaryTreeHelper(nums, tempMaxIndex + 1, rightIndex);
            return nd;
        }

        //LeetCode 79: Word Search
        //Given a 2D board and a word, find if the word exists in the grid.

        //The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring.The same letter cell may not be used more than once.

        //Example:

        //board =
        //[
        //  ['A','B','C','E'],
        //  ['S','F','C','S'],
        //  ['A','D','E','E']
        //]

        //Given word = "ABCCED", return true.
        //Given word = "SEE", return true.
        //Given word = "ABCB", return false.

        public bool Exist(char[][] board, string word)
        {
            bool bExist = false;
            bool[][] bChosen = new bool[board.Length][];
            for (int i = 0; i < board.Length; i++)
                bChosen[i] = new bool[board[0].Length];
            for (int i = 0; i < board.Length; i++)
                for (int j = 0; j < board[0].Length; j++)
                {
                    bExist = FindWord(board, word, bChosen, i, j, 0);
                    if (bExist)
                        return true;
                }

            return false;
        }

        private bool FindWord(char[][] board, string word, bool[][] bChosen, int row, int col, int startIndex)
        {
            bool bExist = false;
            if (board[row][col] == word[startIndex]) // find a match at this location
            {
                bChosen[row][col] = true;
                if (startIndex == word.Length - 1)// we find match of the whole word
                    return true;
                else //search the neighbor
                {
                    //startIndex++;

                    //1. left
                    if (col > 0 && bChosen[row][col - 1] == false)
                    {
                        bExist = FindWord(board, word, bChosen, row, col - 1, startIndex + 1);
                        if (bExist)
                            return true;
                    }
                    //2. right
                    if (col < board[0].Length - 1 && bChosen[row][col + 1] == false)
                    {
                        bExist = FindWord(board, word, bChosen, row, col + 1, startIndex + 1);
                        if (bExist)
                            return true;
                    }
                    //3. UP
                    if (row > 0 && bChosen[row - 1][col] == false)
                    {
                        bExist = FindWord(board, word, bChosen, row - 1, col, startIndex + 1);
                        if (bExist)
                            return true;
                    }

                    //4. DOWN
                    if (row < board.Length - 1 && bChosen[row + 1][col] == false)
                    {
                        bExist = FindWord(board, word, bChosen, row + 1, col, startIndex + 1);
                        if (bExist)
                            return true;
                    }



                }



                bChosen[row][col] = false;
                //startIndex--;
            }

            return false;


        }

        //Leetcode 153: Find Minimum in Rotated Sorted Array
        //Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

        //        (i.e.,  [0, 1, 2, 4, 5, 6, 7] might become[4, 5, 6, 7, 0, 1, 2]).

        //Find the minimum element.

        //You may assume no duplicate exists in the array.

        //Example 1:

        //Input: [3,4,5,1,2]
        //Output: 1

        //Example 2:

        //Input: [4,5,6,7,0,1,2]
        //Output: 0
        public int FindMin(int[] nums)
        {
            //int min = FindMinBinary(nums, 0, nums.Length - 1);
            //return min;

            int left = 0, right = nums.Length - 1;
            int mid;


            while (left < right - 1)
            {
                mid = (left + right) / 2;
                if (nums[mid] > nums[right])
                    left = mid + 1;
                else
                    right = mid;
            }

            if (left == right)
                return nums[left];
            else
                return Math.Min(nums[left], nums[right]);
        }

        //Leetcode 154: Find Minimum in Rotated Sorted Array II
        //Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

        //        (i.e.,  [0, 1, 2, 4, 5, 6, 7] might become[4, 5, 6, 7, 0, 1, 2]).

        //Find the minimum element.

        //The array may contain duplicates.

        //Example 1:

        //Input: [1,3,5]
        //Output: 1

        //Example 2:

        //Input: [2,2,2,0,1]
        //Output: 0
        public int FindMin2(int[] nums)
        {
            int min = FindMinBinary(nums, 0, nums.Length - 1);
            return min;
        }

        private int FindMinBinary(int[] nums, int left, int right)
        {
            int mid;
            while (left < right - 1)
            {
                mid = (left + right) / 2;
                if (nums[left] < nums[right])//non-descending
                    return nums[left];

                int leftMin = FindMinBinary(nums, left, mid);
                int rightMin = FindMinBinary(nums, mid + 1, right);

                return Math.Min(leftMin, rightMin);
                //else if(nums[left]>nums[right])
                //{
                //    if (nums[mid] < nums[right])
                //        right = mid;
                //    else if (nums[mid] > nums[right])
                //        left = mid + 1;
                //    else //left>mid=right
                //        right = mid;


                //}
                //else//nums[left]==nums[right]
                //{
                //    if (nums[mid] < nums[right])
                //        right = mid;
                //    else if (nums[mid] > nums[right])
                //        left = mid + 1;
                //    else //left=mid=right
                //    {
                //        int leftMin = FindMinBinary(nums, left, mid - 1);
                //        int rightMin = FindMinBinary(nums, mid + 1, right);

                //        return Math.Min(leftMin, rightMin);
                //    }
                //}
            }

            return Math.Min(nums[left], nums[right]);
        }


        //Leetcode 145: Binary Tree PostOrder Traversal
        //Given a binary tree, return the postorder traversal of its nodes' values.

        //        Example:

        //Input: [1,null,2,3]
        //   1
        //    \
        //     2
        //    /
        //   3

        //Output: [3,2,1]

        public IList<int> PostorderTraversal(TreeNode root)
        {
            TreeNode curr, ndLastAdded = null;// = root;
            List<int> list = new List<int>();
            if (root == null)
                return list;
            Stack<TreeNode> st = new Stack<TreeNode>();
            st.Push(root);
            while (st.Count != 0)
            {
                curr = st.Peek();
                if (curr.left == null && curr.right == null)
                {
                    list.Add(curr.val);
                    ndLastAdded = curr;
                    st.Pop();
                }
                //st.Push(curr);
                else if ((ndLastAdded != null) && (ndLastAdded == curr.left || ndLastAdded == curr.right))
                {
                    list.Add(curr.val);
                    ndLastAdded = curr;
                    st.Pop();
                }
                else
                {
                    if (curr.right != null)
                        st.Push(curr.right);
                    if (curr.left != null)
                        st.Push(curr.left);
                }
            }

            return list;
        }

        //LeetCode 51: N-Queens
        //Given an integer n, return all distinct solutions to the n-queens puzzle.

        //        Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space respectively.

        //Example:

        //Input: 4
        //Output: [
        // [".Q..",  // Solution 1
        //  "...Q",
        //  "Q...",
        //  "..Q."],

        // ["..Q.",  // Solution 2
        //  "Q...",
        //  "...Q",
        //  ".Q.."]
        //]
        //Explanation: There exist two distinct solutions to the 4-queens puzzle as shown above
        public IList<IList<string>> SolveNQueens(int n)
        {
            List<IList<string>> result = new List<IList<string>>();

            bool[] RowCheck = new bool[n];
            bool[] ColCheck = new bool[n];
            bool[] UpDiagCheck = new bool[2 * n + 1];
            bool[] DowndiagCheck = new bool[2 * n + 1];
            int[] solution = new int[n];
            NQueen(result, solution, 0, n, RowCheck, ColCheck, UpDiagCheck, DowndiagCheck);

            return result;



        }


        private void NQueen(List<IList<string>> result, int[] solution, int currentRow, int dim, bool[] rowCheck, bool[] colCheck, bool[] upDiagCheck, bool[] downdiagCheck)
        {
            if (currentRow == dim)//we found a solution, insert the current solution to the final result
            {
                //
                string temp = new string('.', dim);
                List<string> list = new List<string>(dim);
                for (int i = 0; i < dim; i++)
                {
                    StringBuilder sb = new StringBuilder(temp);
                    sb[solution[i]] = 'Q';
                    list.Add(sb.ToString());

                }

                result.Add(list);
                return;
            }

            for (int currentCol = 0; currentCol < dim; currentCol++)
            {
                if (!rowCheck[currentRow] && !colCheck[currentCol] && !upDiagCheck[currentCol + currentRow] && !downdiagCheck[currentRow - currentCol + dim - 1])
                {
                    solution[currentRow] = currentCol;
                    rowCheck[currentRow] = true;
                    colCheck[currentCol] = true;
                    upDiagCheck[currentCol + currentRow] = true;
                    downdiagCheck[currentRow - currentCol + dim - 1] = true;

                    NQueen(result, solution, currentRow + 1, dim, rowCheck, colCheck, upDiagCheck, downdiagCheck);

                    rowCheck[currentRow] = false;
                    colCheck[currentCol] = false;
                    upDiagCheck[currentCol + currentRow] = false;
                    downdiagCheck[currentRow - currentCol + dim - 1] = false;
                }

            }



        }

        //LeetCode 611: Valid Triangle Number
        //Given an array consists of non-negative integers, your task is to count the number of triplets chosen from the array that can make triangles if we take them as side lengths of a triangle.

        //        Example 1:

        //Input: [2,2,3,4]
        //        Output: 3
        //Explanation:
        //Valid combinations are: 
        //2,3,4 (using the first 2)
        //2,3,4 (using the second 2)
        //2,2,3

        //Note:

        //    The length of the given array won't exceed 1000.
        //    The integers in the given array are in the range of[0, 1000].
        public int TriangleNumber(int[] nums)
        {
            return 1;
        }

        //LeetCode 32 Longest Valid Parentheses
        //        Given a string containing just the characters '(' and ')', find the length of the longest valid(well-formed) parentheses substring.

        //Example 1:

        //Input: "(()"
        //Output: 2
        //Explanation: The longest valid parentheses substring is "()"


        //Example 2:


        //Input: ")()())"
        //Output: 4
        //Explanation: The longest valid parentheses substring is "()()"
        public int LongestValidParentheses(string s)
        {
            //idea: two parses
            int len = s.Length;
            int leftCount = 0, rightCount = 0;
            int maxLen = 0, currentLen = 0;

            for (int i = 0; i < len; i++) //loop through from left to right
            {
                if (s[i] == ')')
                {
                    if (leftCount <= rightCount)//INVALID now. reset everything 
                    {
                        currentLen = 0;
                        leftCount = 0;
                        rightCount = 0;
                    }
                    else
                    {
                        rightCount++;
                        if (leftCount == rightCount)
                        {
                            currentLen = leftCount;
                            if (currentLen > maxLen)
                                maxLen = currentLen;
                        }
                    }
                }
                else if (s[i] == '(')
                {
                    leftCount++;

                }

            }
            leftCount = 0; rightCount = 0; currentLen = 0; ;
            //int maxLen2 = 0;
            for (int i = len - 1; i >= 0; i--) //loop through right to left
            {
                if (s[i] == ')')
                {
                    rightCount++;
                }
                else if (s[i] == '(')
                {
                    if (rightCount == leftCount)//invalid case, reset
                    {
                        currentLen = 0;
                        leftCount = 0;
                        rightCount = 0;
                    }
                    else
                    {
                        leftCount++;
                        if (leftCount == rightCount)
                        {
                            currentLen = leftCount;
                            if (currentLen > maxLen)
                                maxLen = currentLen;
                        }
                    }

                }
            }

            return maxLen * 2;// < maxLen2 ? maxLen * 2 : maxLen2 * 2;
        }

        //use DP to solve the issue
        public int LongestValidParenthesesDP(string s)
        {
            //status transfer equation
            //assuming LP[N]= LongestValid substring that ends N and S[N] is used in the LP[N] otherwise we leave LP[N]=0
            //if(s[N]=='(') then Lp[N]=0
            //if(s[N]==')') then 
            //      if(S[N-1]=='(') then LP[N]=LP[N-2]+2
            //      else if(S[N-1]==')')
            //                  if(S[N-LP[N-1]-1] =='(') then LP[N]=LP[N-1]+2+ LP[N-LP[N-1]-1];
            //                  
            int len = s.Length;
            int[] LP = new int[len];
            for (int i = 0; i < len; i++)
                LP[i] = 0;
            int maxLP = 0;

            for (int i = 1; i < len; i++)
            {
                if (s[i] == ')')
                {
                    if (s[i - 1] == '(') // i-1,i pairs '()'
                    {
                        if (i > 1)
                            LP[i] = LP[i - 2] + 2;
                    }
                    else //s[i-1]=')', so i-1,i pairs '))'
                    {
                        if (i - 1 - LP[i - 1] >= 0)
                        {
                            if (LP[i - 1 - LP[i - 1]] == '(')
                            {
                                if (i - 1 - LP[i - 1] - 1 >= 0)
                                    LP[i] = LP[i - 1] + 2 + LP[i - 1 - LP[i - 1] - 1];
                                else
                                    LP[i] = LP[i - 1] + 2;
                            }
                        }
                    }

                    if (LP[i] > maxLP)
                        maxLP = LP[i];


                }

                //else if s[i]=='(', the substring ending i can't be a valid one 
            }
            return maxLP;
        }

        //LeetCode 268: Mising #
        //Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.

        //        Example 1:

        //Input: [3,0,1]
        //        Output: 2

        //Example 2:

        //Input: [9,6,4,2,3,5,7,0,1]
        //        Output: 8

        //    
        public int MissingNumber(int[] nums)
        {
            //idea use XOR
            int result=0;
            int len = nums.Length;
            for(int i=0;i<len;i++)
            {
                result ^= i;
                result ^= nums[i];
            }

            result ^= len;
            return result;
        }

        //#LeetCode 62: Unique Path
        //A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

        //        The robot can only move either down or right at any point in time.The robot is trying to reach the bottom-right corner of the grid(marked 'Finish' in the diagram below).

        //How many possible unique paths are there?


        //Above is a 7 x 3 grid.How many possible unique paths are there?

        //Note: m and n will be at most 100.

        //Example 1:

        //Input: m = 3, n = 2
        //Output: 3
        //Explanation:
        //From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
        //1. Right -> Right -> Down
        //2. Right -> Down -> Right
        //3. Down -> Right -> Right

        //Example 2:

        //Input: m = 7, n = 3
        //Output: 28
        public int UniquePaths(int m, int n)
        {
            int[,] result = new int[m,n];
            for (int i = 0; i < n ; i++)
                result[0, i] = 1;
            for (int i = 0; i < m ; i++)
                result[i, 0] = 1;

            for(int i=1;i<m;i++)
                for(int j=1;j<n;j++)
                {
                    result[i, j] = result[i - 1, j] + result[i, j - 1];
                }

            return result[m-1, n-1];
        }

        //Leet Code 121: Best time to buy and sell stock
        //Say you have an array for which the ith element is the price of a given stock on day i.

        //        If you were only permitted to complete at most one transaction(i.e., buy one and sell one share of the stock), design an algorithm to find the maximum profit.

        //       Note that you cannot sell a stock before you buy one.


        //       Example 1:


        //       Input: [7,1,5,3,6,4]
        //Output: 5
        //Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        //             Not 7-1 = 6, as selling price needs to be larger than buying price.

        //Example 2:

        //Input: [7,6,4,3,1]
        //        Output: 0
        //Explanation: In this case, no transaction is done, i.e.max profit = 0
        public int MaxProfit(int[] prices)
        {
            if (prices.Length < 2)
                return 0;

            int profit = 0;
            int currProfit;
            int currMin = prices[0];
           
            for(int i=1;i<prices.Length;i++)
            {
                if (currMin > prices[i])
                    currMin = prices[i];
                else
                {
                    currProfit = (prices[i] - currMin);
                    if (currProfit > profit)
                        profit = currProfit;
                }
               

            }

            return profit;
        }

        //Leet Code 309: Best time to buy stock with Cool Down.
        //Say you have an array for which the ith element is the price of a given stock on day i.
        //        Design an algorithm to find the maximum profit.You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:

        //    You may not engage in multiple transactions at the same time(ie, you must sell the stock before you buy again).
        //    After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)

        //Example:

        //Input: [1,2,3,0,2]
        //        Output: 3 
        //Explanation: transactions = [buy, sell, cooldown, buy, sell]
        public int MaxProfitCD(int[] prices)
        {
            return 1;
        }


        //LeetCode :646. Maximum Length of Pair Chain
        // You are given n pairs of numbers. In every pair, the first number is always smaller than the second number.
        //        Now, we define a pair(c, d) can follow another pair(a, b) if and only if b<c.Chain of pairs can be formed in this fashion.
        //      Given a set of pairs, find the length longest chain which can be formed.You needn't use up all the given pairs. You can select pairs in any order.
        //      Example 1:
        //      Input: [[1, 2], [2,3], [3,4]]
        //Output: 2
        //Explanation: The longest chain is [1,2] -> [3,4]
        //        Note:
        //    The number of given pairs will be in the range[1, 1000].
        public int FindLongestChain(int[][] pairs)
        {
            int pairNumber = pairs.Length;
            Tuple<int, int>[] p = new Tuple<int, int>[pairNumber];
            for (int i = 0; i < pairNumber; i++)
                p[i] = new Tuple<int, int>(pairs[i][0], pairs[i][1]);
            IComparer< Tuple<int, int>> comp = new TupleComparer();
            Array.Sort(p, comp); // sort the pair by first dimension

//            int maxChain = 1;
            int[] dp = new int[pairNumber];
            dp[0] = 1;

            for (int i = 1; i < pairNumber; i++)
            {
                dp[i] = dp[i-1];  // we guarantee that dp[i] is non-decreasing

                for (int j = i - 1; j >= 0; j--)
                {
                    if (p[i].Item1 > p[j].Item2)
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                        j = -1;
                    }
                }
            }
            return dp[pairNumber - 1];
        }
        public int FindLongestChainGreedy(int[][] pairs)
        {
            int pairNumber = pairs.Length;
            Tuple<int, int>[] p = new Tuple<int, int>[pairNumber];
            for (int i = 0; i < pairNumber; i++)
                p[i] = new Tuple<int, int>(pairs[i][0], pairs[i][1]);
            IComparer<Tuple<int, int>> comp = new TupleComparer2();
            Array.Sort(p, comp); // sort the pair by 2nd dimension
            int maxNum = 1;
            int last = p[0].Item2;

            for (int i = 1; i < pairNumber; i++)
            {
                if (p[i].Item1 > last)
                {
                    maxNum++;
                    last = p[i].Item2;
                }
            }
            return maxNum;
        }

    }

    public class TupleComparer : IComparer<Tuple<int,int>>
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        public int Compare(Tuple<int,int> x, Tuple<int,int> y)
        {
            if (x.Item1 == y.Item1)
            {
                if (x.Item2 == y.Item2)
                    return 0;
                else
                    return x.Item2 > y.Item2 ? 1 : -1;
            }
            else
                return x.Item1 > y.Item1 ? 1 : -1;

        }
    }

    public class TupleComparer2 : IComparer<Tuple<int, int>>
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        public int Compare(Tuple<int, int> x, Tuple<int, int> y)
        {

            if (x.Item2 > y.Item2)
                return 1;
            else if (x.Item2 < y.Item2)
                return -1;
            else
                return 0;
            //if (x.Item1 == y.Item1)
            //{
            //    if (x.Item2 == y.Item2)
            //        return 0;
            //    else
            //        return x.Item2 > y.Item2 ? 1 : -1;
            //}
            //else
            //    return x.Item1 > y.Item1 ? 1 : -1;

        }
    }

}
