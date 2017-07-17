using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Sort
{
    public class QuickSort
    {

        public  void QC(int[] org, int low, int high)
        {
            if (low >= high)
                return;

            //ideally, we can call the random method to randomly pick up the pivot index, and swap it to the last
            //int p = Ramom(low,high);
            //Swap(org, high, p);

            //find the pivot
            int pivotIndex = Partition(org, low, high);

            //recurse
            QC(org, low, pivotIndex - 1);
            QC(org, pivotIndex + 1, high);
        }

        //return the index of the pivot element
        int Partition(int[] org, int low, int high)
        {
            //a[x]<=pivot when x in [l,i]
            //a[x]>pivot, when x in [i+1,j-1]
            //a[x] un-partitioned, when x in [j,r-1], 
            //a[x]= pivot, when x = r;
            int i = low - 1;
            int pivot = org[high];
            for(int j=low;j<high;j++)
            {
                if(org[j]<pivot)
                {
                    i++;
                    Swap(org, i, j);
                }
                
            }

            Swap(org, i + 1, high);

            return i + 1;

        }


        //this is the overloaded Partition function used by the nuts and bolts problem.
        //the pivot value is passed in as we don't select the last element(index) as the pivot
        //we assume all the elements in the org array have different values
        int Partition(int[] org, int low, int high, int pivot)
        {
            //a[x]<=pivot when x in [l,i]
            //a[x]>pivot, when x in [i+1,j-1]
            //a[x] un-partitioned, when x in [j,r-1], 
            //a[x]= pivot, when x = r;
            int i = low - 1;
            //int pivot = org[r];
            for (int j = low; j < high; j++)
            {
                if (org[j] < pivot)
                {
                    i++;
                    Swap(org, i, j);
                }
                else if(org[j]==pivot)
                {
                    Swap(org, high, j); //swap pivot to the right
                    j--;//move the next element to be processed 1 position back so it will be processed next time
                }

            }

            Swap(org, i + 1, high); // move the pivot to the right position

            return i + 1; // return the pivot index

        }

        void Swap(int[] org, int i, int j)
        {
            int temp = org[i];
            org[i] = org[j];
            org[j] = temp;
        }

        //Nuts and Bolts problem
        //it's a variation of the quick Sort
        void MatchPair(int[] nuts, int[] bolts, int low, int high)
        {
            if (low >= high)
                return;

            //int size = l - r + 1;

            int pivot = bolts[high];

            int pivotIndexNuts = Partition(nuts, low, high, pivot); // partition the nuts array and return the pivotIndex
            int pivotIndexBolts = Partition(bolts, low, high, nuts[pivotIndexNuts]);

            MatchPair(nuts, bolts, low, pivotIndexNuts - 1);
            MatchPair(nuts, bolts, pivotIndexNuts + 1, high);
        }

    }
}
