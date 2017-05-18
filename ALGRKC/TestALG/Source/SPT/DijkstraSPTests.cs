using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALGRKC.Source.SPT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ALGRKC.Source.SPT;

namespace ALGRKC.Source.SPT.Tests
{
    [TestClass()]
    public class DijkstraSPTests
    {
        [TestMethod()]
        public void DijkstraSPTest()
        {

            EdgeWeightedDiagraph ewg;

            using (StreamReader sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\dataSelf\tinyEWD.txt"))
            {
                ewg = new EdgeWeightedDiagraph(sr);

            }

            int s = 0;
            DijkstraSP SP = new DijkstraSP(ewg, s);
            


            for(int dest =0;dest<ewg.V();dest++)
            {
                if (SP.HasPathTo(dest))
                {
                    Console.Write(s + " to " + dest);
                    Console.Write(" (" + SP.DistanceTo(dest) + "):");
                    foreach (DirectedEdge de in SP.PathTo(dest))
                        Console.Write(de + "  ");
                    Console.WriteLine();
                        
                }
            }
            
        }
    }
}