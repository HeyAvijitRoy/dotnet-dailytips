// Summary: Day 52 — Use Memory<T> + IMemoryOwner<T> with MemoryPool to reduce allocations; slice safely and convert at boundaries
// Day52
// Author: Avijit Roy

using System;
using System.Buffers;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Day 52: Memory<T>, IMemoryOwner<T>, and Pooling ===\n");

        string input = "Avijit Roy, DotNetWithRoy — Memory<T> demo";

        // 1) Uppercase using a pooled Memory<char>, allocating only at the boundary
        Console.WriteLine("[1] Uppercase with MemoryPool<char>:");
        string upper = UppercaseWithPool(input.AsSpan());
        Console.WriteLine($"Input : {input}");
        Console.WriteLine($"Upper : {upper}");

        // 2) UTF-8 encode into a pooled Memory<byte>, slice to bytesWritten
        Console.WriteLine("\n[2] UTF-8 encode with MemoryPool<byte> + TryGetBytes:");
        Utf8EncodeAndInspect(input.AsSpan());

        // 3) Safe slicing within the owner's lifetime (demonstration)
        Console.WriteLine("\n[3] Slicing within owner scope (no copies):");
        DemoSlicingWithMemoryPool("Hello Memory World".AsSpan());

        Console.WriteLine("\nDone.");
    }

    // Uppercase using a rented Memory<char>; only one allocation at the end for display/persistence.
    static string UppercaseWithPool(ReadOnlySpan<char> input)
    {
        using var owner = MemoryPool<char>.Shared.Rent(input.Length);
        var span = owner.Memory.Span;

        for (int i = 0; i < input.Length; i++)
            span[i] = char.ToUpperInvariant(input[i]);

        // Boundary conversion to a stable type
        return new string(span[..input.Length]);
    }

    // Encode text into a rented Memory<byte> and inspect bytes without intermediate arrays.
    static void Utf8EncodeAndInspect(ReadOnlySpan<char> input)
    {
        int max = Encoding.UTF8.GetMaxByteCount(input.Length);
        using var owner = MemoryPool<byte>.Shared.Rent(max);
        var buffer = owner.Memory;

        if (!Encoding.UTF8.TryGetBytes(input, buffer.Span, out int written))
        {
            Console.WriteLine("Encoding failed.");
            return;
        }

        var used = buffer.Slice(0, written); // no copy
        Console.WriteLine($"Bytes written: {written}");
        Console.Write("First bytes: ");
        var span = used.Span;
        for (int i = 0; i < Math.Min(written, 8); i++)
            Console.Write((i > 0 ? "," : "") + span[i]);
        Console.WriteLine();
    }

    // Show slicing within the owner's lifetime. Avoid returning Memory<T> that outlives 'owner'.
    static void DemoSlicingWithMemoryPool(ReadOnlySpan<char> text)
    {
        using var owner = MemoryPool<char>.Shared.Rent(text.Length);
        text.CopyTo(owner.Memory.Span);

        // Slice to the word "Memory"
        ReadOnlyMemory<char> mem = owner.Memory;
        int start = text.IndexOf("Memory", StringComparison.Ordinal);
        if (start >= 0)
        {
            var slice = mem.Slice(start, "Memory".Length);
            Console.WriteLine($"Slice: '{new string(slice.Span)}'");
        }

        // All operations remain within this using block.
        // Do NOT return 'mem' or 'slice' beyond this lifetime if they reference pooled memory.
    }
}
