// Summary: Demonstrates deferred execution in LINQ
// Day 9
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var numbers = new List<int> { 1, 2, 3 };

        var query = numbers.Where(n => n > 1); // Deferred execution

        numbers.Add(4); // This affects the query outcome

        Console.WriteLine("Deferred execution output:");
        foreach (var number in query)
        {
            Console.WriteLine(number); // Will output: 2, 3, 4
        }

        // Eager evaluation snapshot
        var snapshot = query.ToList();
        Console.WriteLine("\nSnapshot after ToList:");
        foreach (var number in snapshot)
        {
            Console.WriteLine(number); // Will also output: 2, 3, 4 (at this point)
        }
    }
}
