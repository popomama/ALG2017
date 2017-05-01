using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ALGRKC.Source.DirectedGraph
{

    //kosaraju–Sharir algorithm for computing strong components
    class SCC
    {
        Digraph dg;
        bool[] isMarked;
        int count;
        int[] id;

        public SCC(Digraph g)
        {
            dg = g;
            Digraph gReverse = g.Reverse();//get the reverse of the orinal graph
            isMarked = new bool[g.V()];

            //we will need do two passes of DFS

            //the first pass is to get the post reverse order of the reverse graph
            DepthFirstOrder dfs = new DepthFirstOrder(gReverse);
            //the reverse order will put the sink vertex of the orginal at the top of the stack returned
            IEnumerable<int> postReverse =   dfs.PostReverseOrder();

            
            foreach(int v in postReverse)
            {
                if (!isMarked[v])//now we remove one sink at a time, and find the SCC component
                {   //the number of the SCC is equal to the number of the times we get isMarked[v]==true;
                    DFS(g, v);
                    count++;
                    Console.WriteLine(0);
                }
            }

        }

        public void DFS(Digraph g, int s)
        {
            isMarked[s] = true;
            id[s] = count;
            Console.Write(s + ", ");
            foreach(int v in g.AdjList(s))
            {
                if (!isMarked[v])
                    DFS(g, v);
            }
        }

        bool IsStronglyConnected(int v, int w)
        {

            return id[v] == id[w];
        }
    }
}
