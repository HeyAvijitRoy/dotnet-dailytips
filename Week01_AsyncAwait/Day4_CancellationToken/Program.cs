// Author: Avijit Roy
// Handle task cancellation using CancellationToken
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        using var cts = new CancellationTokenSource();

        var task = DoWorkAsync(cts.Token);

        Console.WriteLine("Press any key to cancel...");
        Console.ReadKey();
        cts.Cancel();

        try
        {
            await task;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Task was cancelled.");
        }
    }

    static async Task DoWorkAsync(CancellationToken token)
    {
        for (int i = 0; i < 10; i++)
        {
            token.ThrowIfCancellationRequested();
            Console.WriteLine($"Working... {i + 1}");
            await Task.Delay(500, token);
        }
        Console.WriteLine("Task completed.");
    }
}
