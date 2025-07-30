// Summary: Week 6 Recap - LINQ + Collections Toolkit
// Day42
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // 1. Fast filtering with HashSet
        var items = Enumerable.Range(1, 100).ToList();
        var filter = new HashSet<int> { 20, 40, 60 };
        var fastFiltered = items.Where(x => filter.Contains(x)).ToList();

        // 2. Lookup vs Dictionary
        var people = new[] {
            new { Name = "Alice", Dept = "IT" },
            new { Name = "Bob", Dept = "HR" },
            new { Name = "Charlie", Dept = "IT" }
        };
        var lookup = people.ToLookup(p => p.Dept);
        var dict = people.ToDictionary(p => p.Name);

        // 3. Multiple enumeration risk
        var query = items.Where(x => x % 10 == 0);
        var cached = query.ToList(); // safer

        // 4. Set operations
        var a = new[] { "apple", "banana" };
        var b = new[] { "banana", "cherry" };
        var onlyA = a.Except(b);
        var both = a.Intersect(b);
        var all = a.Union(b);

        Console.WriteLine("Week 6 LINQ + Collections complete!");
    }
}
// This code demonstrates the use of LINQ with collections, including fast filtering with HashSet,
// the difference between Lookup and Dictionary, handling multiple enumeration risks, and set operations.