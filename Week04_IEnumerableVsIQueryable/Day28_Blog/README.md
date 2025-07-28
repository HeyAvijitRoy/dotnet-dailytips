## Day 28: IQueryable vs IEnumerable — Deep Dive (Blog)

This post wraps up Week 4 with a full comparison of `IEnumerable` and `IQueryable`, showing why understanding the difference is critical for performance, scalability, and maintainability.

### 🔍 Key Takeaways:

* `IEnumerable` executes in-memory; `IQueryable` builds a query expression tree.
* Filtering with `IQueryable` happens at the source (e.g., SQL server); `IEnumerable` filters after pulling data.
* Calling `.ToList()` too early converts an `IQueryable` into an `IEnumerable`, killing optimizations.
* Custom methods, `DateTime.Now`, or Regex inside `IQueryable` will break translation or silently degrade.

### 🧠 Developer Tips:

* Always defer `.ToList()` until the end.
* Project (`.Select`) only what you need.
* Stick to SQL-translatable expressions when using Entity Framework.
* Use `IQueryable` with EF Core, `IEnumerable` with in-memory collections.

---

## Date: July 20, 2025

🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #IQueryable #IEnumerable #EFCore #LINQ #Day28\_DotNetWithRoy #Week4
