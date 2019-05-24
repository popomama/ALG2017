using ALGRKC.Source.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Misc.Leet
{
    class Batch4
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
    }
}
