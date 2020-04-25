using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book1 = new Book("My Grade Book");

            while (true)
            {
                Console.WriteLine("Enter grade or 'q' to quite: ");
                var ans = Console.ReadLine();
                if (ans == "q")
                    break;
                try
                {
                    var grade = double.Parse(ans);
                    book1.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally{
                    Console.WriteLine("input taken\n");
                }


            }
            System.Console.WriteLine("Printing Stats: \n");


            var stats = book1.GetStats();
            System.Console.WriteLine(stats.Average);
            System.Console.WriteLine(stats.High);
            System.Console.WriteLine(stats.Low);
            System.Console.WriteLine(stats.Letter);
        }
    }
}