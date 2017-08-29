using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALGRKC.Source.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Misc.Tests
{
    [TestClass()]
    public class GoogTests
    {
        [TestMethod()]
        public void LargestSubArraySumTest()
        {

            int[] arr = { -1, 4, -2, 5, -5, 2, -20, 6 };

            //SortMisc s = new SortMisc();
            int result = Goog.LargestSubArraySum(arr);
            Assert.AreEqual(7, result);
        }

        [TestMethod()]
        public void LargestSubArraySum2Test()
        {
            int[] arr = { -2, -3, 4, -1, -2, 1, 5, -3 };

            Tuple<int, int, int> result = Goog.LargestSubArraySum2(arr);
            Assert.AreEqual(result.Item1, 7);
            Assert.AreEqual(result.Item2, 2);
            Assert.AreEqual(result.Item3, 6);

        }

        [TestMethod()]
        public void GetPermsTest()
        {
            string s = "121";
            Goog.GetPerms(s);

        }

        [TestMethod()]
        public void permutateHelperDuplicateTest()
        {


            Goog.PermutateDuplicate("", "bab");
            Console.WriteLine();

            Goog.PermutateDuplicate("", "abcb");
            Console.WriteLine();
            Goog.PermutateDuplicate("", "babb");

            Console.WriteLine();
            Goog.PermutateDuplicate("", "bbb");


            Console.WriteLine();
            Goog.PermutateDuplicate("", "baba");

        }

        [TestMethod()]
        public void GetPermsForDupsTest()
        {
            Goog.GetPermsForDups("", "bab");
            Console.WriteLine();

            Goog.GetPermsForDups("", "abcb");
            Console.WriteLine();
            Goog.GetPermsForDups("", "babb");

            Console.WriteLine();
            Goog.GetPermsForDups("", "bbb");


            Console.WriteLine();
            Goog.GetPermsForDups("", "baba");
        }

        [TestMethod()]
        public void FindNonCrooksNumberTest()
        {
            int[] F = { 1, 3, 5, 6, 9, 11, 17, 20 };
            int[] G = { 1, 4, 6, 8, 11, 25, 29, 31 };
            List<int> result = Goog.FindNonCrooksNumber(F, G);
        }

        [TestMethod()]
        public void GetDupAndMissingElementsTest()
        {
            int[] arr = { 1, 3, 4, 9, 7, 6, 2,9,5 };
            Goog.GetDupAndMissingElements(arr);

        }
    }
}