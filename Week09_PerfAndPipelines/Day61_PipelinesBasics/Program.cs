// Summary: Demonstrates System.IO.Pipelines basics with producer/consumer
// Day61
// Author: Avijit Roy

using System;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var pipe = new Pipe();

        // Producer: write data into the pipe
        _ = Task.Run(async () =>
        {
            for (int i = 0; i < 3; i++)
            {
                string message = $"Message {i}";
                byte[] bytes = Encoding.UTF8.GetBytes(message);

                // Get memory from pipe and copy data
                var memory = pipe.Writer.GetMemory(bytes.Length);
                bytes.CopyTo(memory);

                // Tell the writer how many bytes were written
                pipe.Writer.Advance(bytes.Length);

                // Flush so consumer can read
                await pipe.Writer.FlushAsync();

                await Task.Delay(500);
            }

            await pipe.Writer.CompleteAsync();
        });

        // Consumer: read data from the pipe
        while (true)
        {
            ReadResult result = await pipe.Reader.ReadAsync();
            var buffer = result.Buffer;

            foreach (var segment in buffer)
            {
                string text = Encoding.UTF8.GetString(segment.Span);
                Console.WriteLine($"Read: {text}");
            }

            // Mark everything as consumed
            pipe.Reader.AdvanceTo(buffer.End);

            if (result.IsCompleted) break;
        }

        await pipe.Reader.CompleteAsync();
    }
}
