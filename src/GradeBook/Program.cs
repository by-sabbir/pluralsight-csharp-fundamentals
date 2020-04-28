using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book1 = new InMemory("My Grade Book");
            book1.GradeAdded += OnGradeAdded;
            EnterGrades(book1);

            // DiskBook
            Console.WriteLine("Disk memory: \n");
            IBook book2 = new DiskBook("First Disk Book");
            EnterGrades(book2);

            var stats = book2.GetStats();
            System.Console.WriteLine(stats.Average);
            System.Console.WriteLine(stats.High);
            System.Console.WriteLine(stats.Low);
            System.Console.WriteLine(stats.Letter);
        }

        private static void EnterGrades(IBook book1)
        {
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
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    // Console.WriteLine("input taken\n");
                }


            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A Greade was added");
        }
    }
}