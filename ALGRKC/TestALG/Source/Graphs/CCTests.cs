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
    public class CCTests
    {
        [TestMethod()]
        public void ContectedCompoentTest()
        {
            using (StreamReader sr = new StreamReader(@"E:\Study\ALG2017\ALGRKC\dataSelf\tinyG.txt"))
            {
                Graph g = new Graph(sr);

                CC c = new CC(g);

                int count = c.Count();
                Queue<int>[] ccQueue = new Queue<int>[count];
                for (int i = 0; i < count; i++)
                    ccQueue[i] = new Queue<int>();

                for(int i=0;i<g.V();i++)
                {
                    ccQueue[c.id(i)].Enqueue(i);

                }

                int current;
                for (int i = 0; i < count; i++)
                {
                    Console.Write("CC " + i + " : ");
                    while (ccQueue[i].Count > 1)
                    {
                        current = ccQueue[i].Dequeue();
                        Console.Write(current + ", ");
                    }
                    current = ccQueue[i].Dequeue();
                    Console.WriteLine(current); // wrtie the last one in the current set
                }

            }
        }
    }
}