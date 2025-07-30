// Summary: DateTime Best Practices Playbook — Week 5 Summary
// Day35
// Author: Avijit Roy

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

class Program
{
    public record Event(
        [property: JsonConverter(typeof(DateOnlyJsonConverter))] DateOnly Date,
        [property: JsonConverter(typeof(TimeOnlyJsonConverter))] TimeOnly Time
    );

    static void Main()
    {
        // ✅ 1. DateOnly for birthdays
        DateOnly birthday = new DateOnly(1995, 12, 5);
        Console.WriteLine("Birthday (DateOnly): " + birthday);

        // ✅ 2. TimeOnly for event time
        TimeOnly eventTime = new TimeOnly(9, 0);
        Console.WriteLine("Event Time (TimeOnly): " + eventTime);

        // ✅ 3. Parsing and formatting
        var parsedDate = DateOnly.ParseExact("07/27/2025", "MM/dd/yyyy", CultureInfo.InvariantCulture);
        var parsedTime = TimeOnly.ParseExact("08:45 AM", "hh:mm tt", CultureInfo.InvariantCulture);
        Console.WriteLine($"Parsed: {parsedDate} at {parsedTime}");

        // ✅ 4. JSON serialization (with custom converters)
        var ev = new Event(parsedDate, parsedTime);
        var json = JsonSerializer.Serialize(ev, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine("\nSerialized JSON:\n" + json);

        // ✅ 5. DateTimeOffset over DateTime
        DateTimeOffset now = DateTimeOffset.Now;
        Console.WriteLine("\nDateTimeOffset.Now: " + now);

        // ✅ 6. Time zone conversion (DST-safe)
        var estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        var estTime = TimeZoneInfo.ConvertTime(now, estZone);
        Console.WriteLine("Converted to EST: " + estTime);
    }
}

// Custom JSON Converters for DateOnly and TimeOnly
public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    private const string Format = "yyyy-MM-dd";
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DateOnly.ParseExact(reader.GetString()!, Format);
    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(Format));
}

public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
{
    private const string Format = "HH:mm";
    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => TimeOnly.ParseExact(reader.GetString()!, Format);
    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(Format));
}
