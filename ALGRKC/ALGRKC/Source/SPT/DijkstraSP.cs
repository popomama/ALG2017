using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALGRKC.Source.Basic;

namespace ALGRKC.Source.SPT
{
    public class DijkstraSP
    {
        int vertexNumber;
        double[] distTo;
        DirectedEdge[] edgeTo;
        IndexMinPQ<double> pq;

        public DijkstraSP(EdgeWeightedDiagraph g, int source)
        {
            vertexNumber = g.V();
            distTo = new double[vertexNumber];
            for (int i = 0; i < vertexNumber; i++)
                distTo[i] = double.PositiveInfinity;
            distTo[source] = 0.0;

            edgeTo = new DirectedEdge[vertexNumber];

            pq = new IndexMinPQ<double>(vertexNumber);
            pq.Insert(source, 0.0);

            while(!pq.IsEmpty())
            {
                int current = pq.DelMin();
                Relax(g, current);
            }
        }

        void Relax(EdgeWeightedDiagraph g, int v)
        {
            foreach(DirectedEdge e in g.AdjList(v))
            {
                int w = e.To();
                double weight = e.Weight();
                if (distTo[w] > distTo[v] + weight)
                {
                    //relax
                    edgeTo[w] = e;
                    distTo[w] = distTo[v] + weight;
                    if (pq.Contains(w))
                        pq.ChangeKey(w, distTo[w]);
                    else
                        pq.Insert(w, distTo[w]);
                }

            }
        }

        public double DistanceTo(int dest)
        {
            return distTo[dest];
        }

        public bool HasPathTo(int dest)
        {
            return distTo[dest] < double.PositiveInfinity;
        }

        
        public IEnumerable<DirectedEdge> PathTo(int dest)
        {
            Stack<DirectedEdge> stack = new Stack<DirectedEdge>();
            DirectedEdge e;
            while(edgeTo[dest]!=null)
            {
                e = edgeTo[dest];
                stack.Push(e);
                dest = e.From();
            }

            return stack;
        }


    }
}
