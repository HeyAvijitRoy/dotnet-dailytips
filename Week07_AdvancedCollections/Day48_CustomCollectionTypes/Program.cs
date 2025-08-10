// Summary: Build a custom collection (TodoBucket) that enforces rules and works with LINQ
// Day48
// Author: Avijit Roy

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public sealed class Todo
{
    public string Title { get; }
    public int Priority { get; }   // lower = more important
    public bool Done { get; private set; }

    public Todo(string title, int priority, bool done = false)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Priority = priority;
        Done = done;
    }

    public void MarkDone() => Done = true;

    public override string ToString() => $"{Title} (P{Priority}) {(Done ? "[Done]" : "")}";
}

/// <summary>
/// A custom collection that enforces unique titles and exposes safe enumeration.
/// Because it implements IEnumerable<Todo>, it works with LINQ out of the box.
/// </summary>
public sealed class TodoBucket : IEnumerable<Todo>
{
    // Internal storage uses a dictionary for O(1) title lookups
    private readonly Dictionary<string, Todo> _items = new(StringComparer.OrdinalIgnoreCase);

    // Optional: cap the number of todos to show domain rules
    private readonly int _capacity;

    public TodoBucket(int capacity = 100) => _capacity = capacity;

    public int Count => _items.Count;

    // Add returns false if title already exists or capacity reached
    public bool Add(Todo todo)
    {
        if (todo is null) throw new ArgumentNullException(nameof(todo));
        if (_items.Count >= _capacity) return false;
        return _items.TryAdd(todo.Title, todo);
    }

    public bool TryGet(string title, out Todo? todo) => _items.TryGetValue(title, out todo!);

    // LINQ needs this: defer to dictionary.Values for enumeration
    public IEnumerator<Todo> GetEnumerator() => _items.Values.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class Program
{
    static void Main()
    {
        var bucket = new TodoBucket(capacity: 10);

        // Add some items (duplicates won't be added)
        bucket.Add(new Todo("Fix critical bug", priority: 1));
        bucket.Add(new Todo("Write docs", priority: 3));
        bucket.Add(new Todo("Code review", priority: 2));
        bucket.Add(new Todo("Fix critical bug", priority: 1)); // duplicate title ignored

        // LINQ just works because TodoBucket implements IEnumerable<Todo>
        var nextThree =
            bucket.Where(t => !t.Done)
                  .OrderBy(t => t.Priority)   // lower first
                  .Take(3)
                  .Select(t => t.Title);

        Console.WriteLine("Next up:");
        foreach (var title in nextThree)
            Console.WriteLine($" - {title}");

        // Grouping by priority with projection
        var groups = bucket
            .GroupBy(t => t.Priority)
            .OrderBy(g => g.Key)
            .Select(g => new { Priority = g.Key, Count = g.Count() });

        Console.WriteLine("\nCounts by priority:");
        foreach (var g in groups)
            Console.WriteLine($"P{g.Priority}: {g.Count}");

        // Snapshot vs live view: take a copy when you need stability
        var snapshot = bucket.ToList();
        if (bucket.TryGet("Fix critical bug", out var critical))
            critical!.MarkDone();

        Console.WriteLine("\nAfter marking 'Fix critical bug' done:");
        Console.WriteLine("Live query (reflects change): " +
            string.Join(", ", bucket.Where(t => !t.Done).Select(t => t.Title)));

        Console.WriteLine("Snapshot (unchanged): " +
            string.Join(", ", snapshot.Where(t => !t.Done).Select(t => t.Title)));
    }
}
