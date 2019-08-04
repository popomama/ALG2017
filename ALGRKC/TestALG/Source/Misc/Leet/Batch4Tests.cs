using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        int len=            b4.LongestCommonString(a, b);
        }


        [TestMethod()]
        public void Test()
        {
            int[] arr = { 2, 4, 5, 6,7 };
           int a = Array.BinarySearch(arr, 0,5, 3);
        }



        [TestMethod()]
        public void LRUTest()
        {
            int i;
            LRUCache cache = new LRUCache(2);
            cache.Put(2, 1);
            cache.Put(1,1);
            cache.Put(2, 3);
            cache.Put(4, 1);

           i=  cache.Get(1);       // returns 1
            
          i=  cache.Get(2);       // returns -1 (not found)
          //  cache.Put(4, 4);    // evicts key 1
          //i=  cache.Get(1);       // returns -1 (not found)
          //i=  cache.Get(3);       // returns 3
          //i=  cache.Get(4);       // returns 4


        }
    }
}