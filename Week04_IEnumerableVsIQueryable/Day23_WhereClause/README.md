## Day 23: Where Clause – IEnumerable vs IQueryable

Today’s example shows how the `.Where()` clause behaves differently when used with `IEnumerable` vs `IQueryable`.

### ✅ What it shows:

* With `IEnumerable`, the filter runs **after** data is loaded into memory.
* With `IQueryable`, the filter becomes part of the expression tree (e.g., SQL WHERE clause).

### 🔍 Why it matters:

This small difference impacts performance dramatically. In a real app using Entity Framework Core, using `IEnumerable` could load **all rows** into memory, then apply the filter. That’s a massive waste of resources.

### 💡 Key Insight:

Always prefer `IQueryable` when querying external data sources like databases — so filtering, paging, and projection can happen at the source.

---

## Date: July 15, 2025

🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #IQueryable #IEnumerable #EFCore #Day23\_DotNetWithRoy #Week4
