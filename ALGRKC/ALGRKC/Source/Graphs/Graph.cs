﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using ALGRKC.Source.Basic;

namespace ALGRKC.Source.Graphs
{
    public class Graph
    {
        int vertNum;//number of vertices
        int edgeNum;//number of edges
        Bag<int>[] adj;  //adjacency lists

        public Graph(int v)
        {
            this.Init(v);

        }

        void Init(int v)
        {

            vertNum = v;
            adj = new Bag<int>[vertNum];
            for (int i = 0; i < vertNum; i++)
                adj[i] = new Bag<int>();
        }

        public Graph(StreamReader sr)
        {

            string line = null;
            line = sr.ReadLine(); // read V;
            int vNum = Int32.Parse(line);
            Init(vNum);

            line = sr.ReadLine();// read E
            this.edgeNum = Int32.Parse(line);

            while((line=sr.ReadLine())!=null)   //each line is an edge
            {
                string[] pair = line.Split();
                int v = Int32.Parse(pair[0]);
                int w = Int32.Parse(pair[1]);
                this.AddEdge(v, w); //add edge

            }



        }

        public int V()
        { return vertNum; }

        public int E()
        { return edgeNum; }

        void AddEdge(int v, int w)
        {
            adj[v].Add(w);//add the edge to both vertices' adjacency lists
            adj[w].Add(v);
            edgeNum++; // increase the edgeNumber
        }

        public IEnumerable<int> AdjList(int v)
        {
            return adj[v];
        }

       
    }
}
