// Compare sequential vs parallel async operations using await foreach and Task.WhenAll
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("== await foreach (Sequential) ==");
        var sw1 = Stopwatch.StartNew();
        await foreach (var result in GetSequentialResultsAsync())
        {
            Console.WriteLine($"[{sw1.ElapsedMilliseconds}ms] {result}");
        }

        Console.WriteLine("\n== Task.WhenAll (Parallel) ==");
        var sw2 = Stopwatch.StartNew();
        var tasks = GetConcurrentTasks();
        var results = await Task.WhenAll(tasks);
        foreach (var result in results)
        {
            Console.WriteLine($"[{sw2.ElapsedMilliseconds}ms] {result}");
        }
    }

    static async IAsyncEnumerable<string> GetSequentialResultsAsync()
    {
        for (int i = 0; i < 5; i++)
        {
            await Task.Delay(500); // Simulate delay
            yield return $"Item {i}";
        }
    }

    static List<Task<string>> GetConcurrentTasks()
    {
        var tasks = new List<Task<string>>();
        for (int i = 0; i < 5; i++)
        {
            int local = i;
            tasks.Add(Task.Run(async () =>
            {
                await Task.Delay(500); // Simulate delay
                return $"Item {local}";
            }));
        }
        return tasks;
    }
}
