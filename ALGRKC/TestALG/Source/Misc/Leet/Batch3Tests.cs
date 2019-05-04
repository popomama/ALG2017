using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALGRKC.Source.Misc.Leet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALGRKC.Source.Basic;

namespace ALGRKC.Source.Misc.Leet.Tests
{
    [TestClass()]
    public class Batch3Tests
    {
        [TestMethod()]
        public void HammingDistanceTest()
        {
            Batch3 b3 = new Batch3();
            int dist = b3.HammingDistance(1, 4);
        }

        [TestMethod()]
        public void FindContentChildrenTest()
        {
            Batch3 b3 = new Batch3();
            int[] g = { 10, 9, 8, 7 };
            int[] s = { 5, 6, 7, 8 };

            int nFound = b3.FindContentChildren(g, s);
        }

        [TestMethod()]
        public void CalculateMinimumHPTest()
        {
            int[][] d = new int[][] { new int[] { -2, -3, 3 }, new int[] { -5, -10, 1 }, new int[] { 10, 30, -5 } };
            Batch3 b3 = new Batch3();
            int result = b3.CalculateMinimumHP(d);
        }

        [TestMethod()]
        public void PrintTreeTest()
        {
            TreeNode nd = new TreeNode(1);
            TreeNode nd2 = new TreeNode(2), nd3 = new TreeNode(3);
            nd.left = nd2; nd.right = nd3;
            TreeNode nd4 = new TreeNode(4);
            nd2.right = nd4;

            Batch3 b3 = new Batch3();
            IList<IList<string>> PrintTreeResult = b3.PrintTree(nd);
        }

        [TestMethod()]
        public void MaxSubArrayTest()
        {
            int[] a = { -2, 3, 1, 3 };
            Batch3 b = new Batch3();
            int max = b.MaxSubArray(a);
        }

        [TestMethod()]
        public void WordBreakTest()
        {
            IList<string> dic = new List<string>();
            dic.Add("leet");
            dic.Add("code");
            string sIn = "leetcode";
            Batch3 b = new Batch3();
            bool breakable = b.WordBreak(sIn, dic);

        }
    }
}