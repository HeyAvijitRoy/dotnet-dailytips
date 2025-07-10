## throw vs throw ex

One of the most common mistakes in C# exception handling is rethrowing an exception incorrectly.

### What is it?

* `throw;` rethrows the **original exception**, preserving its stack trace.
* `throw ex;` rethrows the **same exception**, but resets the stack trace — making it harder to trace where the error first occurred.

### Why does it matter?

If you reset the stack trace, debugging becomes much harder because you lose the original error location.

### How does it work?

```csharp
try
{
    // Code that may fail
}
catch (Exception ex)
{
    Console.WriteLine("Error occurred: " + ex.Message);

    throw;    // ✅ Recommended: preserves the original stack trace
    // throw ex; // ❌ Bad practice: resets the stack trace
}
```

### Key takeaway:

✔ Use `throw;` when you just want to propagate the exception up the call stack.
✔ Only use `throw ex;` when you're creating a **new exception instance**, or intentionally changing the error context.

## Date: July 8, 2025
🔗 **Code:** [https://github.com/heyavijitroy/dotnet-dailytips/tree/main/Week03\_ExceptionHandling/Day17\_ThrowVsThrowEx/Program.cs](https://github.com/heyavijitroy/dotnet-dailytips/tree/main/Week03_ExceptionHandling/Day17_ThrowVsThrowEx/Program.cs)  

🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #exceptionhandling #Day17\_DotNetWithRoy #Week3
