// Summary: Demonstrates stackalloc with Span<T> and slicing behavior
// Day58
// Author: Avijit Roy

using System;

class Program
{
    static void Main()
    {
        // Using stackalloc to allocate small memory on the stack
        Span<int> buffer = stackalloc int[5] { 1, 2, 3, 4, 5 };
        Console.WriteLine("Stackalloc buffer: " + string.Join(", ", buffer.ToArray()));

        // Slice the stack-allocated span
        Span<int> slice = buffer.Slice(1, 3); // {2,3,4}
        Console.WriteLine("Sliced Span: " + string.Join(", ", slice.ToArray()));

        // Example of safety concern
        // Large allocation can risk stack overflow
        // Uncommenting the next line can crash for very large sizes
        // Span<byte> bigBuffer = stackalloc byte[1_000_000];
    }
}
