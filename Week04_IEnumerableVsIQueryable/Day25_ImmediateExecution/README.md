## Day 25: Immediate Execution in IEnumerable

Today's example illustrates how `IEnumerable` executes **immediately** when you use terminal methods like `.ToList()`, `.Count()`, or even a `foreach` loop.

### ✅ What it shows:

* Calling `.ToList()` on an `IEnumerable` causes the full query to execute instantly.
* Any logic chained after `.ToList()` does **not** benefit from deferred execution — it works on the materialized result.

### 🚫 Why it matters:

If you’re trying to build a dynamic query and accidentally call `.ToList()` too early, the query runs — and further logic won’t be optimized or deferred.

This leads to:

* Unnecessary memory usage
* Missed database optimizations
* Hard-to-track bugs when refactoring LINQ code

### ⚠️ Common trap:

```csharp
var users = db.Users.Where(x => x.IsActive).ToList();
// You can’t add more filters efficiently now — it's just a List.
```

---

## Date: July 17, 2025

🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #IEnumerable #ImmediateExecution #Day25\_DotNetWithRoy #Week4
