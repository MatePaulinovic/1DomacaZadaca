using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public interface IGenericList<X> : IEnumerable<X>
    {
        /// <summary >
        /// Adds an item to the collection .
        /// </ summary >
        void Add(X item);
        /// <summary >
        /// Removes the first occurrence of an item from the collection .
        /// If the item was not found , method does nothing .
        /// </ summary >
        bool Remove(X item);
        /// <summary >
        /// Removes the item at the given index in the collection .
        /// </ summary >
        bool RemoveAt(int index);
        /// <summary >
        /// Returns the item at the given index in the collection .
        /// </ summary >
        X GetElement(int index);
        /// <summary >
        /// Returns the index of the item in the collection .
        /// If item is not found in the collection , method returns -1.
        /// </ summary >
        int IndexOf(X item);
        /// <summary >
        /// Readonly property . Gets the number of items contained in the collection.
        /// </ summary >
        int Count { get; }
        /// <summary >
        /// Removes all items from the collection .
        /// </ summary >
        void Clear();
        /// <summary >
        /// Determines whether the collection contains a specific value .
        /// </ summary >
        bool Contains(X item);
    }

    public class GenericList<X> : IGenericList<X>
    {

        X[] internalStorage;
        int size = 0;

        public GenericList()
        {
            internalStorage = new X[4];
        }

        public GenericList(int initialSize)
        {
            internalStorage = new X[initialSize];
        }

        public void Add(X item)
        {
            if (internalStorage.Length == Count)
            {
                Array.Resize(ref internalStorage, 2 * Count);
            }
            internalStorage[Count] = item;
            size++;
        }

        public void Clear()
        {
            Array.Clear(internalStorage, 0, internalStorage.Length);
            size = 0;
        }

        public bool Contains(X item)//
        {
            if (IndexOf(item) >= 0)
                return true;
            else
                return false;
        }

        public int Count
        {
            get
            {
                return size;
            }
        }

        public X GetElement(int index)
        {
            return internalStorage[index];
        }

        public int IndexOf(X item)
        {
            return Array.IndexOf(internalStorage, item);
        }

        public bool Remove(X item)//
        {
            return RemoveAt(IndexOf(item));
        }

        public bool RemoveAt(int index)
        {
            if (index >= Count || index < 0)
                return false;
            for (int i = index; i < Count; i++)
            {
                internalStorage[i] = internalStorage[i + 1];
            }
            size--;
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator<X> IEnumerable<X>.GetEnumerator()
        {
            return (IEnumerator<X>)GetEnumerator();
        }

        public class GenericListEnumerator<X> : IEnumerator<X>
        {
            GenericList<X> genList;
            int current = -1;

            public GenericListEnumerator(GenericList<X> genList)
            {
                this.genList = genList;
            }

            public X Current
            {
                get
                {
                    return genList.internalStorage[current];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                //not implemented;
            }

            public bool MoveNext()
            {
                if (current < genList.internalStorage.Length - 1)
                {
                    current++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                current = 0;
            }
        }

    }
}