using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALGRKC.Source.Basic;
using System.IO;

namespace ALGRKC.Source.SPT
{
    public class EdgeWeightedDiagraph
    {
        int vertexNumber;
        int edgeNumber;
        Bag<DirectedEdge>[] adj;

        public EdgeWeightedDiagraph(int v)
        {
            Init(v);
        }

        public EdgeWeightedDiagraph(StreamReader sr)
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
            DirectedEdge e;
            for (int i = 0; i < eNum; i++)
            {
                line = sr.ReadLine();
                items = line.Split(' ');
                from = Int32.Parse(items[0]);
                to = Int32.Parse(items[1]);
                w = Double.Parse(items[2]);
                e = new DirectedEdge(from, to, w);

                AddEdge(e);
            }
        }

        void Init(int v)
        {
            this.vertexNumber = v;
            adj = new Bag<DirectedEdge>[v];
            for (int i = 0; i < v; i++)
                adj[i] = new Bag<DirectedEdge>();
        }
        public int V()
        {
            return this.vertexNumber;
        }

        public int E()
        {
            return this.edgeNumber;
        }

        public void AddEdge(DirectedEdge e)
        {
            int from = e.From();
            adj[from].Add(e);
            edgeNumber++;
        }

        public IEnumerable<DirectedEdge> AdjList(int v)
        {
            return adj[v];
        }


        public IEnumerable<DirectedEdge> Edges()
        {
            Bag<DirectedEdge> edges = new Bag<DirectedEdge>();
            //int other;

            for (int i = 0; i < this.vertexNumber; i++)
            {
                foreach (DirectedEdge e in this.adj[i])
                {
                    //either = e.Either();
                    //other = e.Other(i);
                    //if (i < other) //only add the edge when current vertex number is smaller to avoid duplicates
                    //    edges.Add(e);
                    edges.Add(e);
                }
            }

            return edges;
        }

    }
}
