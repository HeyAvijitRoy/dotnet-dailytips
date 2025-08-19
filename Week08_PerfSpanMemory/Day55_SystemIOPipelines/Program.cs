// Summary: Day 55 — System.IO.Pipelines basics: chunked producer + line-parsing consumer with minimal copying
// Day55
// Author: Avijit Roy

using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("=== Day 55: System.IO.Pipelines — Readers/Writers Basics ===\n");

        var pipe = new Pipe();

        // Run producer and consumer concurrently
        var produce = ProduceAsync(pipe.Writer);
        var consume = ConsumeAsync(pipe.Reader);

        await Task.WhenAll(produce, consume);

        Console.WriteLine("\nDone.");
    }

    // PRODUCER: Write UTF-8 lines in fragmented chunks to simulate network I/O.
    static async Task ProduceAsync(PipeWriter writer)
    {
        string[] lines =
        {
            "alpha",
            "beta",
            "gamma",
            "δelta 🚀", // includes non-ASCII to show UTF-8 handling
        };

        foreach (var line in lines)
        {
            // Encode the line + newline
            var bytes = Encoding.UTF8.GetBytes(line + "\n");

            // Write in small chunks (simulate partial socket sends)
            int i = 0;
            while (i < bytes.Length)
            {
                int chunk = Math.Min(3, bytes.Length - i); // tiny chunks on purpose
                var span = writer.GetSpan(chunk).Slice(0, chunk);
                bytes.AsSpan(i, chunk).CopyTo(span);
                writer.Advance(chunk);
                i += chunk;

                // Flush so the reader sees progress
                var result = await writer.FlushAsync();
                if (result.IsCompleted) break;
            }
        }

        await writer.FlushAsync();
        await writer.CompleteAsync();
    }

    // CONSUMER: Read, find newline boundaries, and print complete lines.
    static async Task ConsumeAsync(PipeReader reader)
    {
        while (true)
        {
            ReadResult read = await reader.ReadAsync();
            var buffer = read.Buffer;

            while (TryReadLine(ref buffer, out ReadOnlySequence<byte> line))
            {
                // Boundary allocation for display (safe to do once per message)
                Console.WriteLine($"Line: {Encoding.UTF8.GetString(line)}");
            }

            // Tell the Pipe how much we consumed/examined
            reader.AdvanceTo(buffer.Start, buffer.End);

            if (read.IsCompleted)
            {
                // Drain any trailing data without newline as a final line
                if (!buffer.IsEmpty && buffer.Length > 0)
                {
                    Console.WriteLine($"Line: {Encoding.UTF8.GetString(buffer)}");
                }
                break;
            }
        }

        await reader.CompleteAsync();
    }

    // Find a '\n' line ending. Handles optional '\r\n' by trimming '\r'.
    static bool TryReadLine(ref ReadOnlySequence<byte> buffer, out ReadOnlySequence<byte> line)
    {
        var pos = buffer.PositionOf((byte)'\n');
        if (pos == null)
        {
            line = default;
            return false;
        }

        // Slice [0, pos) as the line (exclude '\n')
        line = buffer.Slice(0, pos.Value);

        // Trim trailing '\r' if present (CRLF)
        if (!line.IsEmpty)
        {
            var last = line.Slice(line.Length - 1, 1);
            if (last.FirstSpan.Length > 0 && last.FirstSpan[0] == (byte)'\r')
                line = line.Slice(0, line.Length - 1);
        }

        // Move buffer past the newline
        var next = buffer.GetPosition(1, pos.Value);
        buffer = buffer.Slice(next);
        return true;
    }
}
