// Summary: Demonstrates when ToList() causes unnecessary early execution
// Day 11
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Initial data source
        var numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Define a deferred LINQ query with a side-effect (Console.WriteLine)
        var query = numbers.Where(n =>
        {
            Console.WriteLine($"Filtering: {n}"); // Will only run during enumeration
            return n > 2;
        });

        Console.WriteLine("Without ToList():");

        // LINQ executes here during the foreach — this is deferred execution
        foreach (var n in query)
            Console.WriteLine($"Result: {n}");

        Console.WriteLine("\nWith ToList():");

        // Calling ToList() executes the query immediately (all filtering prints now)
        var snapshot = query.ToList(); // Materializes the results into memory

        // Foreach now works on an already-executed list — no filtering side-effect
        foreach (var n in snapshot)
            Console.WriteLine($"Result: {n}");
    }
}
