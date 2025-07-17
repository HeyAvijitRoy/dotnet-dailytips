## Day 27: Writing Efficient Queries

Today’s example shows how to write efficient LINQ queries using `IQueryable`, focusing on filtering, projecting, and avoiding premature execution.

### ✅ What it shows:

* The danger of calling `.ToList()` too early, which loads everything into memory.
* How to chain `.Where()` and `.Select()` correctly to keep the logic SQL-translatable.
* Reducing memory use and improving performance by projecting only needed fields.

### 🧠 Why it matters:

Writing LINQ that "works" is easy. Writing LINQ that scales is different.
Many apps accidentally load entire tables before filtering or mapping — this causes memory pressure and slows down response times.

### 🚀 Best Practices Illustrated:

* Don’t call `.ToList()` before filtering.
* Use `.Select()` to return only what you need (e.g., `Email`, not full `User` object).
* Stick to SQL-friendly LINQ expressions.

---

## Date: July 19, 2025

🔗 **Code:** [Program.cs](./Program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #IQueryable #EfficientQueries #Day27\_DotNetWithRoy #Week4
