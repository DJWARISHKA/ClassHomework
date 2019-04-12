using System;

namespace ClassHomework
{
    internal class Point
    {
        private int x;
        private int y;

        public Point()
        {
            x = y = 0;
        }

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public int X { get => x; set => x = value >= 0 ? value : x; }
        public int Y { get => y; set => y = value >= 0 ? value : y; }

        public void Show()
        {
            Console.WriteLine($"X = {x}\nY = {y}");
        }

        public double FromZeroToPoint()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public Point ToVector(int a, int b)
        {
            x += a;
            y += b;
            return this;
        }

        static public Point operator *(Point op1, int op2)
        {
            return new Point(op1.x * op2, op1.y * op2);
        }
    }
}