// Summary: Filters students with score > 85 and selects their names
// Day 8: Where and Select Example
    // Author: Avijit Roy
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    static void Main()
    {
        var students = new List<Student>
        {
            new Student { Name = "Avijit", Score = 92 },
            new Student { Name = "Proma", Score = 88 },
            new Student { Name = "Zahin", Score = 79 },
            new Student { Name = "Anika", Score = 95 }
        };

        var toppers = students
            .Where(s => s.Score > 85)
            .Select(s => s.Name);

        Console.WriteLine("Top Scorers:");
        foreach (var name in toppers)
            Console.WriteLine(name);
    }
}
