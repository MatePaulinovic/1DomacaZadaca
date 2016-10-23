using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public interface IIntegerList
    {
        /// <summary >
        /// Adds an item to the collection .
        /// </ summary >
        void Add(int item);
        /// <summary >
        /// Removes the first occurrence of an item from the collection .
        /// If the item was not found , method does nothing .
        /// </ summary >
        bool Remove(int item);
        /// <summary >
        /// Removes the item at the given index in the collection .
        /// </ summary >
        bool RemoveAt(int index);
        /// <summary >
        /// Returns the item at the given index in the collection .
        /// </ summary >
        int GetElement(int index);
        /// <summary >
        /// Returns the index of the item in the collection .
        /// If item is not found in the collection , method returns -1.
        /// </ summary >
        int IndexOf(int item);
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
        bool Contains(int item);
    }

    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int _size;
        public IntegerList() : this(4)
        {
        }
        public IntegerList(int initialSize)
        {
            if (initialSize <= 0)
            {
                Console.WriteLine("Initial size must be greater than 0");
            }
            else
            {
                _internalStorage = new int[initialSize];
                _size = 0;
            }
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public void Add(int x)
        {
            if (_size == _internalStorage.Length)
            {
                Array.Resize(ref _internalStorage, _size * 2);

            }
            _internalStorage[_size++] = x;
        }

        public void Clear()
        {
            Array.Clear(_internalStorage, 0, _size);
            _size = 0;
        }

        public bool Contains(int item)
        {
            int x = IndexOf(item);
            if (x == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int GetElement(int index)
        {
            if (index < _size)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (item == _internalStorage[i])
                {
                    return i;
                }
            }
            return -1;

        }

        public bool Remove(int item)
        {
            for (int i = 0; i <= _size; i++)
            {
                if (item == _internalStorage[i])
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= _size)
            {
                return false;
            }
            else
            {
                for (int i = index; i < _size - 1; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
                _size--;
                return true;
            }
        }

    }


}