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
        // Sample list of people with Name and City
        var people = new List<Person>
        {
            new Person("Alice", "NYC"),
            new Person("Bob", "LA"),
            new Person("Charlie", "NYC"),
            new Person("David", "Chicago"),
            new Person("Eva", "LA"),
        };

        // Group people by their city
        var groupedByCity = people.GroupBy(p => p.City);

        // Display the groups
        foreach (var group in groupedByCity)
        {
            Console.WriteLine($"City: {group.Key} (Total: {group.Count()})");
            foreach (var person in group)
            {
                Console.WriteLine($"  - {person.Name}");
            }
        }
    }

    record Person(string Name, string City);
}
