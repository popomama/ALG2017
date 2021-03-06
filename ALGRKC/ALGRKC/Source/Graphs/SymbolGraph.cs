﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ALGRKC.Source.Graphs
{
    public class SymbolGraph
    {
        Dictionary<string, int> st;//symbol table to record name-index pair 
        //int[] index; //store index of the names
        string[] keys; //store index-name
        Graph g; // graph will only record the index

        public SymbolGraph(String fileName, string separator)
        {
            string line;
            string[] names;
            int vertexNum = 0;



            //step 1  build the symbol  table(first parse of the file)
            StreamReader sr;
            using (sr = new StreamReader(fileName))
            {
                st = new Dictionary<string, int>();

                while ((line = sr.ReadLine()) != null)
                {
                    names = line.Split(separator.ToCharArray(), StringSplitOptions.None);

                    for (int i = 0; i < names.Length; i++)
                    {
                        string name = names[i];
                        if (!st.ContainsKey(name))
                            st.Add(name, st.Count);
                        //vertexNum++;
                    }

                    //vertexNum--;//remove the first source;
                }
            }

            //step 2 populate the index-name array
            int index;
            keys = new string[st.Count];
            foreach(string name in st.Keys)
            {
                index = st[name];
                keys[index] = name;
            }

            string source, destination;
            int sourceIndex, destinationIndex;
            
            //step 3 build graph(2nd parse of the file)
            vertexNum = st.Count();
            g = new Graph(vertexNum);


            //sr = new StreamReader(stream);

            using (sr = new StreamReader(fileName))//need to create the stream again so that we can read the file from the beginning.
            {
                while ((line = sr.ReadLine()) != null)
                {
                    names = line.Split(separator.ToCharArray(), StringSplitOptions.None);
                    source = names[0];
                    sourceIndex = st[source];

                    for (int i = 1; i < names.Length; i++)
                    {
                        destination = names[i];
                        destinationIndex = st[destination];
                        g.AddEdge(sourceIndex, destinationIndex);
                    }



                }

            }
        }

        public Graph G()
        {
            return g;
        }

        public int Index(string key)
        {
            return st[key];
        }

        public string KeyName(int index)
        {
            return keys[index];
        }

        public bool Contains(string key)
        {
            return st.ContainsKey(key);
        }
    }
}
