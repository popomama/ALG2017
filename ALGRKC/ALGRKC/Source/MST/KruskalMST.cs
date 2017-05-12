using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALGRKC.Source.Basic;

namespace ALGRKC.Source.MST
{
   
    public class KruskalMST
    {
        EdgeWeightedGraph g;
        Queue<Edge> mstEdges;
        MinPQ<Edge> minPQ;

        public KruskalMST(EdgeWeightedGraph ewg)
        {
            this.g = ewg;
            minPQ = new MinPQ<Edge>(g.E());
            mstEdges = new Queue<Edge>();
            //first we need to create a priority queue to store all Edges

            int either, other;

            foreach (Edge edge in ewg.Edges())
            {
                //either = edge.Either();
                //other = edge.Other(either);
                //if(either<other) //insert the same edge once only when either<other;
                    minPQ.Insert(edge);
            }
            Edge currrent;
           
            Utils.UF uf = new Utils.UF(g.V()); //instantiate the union find variable 

            //second, we take min from the PQ one at a time and insert to the queue if both ends are not connected yet
            while (!minPQ.IsEmpty() && mstEdges.Count < (this.g.V() - 1))
            {
                currrent = minPQ.DelMin();
                either = currrent.Either();
                other = currrent.Other(either);
                if (!uf.IsConnected(either, other)) //only add the edge into the final queue if both ends are not connected
                {
                    mstEdges.Enqueue(currrent);
                    uf.Union(either, other);
                }
            }
        }

        public IEnumerable<Edge> MSTEdges()
        {
            return mstEdges;
        }
        public double MSTValue()
        {
            double weight = 0.0;
            foreach (Edge e in mstEdges)
                weight += e.Weight();

            return weight;
        }
    }
}
