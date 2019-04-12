using System;

namespace ClassHomework
{
    internal class MyDateTime
    {
        private DateTime date;
        public DateTime Date { get => date; set => date = value; }

        private MyDateTime(int year = 2009, int month = 1, int day = 1)
        {
            date = new DateTime(year, month, day);
        }

        public DateTime LastDay()
        {
            return date.AddDays(-1.0);
        }

        public DateTime NextDay()
        {
            return date.AddDays(1.0);
        }

        public int DayToNextMonth()
        {
            DateTime nextm = new DateTime(date.Year, date.Month + 1, 1);
            nextm = nextm.AddDays(-1.0);//Считаю что конец месяца это 31е
            return nextm.Day - date.Day;
        }
    }
}