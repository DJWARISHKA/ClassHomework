using System;

namespace ClassHomework
{
    internal class MyArray<T>
        where T : IComparable<T>
    {
        private T[] _MArray;
        private int n;

        public T[] MArray
        {
            get => _MArray;
            set
            {
                _MArray = value;
                n = _MArray.Length;
            }
        }

        public int Count { get => n; }

        public MyArray(int count)
        {
            if (count < 0) count = 0;
            MArray = new T[count];
            n = count;
        }

        public MyArray(T[] arr)
        {
            MArray = new T[arr.Length];
            n = arr.Length;
            for (int i = 0; i < n; i++)
                _MArray[i] = arr[i];
        }

            public void Show()
        {
            for (int i = 0; i < n; i++)
                Console.Write($"{_MArray[i]} | ");
        }

        public void Input()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Element {i} = ");
                dynamic str = Console.ReadLine();
                _MArray = str;
            }
        }

        public T[] SortToMax()
        {
            SotrTree<T> tree = new SotrTree<T>();
            for (int i = 0; i < n; i++)
            {
                tree.Add(_MArray[i]);
            }
            return tree.MinToMax(n);
        }

        public T[] SortToMin()
        {
            SotrTree<T> tree = new SotrTree<T>();
            for (int i = 0; i < n; i++)
            {
                tree.Add(_MArray[i]);
            }
            return tree.MaxToMin(n);
        }
    }
}