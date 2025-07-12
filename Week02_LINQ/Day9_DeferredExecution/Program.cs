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
        // Initialize a list of integers
        var numbers = new List<int> { 1, 2, 3 };

        // Define a LINQ query using Where
        // This is DEFERRED — the filter doesn't run yet
        var query = numbers.Where(n => n > 1);

        // Add another number after defining the query
        // Because of deferred execution, this WILL affect the results
        numbers.Add(4);

        Console.WriteLine("Deferred execution output:");
        foreach (var number in query)
        {
            // Evaluation happens here — filters the updated list
            Console.WriteLine(number); // Outputs: 2, 3, 4
        }

        // Force execution using ToList() — captures current state
        var snapshot = query.ToList();

        Console.WriteLine("\nSnapshot after ToList:");
        foreach (var number in snapshot)
        {
            // Outputs same result as above, but now fixed
            Console.WriteLine(number); // Outputs: 2, 3, 4
        }
    }
}
