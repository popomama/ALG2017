using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.SPT
{
    public class DirectedEdge
    {
        int from;
        int to;
        double weight;

        public DirectedEdge(int from, int to, double weight)
        {
            this.from = from;
            this.to = to;
            this.weight = weight;
        }

        public double Weight()
        {
            return this.weight;
        }

        public int From()
        {
            return this.from;
        }

        public int To()
        {
            return this.to;
        }

        public override string ToString()
        {
            return this.from + " -> " + this.to + " : " + this.weight;
        }
    }
}
