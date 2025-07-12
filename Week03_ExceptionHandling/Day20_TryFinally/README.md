## Try-Finally without Catch

In C#, you can use a **try-finally** block without a `catch`. This ensures cleanup code runs, even if an exception occurs, and lets the exception bubble up to the caller.

### What is it?

* `try`: Put risky code here.
* `finally`: Cleanup code that always runs, whether an exception occurs or not.

No `catch` block is required.

### Why use it?

* Guarantees resource cleanup (files, streams, DB connections).
* Lets exception handling occur elsewhere (higher in the call stack).
* Keeps cleanup logic close to the risky code.

### How does it work?

```csharp
try
{
    // Risky operations
}
finally
{
    // Always runs: clean up resources
}
```

This is especially useful when you want your method to clean up after itself but let **someone else handle the error**.

## Date: July 11, 2025

🔗 **Code:** [https://github.com/heyavijitroy/dotnet-dailytips/tree/main/Week03\_ExceptionHandling/Day20\_TryFinally/Program.cs](https://github.com/heyavijitroy/dotnet-dailytips/tree/main/Week03_ExceptionHandling/Day20_TryFinally/Program.cs)  

🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #exceptionhandling #Day20\_DotNetWithRoy #Week3
