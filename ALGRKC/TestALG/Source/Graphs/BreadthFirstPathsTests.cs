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
    public class BreadthFirstPathsTests
    {
        [TestMethod()]
        public void bfsTest()
        {
            using (StreamReader sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\dataSelf\tinyCG.txt"))
            {
                Graph g = new Graph(sr);
                int source = 0;
                BreadthFirstPaths bfp = new BreadthFirstPaths(g, source);
                bfp.bfs(g, source);

                for(int i=0;i<g.V();i++)
                {
                    Console.Write(source + " to " + i + " : ");
                    if(bfp.HasPathTo(i))
                    {
                        foreach(int v in bfp.PathTo(i))
                        {
                            if (v == source)
                                Console.Write(source);
                            else
                            {
                                Console.Write("-" + v);
                            }
                        }
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine("no path");
                    }
                }
                    }
        }
    }
}