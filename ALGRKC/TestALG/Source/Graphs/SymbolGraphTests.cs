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
    public class SymbolGraphTests
    {
        [TestMethod()]
        public void SymbolGraphTest()
        {
            string sep = " ";
            StreamReader sr;
            using (sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\data\routes.txt"))
            {
                SymbolGraph sg = new SymbolGraph(sr, sep);
                Graph g = sg.G();

                string source;

                source = "JFK";

                foreach (int v in g.AdjList(sg.Index(source)))
                {
                    Console.WriteLine(sg.KeyName(v));

                }
                Console.WriteLine();





            }
        }
    }
}