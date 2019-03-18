using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALGRKC.Source.Graphs;
using System.Diagnostics;

namespace ALGRKC.Source.Graphs.Tests
{
    [TestClass()]
    public class TestGraph
    {
        public void TestCycle()
        {
            Graph g = new Graph(5);

            
        }

        [TestMethod()]
        public void TestPath()
        {
            StreamReader sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\data\tinyCG.txt");
            Graph g = new Graph(sr);
            int source = 0;
           // BreadthFirstPaths path= new BreadthFirstPaths(g, source);
            DepthFirstPaths path = new DepthFirstPaths(g, source);
            for (int i=0;i<g.V();i++)
            {
                Debug.Write("From " + source + " to " + i + " : ");

                if (path.HasPathTo(i))
                {
                    
                    //print path
                    foreach (int j in path.PathTo(i))
                    {
                        Debug.Write(j + "-");
                    }

                    Debug.WriteLine("");


                }
                else
                    Debug.WriteLine("No path from " + source + " to " + i);
            }

        }
    }
}
