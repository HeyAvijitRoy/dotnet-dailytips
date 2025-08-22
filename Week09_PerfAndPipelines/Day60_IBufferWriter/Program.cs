// Summary: Demonstrates IBufferWriter<T> with ArrayBufferWriter for efficient writing
// Day60
// Author: Avijit Roy

using System;
using System.Buffers;
using System.Text;

class Program
{
    static void Main()
    {
        // ArrayBufferWriter<T> is a built-in implementation of IBufferWriter<T>
        IBufferWriter<byte> writer = new ArrayBufferWriter<byte>();

        // Write "Hello" into the buffer
        WriteString(writer, "Hello");
        WriteString(writer, " World!");

        // Convert written data to a string
        var writtenData = Encoding.UTF8.GetString(((ArrayBufferWriter<byte>)writer).WrittenSpan);
        Console.WriteLine("Written Data: " + writtenData);
    }

    static void WriteString(IBufferWriter<byte> writer, string text)
    {
        // Encode string into UTF8
        byte[] utf8Bytes = Encoding.UTF8.GetBytes(text);

        // Request a span with enough space
        Span<byte> span = writer.GetSpan(utf8Bytes.Length);

        // Copy data into the buffer
        utf8Bytes.CopyTo(span);

        // Tell the writer how many bytes we actually used
        writer.Advance(utf8Bytes.Length);
    }
}
