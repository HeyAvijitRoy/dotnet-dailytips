## Multiple Catch Blocks

In C#, it's common to encounter different kinds of exceptions in a single block of code. Instead of handling them all in one `catch`, you can use **multiple catch blocks**, making your code more precise and maintainable.

### What is it?

* **Multiple catch blocks** allow you to handle different exception types separately.
* Each block catches one specific exception type.

### Why use it?

* Makes your code easier to understand and maintain.
* Lets you handle only what you care about, and log or rethrow unexpected exceptions.
* Avoids one massive, generic catch block that hides the real problem.

### How does it work?

```csharp
try
{
    // Risky operations
}
catch (FileNotFoundException ex)
{
    // Handle missing file
}
catch (DivideByZeroException ex)
{
    // Handle math error
}
catch (Exception ex)
{
    // Handle any other exceptions
}
finally
{
    // Clean up resources
}
```

Always catch the **most specific exceptions first**, then general ones.

## **Date:** July 8, 2025
🔗 **Code:** [https://github.com/heyavijitroy/dotnet-dailytips/tree/main/Week03\_ExceptionHandling/Day16\_MultipleCatch/Program.cs](https://github.com/heyavijitroy/dotnet-dailytips/tree/main/Week03_ExceptionHandling/Day16_MultipleCatch/Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #exceptionhandling #Day16\_DotNetWithRoy #Week3
