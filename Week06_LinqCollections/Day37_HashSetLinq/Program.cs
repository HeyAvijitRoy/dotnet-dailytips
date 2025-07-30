// Summary: Using LINQ efficiently with HashSet for fast lookups
// Day37
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main()
    {
        var items = Enumerable.Range(1, 1000000).ToList();
        var filterSet = new HashSet<int>(Enumerable.Range(500000, 100000));

        // Fast lookup with HashSet.Contains in Where
        Stopwatch sw = Stopwatch.StartNew();
        var matched = items.Where(x => filterSet.Contains(x)).ToList();
        sw.Stop();

        Console.WriteLine($"Filtered items count: {matched.Count}");
        Console.WriteLine($"HashSet.Contains + Where took: {sw.ElapsedMilliseconds} ms");

        // Intersect (LINQ) — slower for large collections
        Stopwatch sw2 = Stopwatch.StartNew();
        var intersected = items.Intersect(filterSet).ToList();
        sw2.Stop();

        Console.WriteLine($"Intersect count: {intersected.Count}");
        Console.WriteLine($"LINQ Intersect took: {sw2.ElapsedMilliseconds} ms");
    }
}
// This code demonstrates the performance difference between using HashSet.Contains in a LINQ Where clause
// and using LINQ Intersect for filtering large collections. HashSet provides O(1)