using System;

namespace ClassHomework
{
    internal class SotrTree<T>
        where T : IComparable<T>
    {
        public T Values
        {
            get; set;
        }

        public SotrTree<T> Left
        {
            get; set;
        }

        public SotrTree<T> Right
        {
            get; set;
        }

        public void Clear()
        {
            _root = null;
        }

        private SotrTree<T> _root = null;

        public void Add(T values)
        {
            if (_root == null)
            {
                _root = new SotrTree<T>
                {
                    Values = values
                };
            }
            else
            {
                Add(values, _root);
            }
        }

        public void Add(T values, SotrTree<T> item)
        {
            if (item.Values.CompareTo(values) > 0)
            {
                if (item.Left == null)
                {
                    item.Left = new SotrTree<T>
                    {
                        Values = values
                    };
                }
                else
                {
                    Add(values, item.Left);
                }
            }
            else
            {
                if (item.Right == null)
                {
                    item.Right = new SotrTree<T>
                    {
                        Values = values
                    };
                }
                else
                {
                    Add(values, item.Right);
                }
            }
        }

        public T[] MinToMax(int count)
        {
            if (_root == null)
            {
                Console.WriteLine("Tree is empty");
            }
            else
            {
                i = 0;
                arr = new T[count];
                MinToMax(_root);
            }
            i = 0;
            return arr;
        }

        public void MinToMax(SotrTree<T> item)
        {
            if (item.Left != null)
            {
                MinToMax(item.Left);
            }
            arr[i++] = item.Values;
            if (item.Right != null)
            {
                MinToMax(item.Right);
            }
        }

        private T[] arr;
        private int i;

        public T[] MaxToMin(int count)
        {
            if (_root == null)
            {
                Console.WriteLine("Tree is empty");
            }
            else
            {
                i = 0;
                arr = new T[count];
                MaxToMin(_root);
            }
            i = 0;
            return arr;
        }

        public void MaxToMin(SotrTree<T> item)
        {
            if (item.Right != null)
            {
                MaxToMin(item.Right);
            }
            arr[i++] = item.Values;
            if (item.Left != null)
            {
                MaxToMin(item.Left);
            }
        }
    }
}