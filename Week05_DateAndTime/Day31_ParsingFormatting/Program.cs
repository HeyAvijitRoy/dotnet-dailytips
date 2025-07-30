// Summary: How to parse and format DateOnly and TimeOnly values
// Day31
// Author: Avijit Roy

using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        // Parsing a date string into DateOnly
        var dob = DateOnly.ParseExact("07/15/2025", "MM/dd/yyyy", CultureInfo.InvariantCulture);
        Console.WriteLine("Parsed DateOnly: " + dob); // 2025-07-15

        // Formatting DateOnly into a readable string
        Console.WriteLine("Formatted: " + dob.ToString("MMMM dd, yyyy")); // July 15, 2025

        // Parsing a time string into TimeOnly
        var time = TimeOnly.ParseExact("08:30 AM", "hh:mm tt", CultureInfo.InvariantCulture);
        Console.WriteLine("Parsed TimeOnly: " + time); // 08:30

        // Formatting TimeOnly for display
        Console.WriteLine("Formatted: " + time.ToString("h:mm tt")); // 8:30 AM
    }
}
