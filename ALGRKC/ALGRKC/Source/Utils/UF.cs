using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Utils
{
    //this class implement Union Find
    class UF
    {
        int count;
        int[] id;
        int[] size;

        public UF(int count)
        {
            this.count = count;
            id = new int[count];

            for (int i = 0; i < count; i++)
            {
                id[i] = i;//initialize the id to the index itself in the array
                size[i] = 1;
            }
        }

        int Find(int a )
        {
            while (id[a] != a)
                a = id[a];

            return a;
        }
        void Union(int a , int b)
        {
            int idA = Find(a);
            int idB = Find(b);
            if(idA !=idB)//if a and b are not connected yet
            {
                if(size[a]>size[b]) //if the tree containing a is bigger than move the tree b under the tree contain a;
                {
                    id[b] = idA;
                    size[a] += size[b];
                }
                else
                {
                    id[a] = idB;
                    size[b] += id[a];
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
