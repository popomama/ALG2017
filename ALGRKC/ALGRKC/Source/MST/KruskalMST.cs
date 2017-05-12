using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALGRKC.Source.Basic;

namespace ALGRKC.Source.MST
{
   
    class KruskalMST
    {
        EdgeWeightedGraph g;
        Queue<Edge> edges;
        MinPQ<Edge> minPQ;

        public KruskalMST(EdgeWeightedGraph ewg)
        {
            this.g = ewg;
            minPQ = new MinPQ<Edge>(g.E());
            //first we need to create a priority queue to store all edges
            foreach(Edge edge in ewg.Edges())
            {
                minPQ.Insert(edge);
            }
            Edge currrent;
            int either, other;
            Utils.UF uf = new Utils.UF(g.V()); //instantiate the union find variable 

            //second, we take min from the PQ one at a time and insert to the queue if both ends are not connected yet
            while (!minPQ.IsEmpty() && edges.Count < (this.g.V() - 1))
            {
                currrent = minPQ.DelMin();
                either = currrent.Either();
                other = currrent.Other(either);
                if (!uf.IsConnected(either, other)) //only add the edge into the final queue if both ends are not connected
                {
                    edges.Enqueue(currrent);
                    uf.Union(either, other);
                }
            }
        }

        IEnumerable<Edge> MSTEgdes()
        {
            return edges;
        }
        public double Weight()
        {
            double weight = 0.0;
            foreach (Edge e in edges)
                weight += e.Weight();

            return weight;
        }
    }
}
