using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Basic
{
    //this class implements Index MinPQ
    class IndexMinPQ <T> where T : IComparable<T>
    {
        int maxSize;
        int size;
        T[] pq;

        public IndexMinPQ(int maxSize)
        {
            this.maxSize = maxSize;
            pq = new T[maxSize + 1];
            size = 0;

        }
    }
}
