﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.DirectedGraph
{
    public class DirectedCycle
    {
        bool[] marked;
        bool[] onStack;
        Stack<int> stackCycle;
        int[] edgeTo;
        bool hasCycle = false;

        public DirectedCycle(Digraph dg)
        {
            marked = new bool[dg.V()];
            onStack = new bool[dg.V()];
            edgeTo = new int[dg.V()];

            for (int i = 0; i < dg.V(); i++)
                if (!marked[i])
                    DFS(dg, i);
        }

        void DFS(Digraph g, int s)
        {
            marked[s] = true;
            onStack[s] = true;
            foreach (int v in g.AdjList(s))
            {
                if (hasCycle)
                    return;
                if (!marked[v])
                {
                    edgeTo[v] = s;
                    DFS(g, v);
                }
                else
                {
                    if (onStack[v]) // this means, we hit v agin in a cycle
                    {
                        hasCycle = true;
                        stackCycle = new Stack<int>();
                        for (int x = s; x != v; x = edgeTo[x])
                            stackCycle.Push(x);
                        stackCycle.Push(v);
                        stackCycle.Push(s);
                    }
                }
            }
            onStack[s] = false;


        }

        public bool Hascycle()
        {
            return hasCycle;
        }

        public IEnumerable<int> Cycle()
        {
            return stackCycle;
        }
    }
}
