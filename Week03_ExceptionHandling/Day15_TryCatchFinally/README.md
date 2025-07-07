## Try-Catch-Finally Basics

Exception handling is a core part of writing robust applications. In C#, the **try-catch-finally** block helps you handle runtime errors and ensure resources are cleaned up properly.

### What is it?

* **try**: Put your risky code here. If an exception occurs, it jumps to catch.
* **catch**: Handle specific or general exceptions gracefully.
* **finally**: Always executes, whether or not an exception was thrown. Used for cleanup (e.g., closing files, releasing connections).

### Why use it?

Without exception handling, unexpected runtime errors will crash your app. With try-catch-finally, you:

* Prevent abrupt crashes.
* Control how your app responds to errors.
* Release resources properly, avoiding leaks.

### How does it work?

```csharp
try
{
    // Risky operations
}
catch (SpecificException ex)
{
    // Handle that specific exception
}
catch (Exception ex)
{
    // Handle all other exceptions
}
finally
{
    // Always runs: clean up resources
}
```

Start simple: catch what you can handle, log what you can't, and always clean up.

## Date: July 6, 2025  
🔗 **Code:** [https://github.com/heyavijitroy/dotnet-dailytips/tree/main/Week03\_ExceptionHandling/Day15\_TryCatchFinally/Program.cs](https://github.com/heyavijitroy/dotnet-dailytips/tree/main/Week03_ExceptionHandling/Day15_TryCatchFinally/Program.cs)  

🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #exceptionhandling #Day15\_DotNetWithRoy #Week3
