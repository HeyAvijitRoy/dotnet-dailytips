// Author: Avijit Roy 
// Demo of AggregateException vs normal await exception handling
using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            // This will wrap the exception in AggregateException
            var result = DangerousAsync().GetAwaiter().GetResult();
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught exception: {ex.GetType().Name} - {ex.Message}");
        }
    }

    static async Task<string> DangerousAsync()
    {
        await Task.Delay(500);
        throw new InvalidOperationException("This is a failure.");
    }
}
