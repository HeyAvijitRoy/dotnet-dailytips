// Summary: Comparing DateTime and DateTimeOffset for time zone awareness
// Day33
// Author: Avijit Roy

using System;

class Program
{
    static void Main()
    {
        // Local time without offset — risky for time zone-sensitive systems
        DateTime local = DateTime.Now;
        Console.WriteLine("DateTime.Now: " + local);

        // Universal time — no local context
        DateTime utc = DateTime.UtcNow;
        Console.WriteLine("DateTime.UtcNow: " + utc);

        // Local time with offset — preferred
        DateTimeOffset localOffset = DateTimeOffset.Now;
        Console.WriteLine("DateTimeOffset.Now: " + localOffset); // includes offset

        // Universal with offset = safest for logs and timestamps
        DateTimeOffset utcOffset = DateTimeOffset.UtcNow;
        Console.WriteLine("DateTimeOffset.UtcNow: " + utcOffset);

        // Convert between them
        Console.WriteLine("As DateTime: " + utcOffset.DateTime);
    }
}
