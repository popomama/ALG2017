using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALGRKC.Source.Basic;

namespace ALGRKC.Source.Misc.Leet
{
    public class Batch3
    {


        //894. All Possible Full Binary Trees
        //A full binary tree is a binary tree where each node has exactly 0 or 2 children.
        //Return a list of all possible full binary trees with N nodes.Each element of the answer is the root node of one possible tree.
        //Each node of each tree in the answer must have node.val = 0.
        //You may return the final list of trees in any order.
        public IList<TreeNode> AllPossibleFBT(int N)
        {
            if (N < 1)
                return null;

            TreeNode root = new TreeNode(0);

            IList<TreeNode> tList = new List<TreeNode>();

            BuildTree(tList, root, root, N - 1);

            return tList;
        }

        void BuildTree(IList<TreeNode> tList, TreeNode root, TreeNode parentNode, int nodeLeft)
        {
            if (nodeLeft == 0)
                tList.Add(root);
            TreeNode ndLeft = new TreeNode(0);
            parentNode.left = ndLeft;
            BuildTree(tList, root, ndLeft, nodeLeft - 1);

            TreeNode ndRight = new TreeNode(0);
            if (nodeLeft > 1)
            {
                parentNode.right = ndRight;
                BuildTree(tList, root, ndLeft, nodeLeft - 2);
            }

            parentNode.left = null;
            BuildTree(tList, root, ndRight, nodeLeft - 1);


        }



        //461. Hamming Distance
        //        The Hamming distance between two integers is the number of positions at which the corresponding bits are different.
        //Given two integers x and y, calculate the Hamming distance.
        //Note:
        //0 ≤ x, y< 2^31.

        //Example:
        //Input: x = 1, y = 4
        //Output: 2

        //Explanation:
        //1   (0 0 0 1)
        //4   (0 1 0 0)
        //       ↑   ↑
        //The above arrows point to positions where the corresponding bits are different.
        public int HammingDistance(int x, int y)
        {
            int diff = x ^ y;
            //int bit = 1;
            int result = 0;
            while (diff != 0)
            {
                if ((diff & 1) != 0)
                    result++;
                diff = diff >> 1;
            }
            return result;



        }

        //Leet 455
        //Assume you are an awesome parent and want to give your children some cookies.But, you should give each child at most one cookie.Each child i has a greed factor gi, which is the minimum size of a cookie that the child will be content with; and each cookie j has a size sj.If sj >= gi, we can assign the cookie j to the child i, and the child i will be content.Your goal is to maximize the number of your content children and output the maximum number.
        //Note:
        //You may assume the greed factor is always positive.
        //You cannot assign more than one cookie to one child.

        //Example 1:
        //Input: [1,2,3], [1,1]
        //Output: 1

        //Explanation: You have 3 children and 2 cookies.The greed factors of 3 children are 1, 2, 3. 
        //And even though you have 2 cookies, since their size is both 1, you could only make the child whose greed factor is 1 content.
        //You need to output 1.

        //Example 2:

        //Input: [1,2], [1,2,3]

        //Output: 2

        //Explanation: You have 2 children and 3 cookies.The greed factors of 2 children are 1, 2. 
        //You have 3 cookies and their sizes are big enough to gratify all of the children, 
        //You need to output 2.

        public int FindContentChildren(int[] g, int[] s)
        {

            //sort the greed array and cooie array
            Array.Sort(g);
            Array.Sort(s);

            int curChild = 0;
            int curCookie = 0;
            int numFound = 0;
            while (curChild < g.Length && curCookie < s.Length)
            {
                while ((curCookie < s.Length) && (g[curChild] > s[curCookie]))
                    curCookie++;

                if (curCookie < s.Length)//we found one
                {
                    numFound++;
                    curChild++;
                }


                curCookie++;
            }

            return numFound;
        }


        //leet 404: Sum of left leaves
        // Find the sum of all left leaves in a given binary tree.
        public int SumOfLeftLeaves(TreeNode root)
        {
            int sum = 0;
            if (root == null)
                return 0;
            if ((root.left != null) && (root.left.left == null) && (root.left.right == null))
            {
                sum = root.left.val + SumOfLeftLeaves(root.right);
            }
            else
                sum = SumOfLeftLeaves(root.left) + SumOfLeftLeaves(root.right);

            return sum;
        }


