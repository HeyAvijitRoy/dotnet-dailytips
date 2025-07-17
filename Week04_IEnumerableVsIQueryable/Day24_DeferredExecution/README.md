## Day 24: Deferred Execution in IQueryable

Today’s code demonstrates how `IQueryable` supports **deferred execution** — meaning the actual database query (or operation) happens only when the result is enumerated.

### ✅ What it shows:

* A LINQ query is defined but not executed until a terminal operation like `foreach`.
* Execution is delayed, allowing you to add more filters or projections before hitting the data source.

### 🧠 Why it matters:

With `IQueryable`, you can build efficient, expressive, and composable queries. Nothing is executed until absolutely necessary — avoiding wasted DB calls.

This enables scenarios like:

* Building dynamic queries conditionally
* Adding paging or sorting later
* Logging or profiling before query hits the DB

---

## Date: July 16, 2025

🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #IQueryable #DeferredExecution #Day24\_DotNetWithRoy #Week4
