// Summary: LINQ operations on Dictionary - keys, values, and full pairs
// Day38
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var data = new Dictionary<string, int>
        {
            { "apple", 5 },
            { "banana", 12 },
            { "cherry", 7 },
            { "date", 20 },
            { "elderberry", 3 }
        };

        // Filter by value using full KeyValuePair
        var highStock = data.Where(kv => kv.Value > 10).ToList();
        Console.WriteLine("Fruits with stock > 10:");
        foreach (var kv in highStock)
            Console.WriteLine($"{kv.Key} = {kv.Value}");

        // Just keys with stock > 10
        var keysOnly = data.Where(kv => kv.Value > 10).Select(kv => kv.Key).ToList();
        Console.WriteLine("\nKeys only:");
        keysOnly.ForEach(Console.WriteLine);

        // Using .Values (faster, but no key access)
        var evenStocks = data.Values.Where(v => v % 2 == 0).ToList();
        Console.WriteLine("\nEven stock values:");
        evenStocks.ForEach(Console.WriteLine);
    }
}
