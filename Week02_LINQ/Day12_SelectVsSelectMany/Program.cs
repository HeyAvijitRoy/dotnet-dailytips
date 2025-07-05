// Summary: Demonstrates the difference between Select() and SelectMany()
// Day 12: Select vs SelectMany
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Person
    {
        public string Name { get; set; }
        public List<string> Skills { get; set; }
    }

    static void Main()
    {
        var people = new List<Person>
        {
            new Person { Name = "Avijit", Skills = new List<string> { "C#", "SQL" } },
            new Person { Name = "Proma", Skills = new List<string> { "Java", "Python" } }
        };

        Console.WriteLine("Using Select():");
        var selected = people.Select(p => p.Skills);
        foreach (var skillList in selected)
            Console.WriteLine(string.Join(", ", skillList));

        Console.WriteLine("\nUsing SelectMany():");
        var flattened = people.SelectMany(p => p.Skills);
        foreach (var skill in flattened)
            Console.WriteLine(skill);
    }
}
