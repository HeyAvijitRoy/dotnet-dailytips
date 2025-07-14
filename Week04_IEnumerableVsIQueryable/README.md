## Week 4: Mastering IEnumerable vs IQueryable

Understanding the difference between `IEnumerable` and `IQueryable` is key to writing efficient and scalable .NET applications, especially when working with LINQ and Entity Framework Core. This week, we’ll dive deep into how these two interfaces behave, where each should be used, and common mistakes to avoid.

### What is IEnumerable?

* Works in-memory.
* Supports LINQ to Objects.
* Deferred execution, but all data must be loaded first (e.g., from a database).

### What is IQueryable?

* Works with out-of-memory data (e.g., databases).
* Enables deferred execution *and* translation of LINQ expressions into SQL.
* Useful for EF Core, LINQ to SQL, and remote queries.

### Why this matters:

Using the wrong interface can lead to unnecessary data loading, poor performance, and loss of query optimizations. By mastering when and how to use each, you write cleaner, faster, and more maintainable code.

---

### Daily Breakdown

| Day    | Topic                                     | Link                                |
| ------ | ----------------------------------------- | ----------------------------------- |
| Day 22 | Intro to IEnumerable vs IQueryable        | [View](./Day22_Intro/)              |
| Day 23 | Where clause: IEnumerable vs IQueryable   | [View](./Day23_WhereClause/)        |
| Day 24 | Deferred Execution in IQueryable          | [View](./Day24_DeferredExecution/)  |
| Day 25 | Immediate Execution in IEnumerable        | [View](./Day25_ImmediateExecution/) |
| Day 26 | Mixing LINQ and EF Core: Gotchas          | [View](./Day26_LinqEfCoreMixing/)   |
| Day 27 | Writing Efficient Queries                 | [View](./Day27_EfficientQueries/)   |
| Day 28 | Blog: IQueryable vs IEnumerable Deep Dive | [View](./Day28_Blog/)               |

---

## Date: July 14–20, 2025

🔗 **Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)

**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #IEnumerable #IQueryable #Day22\_DotNetWithRoy #Week4
