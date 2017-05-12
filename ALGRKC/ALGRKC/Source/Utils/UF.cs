using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Utils
{
    //this class implement Union Find
    //this algorithm has O(lgN) in both Find and Union
    class UF
    {
        int count;
        int[] id;
        int[] size;

        public UF(int count)
        {
            this.count = count;
            id = new int[count];
            size = new int[count];

            for (int i = 0; i < count; i++)
            {
                id[i] = i;//initialize the id to the index itself in the array
                size[i] = 1;
            }
        }

        public int Find(int a )
        {
            while (id[a] != a)
                a = id[a];

            return a;
        }
        public void Union(int a , int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);
            if(rootA != rootB)//if a and b are not connected yet
            {
                if(size[rootA] >size[rootB]) //if the tree containing a is bigger than move the tree b under the tree contain a;
                {
                    id[rootB] = rootA;
                    size[rootA] += size[rootB];
                }
                else
                {
                    id[rootA] = rootB;
                    size[rootB] += size[rootA];
                }

                count--;
            }
                
        }


        public bool IsConnected(int a, int b)
        {
            return Find(a)   == Find(b);
        }

        public int Count()
        {
            return count;
        }
    }
}
