// Summary: Demonstrates a custom ChunkBy() LINQ extension
// Day 13
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Sample data: numbers from 1 to 10
        var numbers = Enumerable.Range(1, 10);

        // Use the custom ChunkBy extension to divide into chunks of 3
        foreach (var chunk in numbers.ChunkBy(3))
        {
            // Print each chunk as a comma-separated line
            Console.WriteLine(string.Join(", ", chunk));
        }
    }
}

// Custom LINQ extension class
public static class LinqExtensions
{
    // ChunkBy splits an IEnumerable<T> into smaller chunks of a specified size
    public static IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> source, int size)
    {
        if (size <= 0)
            throw new ArgumentException("Size must be greater than 0.", nameof(size));

        // Temporary list to hold current chunk
        var chunk = new List<T>(size);

        foreach (var item in source)
        {
            chunk.Add(item);

            // When the chunk is full, yield it and start a new one
            if (chunk.Count == size)
            {
                yield return chunk;
                chunk = new List<T>(size);
            }
        }

        // Yield the final chunk if any elements remain
        if (chunk.Any())
            yield return chunk;
    }
}
