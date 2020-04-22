using System;
using System.Collections.Generic;

namespace Program
{
    class GradeBook
    {
        static void Main(string[] args)
        {
            var numbers = new double[] {12.1, 11.2, 23.2, 45.4};

            // generic list
            List<double> grades = new List<double>() {12.1, 11.2, 23.2, 45.5};
            grades.Add(56.1);

            double result = 0;
            // for (var i = 0; i < numbers.Length; i++){
            //     result = result + numbers[i];
            // }
            foreach (var number in grades)
            {
                result += number;
            }
            var avg = result / grades.Count;
            Console.WriteLine(avg);
            if (args.Length > 0)
            {
                Console.WriteLine($"Hello {args[0]}");
            }
            else
            {
                Console.WriteLine("Hello World!");            
            }
        }
    }
}