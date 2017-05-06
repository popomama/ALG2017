using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.MST
{
    class Edge : IComparable<Edge>
    {
        int v, w;
        double weight;
        public Edge(int v, int w , double weight)
        {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }

        public int Either()
        {
            return v;
        }

        public int Other()
        {
            return w;
        }

        public double Weight()
        {
            return weight;
        }

        public int CompareTo(Edge e)
        {
            return weight.CompareTo(e.weight);

        }

        public override string ToString()
        {
            return this.v + " - " + this.w + " : " + this.weight;
        }
    }
}
