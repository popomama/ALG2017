﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALGRKC.Source.Misc.Leet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ALGRKC.Source.Misc.Leet.Tests
{
    [TestClass()]
    public class Batch4Tests
    {


        [TestMethod()]
        public void FindMin2Test()
        {
            Batch4 b4 = new Batch4();
            int[] nums = { 2, 0, 1, 1, 1 };
            int min = b4.FindMin2(nums);
        }

        [TestMethod()]
        public void SolveNQueensTest()
        {
            Batch4 b4 = new Batch4();
            IList<IList<string>> result = b4.SolveNQueens(4);

        }

        [TestMethod()]
        public void LongestValidParenthesesTest()
        {
            Batch4 b4 = new Batch4();
            int l = b4.LongestValidParentheses("()(())");
        }

        [TestMethod()]
        public void FindLongestChainTest()
        {

            //[[-6,9],[1,6],[8,10],[-1,4],[-6,-2],[-9,8],[-5,3],[0,3]]
            Batch4 b4 = new Batch4();
            int[][] pairs = new int[][]
                    {
                        new int[] { -6, 9 },
                        new int[] { 1, 6 },
                        new int[] {  8,10},
                        new int[] {-1,4},
                        new int [] {-6,-2},
                        new int [] {-9,8},
                        new int [] {-5,3},
                        new int [] {0,3}



                    };
            b4.FindLongestChain(pairs);
        }

        [TestMethod()]
        public void KnapsackTest()
        {
            int[] weight = { 5, 4, 6, 7 };
            int[] value = { 10, 40, 30, 70 };

            Batch4 b4 = new Batch4();
            int max = b4.Knapsack(weight.Length, 9, weight, value);

        }

        [TestMethod()]
        public void LongestCommonStringTest()
        {
            string a = "zxabcdezy", b = "yzabcdezx";

            Batch4 b4 = new Batch4();
            int len = b4.LongestCommonString(a, b);
        }


        [TestMethod()]
        public void Test()
        {
            int[] arr = { 2, 4, 5, 6, 7 };
            int a = Array.BinarySearch(arr, 0, 5, 3);
        }



        [TestMethod()]
        public void LRUTest()
        {
            int i;
            LRUCache cache = new LRUCache(2);
            cache.Put(2, 1);
            cache.Put(1, 1);
            cache.Put(2, 3);
            cache.Put(4, 1);

            i = cache.Get(1);       // returns 1

            i = cache.Get(2);       // returns -1 (not found)
                                    //  cache.Put(4, 4);    // evicts key 1
                                    //i=  cache.Get(1);       // returns -1 (not found)
                                    //i=  cache.Get(3);       // returns 3
                                    //i=  cache.Get(4);       // returns 4


        }

        [TestMethod()]
        public void FindItineraryTest()
        {
            Batch4 b4 = new Batch4();

            //[["MUC","LHR"],["JFK","MUC"],["SFO","SJC"],["LHR","SFO"]]
            IList<IList<string>> tickets = new List<IList<string>>();
            List<string> tempList;
            tempList = new List<string>();
            tempList.Add("MUC");
            tempList.Add("LHR");
            tickets.Add(tempList);

            tempList = new List<string>();
            tempList.Add("JFK");
            tempList.Add("MUC");
            tickets.Add(tempList);

            tempList = new List<string>();
            tempList.Add("SFO");
            tempList.Add("SJC");
            tickets.Add(tempList);

            tempList = new List<string>();
            tempList.Add("LHR");
            tempList.Add("SFO");
            tickets.Add(tempList);

            IList<string> routes = b4.FindItinerary(tickets);

        }

        [TestMethod()]
        public void FrequencySortTest()
        {
            Batch4 b4 = new Batch4();

            string result = b4.FrequencySort("aDDbbbcAc");



        }

        [TestMethod()]
        public void LFUCacheTest()
        {
            //    ["LFUCache","put","put","get","put","get","get","put","get","get","get"]
            //      [[2],[1,1],[2,2],[1],[3,3],[2],[3],[4,4],[1],[3],[4]]

            int result;

            LFUCache lfuCache = new LFUCache(2);

            lfuCache.Put(1, 1);
            lfuCache.Put(2, 2);

            result = lfuCache.Get(1);

            lfuCache.Put(3, 3);
            result = lfuCache.Get(2);
            result = lfuCache.Get(3);

            lfuCache.Put(4, 4);

            result = lfuCache.Get(1);
            result = lfuCache.Get(3);
            result = lfuCache.Get(4);
            //result = lfuCache.Get(3);

            //    Test case 2:

            //    ["LFUCache","put","put","put","put","get"]
            //[[2],[3,1],[2,1],[2,2],[4,4],[2]]
            lfuCache = new LFUCache(2);

            lfuCache.Put(3, 1);
            lfuCache.Put(2, 1);
            lfuCache.Put(2, 2);
            lfuCache.Put(2, 4);

            result = lfuCache.Get(2);


        }

        [TestMethod()]
        public void UniquePathsWithObstaclesTest()
        {
            //[[0,0,0],[0,1,0],[0,0,0]]

            int[][] arr = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 0 }, new int[] { 0, 0, 0 } };

            Batch4 b4 = new Batch4();
            int nPaths = b4.UniquePathsWithObstacles(arr);

        }

        [TestMethod()]
        public void NumTilingsTest()
        {
            int n = 30;
            Batch4 b4 = new Batch4();
            int v = b4.NumTilings(30);
        }

        [TestMethod()]
        public void MinSwapTest()
        {
            int[] A = { 1, 3, 5, 4 };
            int[] B = { 1, 2, 3, 7 };
            Batch4 b4 = new Batch4();
            int num = b4.MinSwap(A, B);

        }

        [TestMethod()]
        public void FindNumberOfLISTest()
        {
            int[] a = { 1, 2, 4, 3, 5, 4, 7, 2 };
            Batch4 b4 = new Batch4();
            int result = b4.FindNumberOfLIS(a);
        }
    }
}