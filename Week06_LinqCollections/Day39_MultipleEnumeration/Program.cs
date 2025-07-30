// Summary: Demonstrating multiple enumeration and how to avoid it with LINQ
// Day39
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static IEnumerable<int> GetData()
    {
        Console.WriteLine("Fetching data...");
        return Enumerable.Range(1, 5).Select(x =>
        {
            Console.WriteLine($"Processing {x}");
            return x;
        });
    }

    static void Main()
    {
        var query = GetData().Where(x => x > 2);

        Console.WriteLine("First enumeration:");
        foreach (var item in query)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nSecond enumeration:");
        foreach (var item in query)
        {
            Console.WriteLine(item);
        }

        // Fix: materialize the result
        Console.WriteLine("\nCached version:");
        var cached = query.ToList();
        foreach (var item in cached)
        {
            Console.WriteLine(item);
        }
    }
}
