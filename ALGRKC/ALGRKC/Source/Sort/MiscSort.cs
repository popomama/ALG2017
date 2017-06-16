using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Sort
{
    class MiscSort
    {
        //sort assumes that each of the n input elements is an integer in the range
        //0 to k, for some integer k. the complexity is O(n+k)
        static void CountingSort(int[] org, int[] result, int k)
        {
            int[] counts = new int[k+1]; //create the counting array
            for (int i = 0; i <= k; i++)
                counts[i] = 0; //initialize the original counts to 0 for each possible values 0 to k

            
            int size = org.Length;

            for (int i = 0; i < size; i++)
                result[i] = 0;

            for (int i = 0; i < size; i++)
                counts[org[i]]++;

            for (int i = 1; i <= k; i++)
                counts[i] = counts[i] + counts[i - 1];//accumulate the counts so that counts[i] now denotes index+1 of the last i in the sorted array

            for(int i=size-1;i>=0;i--)
            {
                result[counts[org[i]] - 1] = org[i];
                counts[org[i]]--;
            }
        }
    }
}
