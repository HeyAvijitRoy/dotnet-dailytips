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
        var numbers = Enumerable.Range(1, 10);

        foreach (var chunk in numbers.ChunkBy(3))
        {
            Console.WriteLine(string.Join(", ", chunk));
        }
    }
}

public static class LinqExtensions
{
    public static IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> source, int size)
    {
        if (size <= 0) throw new ArgumentException("Size must be greater than 0.", nameof(size));

        var chunk = new List<T>(size);

        foreach (var item in source)
        {
            chunk.Add(item);
            if (chunk.Count == size)
            {
                yield return chunk;
                chunk = new List<T>(size);
            }
        }

        if (chunk.Any())
            yield return chunk;
    }
}
