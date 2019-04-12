using System;

namespace ClassHomework
{
    internal class Money
    {
        private int first;//номинал купюры
        private int second; //количество купюр

        public int Value { get => first; set => first = value; }
        public int Count { get => second; set => second = value; }

        public int Summ
        {
            get => first * second;
        }

        public void Show()
        {
            Console.WriteLine($"{second} купюр по {first} грн");
        }

        public bool CanBuy(int N)
        {
            return Summ > N;
        }

        public int HowMany(int N)
        {
            return Summ / N;
        }
    }
}