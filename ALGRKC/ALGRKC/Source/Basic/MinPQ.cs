using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Basic
{
    //implements min priority queue via Heap data structure
    public class MinPQ<T> where T : IComparable<T>
    {
        int maxSize;
        int size; //real # of elements in the queue
        T[] pq;

        public MinPQ(int maxSize)
        {
            this.maxSize = maxSize;
            size = 0;
            pq = new T[maxSize + 1]; //we leav T[0] empty, only use from 1 to maxSize element for convenenience
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public int Size()
        {
            return size;
        }

        public void Insert(T value)
        {
            if (size == maxSize)
                throw new Exception("Exceeding the max size!");

            size++;
            pq[size] = value ;

            Swim(size);
        }

        public T DelMin()
        {
            T temp = pq[1];
            //size--;
            if (size > 1)
            {
                pq[1] = pq[size];
                //pq[size] = null;
                size--;
                Sink(1);
            }
            else
                size--;
            

            return temp;

        }

        public T Min()
        {
            if (size == 0)
                throw new Exception("Empty Queue");

            return pq[1];
        }

        public void ChangeKey(int i, T v)
        {
            T originalValue = pq[i];
            pq[i] = v;
            if (originalValue.CompareTo(v)>0)
                Swim(i);
            else if (originalValue.CompareTo(v) < 0)
                Sink(i);
          
        }

        //bottom-up reheapify
        void Swim(int i)
        {
            while((i>1) && Great(i / 2, i))
            {
                exch(i, i / 2); //exchang, the current with the parent;
                i = i / 2;  //get the parent;
            }
        }

        //top-down reheapify
        void Sink(int i)
        {
            while (i*2 <= size )//Only process if the current(i) has child
            {
 
                int j = i * 2; //j is left child now
                if ((j < size) && Less(j + 1, j)) //if right child is smaller than left child, set j to right child
                    j = j + 1;
                if (Great(i, j)) //if the current is greater than the child 
                {
                    exch(i, j);
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
            return pq[i].CompareTo(pq[j]) > 0;
        }
        bool Less(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) < 0;
        }

        void exch(int i, int j)
        {
            T temp = pq[i];
            pq[j] = temp;
            pq[j] = pq[i];
        }
    }
}
