using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGRKC.Source.Basic
{
    public class Bag<T> : IEnumerable<T>
    {
        private Node<T> first;    // beginning of bag
        private int size;               // number of elements in bag

        // helper linked list class
        public  class Node<T>
        {
             public T item;
             public Node<T> next;
        }

        /**
         * Initializes an empty bag.
         */
        public Bag()
        {
            first = null;
            size = 0;
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public int Size()
        {
            return this.size;
        }

        public void Add(T item)
        {
            Node<T> oldFirst = first;
            first = new Node<T>();
            first.item = item;
            first.next = oldFirst;
            size++;
        }


        // Must implement GetEnumerator, which returns a new StreamReaderEnumerator.
        public IEnumerator<T> GetEnumerator()
        {
            return new ListIterator<T>(first);
        }

        // Must also implement IEnumerable.GetEnumerator, but implement as a private method.
        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }

        public class ListIterator<T> : IEnumerator<T>
        {
            private Node<T> current;
            bool bStarted = false;

            public ListIterator(Node<T> first)
            {
                current = first;
                bStarted = false;
            }

            // Implement the IEnumerator(T).Current publicly, but implement 
            // IEnumerator.Current, which is also required, privately.
            public T Current
            {

                get
                {
                    if (current == null)
                    {
                        throw new InvalidOperationException();
                    }

                    return current.item ;
                }
            }

            private object Current1
            {

                get { return this.Current; }
            }

            object IEnumerator.Current
            {
                get { return Current1; }
            }


//            T IEnumerator<T>.Current => throw new NotImplementedException();

            // Implement MoveNext and Reset, which are required by IEnumerator.
            public bool MoveNext()
            {
                //if (current == null)
                //    return false;

                //current = current.next;

                //if (current == null)
                //    return false;
                //return true;
                if (bStarted)
                {
                    if (current == null)
                        return false;
                    current = current.next;
                }
                else
                {
                    bStarted = true;

                }

                if (current == null)
                    return false;
                else
                    return true;
            }

            void IDisposable.Dispose()
            {
               // throw new NotImplementedException();
            }

            //bool IEnumerator.MoveNext()
            //{
            //    throw new NotImplementedException();
            //}

            void IEnumerator.Reset()
            {
                throw new NotImplementedException();
            }
        }

    }
}
