// Summary: Comparing Lookup and Dictionary for key-based access
// Day40
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var students = new[]
        {
            new { Name = "Alice", Class = "A" },
            new { Name = "Bob", Class = "B" },
            new { Name = "Charlie", Class = "A" },
            new { Name = "Daisy", Class = "C" },
            new { Name = "Evan", Class = "B" }
        };

        // Group using ToLookup
        var classLookup = students.ToLookup(s => s.Class);

        Console.WriteLine("Students in Class B:");
        foreach (var student in classLookup["B"])
            Console.WriteLine(student.Name);

        // Dictionary equivalent would throw if duplicate keys were added
        var dict = students
            .GroupBy(s => s.Name)
            .ToDictionary(g => g.Key, g => g.First());

        Console.WriteLine("\nDictionary access:");
        Console.WriteLine(dict["Alice"].Class);
    }
}
// Note: Lookup allows multiple values for the same key, while Dictionary does not.