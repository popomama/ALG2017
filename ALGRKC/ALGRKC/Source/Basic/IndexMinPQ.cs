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
        T[] keys;//the array stores the keys based on the original index
        int[] pq; //pq[i] = index of the key in the qp array
        int[] qp; //inverse: qp[i] = the index of the key in the priority queue, qp[i] is set to -1 initially to incate the i-th Key is not in the priority queue 

        public IndexMinPQ(int maxSize)
        {
            this.maxSize = maxSize;
            pq = new int[maxSize + 1];
            qp = new int[maxSize + 1];
            keys = new T[maxSize + 1];

            for (int i = 0; i < maxSize + 1; i++)
                qp[i] = -1; //set qp[i] to -1(i.e. i-th element in the original array is not in the pq yet)

            size = 0;

        }

        public bool IsEmpty()
        {
            return size==0;
        }

        //check if the i-th element in the original array is in the MinPQ
        public bool Contains(int i)
        {
            return qp[i] != -1;
        }
        
        //insert the i-th element from the original array into MinPQ
        public void Insert(int i , T key)
        {
            if (size == maxSize)
                throw new Exception("Queue is full!");

            size++;
            qp[i] = size;
            keys[i] = key;
            pq[size] = i;
            Swim(size);
        }

        //change key value of the i-th element in the original array 
        public void ChangeKey(int i, T key)
        {
            T originalKey = keys[i];
            keys[i] = key;

            if(key.CompareTo(originalKey)<0)
                Swim(qp[i]);//question: how do we do Swim and Sink together?
            else　if (key.CompareTo(originalKey)>0)
                Sink(qp[i]);
        }

        public T MinKey()
        {
            return keys[pq[1]];
        }

        //return the index of the Min Key(of the original Array)
        public int MinIndex()
        {
            return pq[1];
        }

        //return the index of min key in the keys[] of the original array
        public int DelMin()
        {
            if (IsEmpty())
                throw new Exception("no min in the empty queue");

            int indexOfMin = pq[1];
            if (size > 1)
            {
                Exch(1, size);
                size--;
                Sink(1);
            }
            else
                size--;
            keys[pq[size + 1]] = default(T);//set to null
            qp[pq[size + 1]] = -1;

            return indexOfMin;
            
        }

        //delete an item with i-th index  from the original keys arrary
        public void Delete(int i)
        {
            int index = qp[i];
            Exch(index, size);
            size--;

            Swim(index);//question : how do we do Swim and Sink together?
            Sink(index);//Either Sink or Swim will run, but not both

            keys[i] = default(T);
            qp[i] = -1;
        }


        //To all the methods below, the parameter i(j) is for the pq[], but not the original array
        //bottom-up reheapify
        void Swim(int i)
        {
            while ((i > 1) && Great(i / 2, i))
            {
                Exch(i, i / 2); //Exchang, the current with the parent;
                i = i / 2;  //get the parent;
            }
        }

        //top-down reheapify
        void Sink(int i)
        {
            while (i * 2 <= size)//Only process if the current(i) has child
            {

                int j = i * 2; //j is left child now
                if ((j < size) && Less(j + 1, j)) //if right child is smaller than left child, set j to right child
                    j = j + 1;
                if (Great(i, j)) //if the current is greater than the child 
                {
                    Exch(i, j);
                    i = j;
                }
                else
                {
                    break;
                }
            }
        }

        bool Great(int i, int j)
        {
            // return pq[i].CompareTo(pq[j]) > 0;
            int indexI = pq[i];
            int indexJ = pq[j];
            return keys[i].CompareTo(keys[j]) > 0;
        }
        bool Less(int i, int j)
        {
            //            return pq[i].CompareTo(pq[j]) < 0;
            int indexI = pq[i];
            int indexJ = pq[j];
            return keys[i].CompareTo(keys[j]) < 0;

        }

        //exchange both the orighnal index and inverse index
        //we will keep the orignal keys[] array unchanged
        void Exch(int i, int j)
        {

            int indexI = pq[i];
            int indexJ = pq[j];

            int temp = indexI;
          //  T tempKey = keys[indexI];

            pq[i] = pq[j];
         //   keys[indexI] = keys[indexJ];


            qp[indexJ] = i;
            qp[indexI] = j;


            pq[j] = temp;
           // keys[indexJ] = tempKey;

            //T temp = pq[i];
            //pq[i] = pq[j];
            //pq[j] = temp;
        }
    }
}
