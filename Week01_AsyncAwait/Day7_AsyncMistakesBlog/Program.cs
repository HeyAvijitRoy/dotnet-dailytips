// Author: Avijit Roy
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting demo of common async mistakes...\n");

        // 1: Blocking
        try
        {
            var result = GetValueAsync().Result;
            Console.WriteLine("Blocked Result: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Caught (blocking): " + ex.Message);
        }

        // 2: No ConfigureAwait (shown via code comment)
        await Task.Delay(200).ConfigureAwait(false);

        // 3: Async void (not demonstrable directly here)

        // 4: Sequential loop
        await foreach (var item in GetItemsAsync()) Console.WriteLine(item);

        // 5: CancellationToken
        var cts = new CancellationTokenSource(300);
        try
        {
            await Task.Delay(1000, cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Cancelled gracefully.");
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
