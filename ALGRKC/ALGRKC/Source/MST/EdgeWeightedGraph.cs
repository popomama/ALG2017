using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALGRKC.Source.Basic;
using System.IO;

namespace ALGRKC.Source.MST
{
    public class EdgeWeightedGraph
    {
        int vertexNumer;
        int edgeNumber;
        Bag<Edge>[] adj;
        
        public EdgeWeightedGraph(int v)
        {
            Init(v);  
        }

        public EdgeWeightedGraph(StreamReader sr)
        {
            string line = null;
            line = sr.ReadLine();
            int v = Int32.Parse(line);

            Init(v);

            line = sr.ReadLine();
            int eNum = Int32.Parse(line);

            string[] items;
            int from, to;
            double w;
            for (int i=0;i<eNum; i++)
            {
                line = sr.ReadLine();
                items=  line.Split(' ');
                from = Int32.Parse(items[0]);
                to= Int32.Parse(items[1]);
                w = Double.Parse(items[2]);
                AddEdge(from, to, w);
            }


        }

        void Init(int v)
        {
            this.vertexNumer = v;
            adj = new Bag<Edge>[v];
            for (int i = 0; i < v; i++)
                adj[i] = new Bag<Edge>();
        }

        public void AddEdge(int v, int w, double weight)
        {
            Edge e = new Edge(v, w, weight);
            adj[v].Add(e);
            adj[w].Add(e);
            edgeNumber++;
        }

        public IEnumerable<Edge> AdjList(int v)
        {
            return adj[v];
        }

        public int V()
        {
            return vertexNumer;
        }

        public int E()
        {
            return edgeNumber;
        }
        public IEnumerable<Edge> Edges()
        {
            Bag<Edge> edges = new Bag<Edge>();
            int  other;

            for (int i = 0; i < this.vertexNumer; i++)
            {
                foreach (Edge e in this.adj[i])
                {
                    //either = e.Either();
                    other = e.Other(i);
                    if (i < other) //only add the edge when current vertex number is smaller to avoid duplicates
                        edges.Add(e);
                }
            }

            return edges;
        }
    }
}
