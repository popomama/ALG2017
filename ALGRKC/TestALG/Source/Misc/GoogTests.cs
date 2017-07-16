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
            Assert.AreEqual(result.Item1,7);
            Assert.AreEqual(result.Item2,2);
            Assert.AreEqual(result.Item3,6);

        }
    }
}