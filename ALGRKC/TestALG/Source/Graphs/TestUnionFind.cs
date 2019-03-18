using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALGRKC.Source.Graphs;
using System.IO;
using System.Diagnostics;
using ALGRKC.Source.Graphs.Tests;

namespace TestALG.Source.Graphs
{
    [TestClass]
    public class TestUnionFind
    {
        [TestMethod]
        public void UnionFind()
        {

            StreamReader sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\data\tinyUF.txt");
            string line = null;
            line = sr.ReadLine(); // read V;
            int vNum = Int32.Parse(line);
            WeightedQuickUF uf = new WeightedQuickUF(vNum);

            while(!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] pair = line.Split();
                int v = Int32.Parse(pair[0]);
                int w = Int32.Parse(pair[1]);
                if (!uf.isConnected(v, w))
                {
                    uf.union(v, w);
                    Debug.WriteLine(v + " " + w);
                }
            }

            Debug.WriteLine(uf.Count() + " components");




        }
    }
}
