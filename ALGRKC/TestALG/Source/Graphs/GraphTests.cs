using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALGRKC.Source.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ALGRKC.Source.Graphs.Tests
{
    [TestClass()]
    public class GraphTests
    {
        [TestMethod()]
        public void GraphTest()
        {
            using (StreamReader sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\dataSelftinyG.txt")) 
            {
                Graph g = new Graph(sr);
                Assert.AreEqual(g.V(), 13);
                Assert.AreEqual(g.E(), 13);

            }

        }

        //[TestMethod()]
        //public void GraphTest1()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void VTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ETest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void AdjListTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void ToStringTest()
        {
            using (StreamReader sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\dataSelftinyG.txt"))
            {
                Graph g = new Graph(sr);
                Console.WriteLine(g.ToString()); ;

            }
        }
    }
}