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
        EdgeWeightedGraph g;
        Queue<Edge> mstEdges;
        bool[] isVisited;
        MinPQ<Edge> minQueue;

        public LazyPrimMST(EdgeWeightedGraph ewg)
        {
            g = ewg;
            int vertexNum = g.V();
            int edgeNum = g.E();
            isVisited = new bool[vertexNum];
            minQueue = new MinPQ<Edge>(edgeNum);
            mstEdges = new Queue<Edge>();

            Visit(0);

            Edge eCurrent;
            int either, other;

            while (!minQueue.IsEmpty())
            {
                eCurrent = minQueue.DelMin();
                either = eCurrent.Either();
                other = eCurrent.Other(either);
                if (!isVisited[either] && !isVisited[other])
                {
                    mstEdges.Enqueue(eCurrent);
                    if (!isVisited[either])
                        Visit(either);
                    else
                        Visit(other);
                }
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
            int  other;
            foreach(Edge e in g.AdjList(vertexNumber))
            {
                //either = e.Either();
                other = e.Other(vertexNumber);
                if ( !isVisited[other]) //only add the edge into the queue when the other vertex is not visited
                    minQueue.Insert(e);
            }

        }

        public double MSTValue()
        {
            double mstValue=0.0;
            foreach (Edge e in mstEdges)
                mstValue += e.Weight();

            return mstValue;

        }

        public IEnumerable<Edge> MSTEdges()
        {
            return mstEdges;
        }
    }
}
