## Exception Filters (when)

Sometimes the same exception type can occur for **different reasons**, and you don’t want to catch them all in one block. This is where **exception filters** help.

### What is it?

* The `when` keyword lets you add a **filter condition** to your `catch` block.
* Only exceptions matching the filter will be caught by that block.

### Why use it?

* Keeps your exception handling **clean and focused**.
* Avoids mixing logic for different error cases.
* Lets you skip catching errors you’re not interested in.

### How does it work?

```csharp
try
{
    // Risky operations
}
catch (Exception ex) when (ex.Message.Contains("timeout"))
{
    // Only catches exceptions whose message contains "timeout"
}
catch (Exception ex)
{
    // Handles all other exceptions
}
```

Filters **evaluate before** the catch block executes, so your logic stays clean.

## Date: July 10, 2025

🔗 **Code:** [https://github.com/heyavijitroy/dotnet-dailytips/tree/main/Week03\_ExceptionHandling/Day19\_ExceptionFilters/Program.cs](https://github.com/heyavijitroy/dotnet-dailytips/tree/main/Week03_ExceptionHandling/Day19_ExceptionFilters/Program.cs)  

🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #exceptionhandling #Day19\_DotNetWithRoy #Week3
