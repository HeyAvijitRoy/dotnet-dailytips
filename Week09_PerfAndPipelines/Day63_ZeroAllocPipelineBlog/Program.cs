// Summary: Blog demo — building a zero-allocation CSV/JSON pipeline in .NET
// Day63
// Author: Avijit Roy

using System;
using System.Buffers;
using System.Buffers.Text;
using System.IO.Pipelines;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var pipe = new Pipe();

        // Simulate producer writing JSON messages into the pipeline
        _ = Task.Run(async () =>
        {
            string[] messages = {
                "{\"id\":1,\"name\":\"Roy\"}",
                "{\"id\":2,\"name\":\"Avijit\"}"
            };

            foreach (var msg in messages)
            {
                byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
                data.CopyTo(pipe.Writer.GetSpan(data.Length));
                pipe.Writer.Advance(data.Length);
                await pipe.Writer.FlushAsync();
            }

            await pipe.Writer.CompleteAsync();
        });

        // Consumer: process JSON messages without extra allocations
        while (true)
        {
            ReadResult result = await pipe.Reader.ReadAsync();
            var buffer = result.Buffer;

            var sequence = buffer;
            SequencePosition? pos;
            while ((pos = sequence.PositionOf((byte)'\n')) != null)
            {
                var slice = sequence.Slice(0, pos.Value);
                ProcessJson(slice);
                sequence = sequence.Slice(sequence.GetPosition(1, pos.Value));
            }

            pipe.Reader.AdvanceTo(sequence.Start, sequence.End);

            if (result.IsCompleted) break;
        }

        await pipe.Reader.CompleteAsync();
    }

    static void ProcessJson(ReadOnlySequence<byte> slice)
    {
        var reader = new Utf8JsonReader(slice);
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
                Console.Write($"{reader.GetString()}: ");
            else if (reader.TokenType == JsonTokenType.String)
                Console.WriteLine(reader.GetString());
            else if (reader.TokenType == JsonTokenType.Number)
            {
                if (Utf8Parser.TryParse(reader.ValueSpan, out int val, out _))
                    Console.WriteLine(val);
            }
        }
        Console.WriteLine("---");
    }
}
