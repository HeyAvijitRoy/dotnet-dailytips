// Avoid capturing context in background tasks
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting async call...");
        await MakeApiCallAsync().ConfigureAwait(false);
        Console.WriteLine("Finished without capturing context.");
    }

    static async Task MakeApiCallAsync()
    {
        using var httpClient = new HttpClient();
        var result = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/todos/1");
        Console.WriteLine("Fetched data:");
        Console.WriteLine(result);
    }
}
