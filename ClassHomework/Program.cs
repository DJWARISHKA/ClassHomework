using System;

namespace ClassHomework
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random rand = new Random();
            MyMatr<double> MyMas = new MyMatr<double>(5, 10);
            double[][] mas = new double[5][];
            for (int i = 0; i < 5; i++)
                mas[i] = new double[10];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 10; j++)
                    mas[i][j] = rand.Next(0, 200) * 0.3;
            MyMas.DoubelArray = mas;
            MyMas.Show();
            Console.WriteLine("\n---------------------");
            MyMas.DoubelArray = MyMas.SortToMax();
            MyMas.Show();
        }
    }
}