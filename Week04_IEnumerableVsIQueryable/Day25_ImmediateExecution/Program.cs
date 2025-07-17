// Summary: Demonstrates immediate execution of IEnumerable when using ToList
// Day25
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

namespace Day25_ImmediateExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a sequence of integers from 1 to 10
            IEnumerable<int> source = Enumerable.Range(1, 10);

            Console.WriteLine("Applying .Where(), but not executed yet.");

            // Apply a filter using .Where(), but this is deferred execution.
            // No iteration happens until the sequence is enumerated.
            var filtered = source.Where(n =>
            {
                Console.WriteLine($"Filtering: {n}"); // Will print only when iterated
                return n % 2 == 0; // Keep even numbers
            });

            Console.WriteLine("\nNow calling .ToList() to force execution:");

            // ToList() triggers immediate execution — the filtering lambda runs now.
            var resultList = filtered.ToList();

            Console.WriteLine("\nResult:");

            // The resultList is a materialized list, already filtered and fixed.
            foreach (var n in resultList)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("\nTrying to chain more filters — too late!");

            // Adding a second filter, but this happens on the already-executed resultList.
            // No original source or lazy eval is involved anymore.
            var doubleFilter = resultList.Where(n =>
            {
                Console.WriteLine($"Re-filtering: {n}"); // Now only runs for even numbers
                return n > 4;
            });

            // Final output — second filter applied to already-realized list
            foreach (var n in doubleFilter)
            {
                Console.WriteLine($"Final Result: {n}");
            }
        }
    }
}