        //leet 174: Dungeon Game
        //consists of M x N rooms laid out in a 2D grid.Our valiant knight(K) was initially positioned in the top-left room and must fight his way through the dungeon to rescue the princess.
        //The knight has an initial health point represented by a positive integer.If at any point his health point drops to 0 or below, he dies immediately.
        //Some of the rooms are guarded by demons, so the knight loses health (negative integers) upon entering these rooms; other rooms are either empty(0's) or contain magic orbs that increase the knight's health (positive integers).
        //In order to reach the princess as quickly as possible, the knight decides to move only rightward or downward in each step.
        //Use DP: Cost: O(MN)
        public int CalculateMinimumHP(int[][] dungeon)
        {
            int rowNumber = dungeon.GetLength(0);
            int columnNumber = dungeon[0].Length;


            //method 1: add one more row and one more column to process uniformly
            //int[][] target = new int[rowNumber+1][];

            //for (int i = 0; i <= rowNumber; i++)
            //{
            //    target[i] = new int[columnNumber+1];

            //}

            //for (int i = 0; i <= rowNumber; i++)
            //    for (int j = 0; j <= columnNumber; j++)
            //        target[i][j] = Int32.MaxValue;
            //target[rowNumber][columnNumber - 1] = 0;
            //target[rowNumber - 1][columnNumber] = 0;

            //for (int i = rowNumber - 1; i >= 0; i--)
            //    for (int j = columnNumber - 1; j >= 0; j--)
            //    {
            //        target[i][j] = Math.Max(0, Math.Min(target[i + 1][j], target[i][j + 1]) - dungeon[i][j]);
            //    }

            //method 2: keep te original dimision, but process last row and last column as special case.
            int[][] target = new int[rowNumber][];

            for (int i = 0; i < rowNumber; i++)
            {
                target[i] = new int[columnNumber];

            }


            target[rowNumber - 1][columnNumber - 1] = Math.Max(0, -dungeon[rowNumber - 1][columnNumber - 1]);

            for (int i = rowNumber - 2; i >= 0; i--)
            {
                target[i][columnNumber - 1] = Math.Max(0, target[i + 1][columnNumber - 1] - dungeon[i][columnNumber - 1]);

            }

            for (int j = columnNumber - 2; j >= 0; j--)
                target[rowNumber - 1][j] = Math.Max(0, target[rowNumber - 1][j + 1] - dungeon[rowNumber - 1][j]);


            for (int i = rowNumber - 2; i >= 0; i--)
                for (int j = columnNumber - 2; j >= 0; j--)
                {
                    target[i][j] = Math.Max(0, Math.Min(target[i + 1][j], target[i][j + 1]) - dungeon[i][j]);
                }

            return Math.Max(0, target[0][0]) + 1;
        }

        //Leet 561 Array Partition
        // Given an array of 2n integers, your task is to group these integers into n pairs of integer, say(a1, b1), (a2, b2), ..., (an, bn) which makes sum of min(ai, bi) for all i from 1 to n as large as possible.

        //Example 1:

        //Input: [1,4,3,2]

        //        Output: 4
        //Explanation: n is 2, and the maximum sum of pairs is 4 = min(1, 2) + min(3, 4).
        //Note:
        //    n is a positive integer, which is in the range of[1, 10000].
        //    All the integers in the array will be in the range of[-10000, 10000].
        public int ArrayPairSum(int[] nums)
        {
            //Solution 1: sorting, and add up the 1,3,5,7...
            //Array.Sort(nums);
            //int sum = 0;
            //for(int i=0;i<nums.Length;i+=2)
            //{
            //    sum += nums[i];

            //}

            //solution2: use hashtable like look up to avoid sorting
            //this only shows the advantage if the n is bigger/close to 10000
            int nMax = 10000;
            int[] newArray = new int[nMax * 2 + 1];
            int sum = 0;
            for (int i = 0; i < newArray.Length; i++)
                newArray[i] = 0;

            for (int i = 0; i < nums.Length; i++)
                newArray[nums[i] + nMax]++;

            bool bFirst = true;
            for (int i = 0; i < newArray.Length; i++)
            {
                while (newArray[i] != 0)
                {
                    newArray[i]--;
                    if (bFirst)
                    {
                        sum += i - nMax;
                        bFirst = false;
                    }
                    else
                    {
                        //just skip since it's the send element of the pair
                        // we only set the bFirst to true;
                        bFirst = true;
                    }
                }
            }


            return sum;

        }


        //Leet 655 Print Binary Tree
        //Print a binary tree in an m*n 2D string array following these rules:

