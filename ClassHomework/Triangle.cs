using System;

namespace ClassHomework
{
    internal class Triangle : IFigure
    {
        private int a;
        private int b;
        private int c;

        public int A { get => a; set => a = Math.Abs(value); }
        public int B { get => b; set => b = Math.Abs(value); }
        public int C { get => c; set => c = Math.Abs(value); }

        private Triangle()
        {
            a = b = c = 0;
        }

        private Triangle(int A, int B, int C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public bool Exist
        {
            get
            {
                if (a >= b + c || b >= a + c || c >= b + a || a == 0 || b == 0 || c == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public void Show()
        {
            Console.WriteLine($"A = {a}\nB = {b}\nC = {c}");
        }

        public int Perimeter()
        {
            return a + b + c;
        }

        public double Square()
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        static public Triangle operator *(Triangle op1, int op2)
        {
            return new Triangle(op1.a * op2, op1.b * op2, op1.c * op2);
        }
    }
}