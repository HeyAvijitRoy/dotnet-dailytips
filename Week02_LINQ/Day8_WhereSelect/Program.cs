// Summary: Filters students with score > 85 and selects their names
// Day 8: Where and Select Example
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Define a simple Student class with Name and Score properties
    class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    static void Main()
    {
        // Sample data: a list of students with their scores
        var students = new List<Student>
        {
            new Student { Name = "Avijit", Score = 92 },
            new Student { Name = "Proma", Score = 88 },
            new Student { Name = "Parinita", Score = 79 },
            new Student { Name = "Ami", Score = 95 }
        };

        // LINQ chain:
        // - Where: filters students with Score > 85
        // - Select: projects only the Name of those students
        var toppers = students
            .Where(s => s.Score > 85)
            .Select(s => s.Name);

        // Output the names of top scorers
        Console.WriteLine("Top Scorers:");
        foreach (var name in toppers)
            Console.WriteLine(name);
    }
}
