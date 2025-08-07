// Summary: Demonstrates usage of ImmutableList and how it behaves with updates
// Day45
// Author: Avijit Roy

using System;
using System.Collections.Immutable;

class Program
{
    static void Main()
    {
        // Create an ImmutableList
        var names = ImmutableList.Create("Alice", "Bob", "Charlie");

        // Add a new item (returns a new list)
        var updatedNames = names.Add("David");

        Console.WriteLine("Original List:");
        foreach (var name in names)
            Console.WriteLine(name);

        Console.WriteLine("\nUpdated List:");
        foreach (var name in updatedNames)
            Console.WriteLine(name);
    }
}
