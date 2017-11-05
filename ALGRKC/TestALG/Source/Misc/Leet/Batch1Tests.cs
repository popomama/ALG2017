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
    public class Batch1Tests
    {
        [TestMethod()]
        public void LengthOfLongestSubstringTest()
        {
            string s = "abcddcba";
            int len;
            len = Batch1.LengthOfLongestSubstring(s);
            Assert.AreEqual(4, len);

            s = "abcdkmcbha";
            len = Batch1.LengthOfLongestSubstring(s);
            Assert.AreEqual(7, len);

        }

        [TestMethod()]
        public void LengthOfLongestSubstring2Test()
        {
            string s = "abcddcba";
            int len;
            len = Batch1.LengthOfLongestSubstring2(s);
            Assert.AreEqual(4, len);

            s = "abcdkmcbha";
            len = Batch1.LengthOfLongestSubstring2(s);
            Assert.AreEqual(7, len);

            s = "aaa";
            len = Batch1.LengthOfLongestSubstring2(s);
            Assert.AreEqual(1, len);
        }

        [TestMethod()]
        public void GetMaxAreaTest()
        {
            int[] hist = { 6, 2, 5, 4, 5, 1, 6 };
            int maxArea= Batch1.GetMaxArea(hist);
            Assert.AreEqual(12, maxArea);

            int[] hist2 =  { 1, 2, 3, 4, 5 };
            maxArea = Batch1.GetMaxArea(hist2);
            Assert.AreEqual(9, maxArea);
        }
    }
}