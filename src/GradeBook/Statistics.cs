using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average;
        public double High;
        public double Low;
        public double Sum;
        public int Count;
        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            Average = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            High = Math.Max(High, number);
            Low = Math.Min(Low, number);
        }
        public double GetAverage
        {
            get
            {
                return (Sum / Count);
            }
        }
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
    }
}