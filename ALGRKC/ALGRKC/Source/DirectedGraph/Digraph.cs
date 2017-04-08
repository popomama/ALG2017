using ALGRKC.Source.Basic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.DirectedGraph
{
    public class Digraph
    {
        int vertNum;//number of vertices
        int edgeNum;//number of edges
        Bag<int>[] adj;  //adjacency lists

        public Digraph(int v)
        {
            Init(v);
        }

        public Digraph(StreamReader sr)
        {
            string line = null; 
            line = sr.ReadLine();
            Init(Int32.Parse(line));

            line = sr.ReadLine();
            int edge = Int32.Parse(line);
            string[] pair;
            int source, destination;
            for(int i=0;i<edge;i++)
            {
                line = sr.ReadLine();
                pair = line.Split(' ');
                source = Int32.Parse(pair[0]);
                destination = Int32.Parse(pair[1]);

                AddEdge(source, destination);


            }

        }

        void Init(int v)
        {
            this.vertNum = v;
            adj = new Bag<int>[v];
            for (int i=0;i<v;i++)
            {
                adj[i] = new Bag<int>();
            }
        }
        public int V()
        {
            return vertNum;
        }

        public int E()
        {
            return edgeNum;
        }

        public void AddEdge(int source, int destination)
        {
            adj[source].Add(destination);//since this is DAG, only one way is needed.
            edgeNum++;//increase the edge number

        }

        public IEnumerable<int> AdjList(int v)
        {
            return adj[v];
        }
        public Digraph Reverse()
        {
            Digraph g = new Digraph(this.vertNum);

            for(int i=0;i<vertNum;i++)
            {
                foreach (int v in adj[i])
                    g.AddEdge(v, i);

            }

            return g;
        }


    }

}
