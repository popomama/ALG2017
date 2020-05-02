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
            int result = 0;
            int len = nums.Length;
            for (int i = 0; i < len; i++)
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
            int[,] result = new int[m, n];
            for (int i = 0; i < n; i++)
                result[0, i] = 1;
            for (int i = 0; i < m; i++)
                result[i, 0] = 1;

            for (int i = 1; i < m; i++)
                for (int j = 1; j < n; j++)
                {
                    result[i, j] = result[i - 1, j] + result[i, j - 1];
                }

            return result[m - 1, n - 1];
        }


        //Leetcode 63
        //A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
        //The robot can only move either down or right at any point in time.The robot is trying to reach the bottom-right corner of the grid(marked 'Finish' in the diagram below).
        //Now consider if some obstacles are added to the grids.How many unique paths would there be?
        //An obstacle and empty space is marked as 1 and 0 respectively in the grid.
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {

            if (obstacleGrid[0][0] == 1)
                return 0;


            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;

            
            //int[][] result = new int[m][];
            int[,] result = new int[m, n];

            result[0, 0] = 1;

            for (int i = 1; i < m; i++)
            {
                if (obstacleGrid[i][0] == 1 || result[i - 1, 0] == 0)
                    result[i, 0] = 0;
                else
                    result[i, 0] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                if (obstacleGrid[0][i] == 1 || result[0, i - 1] ==0)
                    result[0, i] = 0;
                else
                    result[0, i] = 1;
            }




            for (int i=1;i<m;i++)
                for(int j=1;j<n;j++)
                {
                    if ((obstacleGrid[i][j] == 1) || ((result[i - 1, j] == 0) && (result[i, j - 1] == 0)))
                        result[i, j] = 0;
                    else
                        result[i, j] = result[i - 1, j] + result[i, j - 1];
                }

            return result[m - 1, n - 1];

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

            for (int i = 1; i < prices.Length; i++)
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
        // we have 3 states Wait, Bought and Sold state
        // wait -->  wait (via cooldown), or bought(via buy)    wait[i]=max(wait[i-1], sold[i-1])
        // Bought --> sold(via sell), or bought(via cooldown)   bought[i]= max(wait[i-1]-price[i-1], bought[i-1]) 
        // Sold --> wait(via cool down)                         sold[i] = bought[i-1]+price[i-1]          

        public int MaxProfitCD(int[] prices)
        {
            int length = prices.Length;

            //create 3 arrays, initialize to 0
            int[] bought = new int[length+1];
            int[] sold = new int[length+1];
            int[] wait = new int[length+1];
            wait[0] = sold[0] = 0;
            bought[0] = int.MinValue;

            for(int i=1;i<=length;i++)
            {
                // prices[i-1] really represents prince[i], it just shifts 1
                wait[i] = Math.Max(wait[i - 1], sold[i - 1]);
                bought[i] = Math.Max(wait[i - 1] - prices[i - 1], bought[i - 1]);
                sold[i] = bought[i - 1] + prices[i-1];

            }

            return Math.Max(sold[length], wait[length]);


        }


        //Leetcode 740 : Delete and Earn
        //Given an array nums of integers, you can perform operations on the array.
        //In each operation, you pick any nums[i] and delete it to earn nums[i] points.After, you must delete every element 
        //equal to nums[i] - 1 or nums[i] + 1
        //You start with 0 points.Return the maximum number of points you can earn by applying such operations.

        //Example 1:

        //Input: nums = [3, 4, 2]
        //        Output: 6
        //Explanation: 
        //Delete 4 to earn 4 points, consequently 3 is also deleted.
        //Then, delete 2 to earn 2 points. 6 total points are earned.

        //Example 2:
        //        Input: nums = [2, 2, 3, 3, 3, 4]
        //        Output: 9
        //Explanation: 
        //Delete 3 to earn 3 points, deleting both 2's and the 4.
        //Then, delete 3 again to earn 3 points, and 3 again to earn 3 points.
        //9 total points are earned.

        public int DeleteAndEarn(int[] nums)
        {
            int len = nums.Length;
            if (len ==0)
                return 0;

            int max = nums.Max();
            int min = nums.Min();

            int[] arr = new int[max - min+1];

            for (int i = 0; i < len; i++)
                arr[nums[i] - min] += nums[i];

            int dp1 = 0, dp2=arr[0];
            int temp;
            //now use robber skip to caculate the max points , see Leetcode 198 House Robber
            for(int i=1;i<max-min+1;i++)
            {
                temp  = Math.Max(dp1 + arr[i], dp2);
                dp1 = dp2;
                dp2 = temp;
            }

            return dp2;
        }

        //Note: The length of nums is at most 20000.
        //      Each element nums[i] is an integer in the range[1, 10000].


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
            IComparer<Tuple<int, int>> comp = new TupleComparer();
            Array.Sort(p, comp); // sort the pair by first dimension

            //            int maxChain = 1;
            int[] dp = new int[pairNumber];
            dp[0] = 1;

            for (int i = 1; i < pairNumber; i++)
            {
                dp[i] = dp[i - 1];  // we guarantee that dp[i] is non-decreasing

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

        //Knapsack problem:
        //A set of n items, where item i has weight w[i] and value[i], and a knapsack with capacity W.
        //Suppose to pick a few elements from the ne elements such that their weight is <= W  but the summed value is maximized
        public int Knapsack(int n, int capacity, int[] weight, int[] value)
        {
            //use DP
            int[,] R = new int[n + 1, capacity + 1];
            //initialization to 0
            for (int i = 0; i <= n; i++)
                for (int j = 0; j <= capacity; j++)
                    R[i, j] = 0;

            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= capacity; j++)
                {
                    if ((j - weight[i - 1]) < 0)
                        R[i, j] = R[i - 1, j];
                    else
                    {
                        if ((value[i - 1] + R[i - 1, j - weight[i - 1]]) > R[i - 1, j]) //take item i
                            R[i, j] = value[i - 1] + R[i - 1, j - weight[i - 1]];
                        else
                            R[i, j] = R[i - 1, j]; // don't take item i
                    }
                }

            return R[n, capacity];
        }

        //find the longest common substring of two strings a and b
        //complextity O(mn)
        public int LongestCommonString(string a, string b)
        {
            int lenA = a.Length;
            int lenB = b.Length;
            int[,] comm = new int[lenA + 1, lenB + 1];
            int maxLen = 0;
            for (int i = 0; i < lenB + 1; i++)
                comm[0, i] = 0;
            for (int j = 0; j < lenA + 1; j++)
                comm[j, 0] = 1;

            for (int i = 0; i < lenA; i++)
                for (int j = 0; j < lenB; j++)
                {
                    if (a[i] == b[j])
                    {
                        comm[i + 1, j + 1] = comm[i, j] + 1;
                        if (comm[i + 1, j + 1] > maxLen)
                            maxLen = comm[i + 1, j + 1];
                    }
                    else
                        comm[i + 1, j + 1] = 0;

                }

            return maxLen;

        }

        //find the longest common subsequence
        int LongestCommonSubsequence(string a, string b)
        {
            int lenA = a.Length;
            int lenB = b.Length;
            int[,] comm = new int[lenA + 1, lenB + 1];
            // int maxLen = 0;
            for (int i = 0; i < lenB + 1; i++)
                comm[0, i] = 0;
            for (int j = 0; j < lenA + 1; j++)
                comm[j, 0] = 1;

            for (int i = 0; i < lenA; i++)
                for (int j = 0; j < lenB; j++)
                {
                    if (a[i] == b[j])
                    {
                        comm[i + 1, j + 1] = comm[i, j] + 1;// Math.Max( comm[i, j] + 1, Math.Max(comm[i+1,j],comm[i,j+1]));

                    }
                    else
                    {
                        comm[i + 1, j + 1] = Math.Max(comm[i + 1, j], comm[i, j + 1]);
                    }
                }

            return comm[lenA, lenB];
        }

        //Leetcode 300: LongestIncreasingsubsequence
        //Given an unsorted array of integers, find the length of longest increasing subsequence.

        //Example:

        //Input: [10,9,2,5,3,7,101,18]
        //Output: 4 
        //Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4. 

        //Note:

        //    There may be more than one LIS combination, it is only necessary for you to return the length.
        //    Your algorithm should run in O(n2) complexity.

        //Follow up: Could you improve it to O(n log n) time complexity?

        public int LengthOfLIS(int[] nums)
        {
            int maxLen = 1;
            if (nums.Length <= 1)
                return nums.Length;
            //int currentMax = 1;
            int[] incNums = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                incNums[i] = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                //currentMax = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        incNums[i] = Math.Max(incNums[j] + 1, incNums[i]);
                    }
                }
            }

            for (int i = 0; i < nums.Length; i++)
                maxLen = Math.Max(incNums[i], maxLen);

            return maxLen;
        }

        //O(NlgN) 
        public int LengthOfLIS2(int[] nums)
        {
            int arrLen = nums.Length;
            if (arrLen <= 1)
                return arrLen;

            int[] arr = new int[arrLen];

            arr[0] = nums[0];
            int currentLen = 1;
            for (int i = 1; i < arrLen; i++)
            {

                if (nums[i] > arr[currentLen - 1])
                {
                    //append the current item to the last of the arr
                    arr[currentLen] = nums[i];
                    currentLen++;

                }
                else
                {
                    //need to find the replacement position
                    //BinarySearch:
                    //The index of the specified value in the specified array, if value is found; 
                    //otherwise, a negative number.If value is not found and value is less than one or more elements in array, 
                    //the negative number returned is the bitwise complement(-(index+1)) of the index of the first element that is larger than 
                    //value.If value is not found and value is greater than all elements in array, the negative number returned 
                    //is the bitwise complement of(the index of the last element plus 1). 
                    int index = Array.BinarySearch(arr, 0, currentLen, nums[i]);
                    if (index < 0)
                        arr[-(index + 1)] = nums[i];
                    // else

                }



            }

            return currentLen;


        }


        //332 Reconstruct Itinerary
        //Given a list of airline tickets represented by pairs of departure and arrival airports [from, to], reconstruct the itinerary in order. All of the tickets belong to a man who departs from JFK. Thus, the itinerary must begin with JFK.

        //    Note:

        //    If there are multiple valid itineraries, you should return the itinerary that has the smallest lexical order when read as a single string. For example, the itinerary["JFK", "LGA"] has a smaller lexical order than["JFK", "LGB"].
        //    All airports are represented by three capital letters(IATA code).
        //    You may assume all tickets form at least one valid itinerary.

        //Example 1:

        //Input: [["MUC", "LHR"], ["JFK", "MUC"], ["SFO", "SJC"], ["LHR", "SFO"]]
        //Output: ["JFK", "MUC", "LHR", "SFO", "SJC"]

        //    Example 2:

        //Input: [["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]]
        //Output: ["JFK","ATL","JFK","SFO","ATL","SFO"]
        //    Explanation: Another possible reconstruction is ["JFK","SFO","ATL","JFK","ATL","SFO"].
        //             But it is larger in lexical order.
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {

            if (tickets == null || tickets.Count == 0)
                return null; // there is no tickets

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();


            List<string> routes = new List<string>(tickets.Count); //record the routes

            for (int i = 0; i < tickets.Count; i++)
            {
                IList<string> pair = tickets[i];

                string source = pair[0];
                string dest = pair[1];

                if (!dict.ContainsKey(source))
                {
                    List<string> list = new List<string>();
                    list.Add(dest);
                    dict.Add(source, list);
                }
                else
                {
                    dict[source].Add(dest);
                }

            }

            //now sort the lists for each source
            foreach (List<string> list in dict.Values)
            {
                list.Sort();
            }


            string start = "JFK";

            DFSIter(start, dict, ref routes);

            routes.Reverse();

            return routes;
        }

        void DFSIter(string start, Dictionary<string, List<string>> dict, ref List<string> routes)
        {
            
            if(dict.ContainsKey(start))// if the tickets don't include this start, it means it's a destination only, so it has to be the last in the route
            {  
            List<string> destList = dict[start];

            string dest;

                while (destList.Count > 0)
                {
                    dest = destList[0];
                    destList.RemoveAt(0);

                    DFSIter(dest, dict, ref routes);

                }
            }

            routes.Add(start);



        }


        //Leetcode 451. sort Characters by frequency
        //Given a string, sort it in decreasing order based on the frequency of characters.

        //        Example 1:

        //Input:
        //"tree"

        //Output:
        //"eert"

        //Explanation:
        //'e' appears twice while 'r' and 't' both appear once.
        //So 'e' must appear before both 'r' and 't'. Therefore "eetr" is also a valid answer.
        public string FrequencySort(string s)
        {
            Dictionary<char,int> dict = new Dictionary<char, int>();


            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                    dict[s[i]]++;
                else
                    dict.Add(s[i], 1);
            }

            List<KeyValuePair<char, int>> l = new List<KeyValuePair<char, int>>();

           foreach(char key in dict.Keys)
            {
                l.Add(new KeyValuePair<char, int>(key, dict[key]));

            }

           //sort the pair
            l.Sort(valuePairComp);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < l.Count; i++)
                sb.Append(l[i].Key, l[i].Value);

            return sb.ToString();


        
        }

        static int valuePairComp(KeyValuePair<char, int> p1, KeyValuePair<char, int> p2)
        {
            if (p1.Value < p2.Value)
            {
                return 1;
            }
            if (p1.Value > p2.Value)
                return -1;

            return 0;
        }

    }





    //676. Implement Magic Dictionary
    //        Implement a magic directory with buildDict, and search methods.
    //For the method buildDict, you'll be given a list of non-repetitive words to build a dictionary.
    //For the method search, you'll be given a word, and judge whether if you modify exactly one character 
    //into another character in this word, the modified word is in the dictionary you just built.
    //Example 1:
    //Input: buildDict(["hello", "leetcode"]), Output: Null
    //Input: search("hello"), Output: False
    //Input: search("hhllo"), Output: True
    //Input: search("hell"), Output: False
    //Input: search("leetcoded"), Output: False

    //Note:

    //    You may assume that all the inputs are consist of lowercase letters a-z.
    //    For contest purpose, the test data is rather small by now.You could think about highly efficient algorithm after 
    //    the contest.
    //    Please remember to RESET your class variables declared in class MagicDictionary, as static/class variables are 
    //    persisted across multiple test cases.Please see here for more details.
    public class MagicDictionary
    {
        
        /** Initialize your data structure here. */
        public MagicDictionary()
        {

        }

        /** Build a dictionary through a list of words */
        public void BuildDict(string[] dict)
        {

        }

        /** Returns if there is any word in the trie that equals to the given word after modifying exactly one character */
        public bool Search(string word)
        {
            return true;
        }
    }


    //leetcode 460: LFU Cache
    //    Design and implement a data structure for Least Frequently Used(LFU) cache.It should support the 
    //    following operations: get and put.

    //get(key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
    //put(key, value) - Set or insert the value if the key is not already present. When the cache reaches its capacity, 
    //it should invalidate the least frequently used item before inserting a new item.For the purpose of this problem, 
    //when there is a tie (i.e., two or more keys that have the same frequency), the least recently used key would be evicted.

    //Follow up:
    //Could you do both operations in O(1) time complexity?

    //Example:

    //LFUCache cache = new LFUCache( 2 /* capacity */ );

    //cache.put(1, 1);
    //cache.put(2, 2);
    //cache.get(1);       // returns 1
    //cache.put(3, 3);    // evicts key 2
    //cache.get(2);       // returns -1 (not found)
    //cache.get(3);       // returns 3.
    //cache.put(4, 4);    // evicts key 1.
    //cache.get(1);       // returns -1 (not found)
    //cache.get(3);       // returns 3
    //cache.get(4);       // returns 4
    public class LFUCache  //O(1) implementation
    {
        int capacity, minFrequency;
        Dictionary<int, CacheNode> dicKeyNode; //maps key and the value/frequency/location in the freqlist

        Dictionary<int, LinkedList<int>> dicKeyFrequencyList;  //maps frequency and the node(with key) in the corresponding frequency list

        public LFUCache(int capacity)
        {
            this.capacity = capacity ;
            dicKeyFrequencyList = new Dictionary<int, LinkedList<int>>();
            dicKeyNode = new Dictionary<int, CacheNode>();
        }

        public int Get(int key)
        {
            if(!dicKeyNode.ContainsKey(key)) //key doesn't exist
            {
                return -1;
            }

            CacheNode nd = dicKeyNode[key];
            int value = nd.value;
            int currFrequency = nd.frequency;
            LinkedList<int> orgFreqList = dicKeyFrequencyList[currFrequency];
            LinkedListNode<int> orgndInFrequencyList = nd.ndInFrequencyList;

            //remove from the original frequency list
            orgFreqList.Remove(orgndInFrequencyList);

            //adjust the minimum frequency if the orgFreqList becomes empty
            if ((currFrequency == minFrequency) && (orgFreqList.Count<1))
                minFrequency++;


            //increment frequency
            nd.frequency++;

            if (!dicKeyFrequencyList.ContainsKey(nd.frequency)) // if the new frequency list doesn't exist before, create a new list first
                dicKeyFrequencyList[nd.frequency] = new LinkedList<int>();

            //add the key into the new frequency list and get the node back(position for future removal purpose)
            LinkedListNode<int> ndFrequency =dicKeyFrequencyList[nd.frequency].AddFirst(key); 
            nd.ndInFrequencyList = ndFrequency;

            return value;


        }
        //        return 0;

        public void Put(int key, int value)
        {
            if (capacity == 0)
                return;
            if(dicKeyNode.ContainsKey(key)) // key exist, so only need to update the information
            {
                CacheNode nd = dicKeyNode[key];
                nd.value = value; // update the value
               // int value = nd.value;
                int currFrequency = nd.frequency;
                nd.frequency++;
                LinkedList<int> orgFreqList = dicKeyFrequencyList[currFrequency];
                LinkedListNode<int> orgndInFrequencyList = nd.ndInFrequencyList;

                //remove from the original frequency list
                orgFreqList.Remove(orgndInFrequencyList);
                if (orgFreqList.Count == 0)
                    minFrequency = nd.frequency;
                
                if (!dicKeyFrequencyList.ContainsKey(nd.frequency))
                    dicKeyFrequencyList[nd.frequency] = new LinkedList<int>();

                LinkedListNode<int> ndInNewFrequnecyList = dicKeyFrequencyList[nd.frequency].AddFirst(key);
                nd.ndInFrequencyList = ndInNewFrequnecyList;
                return;
            }
            else//key never exists
            { 
                if(capacity==dicKeyNode.Count) //if we reach capacity already
                {

                    LinkedListNode<int> ndEvicted = dicKeyFrequencyList[minFrequency].Last;
                    //remove the evicted node from the frequency list;
                    dicKeyFrequencyList[minFrequency].RemoveLast();

                    //remove the evicted key from dictionary
                    dicKeyNode.Remove(ndEvicted.Value);

                    CacheNode nd = new CacheNode(key, value, 1);
                    LinkedListNode<int> ndInNewFrequnecyList = dicKeyFrequencyList[nd.frequency].AddFirst(key);
                    nd.ndInFrequencyList = ndInNewFrequnecyList;

                    dicKeyNode.Add(key, nd);
                    minFrequency = 1;
                    return;


                }
                else // we still have room and just add the value
                {
                    CacheNode nd = new CacheNode(key, value, 1);
                    if (!dicKeyFrequencyList.ContainsKey(1)) // create a new frequency list if it doesn't exist 
                        dicKeyFrequencyList[1] = new LinkedList<int>();
                    LinkedListNode<int> ndInNewFrequnecyList = dicKeyFrequencyList[nd.frequency].AddFirst(key);
                    nd.ndInFrequencyList = ndInNewFrequnecyList;
                    
                    //add the key, node pair to the dictionary
                    dicKeyNode.Add(key, nd);

                    minFrequency = 1;
                    return;


                }


            }

        }
    }

    public class CacheNode
    {
        public int key;
        public int value;
        public int frequency;
        public LinkedListNode<int> ndInFrequencyList;
       

        public CacheNode(int key, int value, int frequency ) 
        {
            this.key = key;
            this.value = value;
            this.frequency = frequency;
        }
    }

    //Leetcode 146 LRU Cache

    //Design and implement a data structure for Least Recently Used(LRU) cache.It should support the following operations: get and put.

    //get(key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
    //put(key, value) - Set or insert the value if the key is not already present.When the cache reached its capacity, 
    //it should invalidate the least recently used item before inserting a new item.

    //The cache is initialized with a positive capacity.

    //Follow up:
    //Could you do both operations in O(1) time complexity?

    //Example:

    //LRUCache cache = new LRUCache(2 /* capacity */ );

    //cache.put(1, 1);
    //cache.put(2, 2);
    //cache.get(1);       // returns 1
    //cache.put(3, 3);    // evicts key 2
    //cache.get(2);       // returns -1 (not found)
    //cache.put(4, 4);    // evicts key 1
    //cache.get(1);       // returns -1 (not found)
    //cache.get(3);       // returns 3
    //cache.get(4);       // returns 4

    public class LRUCache
    {
        
        LinkedList<KeyValuePair<int,int>> list; // each node is a keyvalue pair consisting key value, and a linkedlist node that has value
        Dictionary<int,LinkedListNode<KeyValuePair<int,int>>> cache;
        int capacity;
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            cache = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>(capacity);
            list = new LinkedList<KeyValuePair<int, int>>();
        }

        public int Get(int key)
        {
            if (cache.ContainsKey(key))
            {
                //need to move the current key to the front of the linked list to mark it as the latest visited key
                LinkedListNode<KeyValuePair<int, int>> current = cache[key];
                list.Remove(current);
                list.AddFirst(current);
                return cache[key].Value.Value;
            }
            else
                return -1;
        }

        public void Put(int key, int value)
        {
            

            if (cache.ContainsKey(key))
            {
                LinkedListNode<KeyValuePair<int, int>> currentNode = cache[key];
                currentNode.Value = new KeyValuePair<int, int>(key, value); //reset the value
                list.Remove(currentNode);
                list.AddFirst(currentNode);
//                cache[key].Value = value;
            }
            else
            {
                if (cache.Count >= capacity) // the capacity is reached.
                {
                    //we need to remove the least used key from the linkedlist first
                    LinkedListNode<KeyValuePair<int, int>> lastNode = list.Last;
                    cache.Remove(lastNode.Value.Key); // remove the key from the list
                    list.RemoveLast();

                    KeyValuePair<int, int> keypair = new KeyValuePair<int, int>(key, value);   //new KeyValuePair<int, int>(key, value);
                    LinkedListNode<KeyValuePair<int, int>> newNode = new LinkedListNode<KeyValuePair<int, int>>(keypair);  // create the new node
                    //                        new LinkedListNode<int, KeyValuePair<int, int>>(key, keypair);
                    list.AddFirst(newNode); //add it to the front of the list, which means it is the latest visited key
                    cache.Add(key, newNode ); //add the key to the cache

                }
                else //it's still under capactiy, we can add the new values right away
                {
                    KeyValuePair<int, int> keypair = new KeyValuePair<int, int>(key, value);   //new KeyValuePair<int, int>(key, value);
                    LinkedListNode<KeyValuePair<int, int>> newNode = new LinkedListNode<KeyValuePair<int, int>>(keypair);  // create the new node
                    //                        new LinkedListNode<int, KeyValuePair<int, int>>(key, keypair);
                    list.AddFirst(newNode); //add it to the front of the list, which means it is the latest visited key
                    cache.Add(key, newNode); //add the key to the cache


                }

            }
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
