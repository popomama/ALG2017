using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALGRKC.Source.MST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ALGRKC.Source.MST.Tests
{
    [TestClass()]
    public class KruskalMSTTests
    {
        [TestMethod()]
        public void KruskalMSTTest()
        {
            //            LazyPrimMST primMST = new LazyPrimMST()
            EdgeWeightedGraph ewg;
            using (StreamReader sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\dataSelf\tinyEWG.txt"))
            {
                ewg = new EdgeWeightedGraph(sr);
            }

            LazyPrimMST primMST = new LazyPrimMST(ewg);

            IEnumerable<Edge> mstEdges = primMST.MSTEdges();
            foreach (Edge e in mstEdges)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine(primMST.MSTValue());

        }
    }
}