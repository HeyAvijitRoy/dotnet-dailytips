// Summary: Day 50 — Span<T> fundamentals and zero-copy slicing/parsing with ReadOnlySpan<char>
// Day50
// Author: Avijit Roy

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Day 50: Span<T> Fundamentals & Slicing ===\n");

        // 1) Zero-copy string tokenization using ReadOnlySpan<char>
        // We avoid Substring allocations by slicing the input span.
        string csv = "42,17,9,100";
        Console.WriteLine("[1] Zero-copy CSV tokenization:");
        ProcessCsv(csv.AsSpan(), ',');

        // 2) Zero-copy numeric parsing from a delimited string
        Console.WriteLine("\n[2] Zero-copy numeric parsing with TryParse(ReadOnlySpan<char>):");
        int sum = SumCsv(csv.AsSpan());
        Console.WriteLine($"Sum = {sum}");

        // 3) Array slicing with Span<T> (mutations affect the underlying array)
        Console.WriteLine("\n[3] Array slicing via Span<T>:");
        int[] numbers = { 1, 2, 3, 4, 5 };
        Console.WriteLine($"Before: [{string.Join(", ", numbers)}]");

        // Create a window into the array (indexes 1..3)
        Span<int> middle = numbers.AsSpan(1, 3);
        middle[0] = 99;     // modifies numbers[1]
        middle[^1] = -7;    // modifies numbers[3]

        Console.WriteLine($"After:  [{string.Join(", ", numbers)}]");

        // 4) Simple string slicing to demonstrate zero-copy substring-ish behavior
        Console.WriteLine("\n[4] Simple string slicing with AsSpan:");
        string text = "Hello, Span!";
        ReadOnlySpan<char> hello = text.AsSpan(0, 5);   // "Hello"
        ReadOnlySpan<char> worldy = text.AsSpan(7, 5);  // "Span!"
        // NOTE: hello/worldy.ToString() allocates; we only do it here for display.
        Console.WriteLine($"hello='{hello.ToString()}', worldy='{worldy.ToString()}'");

        Console.WriteLine("\nDone.");
    }

    // Tokenize a delimited line using zero-copy slicing.
    // Note: We print tokens with ToString() just to show results (that part allocates).
    static void ProcessCsv(ReadOnlySpan<char> line, char separator)
    {
        int idx;
        int i = 0;
        while (true)
        {
            idx = line.IndexOf(separator);
            ReadOnlySpan<char> token = (idx >= 0) ? line[..idx] : line;

            Console.WriteLine($"Token[{i++}] => '{token.ToString()}'");

            if (idx < 0) break;           // no more separators
            line = line[(idx + 1)..];     // advance past separator
        }
    }

    // Parse integers from a comma-separated line using zero-copy spans.
    static int SumCsv(ReadOnlySpan<char> line)
    {
        int total = 0;
        while (true)
        {
            int idx = line.IndexOf(',');
            ReadOnlySpan<char> token = (idx >= 0) ? line[..idx] : line;

            if (int.TryParse(token, out int value))
                total += value;

            if (idx < 0) break;
            line = line[(idx + 1)..];
        }
        return total;
    }
}
