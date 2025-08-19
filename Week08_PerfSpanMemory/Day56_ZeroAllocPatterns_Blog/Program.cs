// Summary: Day 56 — Practical zero-allocation patterns: UTF-8 parsing, Rune normalization, pooled buffers, and Pipelines end-to-end
// Day56
// Author: Avijit Roy

using System;
using System.Buffers;
using System.Buffers.Text;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;

class Program
{
    // This sample simulates a network text stream:
    //  - Producer writes UTF-8 lines in tiny chunks.
    //  - Consumer parses each line zero-alloc: sums CSV ints via Utf8Parser,
    //    normalizes text with Rune (letters/digits/space, uppercase),
    //    and builds an output line using IBufferWriter<char> (no StringBuilder churn).
    static async Task Main()
    {
        Console.WriteLine("=== Day 56: Zero-allocation patterns (end-to-end) ===\n");

        var pipe = new Pipe();
        var producer = ProduceAsync(pipe.Writer);
        var consumer = ConsumeAsync(pipe.Reader);

        await Task.WhenAll(producer, consumer);

        Console.WriteLine("\nDone.");
    }

    // PRODUCER: Emit fragmented UTF-8 lines to mimic socket behavior.
    static async Task ProduceAsync(PipeWriter writer)
    {
        string[] lines =
        {
            "name=Café Rocket,val=12,7,-3,1000",
            "name=alpha beta,val=1,2,3,4,5",
            "name=Δelta Mix,val=42,17,9",
        };

        foreach (var line in lines)
        {
            var bytes = Encoding.UTF8.GetBytes(line + "\n"); // newline-delimited
            int i = 0;
            while (i < bytes.Length)
            {
                int chunk = Math.Min(4, bytes.Length - i); // deliberately tiny chunks
                var span = writer.GetSpan(chunk).Slice(0, chunk);
                bytes.AsSpan(i, chunk).CopyTo(span);
                writer.Advance(chunk);
                i += chunk;

                var flush = await writer.FlushAsync();
                if (flush.IsCompleted) break;
            }
        }

        await writer.CompleteAsync();
    }

    // CONSUMER: Read lines with Pipelines, parse/normalize with UTF-8 spans, format with IBufferWriter<char>.
    static async Task ConsumeAsync(PipeReader reader)
    {
        while (true)
        {
            ReadResult rr = await reader.ReadAsync();
            var buffer = rr.Buffer;

            while (TryReadLine(ref buffer, out ReadOnlySequence<byte> lineBytes))
            {
                // 1) Extract name=... and val=... CSV pieces from UTF-8 bytes (no ToString yet)
                var (nameUtf8, valuesUtf8) = SplitFields(lineBytes);

                // 2) Normalize the name using Rune (keep letters/digits/space, uppercase)
                string name = NormalizeLettersDigitsUpperUtf8(nameUtf8);

                // 3) Sum the CSV integers directly from UTF-8 using Utf8Parser
                int sum = SumCsvUtf8(valuesUtf8);

                // 4) Format the result with IBufferWriter<char> (zero temp strings)
                string output = FormatResult(name, sum);
                Console.WriteLine(output);
            }

            reader.AdvanceTo(buffer.Start, buffer.End);
            if (rr.IsCompleted) break;
        }

        await reader.CompleteAsync();
    }

    // Find newline; handle optional CRLF.
    static bool TryReadLine(ref ReadOnlySequence<byte> buffer, out ReadOnlySequence<byte> line)
    {
        var pos = buffer.PositionOf((byte)'\n');
        if (pos == null) { line = default; return false; }

        line = buffer.Slice(0, pos.Value);
        // Trim '\r' if CRLF
        if (!line.IsEmpty)
        {
            var last = line.Slice(line.Length - 1, 1);
            if (last.FirstSpan.Length > 0 && last.FirstSpan[0] == (byte)'\r')
                line = line.Slice(0, line.Length - 1);
        }

        buffer = buffer.Slice(buffer.GetPosition(1, pos.Value)); // skip '\n'
        return true;
    }

