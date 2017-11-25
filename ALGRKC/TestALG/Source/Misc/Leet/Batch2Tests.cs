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
    public class Batch2Tests
    {
        [TestMethod()]
        public void FindRangeTest()
        {
            int[] org = { 5, 7, 7, 8, 8, 10 };

            int target = 8;

            Batch2.FindRange(org, target);

        }
    }
}