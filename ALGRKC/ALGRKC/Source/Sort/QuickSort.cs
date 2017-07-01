using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Sort
{
    class QuickSort
    {

        void QC(int[] org, int l, int r)
        {
            if (l >= r)
                return;

            //ideally, we can call the random method to randomly pick up the pivot index, and swap it to the last
            //int p = Ramom(l,r);
            //Swap(org, r, p);

            //find the pivot
            int pivotIndex = Partition(org, l, r);

            //recurse
            QC(org, l, pivotIndex - 1);
            QC(org, pivotIndex + 1, r);
        }

        //return the index of the pivot element
        int Partition(int[] org, int l, int r)
        {
            //a[x]<=pivot when x in [l,i]
            //a[x]>pivot, when x in [i+1,j-1]
            //a[x] un-partitioned, when x in [j,r-1], 
            //a[x]= pivot, when x = r;
            int i = l - 1;
            int pivot = org[r];
            for(int j=l;j<r;j++)
            {
                if(org[j]<pivot)
                {
                    i++;
                    Swap(org, i, j);
                }
                
            }

            Swap(org, i + 1, r);

            return i + 1;

        }

        void Swap(int[] org, int i, int j)
        {
            int temp = org[i];
            org[i] = org[j];
            org[j] = temp;
        }

        //Nuts and Bolts problem
        //it's a variation of the quick Sort
        void Match(int[] nuts, int[] bolts)
        {
            int size = nuts.Length;
            int p = Partition(nuts, 0, size - 1);

        }

    }
}
