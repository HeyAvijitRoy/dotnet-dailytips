// Summary: Demonstrates the difference between DateOnly and DateTime
// Day29
// Author: Avijit Roy

using System;

class Program
{
    static void Main()
    {
        // Using DateTime to represent a birthday (carries a time component)
        DateTime birthdayDateTime = new DateTime(1995, 5, 23);
        Console.WriteLine("DateTime birthday: " + birthdayDateTime); // 1995-05-23 00:00:00

        // Using DateOnly (introduced in .NET 6) — just date, no time
        DateOnly birthdayDateOnly = new DateOnly(1995, 5, 23);
        Console.WriteLine("DateOnly birthday: " + birthdayDateOnly); // 1995-05-23

        // DateOnly helps clearly represent concepts like birthdays, holidays, etc.
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        Console.WriteLine("Today's DateOnly: " + today);
    }
}
