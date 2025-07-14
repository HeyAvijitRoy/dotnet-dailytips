## Day 22: Intro to IEnumerable vs IQueryable

This example introduces the fundamental difference between `IEnumerable` and `IQueryable` in .NET.

### ✅ What it shows:

* `IEnumerable` executes LINQ queries **in memory**, after data is loaded.
* `IQueryable` can **translate LINQ to SQL**, so filtering happens **at the database level**.

### 🧠 Why it matters:

Using `IEnumerable` on a database query loads **all rows first**, then filters in memory. But `IQueryable` lets you push filtering and other operations **to the database**, reducing memory use and improving performance.

This is crucial in Entity Framework Core and large datasets.

### 📌 Example Used:

A simple comparison using a list of numbers, showing how both interfaces behave similarly in-memory. In later posts, we’ll see how they differ significantly when querying databases.

---

## Date: July 14, 2025

🔗 **Code:** [Program.cs](./program.cs)  
🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #IQueryable #IEnumerable #Day22\_DotNetWithRoy #Week4
