## Top Exception Handling Practices

Throughout the week, we explored exception handling in C#. Here are the key takeaways and best practices for writing robust code:

### What is it?

Exception handling in C# allows your app to **gracefully recover from runtime errors**, preventing crashes and managing resources properly.

### Why use it?

* Protect your app from unhandled exceptions.
* Make errors easier to debug and maintain.
* Ensure resources are always released.

### Top Practices Recap:

#### 1. Use try-catch-finally properly

Wrap risky code in `try`, handle it in `catch`, clean up in `finally`.

#### 2. Catch specific exceptions first

Handle what you expect (`FileNotFoundException`, `DivideByZeroException`, etc.) before falling back to a general catch.

#### 3. Rethrow correctly

Use `throw;` to preserve stack trace. Avoid `throw ex;` unless modifying the exception.

#### 4. Create custom exception classes

Make your domain logic clearer with custom exceptions like `InvalidUserActionException`.

#### 5. Use exception filters (`when`)

Filter exceptions **before entering catch blocks** for cleaner handling.

#### 6. Use try-finally without catch when needed

Clean up without handling the exception, letting it bubble up.

#### 7. Always log unhandled exceptions

Never swallow them silently.

## Date: July 12, 2025

🔗 **Code:** [https://github.com/heyavijitroy/dotnet-dailytips/tree/main/Week03\_ExceptionHandling/Day21\_ExceptionPractices/](https://github.com/heyavijitroy/dotnet-dailytips/tree/main/Week03_ExceptionHandling/Day21_ExceptionPractices/)  

🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #exceptionhandling #Day21\_DotNetWithRoy #Week3
