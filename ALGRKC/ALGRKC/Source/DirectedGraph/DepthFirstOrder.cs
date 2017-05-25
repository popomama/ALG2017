using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ALGRKC.Source.SPT;
namespace ALGRKC.Source.DirectedGraph
{
    public class DepthFirstOrder
    {
        private bool[] isMarked;

        Queue<int> preOrder;
        Queue<int> postOrder;
        Stack<int> postReverseOrder; // this is used by the Topological Order call

        public DepthFirstOrder(Digraph g)
        {
            isMarked = new bool[g.V()];

            for (int i = 0; i < g.V(); i++)
                if (!isMarked[i])
                    DFS(g, i);

        }
        public DepthFirstOrder(EdgeWeightedDiagraph g)
        {
            isMarked = new bool[g.V()];

            for (int i = 0; i < g.V(); i++)
                if (!isMarked[i])
                    DFS(g, i);

        }

        void DFS(Digraph g, int source)
        {
            isMarked[source] = false;

            preOrder.Enqueue(source);

            foreach(int v in g.AdjList(source))
                if(!isMarked[v])
                {
                    DFS(g, v);
                }

            postOrder.Enqueue(source);
            postReverseOrder.Push(source);
        }

        void DFS(EdgeWeightedDiagraph g, int source)
        {
            isMarked[source] = false;

            preOrder.Enqueue(source);



            foreach (DirectedEdge de in g.AdjList(source))
            {
                int from = de.From(), to = de.To();
                int v;
                v = source == from ? to : from;

                if (!isMarked[v])
                {
                    DFS(g, v);
                }
            }
            postOrder.Enqueue(source);
            postReverseOrder.Push(source);
        }

        public IEnumerable<int> PreOrder()
        {
            return preOrder;
        }

        public IEnumerable<int> PostOrder()
        {
            return postOrder;
        }

        public IEnumerable<int> PostReverseOrder()
        {
            return postReverseOrder;
        }
    }
}
