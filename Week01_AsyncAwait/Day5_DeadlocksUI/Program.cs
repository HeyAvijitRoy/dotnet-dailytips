// Demonstrate deadlock when blocking on async code in UI-like context
using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine("Starting sync context simulation...");

        try
        {
            // This blocks the main thread, and the async method can't resume
            var result = GetDataAsync().Result;
            Console.WriteLine($"Result: {result}");
        }
        catch (AggregateException ex)
        {
            Console.WriteLine($"💥 Deadlock caught: {ex.InnerException?.Message}");
        }

        Console.WriteLine("Simulation complete.");
    }

    static async Task<string> GetDataAsync()
    {
        await Task.Delay(1000); // Simulate async work
        return "Async Result";
    }
}
