## Day 26: Mixing LINQ and EF Core – Gotchas

This example shows how you can unintentionally kill performance in Entity Framework Core by mixing `IQueryable` and `IEnumerable` incorrectly.

### ✅ What it shows:

* `IQueryable` is **deferred** and can be translated to SQL.
* Calling `.AsEnumerable()` or `.ToList()` too early forces execution — filtering happens in memory.

### 🧠 Why it matters:

If you switch from `IQueryable` to `IEnumerable` too soon (e.g., with `.AsEnumerable()`), you:

* Lose SQL translation benefits
* Fetch **all rows** into memory
* Miss out on indexes, paging, and optimizations

### 🚫 Example Trap:

```csharp
var result = db.Products
               .AsEnumerable()   // BAD: forces execution
               .Where(p => p.Category == "Book"); // Now runs in memory
```

---

## Date: July 18, 2025

🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #EFCore #LINQTraps #IQueryable #Day26\_DotNetWithRoy #Week4
