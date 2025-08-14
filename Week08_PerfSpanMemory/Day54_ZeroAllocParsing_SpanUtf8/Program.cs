// Summary: Day 54 — Zero-allocation parsing from UTF-8 spans using Utf8Parser and Rune-based normalization
// Day54
// Author: Avijit Roy

using System;
using System.Buffers;
using System.Buffers.Text;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Day 54: UTF-8 Spans & Rune ===\n");

        // 1) Zero-alloc CSV integer sum from a UTF-8 byte span
        Console.WriteLine("[1] Sum CSV ints from UTF-8 bytes:");
        string csvText = "12, 7, -3, 1000";
        byte[] csvBytes = Encoding.UTF8.GetBytes(csvText);
        int sum = SumCsvUtf8(csvBytes);
        Console.WriteLine($"Input:  {csvText}");
        Console.WriteLine($"Sum  =  {sum}");

        // 2) Normalize text directly with Rune over UTF-8 bytes
        Console.WriteLine("\n[2] Rune normalization over UTF-8:");
        string raw = "Café 🚀 – año 2025!";
        byte[] rawBytes = Encoding.UTF8.GetBytes(raw);
        string normalized = NormalizeLettersDigitsUpperUtf8(rawBytes);
        Console.WriteLine($"Input : {raw}");
        Console.WriteLine($"Output: {normalized}");

        Console.WriteLine("\nDone.");
    }

    // Parse integers from comma-separated UTF-8 bytes using slicing + Utf8Parser.
    static int SumCsvUtf8(ReadOnlySpan<byte> data)
    {
        int total = 0;
        while (true)
        {
            int idx = data.IndexOf((byte)',');
            ReadOnlySpan<byte> token = (idx >= 0) ? data[..idx] : data;

            // Trim ASCII spaces/tabs around the token (no allocation)
            token = TrimAsciiWhitespace(token);

            if (Utf8Parser.TryParse(token, out int value, out _))
                total += value;

            if (idx < 0) break;
            data = data[(idx + 1)..];
        }
        return total;
    }

    // Keep only letters/digits/space; uppercase via Rune; write back to pooled UTF-8 bytes.
    static string NormalizeLettersDigitsUpperUtf8(ReadOnlySpan<byte> utf8)
    {
        byte[] buffer = ArrayPool<byte>.Shared.Rent(utf8.Length); // output <= input length with our filter
        int write = 0;

        while (!utf8.IsEmpty)
        {
            var status = Rune.DecodeFromUtf8(utf8, out Rune rune, out int consumed);
            if (status != OperationStatus.Done || consumed == 0)
                break;

            // Collapse any whitespace to a single space
            if (Rune.IsWhiteSpace(rune))
            {
                rune = new Rune(' ');
            }

            // Keep letters/digits/space only
            if (Rune.IsLetterOrDigit(rune) || rune.Value == ' ')
            {
                rune = Rune.ToUpperInvariant(rune);
                rune.EncodeToUtf8(buffer.AsSpan(write), out int encoded);
                write += encoded;
            }

            utf8 = utf8[consumed..];
        }

        // Single allocation at boundary to return a string
        string result = Encoding.UTF8.GetString(buffer, 0, write);
        ArrayPool<byte>.Shared.Return(buffer, clearArray: true);
        return result;
    }

    // Trim leading/trailing spaces and tabs in ASCII range.
    static ReadOnlySpan<byte> TrimAsciiWhitespace(ReadOnlySpan<byte> s)
    {
        int start = 0, end = s.Length - 1;

        while (start < s.Length && (s[start] == (byte)' ' || s[start] == (byte)'\t'))
            start++;

        while (end >= start && (s[end] == (byte)' ' || s[end] == (byte)'\t'))
            end--;

        return (start <= end) ? s.Slice(start, end - start + 1) : ReadOnlySpan<byte>.Empty;
    }
}
