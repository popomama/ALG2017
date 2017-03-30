using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Graphs
{
    public class DepthFirstPaths
    {
        int source;
        int[] edgeTo;
        bool[] isMarked;

        public DepthFirstPaths(Graph g, int s)
        {
            source = s;
            edgeTo = new int[g.V()];
            isMarked = new bool[g.V()];

            isMarked[s] = true;
            dfs(g, s);
        }

        void dfs(Graph g, int v)
        {
            //if(!isMarked[v])
            //{
            //    isMarked[v] = true;
            foreach (int i in g.AdjList(v))
            {
                if (!isMarked[i])
                {
                    isMarked[i] = true;
                    edgeTo[i] = v;
                    dfs(g, i);
                }
            }
            //}
        }

        public bool HasPathTo(int v) // return true if there is a path from source to v
        {
            if (isMarked[v])
                return true;
            else
                return false;
        }

        public IEnumerable<int> PathTo(int v)
        {
            Stack<int> stack = new Stack<int>();
            while(edgeTo[v]!=source)
            {
                stack.Push(v);
                v = edgeTo[v];
            }
            return stack;
        }
    }
}
