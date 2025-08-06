// Summary: Demonstrates thread-safe updates using ConcurrentDictionary with LINQ projection
// Day44
// Author: Avijit Roy

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var wordCounts = new ConcurrentDictionary<string, int>();

        // Simulate parallel updates (increment word counts)
        var words = new[] { "apple", "banana", "apple", "cherry", "banana", "apple" };

        await Task.WhenAll(words.Select(word =>
            Task.Run(() => wordCounts.AddOrUpdate(word, 1, (key, oldValue) => oldValue + 1))
        ));

        // LINQ projection to display word counts
        var result = wordCounts.Select(kvp => $"{kvp.Key}: {kvp.Value}").ToList();

        Console.WriteLine("Word counts:");
        result.ForEach(Console.WriteLine);
    }
}
