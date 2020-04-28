using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeBookDelegate(object sender, EventArgs args);

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStats();
        string Name { get; }
        event GradeBookDelegate GradeAdded;
    }
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }
        public abstract event GradeBookDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStats();
    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeBookDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            
        }

        public override Statistics GetStats()
        {
            var result = new Statistics();
            using(var reader = File.OpenText($"{this}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null){
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
    public class InMemory : Book, IBook
    {
        public InMemory(string name) : base(name)
        {
            Name = name;
            grades = new List<double>();
        }
        public override event GradeBookDelegate GradeAdded;
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
        
        public override Statistics GetStats()
        {
            var result = new Statistics();
            
            foreach (var grade in grades)
            {
                result.Add(grade);
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