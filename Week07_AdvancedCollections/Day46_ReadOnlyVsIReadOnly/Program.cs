// Summary: Compare ReadOnlyCollection<T> vs IReadOnlyList<T> and show why neither is immutable
// Day46
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; // For ReadOnlyCollection<T>
using System.Linq;

class Program
{
    static void Main()
    {
        // Source list that CAN change
        var numbers = new List<int> { 1, 2, 3 };

        // A read-only interface view over the same list
        IReadOnlyList<int> roInterface = numbers;

        // A read-only wrapper around the same list
        ReadOnlyCollection<int> roCollection = numbers.AsReadOnly();

        Console.WriteLine("Initial views:");
        Dump("numbers", numbers);
        Dump("roInterface", roInterface);
        Dump("roCollection", roCollection);

        // Mutate the ORIGINAL list (legal)
        numbers.Add(4);

        Console.WriteLine("\nAfter mutating source list (numbers.Add(4)):");
        Dump("numbers", numbers);
        Dump("roInterface", roInterface);   // reflects change
        Dump("roCollection", roCollection); // reflects change

        // roCollection and roInterface are read-only VIEWS: they prevent direct mutation
        // roCollection.Add(5); // ❌ compile error
        // roInterface[0] = 99; // ❌ compile error

        // If you need a truly unchanging snapshot, copy it
        var snapshot = numbers.ToList(); // independent copy
        numbers.Add(5);

        Console.WriteLine("\nAfter snapshot + another mutation (numbers.Add(5)):");
        Dump("numbers", numbers);   // [1,2,3,4,5]
        Dump("snapshot", snapshot); // [1,2,3,4]

        Console.WriteLine("\nTakeaway: ReadOnlyCollection<T> and IReadOnlyList<T> are not immutable. Use ImmutableList<T> when you need immutability.");
    }

    static void Dump(string label, IEnumerable<int> seq)
        => Console.WriteLine($"{label}: [{string.Join(", ", seq)}]");
}
