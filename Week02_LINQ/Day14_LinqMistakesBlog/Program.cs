// Summary: Demonstrates 6 common LINQ mistakes and how to avoid them
// Day14
// Author: Avijit Roy

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("1. Deferred Execution Mistake:");
        DeferredExecution();

        Console.WriteLine("\n2. Unnecessary ToList():");
        UnnecessaryToList();

        Console.WriteLine("\n3. Multiple Enumeration:");
        MultipleEnumeration();

        Console.WriteLine("\n4. Select vs SelectMany Confusion:");
        SelectVsSelectMany();

        Console.WriteLine("\n5. GroupBy Without Projection:");
        GroupByWithoutProjection();

        Console.WriteLine("\n6. Exceptions Inside LINQ:");
        ExceptionsInQuery();

        Console.WriteLine("\n7. Async LINQ Awareness:");
        await AsyncLinq();
    }

    // 1️⃣ Mistake: Deferred execution can yield unexpected results if the source is modified later
    static void DeferredExecution()
    {
        var numbers = new List<int> { 1, 2, 3 };
        var query = numbers.Where(n => n > 1);

        numbers.Add(4); // This change affects the query output

        foreach (var n in query)
            Console.WriteLine(n); // Will include 4 due to deferred execution
    }

    // 2️⃣ Mistake: Using ToList() too early forces unnecessary immediate execution
    static void UnnecessaryToList()
    {
        var numbers = Enumerable.Range(1, 5);

        // Not needed unless the result must be reused or modified
        var result = numbers.Where(n => n > 2).ToList();

        foreach (var n in result)
            Console.WriteLine(n);
    }

    // 3️⃣ Mistake: Enumerating the same query multiple times causes performance issues
    static void MultipleEnumeration()
    {
        var numbers = Enumerable.Range(1, 5);
        var query = numbers.Where(n => n > 2);

        // Runs the same query twice
        Console.WriteLine("Count: " + query.Count());
        Console.WriteLine("First: " + query.First());

        // Better: cache it with ToList() once
        var cached = query.ToList();
        Console.WriteLine("Cached Count: " + cached.Count);
    }

    // 4️⃣ Mistake: Confusing Select with SelectMany can produce incorrect results
    static void SelectVsSelectMany()
    {
        var people = new[]
        {
            new { Name = "Roy", Skills = new[] { "C#", "LINQ" } },
            new { Name = "Avijit", Skills = new[] { "ASP.NET", "Azure" } }
        };

        var nested = people.Select(p => p.Skills);       // IEnumerable<string[]>
        var flat = people.SelectMany(p => p.Skills);     // IEnumerable<string>

        Console.WriteLine("Nested:");
        foreach (var group in nested)
            Console.WriteLine(string.Join(", ", group));

        Console.WriteLine("Flat:");
        foreach (var skill in flat)
            Console.WriteLine(skill);
    }

    // 5️⃣ Mistake: GroupBy without projection leads to unreadable code and duplication
    static void GroupByWithoutProjection()
    {
        var numbers = Enumerable.Range(1, 5);

        var groups = numbers.GroupBy(n => n % 2);

        foreach (var group in groups)
        {
            Console.WriteLine($"Key {group.Key}: {string.Join(", ", group)}");
        }

        // Better: use a projection to make the output more usable
        var shaped = numbers.GroupBy(n => n % 2)
                             .Select(g => new { Key = g.Key, Items = g.ToList() });

        foreach (var g in shaped)
        {
            Console.WriteLine($"Group {g.Key}: {string.Join(", ", g.Items)}");
        }
    }

    // 6️⃣ Mistake: Exceptions inside LINQ queries can be swallowed or missed
    static void ExceptionsInQuery()
    {
        var data = new[] { 1, 0, 2 };

        try
        {
            // Exception thrown during evaluation, not query definition
            var results = data.Select(x => 10 / x).ToList();
            Console.WriteLine(string.Join(", ", results));
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Exception caught in query: " + ex.Message);
        }
    }

    // 7️⃣ Mistake: LINQ isn’t natively async-aware — use IAsyncEnumerable for async queries
    static async Task AsyncLinq()
    {
        var numbers = new[] { 1, 2, 3 };

        // Correct async stream usage with await foreach
        await foreach (var result in GetAsync(numbers))
        {
            Console.WriteLine("Async Result: " + result);
        }
    }

    // Simulated async data stream
    static async IAsyncEnumerable<int> GetAsync(IEnumerable<int> numbers)
    {
        foreach (var n in numbers)
        {
            await Task.Delay(100); // Simulate I/O delay
            yield return n * 10;
        }
    }
}
