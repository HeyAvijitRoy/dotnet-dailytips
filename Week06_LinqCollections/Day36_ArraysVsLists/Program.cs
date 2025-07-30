// Summary: Comparing LINQ behavior and performance on arrays vs lists
// Day36
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create sample data
        int[] array = Enumerable.Range(1, 1000000).ToArray();
        List<int> list = array.ToList();

        // Measure LINQ on array
        Stopwatch swArray = Stopwatch.StartNew();
        var evenFromArray = array.Where(x => x % 2 == 0).ToList();
        swArray.Stop();
        Console.WriteLine($"LINQ on array took: {swArray.ElapsedMilliseconds} ms");

        // Measure LINQ on list
        Stopwatch swList = Stopwatch.StartNew();
        var evenFromList = list.Where(x => x % 2 == 0).ToList();
        swList.Stop();
        Console.WriteLine($"LINQ on list took: {swList.ElapsedMilliseconds} ms");

        // Behavior is the same — but performance can differ slightly
        Console.WriteLine($"Array result count: {evenFromArray.Count}, List result count: {evenFromList.Count}");
    }
}
// This code demonstrates how LINQ queries behave similarly on both arrays and lists,