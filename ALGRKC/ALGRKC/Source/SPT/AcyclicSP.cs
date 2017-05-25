using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALGRKC.Source.DirectedGraph;

namespace ALGRKC.Source.SPT
{
    public class AcyclicSP
    {
        DirectedEdge[] edgeTo;
        double[] distTo;

        public AcyclicSP(EdgeWeightedDiagraph ewg, int source)
        {
            edgeTo = new DirectedEdge[ewg.V()];
            distTo = new double[ewg.V()];
            for (int i = 0; i < ewg.V(); i++)
                distTo[i] = double.PositiveInfinity;
            distTo[source] = 0;
            TopologicalOrder tlOrder = new TopologicalOrder(ewg);
            foreach(int v in tlOrder.Order())
            {
                Relax(ewg,v);
            }

        }

        void Relax(EdgeWeightedDiagraph g, int v)
        {
            foreach (DirectedEdge e in g.AdjList(v))
            {
                int w = e.To();
                if (distTo[w] < distTo[v] + e.Weight())
                {
                    distTo[w] = distTo[v] + e.Weight();
                    edgeTo[w] = e;
                }
            }

        }

        public double  DistTo(int v)
        {
            return distTo[v];
        }

        public bool HasPathTo(int v)
        {
            return distTo[v] < double.PositiveInfinity;
        }

        public IEnumerable<DirectedEdge> PathTo(int v)
        {
            if(!HasPathTo(v))
                return null;

            Stack<DirectedEdge> path = new Stack<DirectedEdge>();
            for (DirectedEdge e = edgeTo[v]; e != null; e = edgeTo[e.From()])
                path.Push(e);

            return path;
        }
    }
}
