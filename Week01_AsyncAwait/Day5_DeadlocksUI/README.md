# Async Deadlocks and UI Threads

Blocking async code with `.Result` or `.Wait()` can cause deadlocks — especially in UI apps.  
Avoid blocking; always use `await`.

## 🧠 Why It Happens

- Async methods resume on the original sync context (like UI thread)
- If that thread is blocked, the continuation can’t run
- Result: deadlock or freeze

📅 **Date:** June 27, 2025  
🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  
🏷 **Tags:** #dotnetdailytips #DotNetWithRoy #csharp #asyncawait #deadlock #Day5_DotNetWithRoy
