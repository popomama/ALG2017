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
    public class DepthFirstPathsTests
    {
        [TestMethod()]
        public void DepthFirstPathsTest()
        {

        }

        [TestMethod()]
        public void HasPathToTest()
        {

        }

        [TestMethod()]
        //0 to 0 : 0
        //0 to 1 : 0-2-1
        //0 to 2 : 0-2
        //0 to 3 : 0-2-3
        //0 to 4 : 0-2-3-4
        //0 to 5 : 0-2-3-5
        public void PathToTest()
        {
            using (StreamReader sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\dataSelf\tinyCG.txt"))
            {
                Graph g = new Graph(sr);
                int source = 0;
                DepthFirstPaths dfp = new DepthFirstPaths(g, source); 

                for(int v=0;v<g.V(); v++)
                {
                    Console.Write(source + " to " + v + " : ");
                    if(dfp.HasPathTo(v))
                    {
                        foreach (int x in dfp.PathTo(v))
                            if (x == source)
                                Console.Write(x);
                            else
                                Console.Write("-" + x);
                    }
                    Console.WriteLine();

                }

            }

        }
    }
}