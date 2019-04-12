using System;

namespace ClassHomework
{
    internal class Rectangle : IFigure
    {
        private int a;
        private int b;

        public int A { get => a; set => a = Math.Abs(value); }
        public int B { get => b; set => b = Math.Abs(value); }

        private Rectangle(int A, int B)
        {
            a = A;
            b = B;
        }

        public void Show()
        {
            Console.WriteLine($"A = {a}\nB = {b}");
        }

        public int Perimeter()
        {
            return (a + b) * 2;
        }

        public double Square()
        {
            return a * b;
        }

        static public Rectangle operator *(Rectangle op1, int op2)
        {
            return new Rectangle(op1.a * op2, op1.b * op2);
        }
    }
}