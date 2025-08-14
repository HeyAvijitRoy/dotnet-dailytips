// Summary: Day 51 — ReadOnlySpan<char> + stackalloc for zero-copy parsing and safe text normalization
// Day51
// Author: Avijit Roy

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Day 51: ReadOnlySpan<char> & stackalloc ===\n");

        // 1) Normalize an email using zero-copy slicing & minimal allocation at the boundary
        string rawEmail = "   USER.Name+news@example.COM   ";
        Console.WriteLine("[1] Email normalization with ReadOnlySpan<char>:");
        string normalized = NormalizeEmail(rawEmail.AsSpan());
        Console.WriteLine($"Input:  '{rawEmail}'");
        Console.WriteLine($"Output: '{normalized}'");

        // 2) Use a stackalloc buffer to compact whitespace, then parse CSV ints with TryParse(ReadOnlySpan<char>)
        Console.WriteLine("\n[2] stackalloc scratch buffer + zero-copy parsing:");
        string messy = "  9,  10,11 , 12 ";
        Console.WriteLine($"Input:    '{messy}'");
        string compact = CompactWhitespaceToNewString(messy.AsSpan());
        Console.WriteLine($"Compacted: '{compact}'");
        int sum = SumCsv(compact.AsSpan());
        Console.WriteLine($"Sum = {sum}");

        Console.WriteLine("\nDone.");
    }

    // Normalizes an email:
    // - Trims spaces
    // - Removes '.' from local part
    // - Removes '+tag' from local part
    // - Lowercases domain
    // Uses ReadOnlySpan<char> to avoid intermediate strings until the final result.
    static string NormalizeEmail(ReadOnlySpan<char> email)
    {
        email = email.Trim(); // span-based trim (no allocation)

        int at = email.IndexOf('@');
        if (at < 0)
        {
            // Not an email; return a boundary allocation for display
            return email.ToString();
        }

        ReadOnlySpan<char> local = email[..at];
        ReadOnlySpan<char> domain = email[(at + 1)..];

        // Process local part into a stack buffer (small & scoped)
        Span<char> localBuf = stackalloc char[local.Length];
        int write = 0;
        bool drop = false; // after '+', drop everything

        for (int i = 0; i < local.Length; i++)
        {
            char c = local[i];
            if (drop) continue;
            if (c == '+') { drop = true; continue; }
            if (c == '.') continue; // Gmail-style dot folding
            localBuf[write++] = char.ToLowerInvariant(c);
        }

        // Lowercase domain safely (copy into a stack buffer, then new string at the boundary)
        Span<char> domainBuf = stackalloc char[domain.Length];
        for (int i = 0; i < domain.Length; i++)
            domainBuf[i] = char.ToLowerInvariant(domain[i]);

        // Allocate final string at the boundary for output or persistence
        return $"{new string(localBuf[..write])}@{new string(domainBuf)}";
    }

    // Compacts all Unicode whitespace in a stack buffer and returns a new string
    // Note: We allocate *once* at the boundary via new string(span[..len]).
    static string CompactWhitespaceToNewString(ReadOnlySpan<char> input)
    {
        Span<char> buf = stackalloc char[input.Length];
        input.CopyTo(buf);

        int write = 0;
        for (int i = 0; i < input.Length; i++)
        {
            char c = buf[i];
            if (!char.IsWhiteSpace(c))
                buf[write++] = c;
        }
        return new string(buf[..write]);
    }

    // Zero-copy integer sum from CSV using ReadOnlySpan<char>
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
