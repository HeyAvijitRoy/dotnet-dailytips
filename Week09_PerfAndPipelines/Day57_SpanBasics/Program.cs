// Summary: Demonstrates Span<T> and ReadOnlySpan<T> for slicing without extra allocations
// Day57
// Author: Avijit Roy

using System;

class Program
{
    static void Main()
    {
        // Example with array
        int[] numbers = { 1, 2, 3, 4, 5 };

        // Create a Span over the entire array
        Span<int> span = numbers;

        // Slice without creating a new array
        Span<int> subSpan = span.Slice(1, 3); // {2,3,4}
        Console.WriteLine("SubSpan: " + string.Join(", ", subSpan.ToArray()));

        // Example with string
        string text = "DotNetWithRoy";

        // Convert to ReadOnlySpan<char> (no new string allocations)
        ReadOnlySpan<char> textSpan = text.AsSpan(0, 6); // "DotNet"
        Console.WriteLine("Text Slice: " + textSpan.ToString());

        // stackalloc for temporary memory on the stack
        Span<int> stackSpan = stackalloc int[3] { 10, 20, 30 };
        Console.WriteLine("StackAlloc Span: " + string.Join(", ", stackSpan.ToArray()));
    }
}
