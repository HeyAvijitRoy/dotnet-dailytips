# Why .GetAwaiter().GetResult() Can Break Production

Blocking async code with `.GetAwaiter().GetResult()` seems harmless — until you’re debugging a buried exception in production.

## 🔥 What Can Go Wrong?

- Exceptions are wrapped in `AggregateException`
- You lose clean stack traces
- It can block threads and cause deadlocks if misused

📅 **Date:** June 28, 2025  
🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/avijitroykabyo/)  
🏷 **Tags:** #dotnetdailytips #DotNetWithRoy #csharp #asyncawait #GetAwaiter #Day6_DotNetWithRoy
