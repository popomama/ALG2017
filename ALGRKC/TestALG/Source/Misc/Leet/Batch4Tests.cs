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
            int[] nums ={2, 0, 1, 1, 1};
            int min = b4.FindMin2(nums);
        }
    }
}