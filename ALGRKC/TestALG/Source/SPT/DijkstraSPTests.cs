using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALGRKC.Source.SPT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

            DijkstraSP SP = new DijkstraSP(ewg, 0);
            
        }
    }
}