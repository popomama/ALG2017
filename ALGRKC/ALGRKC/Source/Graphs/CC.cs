using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Graphs
{
    //this is the ConnectedComponents class
    //still use dfs to search
    public class CC
    {
        bool[] isMarked;
        int[] ID;
        int count;

        public CC(Graph g)
        {
            isMarked = new bool[g.V()];
            ID = new int[g.V()];
            count = 0;

            for (int source = 0; source < g.V(); source++)
            {

                if (!isMarked[source])
                {
                    dfs(g, source);
                    count++;
                }
            }

        }

        void dfs(Graph g, int s)
        {
            //if(!isMarked[s])
            //{
            isMarked[s] = true;
            ID[s] = count;
            foreach (int i in g.AdjList(s))
            {
                if (!isMarked[i])
                    dfs(g, i);
            }
            //}

        }

        public bool IsConnected(int v, int w)
        {
            return ID[v] == ID[w];
        }

        public int Count()
        {
            return count;
        }

        public int id(int v)
        {
            return ID[v];
        }
    }
}
