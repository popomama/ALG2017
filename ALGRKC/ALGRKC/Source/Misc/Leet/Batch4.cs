using ALGRKC.Source.Basic;
using System;
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

            return (IList <IList<int>>)list;



        }

        private void LevelOrder(TreeNode nd, List<IList<int>> list, int level)
        {
            if(nd!=null)
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
            else if(root.left==null && root.right==null)
            {
                return -1;
            }
            else if(root.left.val==root.right.val && root.left.val==rootVal) //check if the 3 values are the same
            {
                return -1;
            }
            return secondMin;


        }

        private void DFSS(TreeNode nd)
        {
            if (nd == null)
                return;
            if (nd.val!=rootVal && nd.val < secondMin)
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

            if(root.val <L)
            {
                return TrimBST(root.right, L, R);
            }

            if(root.val>R)
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

            int tempMaxIndex=leftIndex;
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
            for(int i=0;i<board.Length;i++)
                for(int j=0;j<board[0].Length;j++)
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
            if(board[row][col]==word[startIndex]) // find a match at this location
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
                    if (col < board[0].Length-1 && bChosen[row][col+1] == false)
                    {
                        bExist = FindWord(board, word, bChosen, row, col + 1, startIndex + 1);
                        if (bExist)
                            return true;
                    }
                    //3. UP
                    if (row > 0 && bChosen[row-1][col] == false)
                    {
                        bExist = FindWord(board, word, bChosen, row-1, col, startIndex + 1);
                        if (bExist)
                            return true;
                    }

                    //4. DOWN
                    if (row < board.Length-1 && bChosen[row +1][col] == false)
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

                int leftMin = FindMinBinary(nums, left, mid );
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
            TreeNode curr, ndLastAdded=null;// = root;
            List<int> list = new List<int>();
            if (root == null)
                return list;
            Stack<TreeNode> st = new Stack<TreeNode>();
            st.Push(root);
            while(st.Count!=0)
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

    }
}
