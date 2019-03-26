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
            int[][] d = new int[][] {new int[] { -2, -3, 3 }, new int[] { -5, -10, 1 }, new int[] { 10, 30, -5 } };
            Batch3 b3 = new Batch3();
            int result = b3.CalculateMinimumHP(d);
        }
    }
}