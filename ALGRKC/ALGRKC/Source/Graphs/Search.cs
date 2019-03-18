using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Graphs
{
    class Search
    {
        Search(Graph g, int s)
        {

        }

        bool marked(int v)
        {
            return false;
        }

        int count()
        {
            return 0;
        }

    }

    class DepthFirstSearch
    {
        bool[] isMarked;
        int[] EdgeTo;

        public DepthFirstSearch(Graph g, int  s)
        {
             int v = g.V();
            isMarked = new bool[v];
            EdgeTo = new int[v];
            for (int i = 0; i < v; i++)
                EdgeTo[i] = -1;
            EdgeTo[s] = s;  // the root points to itself as the parent

            dfs(g, s);
        }

        void dfs(Graph g, int s)
        {
            isMarked[s] = true;
            foreach(int v in g.AdjList(s))
            {
                if (!isMarked[v])
                {
                    EdgeTo[v] = s;
                    dfs(g, v);
                }
            }
        }

        public bool hasPathTo(int v)
        {
            return isMarked[v];
        }

        public IEnumerable<int> pathTo(int v)
        {
            Stack<int> path = new Stack<int>();
            int curr = v;
            if (EdgeTo[v] == -1)
                return null;

            path.Push(v);

            while(v!=EdgeTo[v])
            {
                path.Push(EdgeTo[v]);
                v = EdgeTo[v];
            }

            return path;
        }
    }

    class BreadthFirstSearch
    {
        bool[] isMarked;
        int[] edgeTo;
        BreadthFirstSearch(Graph g, int s)
        {
            int v = g.V();
            edgeTo = new int[v];
            isMarked = new bool[v];

            Queue<int> q = new Queue<int>();
            q.Enqueue(s);

            int curr;
            //            int parent = s;
            edgeTo[s] = s;

            while (q.Count !=0)
            {
                curr = q.Dequeue();
                
                //edgeTo[curr] = parent;
                //parent = curr;
                foreach (int i in g.AdjList(curr))
                    if (!isMarked[i])
                    {
                        isMarked[curr] = true;
                        edgeTo[i] = curr;
                        q.Enqueue(i);
                    }


            }



        }

        public bool hasPathTo(int v)
        {
            return isMarked[v];
        }

        public IEnumerable<int> pathTo(int v)
        {
            Stack<int> path = new Stack<int>();
            int curr = v;
            if (!hasPathTo(v))
                return null;

            path.Push(v);

            while (v != edgeTo[v])
            {
                path.Push(edgeTo[v]);
                v = edgeTo[v];
            }

            return path;
        }

    }
}
