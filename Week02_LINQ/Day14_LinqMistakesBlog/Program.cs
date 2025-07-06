// Summary: Example code showing common LINQ mistakes and fixes
// Day14
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var numbers = Enumerable.Range(1, 5);

        // 1. Unnecessary ToList()
        var query = numbers.Where(n => n > 2);
        var firstRun = query.ToList();  // forces execution
        var secondRun = query.ToList(); // executes again (bad if expensive)

        // 2. Correct usage: cache the result
        var cached = numbers.Where(n => n > 2).ToList();

        // 3. Forgetting deferred execution
        var deferred = numbers.Where(n => n > 2); // doesn't run until iterated

        // 4. Select vs SelectMany
        var nested = numbers.Select(n => new List<int> { n, n * 2 });
        var flat = numbers.SelectMany(n => new List<int> { n, n * 2 });

        // 5. GroupBy without projection
        var groups = numbers.GroupBy(n => n % 2);
        foreach (var group in groups)
            Console.WriteLine($"Key {group.Key}: {string.Join(", ", group)}");
    }
}
