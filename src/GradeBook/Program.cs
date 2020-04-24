using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book1 = new Book("My Grade Book");
            book1.AddGrade(91.1);
            book1.AddGrade(12.2);
            book1.AddGrade(87.5);
            book1.AddGrade(23.12);

            var stats = book1.GetStats();
            System.Console.WriteLine(stats.Average);
            System.Console.WriteLine(stats.High);
            System.Console.WriteLine(stats.Low);
        }
    }
}