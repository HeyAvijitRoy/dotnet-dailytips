// Summary: Shows how to serialize and deserialize DateOnly/TimeOnly in JSON
// Day32
// Author: Avijit Roy

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{
    public record Event(
        [property: JsonConverter(typeof(DateOnlyJsonConverter))] DateOnly StartDate,
        [property: JsonConverter(typeof(TimeOnlyJsonConverter))] TimeOnly StartTime
    );

    static void Main()
    {
        var ev = new Event(new DateOnly(2025, 7, 23), new TimeOnly(14, 0));
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(ev, options);

        Console.WriteLine("Serialized:\n" + json);

        // Deserialize it back
        var parsed = JsonSerializer.Deserialize<Event>(json, options);
        Console.WriteLine($"\nDeserialized: {parsed?.StartDate} at {parsed?.StartTime}");
    }
}

// JSON converter for DateOnly
public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    private const string Format = "yyyy-MM-dd";
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DateOnly.ParseExact(reader.GetString()!, Format);

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(Format));
}

// JSON converter for TimeOnly
public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
{
    private const string Format = "HH:mm";
    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => TimeOnly.ParseExact(reader.GetString()!, Format);

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(Format));
}
