// Summary: Demonstrates deferred execution behavior of IQueryable
// Day24
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

namespace Day24_DeferredExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a queryable data source with numbers 1 to 10
            IQueryable<int> numbers = Enumerable.Range(1, 10).AsQueryable();

            // Build a query using .Where() — this does NOT trigger execution.
            // The lambda inside is not run yet.
            var query = numbers.Where(n =>
            {
                Console.WriteLine($"Evaluating: {n}"); // Will only print when enumerated
                return n % 2 == 0; // Keep even numbers
            });

            Console.WriteLine("Query defined, but not yet executed.");

            Console.WriteLine("\nNow iterating over query result:");

            // Execution happens here — the Where clause is evaluated
            foreach (var num in query)
            {
                Console.WriteLine($"Result: {num}");
            }
        }
    }
}
