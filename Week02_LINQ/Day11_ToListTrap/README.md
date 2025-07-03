## Avoiding the ToList() Trap in LINQ

LINQ queries are **deferred by default**, but calling `.ToList()` forces immediate execution.

In many cases, people call `.ToList()` unnecessarily:

* Breaking deferred execution too early
* Adding performance overhead by allocating new lists
* Causing queries to execute multiple times when only once was needed

### Better Approach

Only use `.ToList()` when:

* You need a snapshot (because the source might change)
* You want to avoid multiple evaluations of the query
* You specifically need a `List<T>` API (e.g., indexing)

Example:

```csharp
var query = expensiveSource.Where(x => x.IsActive);

// ❌ Bad: executes the query immediately, allocates a list
var list = query.ToList();

// ✅ Better: delay execution until you need it
foreach (var item in query)
{
    Console.WriteLine(item);
}
```

In this demo, we show:

* The timing difference between `ToList()` and deferred queries
* How to measure when queries actually execute
* Why deferring can improve performance in simple cases

### Day 11 | Date: July 3, 2025
**Code:** [Program.cs](./Program.cs)  
**Author:** [Avijit Roy on LinkedIn](https://www.linkedin.com/in/HeyAvijitRoy/)  
**Tags:** #dotnetdailytips #DotNetWithRoy #csharp #linq #ToList #Day11\_DotNetWithRoy #Week2  