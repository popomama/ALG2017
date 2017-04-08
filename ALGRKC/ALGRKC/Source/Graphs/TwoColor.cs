using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Graphs
{
    //Is the graph bipartie? Can the verties of a given graph be assigned one of the two colors in such
    //a way that no edge connects vertices of the same color's?
    public class TwoColor
    {
        bool[] isMarked;
        bool[] color;
        bool isBipartie = true;


        public TwoColor(Graph g)
        {
            isMarked = new bool[g.V()];
            color = new bool[g.V()];
            for (int i = 0; i < g.V(); i++)
            {
                if(!isMarked[i])
                    DFS(g, i, true);

            }
        }

        void DFS(Graph g, int s, bool currentColor)
        {
            isMarked[s] = true;
            color[s] = currentColor;
            foreach (int v in g.AdjList(s))
            {
                if (!isMarked[v])
                    DFS(g, v, !currentColor);
                else
                {
                    if (color[s] == color[v])
                        isBipartie = false;
                }
            }


        }

        public bool IsBipartie()
        {
            return isBipartie;
        }

    }
}
