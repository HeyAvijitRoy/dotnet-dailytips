// Author: Avijit Roy
// Avoid async void unless you're writing event handlers
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        try
        {
            await DoSomething();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught exception: {ex.Message}");
        }
    }

    static async Task DoSomething()
    {
        await Task.Delay(500);
        throw new InvalidOperationException("Something went wrong.");
    }
}
