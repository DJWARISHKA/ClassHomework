using System;
using System.Linq;

namespace ClassHomework
{
    internal class MyMatr<T>
        where T : IComparable<T>
    {
        private T[][] _DoubelArray;
        private int n, m;

        public T[][] DoubelArray
        {
            get => _DoubelArray;
            set
            {
                _DoubelArray = value;
                n = _DoubelArray.Count<T[]>();
                m = _DoubelArray[0].Count<T>();
            }
        }

        public int Count { get => n * m; }

        public MyMatr()
        {
            n = m = 0;
        }

        public MyMatr(int n, int m)
        {
            _DoubelArray = new T[n][];
            for (int i = 0; i < n; i++)
                _DoubelArray[i] = new T[m];
        }

        //public void Show()
        //{
        //    for (int i = 0; i < n; i++)
        //        for (int j = 0; j < n; j++)
        //            Console.Write($"{_DoubelArray[i][j]} | ");
        //}

        ///<summary>Выводит границы таблицы</summary>
        private void Baunds(int m, int size, int pos)
        {
            string str = "";
            for (int i = 0; i < size; i++)//string.Join("═", size) не помог, выводило size
                str += "═";
            string[] sign = { "╔╠╚", "╦╬╩", "╗╣╝", str };
            str = sign[0][pos].ToString();
            for (int i = 0; i < m - 1; i++)
            {
                str += sign[3];
                str += sign[1][pos].ToString();
            }
            str += sign[3];
            str += sign[2][pos].ToString();
            Console.WriteLine(str);
        }

        ///<summary>Выводит матрицу</summary>
        public void Show()
        {
            int size = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (_DoubelArray[i][j].ToString().Length > size)
                        size = _DoubelArray[i][j].ToString().Length;
            Baunds(m, size, 0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("║");
                    Console.Write(_DoubelArray[i][j].ToString().PadLeft(size));
                }
                Console.WriteLine("║");
                if (i < n - 1)
                    Baunds(m, size, 1);
                else
                    Baunds(m, size, 2);
            }
        }

        public T[][] SortToMax()
        {
            SotrTree<T> tree = new SotrTree<T>();
            T[][] tmp = new T[n][];
            for (int i = 0; i < n; i++)
            {
                tree.Clear();
                for (int j = 0; j < m; j++)
                    tree.Add(_DoubelArray[i][j]);
                tmp[i] = new T[m];
                tmp[i] = tree.MinToMax(m);
            }
            return tmp;
        }

        public T[][] SortToMin()
        {
            SotrTree<T> tree = new SotrTree<T>();
            T[][] tmp = new T[n][];
            for (int i = 0; i < n; i++)
            {
                tree.Clear();
                for (int j = 0; j < m; j++)
                    tree.Add(_DoubelArray[i][j]);
                tmp[i] = new T[m];
                tmp[i] = tree.MinToMax(m);
            }
            return tmp;
        }
    }
}