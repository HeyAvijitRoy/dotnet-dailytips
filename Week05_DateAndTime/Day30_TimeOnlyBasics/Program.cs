// Summary: Demonstrates how to use TimeOnly for time-of-day logic
// Day30
// Author: Avijit Roy

using System;

class Program
{
    static void Main()
    {
        // Using DateTime for just a time value — not ideal
        DateTime oldWay = new DateTime(1, 1, 1, 9, 30, 0); // Jan 1, Year 1, 9:30 AM
        Console.WriteLine("DateTime (for time): " + oldWay);

        // Using TimeOnly — cleaner and semantically correct
        TimeOnly classStartTime = new TimeOnly(9, 30);
        Console.WriteLine("TimeOnly class start: " + classStartTime); // 09:30

        // Getting current time only
        TimeOnly now = TimeOnly.FromDateTime(DateTime.Now);
        Console.WriteLine("TimeOnly now: " + now);

        // Comparing two TimeOnly values
        TimeOnly lunch = new TimeOnly(12, 0);
        if (now < lunch)
        {
            Console.WriteLine("It's not lunchtime yet.");
        }
        else
        {
            Console.WriteLine("Time for lunch!");
        }
    }
}
