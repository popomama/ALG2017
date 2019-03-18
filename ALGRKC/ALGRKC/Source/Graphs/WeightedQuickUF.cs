using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Graphs.Tests
{
    public class WeightedQuickUF
    {
        int[] id;
        int[] size;
        int count;

        public WeightedQuickUF(int N)
        {
            id = new int[N];
            size = new int[N];
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
                size[i] = 1;
            }
            count = N;
        }

        public int find(int i)
        {
            //keep checking the parent until it
            while (i != id[i])
                i = id[i];

            return i;
        }

        public int Count()
        {
            return count;
        }
        public void union(int p , int q)
        {

            int idp, idq;
            idp = find(p);
            idq = find(q);

            if (idp == idq)
                return;

            if(size[idp]<size[idq])
            {
                id[idp] = idq;
                size[idq] += size[idp];
            }
            else
            {
                id[idq] = idp;
                size[idp] += size[idq];
            }

            count--;
        }

        public bool isConnected(int p , int q)
        {
            int idp = find(p);
            int idq=find(q);
            return idp == idq;
        }
    }
}
