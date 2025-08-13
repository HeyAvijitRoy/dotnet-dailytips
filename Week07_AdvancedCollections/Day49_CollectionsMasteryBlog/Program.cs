// Summary: Week 7 Playbook - Demonstrates all advanced collection patterns from the week
// Day49
// Author: Avijit Roy

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Dictionary of Lists ===");
        var studentsByClass = new Dictionary<string, List<string>>();
        AddStudent(studentsByClass, "Math", "Alice");
        AddStudent(studentsByClass, "Math", "Bob");
        studentsByClass["Math"].Where(s => s.StartsWith("A")).ToList().ForEach(Console.WriteLine);

        Console.WriteLine("\n=== Concurrent Collections ===");
        var wordCounts = new ConcurrentDictionary<string, int>();
        var words = new[] { "apple", "banana", "apple" };
        words.AsParallel().ForAll(w => wordCounts.AddOrUpdate(w, 1, (_, old) => old + 1));
        wordCounts.ToList().ForEach(kvp => Console.WriteLine($"{kvp.Key}: {kvp.Value}"));

        Console.WriteLine("\n=== Immutable Collections ===");
        var names = ImmutableList.Create("A", "B");
        var updatedNames = names.Add("C");
        Console.WriteLine("Original: " + string.Join(", ", names));
        Console.WriteLine("Updated: " + string.Join(", ", updatedNames));

        Console.WriteLine("\n=== ReadOnlyCollection vs IReadOnlyList ===");
        var list = new List<int> { 1, 2 };
        IReadOnlyList<int> roList = list;
        ReadOnlyCollection<int> roCollection = list.AsReadOnly();
        list.Add(3);
        Console.WriteLine("roList: " + string.Join(", ", roList));
        Console.WriteLine("roCollection: " + string.Join(", ", roCollection));

        Console.WriteLine("\n=== PriorityQueue ===");
        var pq = new PriorityQueue<string, int>();
        pq.Enqueue("Low priority", 3);
        pq.Enqueue("High priority", 1);
        while (pq.TryDequeue(out var task, out var prio))
            Console.WriteLine($"{task} ({prio})");

        Console.WriteLine("\n=== Custom Collection + LINQ ===");
        var bucket = new TodoBucket();
        bucket.Add(new Todo("Task1", 2));
        bucket.Add(new Todo("Task2", 1));
        bucket.Where(t => t.Priority == 1).ToList().ForEach(t => Console.WriteLine(t.Title));
    }

    static void AddStudent(Dictionary<string, List<string>> dict, string key, string student)
    {
        if (!dict.TryGetValue(key, out var list))
            dict[key] = list = new List<string>();
        list.Add(student);
    }
}

public sealed class Todo
{
    public string Title { get; }
    public int Priority { get; }
    public bool Done { get; private set; }
    public Todo(string title, int priority) { Title = title; Priority = priority; }
    public void MarkDone() => Done = true;
}

public sealed class TodoBucket : IEnumerable<Todo>
{
    private readonly Dictionary<string, Todo> _items = new();
    public bool Add(Todo todo) => _items.TryAdd(todo.Title, todo);
    public IEnumerator<Todo> GetEnumerator() => _items.Values.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}
