using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.SPT
{
    //(bellman-Ford algorithm) The following method solves the singlesource
    //shortest-paths problem from a given source s for any edge-weighted digraph
    //with V vertices and no negative cycles reachable from s: Initialize distTo[s]
    //to 0 and all other distTo[] values to infinity.Then, considering the digraph’s edges
    //in any order, relax all edges. Make V-1 such passes.
    public class BellmanFordSP
    {
        int vertexNum;
        double[] distTo;
        DirectedEdge[] edgeTo;

        //Bellman Ford has the complexity of O(VE)
        public BellmanFordSP(EdgeWeightedDiagraph ewg, int source)
        {
            vertexNum = ewg.V();
            distTo = new double[vertexNum];
            edgeTo = new DirectedEdge[vertexNum];

            for (int i = 0; i < vertexNum; i++)
                distTo[i] = double.PositiveInfinity;
            distTo[source] = 0.0;


        }

        void Relax(EdgeWeightedDiagraph ewg, int v)
        {

        }
    }
}
