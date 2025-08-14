// Summary: Day 53 — Use ArrayPool<T> for reusable buffers and IBufferWriter<T> for growable, allocation-light writes
// Day53
// Author: Avijit Roy

using System;
using System.Buffers;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Day 53: ArrayPool<T> & IBufferWriter<T> ===\n");

        // 1) Base64 encode using pooled buffers (byte[] and char[])
        Console.WriteLine("[1] Base64 encode with ArrayPool:");
        string input = "ArrayPool + IBufferWriter — fast paths, fewer allocations!";
        string b64 = Base64EncodeWithPools(input);
        Console.WriteLine($"Input : {input}");
        Console.WriteLine($"Base64: {b64}");

        // 2) Build CSV using IBufferWriter<char> (ArrayBufferWriter<char>)
        Console.WriteLine("\n[2] CSV build with IBufferWriter<char>:");
        int[] values = { 42, 7, 1024, -3, 99 };
        string csv = BuildCsv(values);
        Console.WriteLine($"CSV   : {csv}");

        Console.WriteLine("\nDone.");
    }

    // Base64 encode text with pooled intermediate buffers.
    // Allocate only once at the end when creating the final string.
    static string Base64EncodeWithPools(string text)
    {
        var enc = Encoding.UTF8;

        // Rent bytes large enough for the UTF-8 encoding of 'text'
        int byteCount = enc.GetByteCount(text);
        byte[] bytes = ArrayPool<byte>.Shared.Rent(byteCount);

        try
        {
            int writtenBytes = enc.GetBytes(text, 0, text.Length, bytes, 0);

            // Compute required Base64 chars: ((n + 2) / 3) * 4
            int charCount = ((writtenBytes + 2) / 3) * 4;
            char[] chars = ArrayPool<char>.Shared.Rent(charCount);

            try
            {
                if (!Convert.TryToBase64Chars(bytes.AsSpan(0, writtenBytes), chars, out int charsWritten))
                {
                    // Fallback (should not happen if charCount is sufficient)
                    return Convert.ToBase64String(bytes, 0, writtenBytes);
                }

                // Boundary allocation for result
                return new string(chars, 0, charsWritten);
            }
            finally
            {
                // Clear sensitive data when returning to the pool
                ArrayPool<char>.Shared.Return(chars, clearArray: true);
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(bytes, clearArray: true);
        }
    }

    // Build a CSV string using IBufferWriter<char> without intermediate strings or repeated resizing.
    static string BuildCsv(ReadOnlySpan<int> numbers)
    {
        var writer = new ArrayBufferWriter<char>();

        for (int i = 0; i < numbers.Length; i++)
        {
            // Reserve enough room to format an Int32 (up to 11 chars with sign)
            Span<char> span = writer.GetSpan(11);
            if (!numbers[i].TryFormat(span, out int written))
            {
                // In practice TryFormat should succeed; this is defensive
                written = numbers[i].ToString().AsSpan().CopyTo(span);
            }
            writer.Advance(written);

            if (i < numbers.Length - 1)
            {
                writer.GetSpan(1)[0] = ',';
                writer.Advance(1);
            }
        }

        // One allocation at the boundary to produce a string for display/persistence
        return new string(writer.WrittenSpan);
    }
}
