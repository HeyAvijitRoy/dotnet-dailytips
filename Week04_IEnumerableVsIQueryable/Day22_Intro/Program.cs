// Summary: Demonstrates basic difference between IEnumerable and IQueryable
// Day22
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

namespace Day22_Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample data source: list of numbers
            List<int> numbers = Enumerable.Range(1, 10).ToList();

            // IEnumerable: operates in memory
            IEnumerable<int> evenNumbersEnumerable = numbers.Where(n => n % 2 == 0);
            Console.WriteLine("IEnumerable result:");
            foreach (var num in evenNumbersEnumerable)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();

            // IQueryable: typically used with LINQ providers like EF Core
            IQueryable<int> numbersQueryable = numbers.AsQueryable();
            var evenNumbersQueryable = numbersQueryable.Where(n => n % 2 == 0);
            Console.WriteLine("IQueryable result:");
            foreach (var num in evenNumbersQueryable)
            {
                Console.Write(num + " ");
            }
        }
    }
}
