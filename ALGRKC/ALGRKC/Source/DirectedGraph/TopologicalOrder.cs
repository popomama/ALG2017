using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALGRKC.Source.SPT;

namespace ALGRKC.Source.DirectedGraph
{
    public class TopologicalOrder
    {

        IEnumerable<int> topologicalOder;

        public TopologicalOrder(Digraph dg)
        {
            DirectedCycle directedCycle = new DirectedCycle(dg);
            if(!directedCycle.HasCycle()) // if it's a DAG, then we can continue to get the Topological Order
            {
                DepthFirstOrder dfsOrder = new DepthFirstOrder(dg);
                topologicalOder = dfsOrder.PostReverseOrder();
            }
        }

        public TopologicalOrder(EdgeWeightedDiagraph ewg)
        {
            DirectedCycle directedCycle = new DirectedCycle(ewg);
            if (!directedCycle.HasCycle()) // if it's a DAG, then we can continue to get the Topological Order
            {
                DepthFirstOrder dfsOrder = new DepthFirstOrder(ewg);
                topologicalOder = dfsOrder.PostReverseOrder();
            }

        }

        public IEnumerable<int> Order()
        {
            return this.topologicalOder;
        }

        public bool IsDAG()
        {

            return topologicalOder != null;
        }

    }
}
