﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class LazyPrimMSTTests
    {
        [TestMethod()]
        public void LazyPrimMSTTest()
        {
            //            LazyPrimMST primMST = new LazyPrimMST()
            EdgeWeightedGraph ewg;
            using (StreamReader sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\dataSelf\tinyEWG.txt"))
            {
                ewg = new EdgeWeightedGraph(sr);
            }

            KruskalMST kruskalMST = new KruskalMST(ewg);

            IEnumerable<Edge> mstEdges = kruskalMST.MSTEdges();
            foreach (Edge e in mstEdges)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine(kruskalMST.MSTValue());
        }
    }
}