// Summary: Demonstrates Utf8JsonReader, Utf8Parser, and Rune for efficient text processing
// Day62
// Author: Avijit Roy

using System;
using System.Buffers.Text;
using System.Text;
using System.Text.Json;

class Program
{
    static void Main()
    {
        // Utf8JsonReader example: parse JSON from UTF-8 bytes
        string json = "{\"name\":\"Roy\",\"age\":27}";
        ReadOnlySpan<byte> utf8Json = Encoding.UTF8.GetBytes(json);

        var reader = new Utf8JsonReader(utf8Json);
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
                Console.WriteLine($"Property: {reader.GetString()}");
            else if (reader.TokenType == JsonTokenType.String)
                Console.WriteLine($"Value (string): {reader.GetString()}");
            else if (reader.TokenType == JsonTokenType.Number)
                Console.WriteLine($"Value (number): {reader.GetInt32()}");
        }

        // Utf8Parser example: parse int directly from UTF-8 bytes
        ReadOnlySpan<byte> utf8Number = Encoding.UTF8.GetBytes("12345");
        if (Utf8Parser.TryParse(utf8Number, out int value, out int consumed))
        {
            Console.WriteLine($"Parsed int: {value}, Bytes consumed: {consumed}");
        }

        // Rune example: iterate Unicode code points safely
        string text = "😊DotNet";
        foreach (var rune in text.EnumerateRunes())
        {
            Console.WriteLine($"Rune: {rune}, UTF-32: U+{rune.Value:X4}");
        }
    }
}
