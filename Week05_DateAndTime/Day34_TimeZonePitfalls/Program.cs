// Summary: Demonstrates common time zone conversion mistakes and fixes
// Day34
// Author: Avijit Roy

using System;

class Program
{
    static void Main()
    {
        // BAD: Using DateTime.Now (no time zone info!)
        DateTime now = DateTime.Now;
        Console.WriteLine($"DateTime.Now: {now} (Kind: {now.Kind})");

        // BETTER: Use DateTimeOffset
        DateTimeOffset nowOffset = DateTimeOffset.Now;
        Console.WriteLine($"DateTimeOffset.Now: {nowOffset}");

        // DANGER: Unspecified kind causes ambiguity
        var unspec = new DateTime(2025, 7, 26, 14, 0, 0, DateTimeKind.Unspecified);
        Console.WriteLine($"Unspecified DateTime: {unspec} (Kind: {unspec.Kind})");

        // CORRECT: Use TimeZoneInfo to convert between zones
        var utcNow = DateTime.UtcNow;
        var estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        var estTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, estZone);
        Console.WriteLine($"UTC: {utcNow} ➡ EST: {estTime}");

        // DST-safe: ConvertTime using DateTimeOffset
        var pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        var pstTime = TimeZoneInfo.ConvertTime(nowOffset, pstZone);
        Console.WriteLine($"Offset-aware conversion to PST: {pstTime}");
    }
}
