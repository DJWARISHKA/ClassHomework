using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassHomework
{
    public class MyArrayList<T> : IList<T>
        where T : IComparable
    {
        private int _capacity = 100;
        private int _size = 0;
        private T[] _arr;

        public MyArrayList()
        {
            _arr = new T[_capacity];
        }

        public MyArrayList(int capacity)
        {
            _capacity = capacity;
            _arr = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if(index>_size) throw new IndexOutOfRangeException("Index out of range");
                return _arr[index];
            }

            set
            {
                if (index > _size) throw new IndexOutOfRangeException("Index out of range");
                _arr[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        private void ResizeArray()
        {
            T[] tmp = new T[_capacity += (_capacity / 2 + 1)];
            for (int i = 0; i < _size; ++i)
            {
                tmp[i] = _arr[i];
            }
            _arr = tmp;
        }

        public void Add(T value)
        {
            if (_size == _capacity)
            {
                ResizeArray();
            }
            _arr[_size++] = value;
        }

        public void Clear()
        {
            _size = 0;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < _size; ++i)
            {
                if (_arr[i].CompareTo(value) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < _size; ++i)
            {
                array[arrayIndex++] = _arr[i];
            }
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < _size; ++i)
            {
                if (_arr[i].CompareTo(value) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T value)
        {
            if (_size == _capacity)
            {
                ResizeArray();
            }
            for (int i = _size; i > index; --i)
            {
                _arr[i] = _arr[i - 1];
            }
            ++_size;
            _arr[index] = value;
        }

        public bool Remove(T value)
        {
            int index = IndexOf(value);
            if (index < 0) return false;
            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            --_size;
            while (index < _size)
            {
                _arr[index] = _arr[index + 1];
                ++index;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyArrayListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyArrayListEnumerator<T>(this);
        }
    }

    public class MyArrayListEnumerator<T> : IEnumerator<T>
    where T : IComparable
    {
        private MyArrayList<T> _list;
        private int _currentIndex = -1;

        public MyArrayListEnumerator(MyArrayList<T> list)
        {
            _list = list;
        }

        public T Current
        {
            get
            {
                return _list[_currentIndex];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return _list[_currentIndex];
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            ++_currentIndex;
            return _currentIndex < _list.Count;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
    }
}