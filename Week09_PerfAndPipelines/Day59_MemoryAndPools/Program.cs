// Summary: Demonstrates Memory<T>, IMemoryOwner<T>, and MemoryPool<T> for buffer reuse
// Day59
// Author: Avijit Roy

using System;
using System.Buffers;

class Program
{
    static void Main()
    {
        // Memory<T> example: can be stored and passed around (unlike Span<T>)
        int[] data = { 1, 2, 3, 4, 5 };
        Memory<int> memory = data.AsMemory();

        Console.WriteLine("Original memory:");
        foreach (var item in memory.Span)
            Console.Write(item + " ");
        Console.WriteLine();

        // MemoryPool<T> example
        using IMemoryOwner<byte> owner = MemoryPool<byte>.Shared.Rent(10);
        Memory<byte> rentedMemory = owner.Memory;

        // Fill buffer with values
        for (int i = 0; i < 10; i++)
            rentedMemory.Span[i] = (byte)(i + 65); // ASCII A–J

        Console.WriteLine("Rented buffer: " + System.Text.Encoding.ASCII.GetString(rentedMemory.Span));
        // Buffer is automatically returned when owner.Dispose() is called
    }
}
