using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        public Book(string name)
        {
            this.name = name;
            grades = new List<double>();
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }
        public void ShowStats()
        {
            double result = 0.0;
            var highGrade = double.MinValue;
            var minGrade = double.MaxValue;
            foreach (var grade in grades)
            {
                highGrade = Math.Max(highGrade, grade);
                minGrade = Math.Min(minGrade, grade);
                result += grade;
            }
            result /= grades.Count;
            Console.WriteLine($"Max: {highGrade}\nMin: {minGrade}\nAVG: {result}");
        }
        private string name;
        private List<double> grades;

    }
}