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
    public class Batch6Tests
    {
        [TestMethod()]
        public void IsAdditiveNumberTest()
        {
            string s1 = "11111111111011111111111"; // "121474836472147483648"; // "101";// "199100199";  //"112358";// "199100199";
            Batch6 b6 = new Batch6();
            bool bIsAdd = b6.IsAdditiveNumber(s1);
        }
    }
}