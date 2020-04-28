using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeBookDelegate(object sender, EventArgs args);

    public abstract class Book : NamedObject
    {
        public Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);
    }
    public class InMemory : Book
    {
        public InMemory(string name) : base(name)
        {
            Name = name;
            grades = new List<double>();
        }
        public event GradeBookDelegate GradeAdded;
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                GradeAdded(this, new EventArgs());
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)} {grade}");
            }
        }
        
        public Statistics GetStats()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            foreach (var grade in grades)
            {
                result.High = Math.Max(result.High, grade);
                result.Low = Math.Min(result.Low, grade);
                result.Average += grade;
            }
            result.Average /= grades.Count;
            
            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter =  'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter =  'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter =  'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
            return result;
        }
        private List<double> grades;
        // private string name;
        // public string Name
        // {
        //     get
        //     {
        //         return name;
        //     }
        //     set
        //     {
        //         if (!string.IsNullOrEmpty(value))
        //             name = value;
        //         else
        //         {
        //             throw new FormatException($"Invalid {nameof(value)}");
        //         }
        //     }
        // }
        public string Name
        {
            get; set;
        }
    }
}