    // Split "name=...,val=..." into (nameUtf8, valuesCsvUtf8) without allocations.
    static (ReadOnlySpan<byte> name, ReadOnlySpan<byte> values) SplitFields(ReadOnlySequence<byte> line)
    {
        // For simplicity, materialize a small contiguous span (lines are short in this demo).
        Span<byte> temp = stackalloc byte[(int)line.Length];
        line.CopyTo(temp);

        ReadOnlySpan<byte> s = temp;
        // Find "name=" prefix
        int nameStart = s.IndexOf(Encoding.ASCII.GetBytes("name="));
        int valStart  = s.IndexOf(Encoding.ASCII.GetBytes(",val="));
        if (nameStart < 0 || valStart < 0) return (ReadOnlySpan<byte>.Empty, ReadOnlySpan<byte>.Empty);

        var name = s.Slice(nameStart + 5, valStart - (nameStart + 5));
        var values = s.Slice(valStart + 5);
        return (name, values);
    }

    // Normalize UTF-8 bytes: keep letters/digits/space, uppercase via Rune; single allocation at boundary.
    static string NormalizeLettersDigitsUpperUtf8(ReadOnlySpan<byte> utf8)
    {
        byte[] pooled = ArrayPool<byte>.Shared.Rent(utf8.Length); // output <= input for this filter
        int write = 0;

        while (!utf8.IsEmpty)
        {
            var status = Rune.DecodeFromUtf8(utf8, out Rune rune, out int consumed);
            if (status != OperationStatus.Done || consumed == 0) break;

            // Map whitespace → space, drop others
            if (Rune.IsWhiteSpace(rune)) rune = new Rune(' ');

            if (Rune.IsLetterOrDigit(rune) || rune.Value == ' ')
            {
                rune = Rune.ToUpperInvariant(rune);
                rune.EncodeToUtf8(pooled.AsSpan(write), out int encoded);
                write += encoded;
            }

            utf8 = utf8[consumed..];
        }

        string result = Encoding.UTF8.GetString(pooled, 0, write); // boundary allocation
        ArrayPool<byte>.Shared.Return(pooled, clearArray: true);
        return result;
    }

    // Sum integers from comma-separated UTF-8 bytes (trim ASCII spaces/tabs only).
    static int SumCsvUtf8(ReadOnlySpan<byte> data)
    {
        int total = 0;
        while (true)
        {
            int idx = data.IndexOf((byte)',');
            var token = (idx >= 0) ? data[..idx] : data;

            token = TrimAsciiWhitespace(token);
            if (Utf8Parser.TryParse(token, out int value, out _))
                total += value;

            if (idx < 0) break;
            data = data[(idx + 1)..];
        }
        return total;
    }

    static ReadOnlySpan<byte> TrimAsciiWhitespace(ReadOnlySpan<byte> s)
    {
        int start = 0, end = s.Length - 1;
        while (start < s.Length && (s[start] == (byte)' ' || s[start] == (byte)'\t')) start++;
        while (end >= start && (s[end] == (byte)' ' || s[end] == (byte)'\t')) end--;
        return (start <= end) ? s.Slice(start, end - start + 1) : ReadOnlySpan<byte>.Empty;
    }

    // Format output using IBufferWriter<char> to avoid repeated resizing.
    static string FormatResult(string name, int sum)
    {
        var w = new ArrayBufferWriter<char>();

        // "NAME:" (uppercased already) + space
        name.AsSpan().CopyTo(w.GetSpan(name.Length));
        w.Advance(name.Length);
        w.GetSpan(2)[0] = ':'; w.Advance(1);
        w.GetSpan(2)[0] = ' '; w.Advance(1);

        // "SUM=" + number
        const string SUM = "SUM=";
        SUM.AsSpan().CopyTo(w.GetSpan(SUM.Length));
        w.Advance(SUM.Length);

        Span<char> num = w.GetSpan(12); // enough for int32
        if (!sum.TryFormat(num, out int written)) written = sum.ToString().AsSpan().CopyTo(num);
        w.Advance(written);

        return new string(w.WrittenSpan); // boundary allocation
    }
}
