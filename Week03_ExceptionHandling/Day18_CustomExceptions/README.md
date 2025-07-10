## Custom Exception Classes

Built-in exceptions in C# cover many cases, but sometimes your application needs domain-specific errors. That’s where **custom exception classes** come in.

### What is it?

* A class that inherits from `Exception`.
* Represents a specific error condition in your app.

### Why use it?

* Makes your errors more meaningful and clear.
* Allows you to catch and handle specific problems in your domain.
* Improves log readability and maintenance.

### How does it work?

```csharp
public class InvalidUserActionException : Exception
{
    public InvalidUserActionException() { }
    public InvalidUserActionException(string message) : base(message) { }
    public InvalidUserActionException(string message, Exception inner) : base(message, inner) { }
}

throw new InvalidUserActionException("This action is not allowed.");
```

You can now catch this specific exception and handle it appropriately.

## Date: July 9, 2025

🔗 **Code:** [https://github.com/heyavijitroy/dotnet-dailytips/tree/main/Week03\_ExceptionHandling/Day18\_CustomExceptions/Program.cs](https://github.com/heyavijitroy/dotnet-dailytips/tree/main/Week03_ExceptionHandling/Day18_CustomExceptions/Program.cs)  

🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #exceptionhandling #Day18\_DotNetWithRoy #Week3
