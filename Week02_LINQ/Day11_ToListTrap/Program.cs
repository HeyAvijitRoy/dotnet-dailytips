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
        var numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Define a query with a side effect to track execution
        var query = numbers.Where(n =>
        {
            Console.WriteLine($"Filtering: {n}");
            return n > 2;
        });

        Console.WriteLine("Without ToList():");
        foreach (var n in query)
            Console.WriteLine($"Result: {n}");

        Console.WriteLine("\nWith ToList():");
        var snapshot = query.ToList(); // Executes query immediately
        foreach (var n in snapshot)
            Console.WriteLine($"Result: {n}");
    }
}
