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
    public class DirectedCycleTests
    {
        [TestMethod()]
        public void DirectedCycleTest()
        {

        }

        [TestMethod()]
        public void HasCycleTest()
        {
            using (StreamReader sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\dataSelf\tinyDG.txt"))
            {
                Digraph dg = new Digraph(sr);

                DirectedCycle dcycle = new DirectedCycle(dg);

                Assert.AreEqual(dcycle.HasCycle(), true);
            }

        }

        [TestMethod()]
        public void CycleTest()
        {
            using (StreamReader sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\dataSelf\tinyDG.txt"))
            {
                Digraph dg = new Digraph(sr);

                DirectedCycle dcycle = new DirectedCycle(dg);

                Assert.AreEqual(dcycle.HasCycle(), true);

                IEnumerable<int> cycle = dcycle.Cycle();
                foreach (int i in cycle)
                    Console.Write(i + " -> ");
                Console.WriteLine();
            }

        }
    }
}