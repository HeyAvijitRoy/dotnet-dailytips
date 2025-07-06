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
    // 1 
    // Deferred execution can lead to unexpected results if the data source changes
    static void DeferredExecution()
    {
        var numbers = new List<int> { 1, 2, 3 };
        var query = numbers.Where(n => n > 1);

        numbers.Add(4); // Changes the data source after defining the query

        foreach (var n in query)
            Console.WriteLine(n); // Now includes the 4
    }

    // 2
    // Unnecessary ToList forces immediate execution, which can be avoided  
    static void UnnecessaryToList()
    {
        var numbers = Enumerable.Range(1, 5);

        // Forces immediate execution unnecessarily
        var result = numbers.Where(n => n > 2).ToList();

        foreach (var n in result)
            Console.WriteLine(n);
    }

    // 3
    // Multiple enumeration of a query can lead to performance issues
    static void MultipleEnumeration()
    {
        var numbers = Enumerable.Range(1, 5);

        var query = numbers.Where(n => n > 2);

        // This runs the query twice
        Console.WriteLine("Count: " + query.Count());
        Console.WriteLine("First: " + query.First());

        // Better: cache it
        var cached = query.ToList();
        Console.WriteLine("Cached Count: " + cached.Count);
    }

    // 4
    // Confusion between Select and SelectMany can lead to unexpected results
    static void SelectVsSelectMany()
    {
        var people = new[]
        {
            new { Name = "Roy", Skills = new[] { "C#", "LINQ" } },
            new { Name = "Avijit", Skills = new[] { "ASP.NET", "Azure" } }
        };

        var nested = people.Select(p => p.Skills); // IEnumerable<string[]>
        var flat = people.SelectMany(p => p.Skills); // IEnumerable<string>

        Console.WriteLine("Nested:");
        foreach (var group in nested)
            Console.WriteLine(string.Join(", ", group));

        Console.WriteLine("Flat:");
        foreach (var skill in flat)
            Console.WriteLine(skill);
    }

    // 5
    // GroupBy without projection can lead to less readable code
    static void GroupByWithoutProjection()
    {
        var numbers = Enumerable.Range(1, 5);

        var groups = numbers.GroupBy(n => n % 2);

        foreach (var group in groups)
        {
            Console.WriteLine($"Key {group.Key}: {string.Join(", ", group)}");
        }

        // Better: add projection
        var shaped = numbers.GroupBy(n => n % 2)
                             .Select(g => new { Key = g.Key, Items = g.ToList() });

        foreach (var g in shaped)
        {
            Console.WriteLine($"Group {g.Key}: {string.Join(", ", g.Items)}");
        }
    }

    // 6
    // Exceptions inside LINQ queries can be hard to catch
    static void ExceptionsInQuery()
    {
        var data = new[] { 1, 0, 2 };

        try
        {
            var results = data.Select(x => 10 / x).ToList();
            Console.WriteLine(string.Join(", ", results));
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Exception caught in query: " + ex.Message);
        }
    }

    // 7
    // Async LINQ requires awareness of async streams
    static async Task AsyncLinq()
    {
        var numbers = new[] { 1, 2, 3 };

        await foreach (var result in GetAsync(numbers))
        {
            Console.WriteLine("Async Result: " + result);
        }
    }

    static async IAsyncEnumerable<int> GetAsync(IEnumerable<int> numbers)
    {
        foreach (var n in numbers)
        {
            await Task.Delay(100);
            yield return n * 10;
        }
    }
}
