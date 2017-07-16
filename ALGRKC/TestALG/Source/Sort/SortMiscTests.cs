using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALGRKC.Source.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Sort.Tests
{
    [TestClass()]
    public class SortMiscTests
    {
        [TestMethod()]
        public void LargestSubArraySumTest()
        {

            int[] arr = { -1, 4, -2, 5, -5, 2, -20, 6 };

            //SortMisc s = new SortMisc();
            int result = SortMisc.LargestSubArraySum(arr);
            Assert.AreEqual(7, result);
        }
    }
}