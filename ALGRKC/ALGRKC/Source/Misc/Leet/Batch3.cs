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
            if(nodeLeft>1)
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
            while(diff!=0)
            {
                if ((diff & 1) != 0)
                    result++;
                diff =diff >> 1;
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
            while(curChild<g.Length && curCookie<s.Length)
            {
                while ((curCookie < s.Length) &&(g[curChild] > s[curCookie]) )
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

            return Math.Max(0, target[0][0])+1;
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
                while(newArray[i]!=0)
                {
                    newArray[i]--;
                    if(bFirst)
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
    }
}
