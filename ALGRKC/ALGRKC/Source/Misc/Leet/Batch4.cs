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
    }
}
