// Summary: Demonstrates Dictionary of Lists pattern with LINQ queries
// Day43
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Creating a Dictionary of Lists — ClassName => List of Students
        var studentsByClass = new Dictionary<string, List<string>>();

        // Adding students
        AddStudent(studentsByClass, "Math", "Alice");
        AddStudent(studentsByClass, "Math", "Bob");
        AddStudent(studentsByClass, "Science", "Charlie");
        AddStudent(studentsByClass, "Math", "David");
        AddStudent(studentsByClass, "Science", "Eve");

        // LINQ Query: Get all students in 'Math' class starting with 'A'
        var mathStudentsA = studentsByClass["Math"]
                                .Where(name => name.StartsWith("A"))
                                .ToList();

        Console.WriteLine("Math Students starting with 'A':");
        mathStudentsA.ForEach(Console.WriteLine);

        // LINQ Query: Get total number of students per class
        var classCounts = studentsByClass
                            .Select(kvp => $"{kvp.Key}: {kvp.Value.Count} students")
                            .ToList();

        Console.WriteLine("\nStudent count per class:");
        classCounts.ForEach(Console.WriteLine);
    }

    // Helper method to add students safely
    static void AddStudent(Dictionary<string, List<string>> dict, string className, string studentName)
    {
        if (!dict.TryGetValue(className, out var students))
        {
            students = new List<string>();
            dict[className] = students;
        }
        students.Add(studentName);
    }
}
