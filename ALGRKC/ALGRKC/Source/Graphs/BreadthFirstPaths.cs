using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Graphs
{
    public class BreadthFirstPaths
    {
        int source;
        int[] edgeTo;
        bool[] isMarked;
        public BreadthFirstPaths(Graph g, int s)
        {
            source = s;
            edgeTo = new int[g.V()];
            isMarked = new bool[g.V()];

        }

        public void bfs(Graph g, int s)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(s);
            isMarked[s] = true;
            
            int current;

            
            while(q.Count!=0)
            {
                current = q.Dequeue();
                //isMarked[current] = true;

                foreach (int v in g.AdjList(current))
                {
                    if (!isMarked[v])
                    {
                        isMarked[v] = true;
                        q.Enqueue(v);
                        edgeTo[v] = current;
                    }
                }
            }
        }

        public bool HasPathTo(int destination)
        {
            return isMarked[destination];
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v))
                return null;

            Stack<int> path = new Stack<int>();

            while (v != source)
            {
                path.Push(v);
                v = edgeTo[v];
            }

            path.Push(source);
            return path;
        }
    }
}
