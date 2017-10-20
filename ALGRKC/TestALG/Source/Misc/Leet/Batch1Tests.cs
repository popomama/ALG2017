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
            string s ="abcddcba";
            int len;
            len=Batch1.LengthOfLongestSubstring(s);
            Assert.AreEqual(4, len);

            s = "abcdkmcbha";
            len = Batch1.LengthOfLongestSubstring(s);
            Assert.AreEqual(7, len);

        }
    }
}