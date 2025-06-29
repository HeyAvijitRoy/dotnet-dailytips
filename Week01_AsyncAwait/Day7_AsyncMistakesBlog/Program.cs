// Author: Avijit Roy
// Illustrative playground combining common async mistakes (for learning/demo only)
// Not for production use. Run each part carefully to understand potential issues.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Demo: Common Async Mistakes in .NET\n");

        // 1. Blocking async code with .Result
        try
        {
            var result = GetValueAsync().Result;
            Console.WriteLine("Blocking Result: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Caught (blocking): " + ex.Message);
        }

        // 2. Forgetting ConfigureAwait(false)
        await Task.Delay(200).ConfigureAwait(false); // See blog for reasoning

        // 3. Async void – cannot demo directly here, would require event context

        // 4. Misunderstanding await foreach (sequential, not concurrent)
        Console.WriteLine("\nSequential await foreach:");
        await foreach (var item in GetItemsAsync())
            Console.WriteLine(item);

        // 5. Ignoring cancellation tokens
        var cts = new CancellationTokenSource(300);
        try
        {
            await Task.Delay(1000, cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Cancelled gracefully via token.");
        }

        // 6. Using GetAwaiter().GetResult() unsafely
        try
        {
            var value = GetValueAsync().GetAwaiter().GetResult(); // similar to .Result
            Console.WriteLine("GetAwaiter().GetResult(): " + value);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Caught (GetAwaiter): " + ex.Message);
        }
    }

    static async Task<string> GetValueAsync()
    {
        await Task.Delay(100);
        return "42";
    }

    static async IAsyncEnumerable<string> GetItemsAsync()
    {
        for (int i = 0; i < 3; i++)
        {
            await Task.Delay(100);
            yield return $"Item {i}";
        }
    }
}
