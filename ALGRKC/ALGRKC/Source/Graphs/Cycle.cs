using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Graphs
{
    public class Cycle
    {
        bool hasCycle;
        bool[] isMarked;
        public Cycle(Graph g)
        {
            isMarked = new bool[g.V()];

            for(int i = 0;i<g.V();i++)
            {
                if (!isMarked[i])
                {
                    hasCycle = DetectCycle(g, i, -1);
                    if (hasCycle)
                        return;
                }
            }
        }



        bool DetectCycle(Graph g, int c, int parent)
        {
            bool bCycled = false;
            isMarked[c] = true;

            foreach(int v in g.AdjList(c))
            {
                if (!isMarked[v])
                {
                    bCycled = DetectCycle(g, v, c);
                    if (bCycled)
                        return true;
                }
                else
                {
                    if (v != parent) // if v has been visited, but we now visit v again and not from the parent of the current vertix c, then we find a cycle
                        return true;// remember in the undirect graph, each edge u-v appears twice in the adjacent list. One in u's and the other in v's
                    //if v== parent, it means we visit parent where it comes from, so we just ignore it.
                }
            }

            return false;
        }

        bool HasCycle(Graph g)
        {
            bool bHasCycle = false;

            for(int i =0;i<g.V(); i++)
            {
                bHasCycle= FindCycle(g, i);
                if (bHasCycle)
                    return true;
            }

            return false;


        }

        bool FindCycle(Graph g, int i)
        {
            bool bFind = false;
            isMarked[i] = true;
            foreach(int j in g.AdjList(i))
            {
                if (isMarked[j])
                {
                    return true;
                    
                }
                else
                    bFind= FindCycle(g, j);
            }

            isMarked[i] = false;
            return bFind;
        }
    }
}
