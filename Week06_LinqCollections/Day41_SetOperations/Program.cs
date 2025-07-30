// Summary: Demonstrating Except, Intersect, and Union LINQ operations
// Day41
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var listA = new[] { "apple", "banana", "cherry" };
        var listB = new[] { "banana", "cherry", "date" };

        var onlyInA = listA.Except(listB);
        var common = listA.Intersect(listB);
        var combined = listA.Union(listB);

        Console.WriteLine("Only in A:");
        foreach (var item in onlyInA) Console.WriteLine(item);

        Console.WriteLine("\nCommon:");
        foreach (var item in common) Console.WriteLine(item);

        Console.WriteLine("\nCombined:");
        foreach (var item in combined) Console.WriteLine(item);
    }
}
