// Summary: Demonstrates how to group a collection using LINQ GroupBy()
// Day 10
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Sample data: list of people with their name and city
        var people = new List<Person>
        {
            new Person("Alice", "NYC"),
            new Person("Bob", "LA"),
            new Person("Charlie", "NYC"),
            new Person("David", "Chicago"),
            new Person("Eva", "LA"),
        };

        // Group the people list by the City property
        var groupedByCity = people.GroupBy(p => p.City);

        // Iterate through each group and display the results
        foreach (var group in groupedByCity)
        {
            // Each group has a Key (City name) and a collection of Person
            Console.WriteLine($"City: {group.Key} (Total: {group.Count()})");
            foreach (var person in group)
            {
                Console.WriteLine($"  - {person.Name}");
            }
        }
    }

    // C# 9+ record type for concise data model
    record Person(string Name, string City);
}