        //The row number m should be equal to the height of the given binary tree.
        //The column number n should always be an odd number.
        //The root node's value (in string format) should be put in the exactly middle of the first row it can be put. The column and the row where the root node belongs will separate the rest space into two parts (left-bottom part and right-bottom part). You should print the left subtree in the left-bottom part and print the right subtree in the right-bottom part. The left-bottom part and the right-bottom part should have the same size. Even if one subtree is none while the other is not, you don't need to print anything for the none subtree but still need to leave the space as large as that for the other subtree.However, if two subtrees are none, then you don't need to leave space for both of them.
        //Each unused space should contain an empty string "".
        //Print the subtrees following the same rules.
        public IList<IList<string>> PrintTree(TreeNode root)
        {
            int nHeight = TreeHeight(root);
            int nColumn = (int)Math.Pow(2, nHeight) - 1;

            //initialize the result matrix
            string[][] result = new string[nHeight][];
            for (int i = 0; i < nHeight; i++)
            {
                result[i] = new string[nColumn];
                for (int j = 0; j < nColumn; j++)
                    result[i][j] = "";
            }

            PrintTree(root, 0, 0, nColumn - 1, result);

            return result;


        }

        //helper function
        void PrintTree(TreeNode root, int level, int leftColumn, int rightColumn, string[][] result)
        {
            if (root == null)
                return;
            int mid = (leftColumn + rightColumn) / 2;
            result[level][mid] = root.val.ToString();

            //divide and conquer
            PrintTree(root.left, level + 1, leftColumn, mid - 1, result);
            PrintTree(root.right, level + 1, mid + 1, rightColumn, result);

        }

        int TreeHeight(TreeNode nd)
        {
            if (nd == null)
                return 0;

            else
            {
                return Math.Max(TreeHeight(nd.left), TreeHeight(nd.right)) + 1;
            }
        }

        //Leet Code 463: Island Perimeter
        //You are given a map in form of a two-dimensional integer grid where 1 represents land and 0 represents water.
        //Grid cells are connected horizontally/vertically (not diagonally). The grid is completely surrounded by water, and there is exactly one island (i.e., one or more connected land cells).
        //The island doesn't have "lakes" (water inside that isn't connected to the water around the island). One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100. Determine the perimeter of the island.
        //Example:

        //Input:
        //[[0,1,0,0],
        // [1,1,1,0],
        // [0,1,0,0],
        // [1,1,0,0]]

        //Output: 16
        public int IslandPerimeter(int[][] grid)
        {
            return 0;

        }

        //Leetcode: 637 Average of Levels in Binary Tree
        //Given a non-empty binary tree, return the average value of the nodes on each level in the form of an array.
        //Input:
        //    3
        //   / \
        //  9  20
        //    /  \
        //   15   7
        //Output: [3, 14.5, 11]
        //        Explanation:
        //The average value of nodes on level 0 is 3,  on level 1 is 14.5, and on level 2 is 11. Hence return [3, 14.5, 11].
        //We use BFS here, but can also use DFS to implment it via PreOrder/InOrder 
        public IList<double> AverageOfLevels(TreeNode root)
        {
            if (root == null)
                return null;
            List<double> list = new List<double>();

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            TreeNode currentNode;
            int currentNodeValue = 0, currentLevelNodeNumber = 1;
            while (q.Count > 0)
            {
                double currentSum = 0;
                int tempNodeNumber = currentLevelNodeNumber;
                int nextLevelNodeNumber = 0;
                while (tempNodeNumber > 0)
                {
                    currentNode = q.Dequeue();
                    currentNodeValue = currentNode.val;
                    currentSum += currentNodeValue;
                    tempNodeNumber--;
                    if (currentNode.left != null)
                    {
                        q.Enqueue(currentNode.left);
                        nextLevelNodeNumber++;
                    }
                    if (currentNode.right != null)
                    {
                        q.Enqueue(currentNode.right);
                        nextLevelNodeNumber++;
                    }


                }
                double currentAvg = currentSum / currentLevelNodeNumber;
                list.Add(currentAvg);
                currentLevelNodeNumber = nextLevelNodeNumber;

            }

            return list;
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }
        //Leetcode 141 Linked List Cycle
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return false;
            ListNode slow = head, fast = head.next;

            while (fast != slow)
            {
                if (fast.next == null || fast.next.next == null)
                    return false;
                slow = slow.next;
                fast = fast.next.next;
            }
            return true;

