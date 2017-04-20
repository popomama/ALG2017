using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALGRKC.Source.DirectedGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ALGRKC.Source.DirectedGraph.Tests
{
    [TestClass()]
    public class TopologicalOrderTests
    {
        [TestMethod()]
        public void TopologicalOrderTest()
        {
            using (StreamReader sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\dataSelf\tinyDG.txt"))
            {
                Digraph dg = new Digraph(sr);
                TopologicalOrder tlOrder = new TopologicalOrder(dg);
                IEnumerable<int> order = tlOrder.Order();
                foreach (int i in order)
                {
                    Console.Write(i + " , ");

                }

                Console.WriteLine();
            }
        }

        [TestMethod()]
        public void IsDAGTest()
        {
            using (StreamReader sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\dataSelf\tinyDG.txt"))
            {
                Digraph dg = new Digraph(sr);
                TopologicalOrder tlOrder = new TopologicalOrder(dg);


                Assert.AreEqual(tlOrder.IsDAG(), true);
            }
        }
    }
}