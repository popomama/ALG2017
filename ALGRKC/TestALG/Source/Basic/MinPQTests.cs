using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALGRKC.Source.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ALGRKC.Source.MST;

namespace ALGRKC.Source.Basic.Tests
{
    [TestClass()]
    public class MinPQTests
    {
        [TestMethod()]
        public void MinPQTest()
        {
            MinPQ<Edge> minQ;
            int edgeNum, vNum;

            //Build minQueue
            using (StreamReader sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\dataSelf\tinyEWG.txt"))
            {
                string line = null;
                line = sr.ReadLine(); // read V;
                string[] pair = line.Split();
                vNum = Int32.Parse(line);
                line = sr.ReadLine();
                edgeNum = Int32.Parse(line);

                minQ = new MinPQ<Edge>(edgeNum);

                //while((line=sr.ReadLine())!=null)   //each line is an edge
                for (int i = 0; i < edgeNum; i++)
                {
                    line = sr.ReadLine();
                    pair = line.Split();
                    int v = Int32.Parse(pair[0]);
                    int w = Int32.Parse(pair[1]);
                    double weight = Double.Parse(pair[2]);
                    Edge e = new Edge(v, w, weight);

                    minQ.Insert(e);
                }
            }

            for (int i = 0; i < edgeNum; i++)
            {
                Edge e = minQ.DelMin();
                Console.WriteLine(e.ToString());
            }
        }
    }
}