            //if (head == null || head.next == null)
            //    return false;
            //ListNode slow = head, fast = head;

            //while (fast != null)
            //{
            //    slow = slow.next;
            //    fast = fast.next;
            //    if (fast != null)
            //    {
            //        fast = fast.next;
            //    }
            //    else
            //        return true;

            //    if (slow == fast)
            //        return true;
            //}
            //return false;
        }

        //Leet code 112 Path Sum
        //Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.

        //Note: A leaf is a node with no children.

        //Example:

        //Given the below binary tree and sum = 22,

        //      5
        //     / \
        //    4   8
        //   /   / \
        //  11  13  4
        // /  \      \
        //7    2      1

        //return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.

        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;
            if (root.val == sum && root.left == null && root.right == null)
                return true;
            return (HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val));
        }

        //Leetcode 113 Path Sum II
        //Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.
        //Note: A leaf is a node with no children.

        //Example:

        //Given the below binary tree and sum = 22,

        //      5
        //     / \
        //    4   8
        //   /   / \
        //  11  13  4
        // /  \    / \
        //7    2  5   1

        //Return:

        //[
        //   [5,4,11,2],
        //   [5,8,4,5]
        //]
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            List<int> current = new List<int>();
            List<List<int>> lists = new List<List<int>>();
            if (root == null)
                return lists.ToList<IList<int>>();
            current.Add(root.val);
            PathSumHelper(root, sum - root.val, lists, current);

            return lists.ToList<IList<int>>();

        }

        private void PathSumHelper(TreeNode root, int sum, List<List<int>> lists, List<int> current)
        {
            if (root == null)
                return;

            if (root.left == null && root.right == null)
            {
                if (sum == 0)//we found one
                {
                    //current.Add(root.val);
                    lists.Add(current.ToList());
                    //current.RemoveAt(current.Count - 1);

                }
                else//go back
                    return;
            }

            if (root.left != null)
            {
                current.Add(root.left.val);
                PathSumHelper(root.left, sum - root.left.val, lists, current);
                current.RemoveAt(current.Count - 1);
                //current.RemoveAt(current.Remove(current.Count-1));

            }

            if (root.right != null)
            {
                current.Add(root.right.val);
                PathSumHelper(root.right, sum - root.right.val, lists, current);
                //current.RemoveAt(current.LastIndexOf(root.right.val));
                current.RemoveAt(current.Count - 1);
            }

        }

        //Leetcode 120: Triangle
        //Given a triangle, find the minimum path sum from top to bottom.Each step you may move to adjacent numbers on the row below.

        //For example, given the following triangle
        //[
        //     [2],
        //   [3,4],
        //  [6,5,7],
        // [4,1,8,3]
        //]

        //The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int level = triangle.Count;
            int[] currentSum = new int[level];
            if (level == 1)
                return triangle[0][0];
            for (int i = 0; i < level; i++)
                currentSum[i] = triangle[level - 1][i];
            for (int i = level - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                    currentSum[j] = Math.Min(currentSum[j], currentSum[j + 1]) + triangle[i][j];
            }

            return currentSum[0];
        }

        //Leetcode 53: Maximum subarray
        //Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum.

        //Example:
        //Input: [-2,1,-3,4,-1,2,1,-5,4],
        //Output: 6
        //Explanation: [4,-1,2,1] has the largest sum = 6.
        public int MaxSubArray(int[] nums)
        {
            int size = nums.Length;
            if (size == 1)
                return nums[0];

            int maxSum = nums[0];

            int currentSum = nums[0] > 0 ? nums[0] : 0; ;
            for (int i = 1; i < size; i++)
            {
                if (currentSum + nums[i] <= 0)
                {
                    currentSum = nums[i] > 0 ? nums[i] : 0;
                    if (maxSum < nums[i])
                        maxSum = nums[i];
                }
                else
                {
                    currentSum += nums[i];

                    if (currentSum > maxSum)
                        maxSum = currentSum;
                }


            }
            return maxSum;

        }

        public int MaxSubArray2(int[] nums)
        {
            int size = nums.Length;
            if (size == 1)
                return nums[0];

            int maxSum = nums[0];
            int currentSum = nums[0];

            //f[i] -- maxSubArray(0:i), f[i] is using i;
            //f[i]=f[i-1]>0?nums[i]+f[i-1]:nums[i]
            for (int i = 1; i < size; i++)
            {
                currentSum = currentSum > 0 ? currentSum + nums[i] : nums[i];
                if (currentSum > maxSum)
                    maxSum = currentSum;
            }

            return maxSum;

        }

        //Leetcode # 139 Word Break
        //Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, determine if s can be segmented into a space-separated sequence of one or more dictionary words.

        //Note:
        //    The same word in the dictionary may be reused multiple times in the segmentation.
        //    You may assume the dictionary does not contain duplicate words.
        //Example 1:
        //Input: s = "leetcode", wordDict = ["leet", "code"]
        //Output: true
        //Explanation: Return true because "leetcode" can be segmented as "leet code".

        //Example 2:
        //Input: s = "applepenapple", wordDict = ["apple", "pen"]
        //Output: true
        //Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
        //             Note that you are allowed to reuse a dictionary word.

        //Example 3:
        //Input: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
        //Output: false

        public bool WordBreak(string sIn, IList<string> wordDict)
        {


            Dictionary<string, bool> hs = new Dictionary<string, bool>();
            //HashSet<string> hs = new HashSet<string>(wordDict); // create an hash table
            hs.Add("", true);//add the empty string here


            return WordBreak(sIn, hs, wordDict);

        }

        public bool WordBreak(string sIn, Dictionary<string, bool> hs, IList<string> wordDict)
        {
            string stToBeProcessed, stLeft;


            if (hs.ContainsKey(sIn))
                return hs[sIn];

            if (wordDict.Contains(sIn))
            {
                hs.Add(sIn, true);
                return true;
            }



            for (int i = 0; i < sIn.Length; i++)
            {
                stToBeProcessed = sIn.Substring(0, i);
                stLeft = sIn.Substring(i);
                if (wordDict.Contains(stLeft) && WordBreak(stToBeProcessed, hs, wordDict)) // check the dictionary first to shortcircuit the logic and speed up the process
                {
                    hs.Add(sIn, true); //sIn is breakable and is added into the hash table
                    return true;
                }
            }

            hs.Add(sIn, false);
            return false;

        }

        //the following implemntation will run out of the space, see comments below.
        //public bool WordBreak(string sIn, IList<string> wordDict)
        //{

        //    string s = sIn;
        //    bool bContained = false;
        //    if (s.Length == 0)
        //        return true;
        //    for(int i=0;i<wordDict.Count;i++)
        //    {
        //        if (s.StartsWith(wordDict[i]))
        //            //this recurisve calls will run out of space if the string is ('a', 500) while dict contains 'a' only. 
        //            bContained = WordBreak(s.Substring(wordDict[i].Length), wordDict);
        //        if (bContained)
        //            return true;

        //    }

        //    return false;

        //}


        //Leetcode 140: WordBreak II
        //Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, add spaces in s to construct a sentence where each word is a valid dictionary word.Return all such possible sentences.

        //Note:
        //    The same word in the dictionary may be reused multiple times in the segmentation.
        //    You may assume the dictionary does not contain duplicate words.

        //Example 1:
        //Input:
        //s = "catsanddog"
        //wordDict = ["cat", "cats", "and", "sand", "dog"]
        //Output:
        //[
        //  "cats and dog",
        //  "cat sand dog"
        //]

        //Example 2:
        //Input:
        //s = "pineapplepenapple"
        //wordDict = ["apple", "pen", "applepen", "pine", "pineapple"]
        //Output:
        //[
        //  "pine apple pen apple",
        //  "pineapple pen apple",
        //  "pine applepen apple"
        //]
        //Explanation: Note that you are allowed to reuse a dictionary word.
        public IList<string> WordBreak2(string sIn, IList<string> wordDict)
        {
            Dictionary<string, bool> hs = new Dictionary<string, bool>();
            //HashSet<string> hs = new HashSet<string>(wordDict); // create an hash table
            hs.Add("", true);//add the empty string here


            return null;// WordBreak2(sIn, hs, wordDict);
        }

        public bool WordBreak2(string sIn, Dictionary<string, bool> hs, IList<string> wordDict)
        {
            string stToBeProcessed, stLeft;


            if (hs.ContainsKey(sIn))
                return hs[sIn];

            if (wordDict.Contains(sIn))
            {
                hs.Add(sIn, true);
                return true;
            }



            for (int i = 0; i < sIn.Length; i++)
            {
                stToBeProcessed = sIn.Substring(0, i);
                stLeft = sIn.Substring(i);
                if (wordDict.Contains(stLeft) && WordBreak(stToBeProcessed, hs, wordDict)) // check the dictionary first to shortcircuit the logic and speed up the process
                {
                    hs.Add(sIn, true); //sIn is breakable and is added into the hash table
                    return true;
                }
            }

            hs.Add(sIn, false);
            return false;

        }

        //LeetCode 110:Balance Binary Tree
        //Given a binary tree, determine if it is height-balanced.
        //For this problem, a height-balanced binary tree is defined as:
        //    a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;

            if ((Math.Abs(TreeHeight(root.left) - TreeHeight(root.right)) <= 1) && IsBalanced(root.left) && IsBalanced(root.right))
                return true;

            return false;
        }

        //this second method to avoid the duplicate calls to the heigh function by pass a reference so that we can both the height and bBalanced value in one call.
        //Complexity O(N)
        public bool IsBalanced2(TreeNode root)
        {
            if (root == null)
                return true;

            bool bBalanced = true;
            int height = TreeHeightB(root, ref bBalanced);

            return bBalanced;
            //if ((Math.Abs(TreeHeight(root.left) - TreeHeight(root.right)) <= 1) && IsBalanced(root.left) && IsBalanced(root.right))
            //    return true;

            //return false;
        }

        int TreeHeightB(TreeNode nd, ref bool bBalanced)
        {
            if ((nd == null) || !bBalanced)
                return 0;

            int lHeight = TreeHeightB(nd.left, ref bBalanced);
            int rHeight = TreeHeightB(nd.right, ref bBalanced);

            if (Math.Abs(lHeight - rHeight) > 1)
                bBalanced = false;

            return Math.Max(lHeight, rHeight) + 1;

        }

        //LeetCode 241: Different Ways to Add Parentheses
        //Given a string of numbers and operators, return all possible results from computing all the different possible ways to group numbers and operators.The valid operators are +, - and*.

        //Example 1:
        //Input: "2-1-1"
        //Output: [0, 2]
        //        Explanation: 
        //((2-1)-1) = 0 
        //(2-(1-1)) = 2

        //Example 2:
        //Input: "2*3-4*5"
        //Output: [-34, -14, -10, -10, 10]
        //        Explanation: 
        //(2*(3-(4*5))) = -34 
        //((2*3)-(4*5)) = -14 
        //((2*(3-4))*5) = -10 
        //(2*((3-4)*5)) = -10 
        //(((2*3)-4)*5) = 10
        Dictionary<string, IList<int>> memResult = new Dictionary<string, IList<int>>();
        public IList<int> DiffWaysToCompute(string input)
        {
            if (memResult.ContainsKey(input))
                return memResult[input];
            List<int> result = new List<int>();
            int len = input.Length;
            string first, second;
            for (int i = 0; i < len; i++)
            {
                if (input[i] == '+' || input[i] == '-' || input[i] == '*')
                {
                    first = input.Substring(0, i);
                    second = input.Substring(i + 1);
                    IList<int> firstResult= DiffWaysToCompute(first);
                    IList<int> secondResult = DiffWaysToCompute(second);

                    // IList<int> result;
                    Opera op = null ;

                    if (input[i] == '+')
                    {
                        op = Add;
                    }
                    if (input[i] == '-')
                    {
                        op = Sub;
                    }
                    if (input[i] == '*')
                    {
                        op = Mult;
                    }


                   
                    for (int k = 0; k < firstResult.Count; k++)
                        for (int j = 0; j < secondResult.Count; j++)
                        {
                            int temp = op(firstResult[k], secondResult[j]);
                            result.Add(temp);
                        }

                   // return result;

                }
            }
            if(result.Count==0)
                result.Add(Int32.Parse(input));
            memResult.Add(input, result);
            return result;


        }

        delegate int Opera(int a, int b);
        int Add(int a, int b)
        {
            return a + b;

        }
        int Sub(int a, int b)
        {
            return a - b;

        }
        int Mult(int a, int b)
        {
            return a * b;

        }


        //delegate IList<int> CartiOpera(IList<int> first, IList<int> second);
        //IList<int> CartiAdd(IList<int> first, IList<int> second)
        //{
        //    List<int> result = new List<int>();
        //    for(int i = 0;i<first.Count;i++)
        //        for(int j=0;j<second.Count;j++)
        //        {
        //            int temp = first[i] + second[j];
        //            result.Add(temp);
        //        }

        //    return result;
        //}
        //IList<int> CartiSub(IList<int> first, IList<int> second)
        //{

        //}
        //IList<int> CartiMulti(IList<int> first, IList<int> second)
        //{

        //}




    }

    




}
