using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALGRKC.Source.Basic;

namespace ALGRKC.Source.MST
{
    public class LazyPrimMST
    {
        double mstValue;
        EdgeWeightedGraph g;
        Edge[] mstEdges;
        bool[] isVisited;
        MinPQ<Edge> minQueue;

        public LazyPrimMST(EdgeWeightedGraph ewg)
        {
            g = ewg;
            int vertexNum = g.V();
            int edgeNum = g.E();
            isVisited = new bool[vertexNum];
            minQueue = new MinPQ<Edge>(edgeNum);

            Visit(0);

            Edge eCurrent;

            while (!minQueue.IsEmpty())
            {
                eCurrent = minQueue.DelMin();
                if (!isVisited[eCurrent.Either()] && !isVisited[eCurrent.Other()])


            }
            //for(int i=0;i<vertexNum;i++)
            //{
            //    if(!isVisisted[i])
            //    {

            //    }
            //}

        }

        void Visit(int vertexNumber)
        {
            isVisited[vertexNumber] = true;
            foreach(Edge e in g.AdjList(vertexNumber))
            {
                if (!isVisited[e.Either()] && !isVisited[e.Other()]) //not visited
                    minQueue.Insert(e);
            }

        }

        double MSTValue()
        {
            return mstValue;
        }

        IEnumerable<Edge> MSTEdges()
        {
            return mstEdges;
        }
    }
}
